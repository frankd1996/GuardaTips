using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions
{
    public interface IEntity
    {        
        int Id { get; set; } 
    }
}
