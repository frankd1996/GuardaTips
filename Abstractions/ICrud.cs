using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface ICrud<T>
    {        
        Task<List<T>> GetItemsAsync();       
        Task<T> GetItemAsync(int id);        
        Task<int> SaveItemAsync(T item);        
        Task<int> DeleteItemAsync(T item);
    }
}
