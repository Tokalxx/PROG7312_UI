using PROG7312_UI.Core;
using PROG7312_UI.MVVM.View_Model.ItemViewModel;

namespace PROG7312_UI.Commands
{
    public class TodoItemReceivedCommand : CommandBase
    {
        private readonly ItemListingViewModel _todoItemListingViewModel;

        public TodoItemReceivedCommand(ItemListingViewModel todoItemListingViewModel)
        {
            _todoItemListingViewModel = todoItemListingViewModel;
        }

        public override void Execute(object parameter)
        {
            _todoItemListingViewModel.AddItem(_todoItemListingViewModel.IncomingItemViewModel);
        }
    }
}