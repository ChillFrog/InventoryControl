using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InventoryConrol.Services;
using InventoryConrol.Models;
using InventoryConrol.Droid;
using SQLite;
using Xamarin.Forms;
using System.Threading.Tasks;

[assembly: Dependency(typeof(SQLite_Android))]
namespace InventoryConrol.Droid
{
    class SQLite_Android : InventoryService
    {
        SQLiteConnection con;
        public SQLiteConnection GetConnectionWithCreateDatabase()
        {
            string fileName = "sampleDatabase.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, fileName);
            con = new SQLiteConnection(path);
            con.CreateTable<Inventory>();
            return con;
        }

        public bool UpdateInventory(Inventory inventory)
        {
            bool res = false;
            try
            {
                string sql = $"UPDATE Employee SET Name='{inventory.Name}',AmountNeeded='{inventory.AmountNeeded}',AmountScanned='{inventory.AmountScanned}',";
                con.Execute(sql);
                res = true;
            }
            catch (Exception ex)
            {

            }
            return res;
        }
    }
}