﻿using PROG7312_UI.MVVM.View_Model.ItemViewModel;
using System.Windows;

namespace PROG7312_UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ItemListingViewModel inProgressTodoItemListingViewModel = new ItemListingViewModel();
            inProgressTodoItemListingViewModel.AddItem(new ItemViewModel("Emyia"));
            inProgressTodoItemListingViewModel.AddItem(new ItemViewModel("Ereshkigal"));
            inProgressTodoItemListingViewModel.AddItem(new ItemViewModel("Salter"));
            inProgressTodoItemListingViewModel.AddItem(new ItemViewModel("Hans"));
            inProgressTodoItemListingViewModel.AddItem(new ItemViewModel("Hercules"));
            inProgressTodoItemListingViewModel.AddItem(new ItemViewModel("Martha"));
            inProgressTodoItemListingViewModel.AddItem(new ItemViewModel("Sapce Ishtar"));
            inProgressTodoItemListingViewModel.AddItem(new ItemViewModel("Ushiwakamaru"));
            inProgressTodoItemListingViewModel.AddItem(new ItemViewModel("Okada Izo"));
            ItemListingViewModel completedTodoItemListingViewModel = new ItemListingViewModel();


            MoveItemViewModel todoViewModel = new MoveItemViewModel(inProgressTodoItemListingViewModel, completedTodoItemListingViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = todoViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
