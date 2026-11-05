using Microsoft.Extensions.DependencyInjection;
using CrudEmpleados.Views;

namespace CrudEmpleados
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.EmpleadosPage());
        }
    }
}