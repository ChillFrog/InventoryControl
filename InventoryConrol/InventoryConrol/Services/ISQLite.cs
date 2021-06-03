using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using InventoryConrol.Services;
using InventoryConrol.Models;

namespace InventoryConrol.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnectionWithCreationDataBase();
        bool UpdateInventory(Inventory invenotry);
    }
}
