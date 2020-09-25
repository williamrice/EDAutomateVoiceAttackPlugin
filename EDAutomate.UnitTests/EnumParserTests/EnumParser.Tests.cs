/*
 * Copyright 2020 Billy Rice. All rights reserved.
 */

using EDAutomate.Enums;
using EDAutomate.Utilities;
using Moq;
using Xunit;

namespace EDAutomate.UnitTests
{
    public class EnumParser_Tests : MockTestBase
    {
        [Theory]
        [InlineData("seven B Shield Cell Bank", Modules.Module.sevenBShieldCellBank)]
        [InlineData("five A Frame Shift Drive", Modules.Module.fiveAFrameShiftDrive)]
        public void ParseStringToEnum_TestParameterizedInput(string inputFromCommand, Modules.Module translatedEnum)
        {
            Proxy.Setup(x => x.GetText(It.Is<string>(s => s == "moduleVariable"))).Returns(inputFromCommand);
            var result = EnumParser.ParseStringToEnum<Modules.Module>(Proxy.Object, "moduleVariable", typeof(Modules.Module));
            Assert.Equal(translatedEnum, result);
        }
    }
}