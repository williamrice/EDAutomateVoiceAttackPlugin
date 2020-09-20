using EDAutomate.Enums;
using Xunit;
using Moq;

namespace EDAutomate.UnitTests
{
    public class EnumParser_Tests {
        [Fact]
        public void ParseStringToEnum_TestParameterizedInput () {
            var mockVaProxy = new Mock<VoiceAttack.VoiceAttackInvokeProxyClass>();
            mockVaProxy.Setup(x => GetText(It.Is<string>(s => s == "moduleVariable"))).Returns("seven B Shield Cell Bank");
            var result = EnumParser.ParseStringToEnum<Modules.Module>(mockVaProxy, "moduleVariable", typeof(Modules.Module));
            Assert.Equal(Modules.Module.sevenBShieldCellBank, result);
        }
    }
}