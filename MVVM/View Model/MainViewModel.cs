using PROG7312_UI.Core;

namespace PROG7312_UI.MVVM.View_Model
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand RBCommand { get; set; }

        public RBViewModel RBVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChnage();
            }
        }


        public MainViewModel()
        {
            RBVM = new RBViewModel();


            RBCommand = new RelayCommand(o =>
            {
                CurrentView = RBVM;
            });


        }
    }
}
