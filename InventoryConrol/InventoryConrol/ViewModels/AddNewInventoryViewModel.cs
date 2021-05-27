using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers.Commands;
using InventoryConrol.Views;
using InventoryConrol.Services;
using InventoryConrol.Models;
using MvvmHelpers;

namespace InventoryConrol.ViewModels
{
    class AddNewInventoryViewModel : BaseViewModel
    {
        public AsyncCommand SaveCommand { get;}

        public AddNewInventoryViewModel()
        {
            SaveCommand = new AsyncCommand(Save);
        }
        public async  Task Save()
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }
    }
}
