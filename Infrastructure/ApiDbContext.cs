using Entities;
using SQLite;
using System;

namespace Infrastructure
{
    public class ApiDbContext
    {
        public readonly SQLiteAsyncConnection database;
        public static string dbPath;
        public ApiDbContext()
        {
            //asignamos la conexión a la BD
            database = new SQLiteAsyncConnection(dbPath);

            //usamos el objeto de conexión para crear las tablas si no existen
            database.CreateTableAsync<TipModel>().Wait();
        }
    }
}
