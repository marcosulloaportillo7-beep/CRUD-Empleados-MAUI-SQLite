using CrudEmpleados.Services;
using System.Text.RegularExpressions;
using CrudEmpleados.Models;

namespace CrudEmpleados.Views;


public partial class EmpleadosPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    private Empleado? empleadoSeleccionado;

    public EmpleadosPage()
    {
        InitializeComponent();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "empleados.db3");
        _databaseService = new DatabaseService(dbPath);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await CargarEmpleados();
    }

    private async Task CargarEmpleados()
    {
        lvEmpleados.ItemsSource =
            await _databaseService.ObtenerEmpleadosAsync();
    }

    private async void Guardar_Clicked(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombres.Text))
        {
            await DisplayAlertAsync(
                "Error",
                "Ingrese nombres",
                "OK");

            return;
        }

        if (string.IsNullOrWhiteSpace(txtApellidos.Text))
        {
            await DisplayAlertAsync(
                "Error",
                "Ingrese apellidos",
                "OK");

            return;
        }

        if (string.IsNullOrWhiteSpace(txtPuesto.Text))
        {
            await DisplayAlertAsync(
                "Error",
                "Ingrese puesto",
                "OK");

            return;
        }

        if (!decimal.TryParse(
            txtSalario.Text,
            out decimal salario))
        {
            await DisplayAlertAsync(
                "Error",
                "Salario inválido",
                "OK");

            return;
        }

        if (salario <= 0)
        {
            await DisplayAlertAsync(
                "Error",
                "El salario debe ser mayor que cero",
                "OK");

            return;
        }

        string patron =
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        if (!Regex.IsMatch(
            txtCorreo.Text ?? "",
            patron))
        {
            await DisplayAlertAsync(
                "Error",
                "Correo inválido",
                "OK");

            return;
        }

        if (empleadoSeleccionado == null)
        {
            Empleado nuevo = new Empleado
            {
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                Puesto = txtPuesto.Text,
                Salario = salario,
                Correo = txtCorreo.Text ?? string.Empty,
                FechaIngreso = dpFechaIngreso.Date ?? DateTime.Now
            };

            await _databaseService
                .InsertarEmpleadoAsync(nuevo);

            await DisplayAlertAsync(
                "Éxito",
                "Empleado guardado",
                "OK");
        }
        else
        {
            empleadoSeleccionado.Nombres =
                txtNombres.Text;

            empleadoSeleccionado.Apellidos =
                txtApellidos.Text;

            empleadoSeleccionado.Puesto =
                txtPuesto.Text;

            empleadoSeleccionado.Salario =
                salario;

            empleadoSeleccionado.Correo =
                txtCorreo.Text ?? string.Empty;

            empleadoSeleccionado.FechaIngreso =
                dpFechaIngreso.Date ?? DateTime.Now;

            await _databaseService
                .ActualizarEmpleadoAsync(
                    empleadoSeleccionado);

            await DisplayAlertAsync(
                "Éxito",
                "Empleado actualizado",
                "OK");
        }

        LimpiarFormulario();

        await CargarEmpleados();
    }

    private void lvEmpleados_ItemSelected(
        object sender,
        SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        empleadoSeleccionado =
            (Empleado)e.SelectedItem;

        lblId.Text =
        $"ID: {empleadoSeleccionado.Id}";

        txtNombres.Text =
            empleadoSeleccionado.Nombres;

        txtApellidos.Text =
            empleadoSeleccionado.Apellidos;

        txtPuesto.Text =
            empleadoSeleccionado.Puesto;

        txtSalario.Text =
            empleadoSeleccionado.Salario.ToString();

        txtCorreo.Text =
            empleadoSeleccionado.Correo;

        dpFechaIngreso.Date =
            empleadoSeleccionado.FechaIngreso;
    }

    private async void Eliminar_Clicked(
        object sender,
        EventArgs e)
    {
        if (empleadoSeleccionado == null)
        {
            await DisplayAlertAsync(
                "Aviso",
                "Seleccione un empleado",
                "OK");

            return;
        }

        bool respuesta =
            await DisplayAlertAsync(
                "Confirmación",
                "¿Desea eliminar este empleado?",
                "Sí",
                "No");

        if (!respuesta)
            return;

        await _databaseService
            .EliminarEmpleadoAsync(
                empleadoSeleccionado);

        await DisplayAlertAsync(
            "Éxito",
            "Empleado eliminado",
            "OK");

        LimpiarFormulario();

        await CargarEmpleados();
    }

    private void LimpiarFormulario()
    {
        lblId.Text = "ID: Nuevo";
        txtNombres.Text = "";
        txtApellidos.Text = "";
        txtPuesto.Text = "";
        txtSalario.Text = "";
        txtCorreo.Text = "";

        dpFechaIngreso.Date = DateTime.Now;

        empleadoSeleccionado = null;

        lvEmpleados.SelectedItem = null;
    }
}