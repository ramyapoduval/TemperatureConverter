using Moq;
using System;
using TemperatureConverter.Services;
using Xunit;

namespace TemperatureConverter.Tests
{
    public class CalculationServiceTests
    {
        private Mock<ILog> _mockLogger;
        private Mock<IValidationService> _mockValidationService;
        private ICalculationService _calculationService;
        public CalculationServiceTests()
        {
            _mockLogger = new Mock<ILog>();
            _mockValidationService = new Mock<IValidationService>();
            _calculationService = new CalculationService(_mockLogger.Object, _mockValidationService.Object);

        }

        [Fact]
        public void Calculate_EmptyValue_ReturnsEmpty()
        {
            var result = _calculationService.Calculate(string.Empty, Utilities.UnitTypeEnum.Celsius);
            Assert.Empty(result);
        }

        [Fact]
        public void Calculate_NullValue_ReturnsEmpty()
        {
            var result = _calculationService.Calculate(null, Utilities.UnitTypeEnum.Celsius);
            Assert.Empty(result);
        }

        [Fact]
        public void Calculate_ValidationFails_LogsError()
        {
            var errorMessage = "Validation failed";
            _mockValidationService.Setup(x => x.Validate(It.IsAny<string>())).Throws(new ApplicationException(errorMessage));
            var result = _calculationService.Calculate("0", Utilities.UnitTypeEnum.Celsius);
            _mockLogger.Verify(l => l.Error(errorMessage));
        }

        [Fact]
        public void Calculate_CelsiusToFahrenheit_ReturnsFahrenheit()
        {
            var result = _calculationService.Calculate("10", Utilities.UnitTypeEnum.Celsius);
            Assert.Equal("50", result);
        }

        [Fact]
        public void Calculate_FahrenheitToCelsius_ReturnsCelsius()
        {
            var result = _calculationService.Calculate("78", Utilities.UnitTypeEnum.Fahrenheit);
            Assert.Equal("25.56", result);
        }
    }
}
