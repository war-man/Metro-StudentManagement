using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudentManagement.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<string> PageNames { get; set; }
        private readonly List<ViewModelBase> _ViewModelList;
        //This hold the current Page, which will be displayed
        private ViewModelBase _currentUserControl;

        public ViewModelBase CurrentUserControl
        {
            get
            {
                return _currentUserControl;
            }

            set
            {
                if (_currentUserControl == value)
                    return;
                _currentUserControl = value;
                OnPropertyChanged("CurrentUserControl");
            }
        }

       //Hold the Selected UserControl index
        public int SelectedUCIndex
        {
            get
            {
                return _selectedUCIndex;
            }

            set
            {
                if (_selectedUCIndex == value)
                    return;
                _selectedUCIndex = value;
                OnPropertyChanged("SelectedUCIndex"); 
                CurrentUserControl = _ViewModelList[_selectedUCIndex];
            }
        }

      
        private int _selectedUCIndex;



        public MainViewModel()
        {
            // Create a list to hold all the UserControl ViewModel Class
            _ViewModelList = new List<ViewModelBase>()
            {
                new IntroWindowViewModel(),
                new MainMenuViewModel(),

            };

            PageNames = new ObservableCollection<string>();
            foreach (ViewModelBase baseVM in _ViewModelList)
                PageNames.Add(baseVM.GetType().Name);

            CurrentUserControl = _ViewModelList[0];
        }

     

    }
}