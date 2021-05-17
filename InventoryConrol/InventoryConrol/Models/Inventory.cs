using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryConrol.Models
{
    public class Inventory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Roaster { get; set; }
        public string Name{ get; set; }
        public string Image { get; set; }
    }
}
