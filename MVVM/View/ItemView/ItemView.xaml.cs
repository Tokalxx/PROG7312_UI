using PROG7312_UI.MVVM.View_Model.ItemViewModel;
using System.Windows;
using System.Windows.Controls;

namespace PROG7312_UI.MVVM.View.ItemView
{
    /// <summary>
    /// Interaction logic for ItemView.xaml
    /// </summary>
    public partial class ItemView : UserControl
    {
        public ItemView()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
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

            ReplacingBooksView rbv = new ReplacingBooksView()
            {
                DataContext = todoViewModel
            };
        }

        private void buttonOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("order");

        }
    }
}
