using WPFTests.ViewModels.Base;

namespace WPFTests.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Тестовое окно";

        public string Title
        {
            get => _Title;
            set
            {
                if(_Title == value) return;
                _Title = value;
                OnPropertyChanged("Title");
            }
        }
    }
}
