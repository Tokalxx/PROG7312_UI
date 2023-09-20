using PROG7312_UI.Commands;
using PROG7312_UI.Core;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PROG7312_UI.MVVM.View_Model.ItemViewModel
{
    public class ItemListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ItemViewModel> _itemsViewModels;

        public IEnumerable<ItemViewModel> ItemViewModels => _itemsViewModels;

        private ItemViewModel _incomingItemViewModel;
        public ItemViewModel IncomingItemViewModel
        {
            get
            {
                return _incomingItemViewModel;
            }
            set
            {
                _incomingItemViewModel = value;
                OnPropertyChanged(nameof(IncomingItemViewModel));
            }
        }

        private ItemViewModel _removeItemViewModel;
        public ItemViewModel RemoveItemViewModel
        {
            get
            {
                return _removeItemViewModel;
            }
            set
            {
                _removeItemViewModel = value;
                OnPropertyChanged(nameof(RemoveItemViewModel));
            }
        }

        private ItemViewModel _insertItemViewModel;
        public ItemViewModel InsertItemViewModel
        {
            get
            {
                return _insertItemViewModel;
            }
            set
            {
                _insertItemViewModel = value;
                OnPropertyChanged(nameof(InsertItemViewModel));
            }
        }

        private ItemViewModel _targetItemViewModel;
        public ItemViewModel TargetItemViewModel
        {
            get
            {
                return _targetItemViewModel;
            }
            set
            {
                _targetItemViewModel = value;
                OnPropertyChanged(nameof(TargetItemViewModel));
            }
        }

        public ICommand ItemRemovedCommand { get; }
        public ICommand ItemReceivedCommand { get; }
        public ICommand ItemInsertCommand { get; }

        public ItemListingViewModel()
        {
            _itemsViewModels = new ObservableCollection<ItemViewModel>();

            ItemReceivedCommand = new TodoItemReceivedCommand(this);
            ItemRemovedCommand = new TodoItemRemovedCommand(this);
            ItemReceivedCommand = new TodoItemReceivedCommand(this);
        }

        public void AddItem(ItemViewModel item)
        {
            if (!_itemsViewModels.Contains(item))
            {
                _itemsViewModels.Add(item);
            }
        }

        public void InsertItem(ItemViewModel insertItem, ItemViewModel targetItem)
        {
            if (insertItem == targetItem)
            {
                return;
            }

            int oldIndex = _itemsViewModels.IndexOf(insertItem);
            int nextIndex = _itemsViewModels.IndexOf(targetItem);

            if (oldIndex != -1 && nextIndex != -1)
            {
                _itemsViewModels.Move(oldIndex, nextIndex);
            }
        }

        public void RemoveItem(ItemViewModel item)
        {
            _itemsViewModels?.Remove(item);
        }

    }
}
