using Abstractions;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IDbContext<T>:ICrud<T>
    {        
    }
    
    public class DbContext<T>: ApiDbContext, IDbContext<T> where T: Entity, new()
    {
        //dbPath de la BD que inyectamos en el constructor
        public static string _dbPath;
        //variable estática que nos servirá de api a la instancia de la BD
        private static ApiDbContext apiDataBase;        
        public static ApiDbContext ApiDataBase
        {
            get
            {
                if (apiDataBase == null)
                {
                    apiDataBase = new ApiDbContext();
                }
                return apiDataBase;
            }
        }
        public DbContext()
        {
            _dbPath = dbPath;
        }
              
        public async Task<List<T>> GetItemsAsync()
        {
            return await ApiDataBase.database.Table<T>().ToListAsync();            
        }

        
        public async Task<T> GetItemAsync(int id)
        {
            var prueba = typeof(T);
            return await ApiDataBase.database.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();            
        }
        
        public async Task<int> SaveItemAsync(T item) 
        {
            if (item.Id != 0)
            {
                return await database.UpdateAsync(item);
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
        
        public async Task<int> DeleteItemAsync(T item)
        {
            return await database.DeleteAsync(item);            
        }        
    }
}
