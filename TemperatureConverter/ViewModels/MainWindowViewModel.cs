namespace TemperatureConverter.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _contentViewModel;
        public object ContentViewModel
        {
            get { return _contentViewModel; }
            set
            {
                _contentViewModel = value;
                OnPropertyChanged(nameof(ContentViewModel));
            }
        }

        public MainWindowViewModel(ITemperatureVM temperatureVM)
        {
            this.ContentViewModel = temperatureVM;
        }
    }
}
