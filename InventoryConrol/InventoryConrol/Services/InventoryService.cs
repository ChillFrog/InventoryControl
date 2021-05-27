using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using InventoryConrol.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace InventoryConrol.Services
{
    public static class InventoryService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
                db = new SQLiteAsyncConnection(databasePath);
                await db.CreateTableAsync<Inventory>();
        }
        public static async Task AddInventory(string name, string amountNeeded, string amountScanned)
        {
            await Init();
            var inventory = new Inventory
            {
                Name = name,
                AmountNeeded = amountNeeded,
                AmountScanned = amountScanned,
            };
           var id = await db.InsertAsync(inventory);
        }
        public static async Task RemoveInventory(int id)
        {
            await Init();
            await db.DeleteAsync<Inventory>(id);
        }
        public static async Task<IEnumerable<Inventory>> GetInventory()
        {
            await Init();
            var inventory = await db.Table<Inventory>().ToListAsync();
            return inventory;
        }
    }
}
