using System;
using TemperatureConverter.Utilities;

namespace TemperatureConverter.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ILog _logger;
        private readonly IValidationService _validationService;
        private Func<double, string> FahrenheitToCelsius => fTemp => ((fTemp - 32) * 5 / 9).ToString("#.##");
        private Func<double, string> CelsiusToFahrenheit => cTemp => ((cTemp * 9 / 5) + 32).ToString("#.##");

        public CalculationService(ILog logger, IValidationService validationService)
        {
            _logger = logger;
            _validationService = validationService;
        }

        public string Calculate(string value, UnitTypeEnum updatedType)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) return string.Empty;
                _validationService.Validate(value);
                switch (updatedType)
                {
                    case UnitTypeEnum.Fahrenheit:
                        return FahrenheitToCelsius(Convert.ToDouble(value));
                    case UnitTypeEnum.Celsius:
                        return CelsiusToFahrenheit(Convert.ToDouble(value));
                    default:
                        throw new Exception("Invalid unit type format");
                }
            }
            catch(ApplicationException ex)
            {
                _logger.Error(ex.Message);
            }
            catch(Exception ex)
            {
                _logger.Error(string.Format("Error calculating the temp : {0}", ex));
            }
            return string.Empty;
        }
    }
}
