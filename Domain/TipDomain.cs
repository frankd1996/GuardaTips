using Abstractions;
using Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public interface IDomain<T>:ICrud<T>
    {        
    }
    public class TipDomain<T> : IDomain<T> where T:Entity, new()
    {
        private readonly IDbContext<T> _dbContext;
        public TipDomain(IDbContext<T> dbContext)
        {
            _dbContext = dbContext;            
        }
        
        public async Task<List<T>> GetItemsAsync()
        {
            return await _dbContext.GetItemsAsync();
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await _dbContext.GetItemAsync(id);
        }

        public async Task<int> SaveItemAsync(T item)
        {
            return await _dbContext.SaveItemAsync(item);
        }

        public async Task<int> DeleteItemAsync(T item)
        {
            return await _dbContext.DeleteItemAsync(item);
        }        
    }
}
