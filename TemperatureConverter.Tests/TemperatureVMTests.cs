using Moq;
using TemperatureConverter.Services;
using TemperatureConverter.Utilities;
using TemperatureConverter.ViewModels;
using Xunit;

namespace TemperatureConverter.Tests
{
    public class TemperatureVMTests
    {
        private Mock<ILog> _mockLogger;
        private Mock<ICalculationService> _mockCalculationService;
        private ITemperatureVM temperatureVM;
        public TemperatureVMTests()
        {
            _mockLogger = new Mock<ILog>();
            _mockCalculationService = new Mock<ICalculationService>();           
        }

        [Fact]
        public void UpdateValues_MethodCalled_PropertyUpdated()
        {
            temperatureVM = new TemperatureVM(_mockCalculationService.Object, _mockLogger.Object);
            _mockCalculationService.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<UnitTypeEnum>())).Returns("75");
            temperatureVM.UpdateValues();
            Assert.Equal("75", temperatureVM.InactiveTemp);
        }

        [Fact]
        public void ActiveTemp_PropertyChanged_UpdateValuesCalled()
        {
            temperatureVM = new TemperatureVM(_mockCalculationService.Object, _mockLogger.Object);
            temperatureVM.ActiveUnitType = UnitTypeEnum.Celsius;
            temperatureVM.ActiveTemp = "89";
            _mockCalculationService.Verify(c => c.Calculate(temperatureVM.ActiveTemp, temperatureVM.ActiveUnitType));
        }

        [Fact]
        public void SwapCommand_CommandExecuted_ValuesSwapped()
        {
            temperatureVM = new TemperatureVM(_mockCalculationService.Object, _mockLogger.Object);
            temperatureVM.ActiveUnitType = UnitTypeEnum.Celsius;
            temperatureVM.ActiveTemp = "5";
            temperatureVM.InactiveTemp = "41";
            temperatureVM.InActiveUnitType = UnitTypeEnum.Fahrenheit;
            temperatureVM.SwapCommand.Execute(null);
            Assert.Equal("41", temperatureVM.ActiveTemp);
            Assert.Equal("5", temperatureVM.InactiveTemp);
            Assert.Equal(UnitTypeEnum.Fahrenheit, temperatureVM.ActiveUnitType);
            Assert.Equal(UnitTypeEnum.Celsius, temperatureVM.InActiveUnitType);
        }
    }
}
