using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using CrudEmpleados.Models;

namespace CrudEmpleados.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Empleado>().Wait();
        }

        public async Task InitAsync()
        {
            if (_database != null)
                return;

            string dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "empleados.db3");

            _database = new SQLiteAsyncConnection(dbPath);

            await _database.CreateTableAsync<Empleado>();
        }

        public async Task<List<Empleado>> ObtenerEmpleadosAsync()
        {
            await InitAsync();

            return await _database
                .Table<Empleado>()
                .ToListAsync();
        }

        public async Task<int> InsertarEmpleadoAsync(
            Empleado empleado)
        {
            await InitAsync();

            return await _database
                .InsertAsync(empleado);
        }

        public async Task<int> ActualizarEmpleadoAsync(
            Empleado empleado)
        {
            await InitAsync();

            return await _database
                .UpdateAsync(empleado);
        }

        public async Task<int> EliminarEmpleadoAsync(
            Empleado empleado)
        {
            await InitAsync();

            return await _database
                .DeleteAsync(empleado);
        }
    }
}
