using PROG7312_UI.Core;
using PROG7312_UI.MVVM.View_Model.ItemViewModel;

namespace PROG7312_UI.Commands
{
    public class TodoItemRemovedCommand : CommandBase
    {
        private readonly ItemListingViewModel _todoItemListingViewModel;

        public TodoItemRemovedCommand(ItemListingViewModel todoItemListingViewModel)
        {
            _todoItemListingViewModel = todoItemListingViewModel;
        }

        public override void Execute(object parameter)
        {
            _todoItemListingViewModel.RemoveItem(_todoItemListingViewModel.RemoveItemViewModel);
        }
    }
}