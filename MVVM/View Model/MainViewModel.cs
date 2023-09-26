using PROG7312_UI.Core;

namespace PROG7312_UI.MVVM.View_Model
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand RBCommand { get; set; }
        public RelayCommand HelpCommand { get; set; }

        public RBViewModel RBVM { get; set; }
        public HelpViewModel HVM { get; set; }


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

        private object _helpView;
        public object HelpView
        {
            get { return _helpView; }
            set
            {
                _helpView = value;
                OnPropertyChnage();
            }
        }


        public MainViewModel()
        {
            RBVM = new RBViewModel();
            HVM = new HelpViewModel();


            RBCommand = new RelayCommand(o =>
            {
                CurrentView = RBVM;
            });
            HelpCommand = new RelayCommand(o =>
            {
                CurrentView = HVM;
            });


        }
    }
}
