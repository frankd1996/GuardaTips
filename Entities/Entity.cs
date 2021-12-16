using Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Entity : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
