using System.Windows.Input;
using TemperatureConverter.Services;
using TemperatureConverter.Utilities;

namespace TemperatureConverter.ViewModels
{
    public class TemperatureVM : ViewModelBase, ITemperatureVM
    {
        private readonly ICalculationService _calculationService;
        private readonly ILog _logger;
        public ICommand SwapCommand { get; set; }
        private string _activeTemp { get; set; }
        public string ActiveTemp
        {
            get { return _activeTemp; }
            set
            {
                _activeTemp = value;
                OnPropertyChanged(nameof(ActiveTemp));
                UpdateValues();
            }
        }

        private string _inactiveTemp { get; set; }
        public string InactiveTemp
        {
            get { return _inactiveTemp; }
            set
            {
                _inactiveTemp = value;
                OnPropertyChanged(nameof(InactiveTemp));
            }
        }

        private UnitTypeEnum _activeUnitType { get; set; }
        public UnitTypeEnum ActiveUnitType
        {
            get { return _activeUnitType; }
            set
            {
                _activeUnitType = value;
                OnPropertyChanged(nameof(ActiveUnitType));
               
            }
        }

        private UnitTypeEnum _inActiveUnitType { get; set; }
        public UnitTypeEnum InActiveUnitType
        {
            get { return _inActiveUnitType; }
            set
            {
                _inActiveUnitType = value;
                OnPropertyChanged(nameof(InActiveUnitType));
            }
        }

        public TemperatureVM(ICalculationService calculationService, ILog logger)
        {
            _logger = logger;
            _calculationService = calculationService;
            SwapCommand = new RelayCommand(o => { SwapControls(); });
            _logger.Info("Setting up start up temperature values");
            ActiveTemp = "0";
            ActiveUnitType = UnitTypeEnum.Celsius;
            InActiveUnitType = UnitTypeEnum.Fahrenheit;
            _logger.Info("Calculating the result temp for application start up");
            UpdateValues();
        }

        private void SwapControls()
        {
            _logger.Info("A swap for the temperature type was selected");
            switch (ActiveUnitType)
            {
                case UnitTypeEnum.Celsius:
                    ChangeTempType(UnitTypeEnum.Fahrenheit, UnitTypeEnum.Celsius);
                    break;
                case UnitTypeEnum.Fahrenheit:
                    ChangeTempType(UnitTypeEnum.Celsius, UnitTypeEnum.Fahrenheit);
                    break;
                default:
                    break;
            }

        }

        public void UpdateValues()
        {
            InactiveTemp = _calculationService.Calculate(ActiveTemp, ActiveUnitType);
        }

        private void ChangeTempType(UnitTypeEnum newActiveType, UnitTypeEnum newInactiveType)
        {
            InActiveUnitType = newInactiveType;
            ActiveUnitType = newActiveType;
            (string, string) tempTuple = (ActiveTemp, InactiveTemp);
            ActiveTemp = tempTuple.Item2;
            InactiveTemp = tempTuple.Item1;
        }

    }
}
