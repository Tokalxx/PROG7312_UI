using PROG7312_UI.Core;

namespace PROG7312_UI.MVVM.View_Model.ItemViewModel
{
    public class ItemViewModel : ViewModelBase
    {
        private string _item;
        public string Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
        }

        public ItemViewModel(string item)
        {
            Item = item;
        }
    }


}
