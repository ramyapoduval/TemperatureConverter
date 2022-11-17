using System.Windows.Input;
using TemperatureConverter.Utilities;

namespace TemperatureConverter.ViewModels
{
    public interface ITemperatureVM
    {
        ICommand SwapCommand { get; set; }
        string ActiveTemp { get; set; }
        string InactiveTemp { get; set; }
        UnitTypeEnum ActiveUnitType { get; set; }
        UnitTypeEnum InActiveUnitType { get; set; }
        void UpdateValues();
    }
}
