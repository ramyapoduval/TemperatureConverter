using System;

namespace TemperatureConverter.Services
{
    public class ValidationService : IValidationService
    {
        public void Validate(string value)
        {
            double num;
            bool isDouble = Double.TryParse(value, out num);
            if (!isDouble)
            {
                throw new ApplicationException("The value was not in the required format");
            }
        }
    }
}
