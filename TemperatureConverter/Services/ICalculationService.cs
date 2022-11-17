using TemperatureConverter.Utilities;

namespace TemperatureConverter.Services
{
    public interface ICalculationService
    {
        string Calculate(string value, UnitTypeEnum updatedType);
    }
}
