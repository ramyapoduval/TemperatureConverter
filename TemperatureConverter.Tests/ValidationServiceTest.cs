using System;
using TemperatureConverter.Services;
using Xunit;

namespace TemperatureConverter.Tests
{
    public class ValidationServiceTest
    {
        private IValidationService validationService;

        [Fact]
        public void Validate_EmptyValue_ReturnsException()
        {
            validationService = new ValidationService();
            Assert.Throws<ApplicationException>(()=>validationService.Validate(string.Empty));
        }

        [Fact]
        public void Validate_NullValue_ReturnsException()
        {
            validationService = new ValidationService();
            Assert.Throws<ApplicationException>(() => validationService.Validate(null));
        }


        [Fact]
        public void Validate_InvalidValue_ReturnsException()
        {
            validationService = new ValidationService();
            Assert.Throws<ApplicationException>(() => validationService.Validate("57abc"));
        }

        [Fact]
        public void Validate_ValidResults_RunsWithNoException()
        {
            validationService = new ValidationService();
            var exception = Record.Exception(() => validationService.Validate("27.9"));
            Assert.Null(exception);
        }
    }
}
