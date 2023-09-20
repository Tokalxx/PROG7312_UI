using PROG7312_UI.Core;

namespace PROG7312_UI.MVVM.View_Model.ItemViewModel
{
    public class MoveItemViewModel : ViewModelBase
    {
        public ItemListingViewModel UnorderedItemListingViewModel { get; }
        public ItemListingViewModel OrderedItemListingViewModel { get; }

        public MoveItemViewModel(ItemListingViewModel unorderedItemListingViewModel, ItemListingViewModel orderedItemListingViewModel)
        {
            UnorderedItemListingViewModel = unorderedItemListingViewModel;
            OrderedItemListingViewModel = orderedItemListingViewModel;
        }
    }
}