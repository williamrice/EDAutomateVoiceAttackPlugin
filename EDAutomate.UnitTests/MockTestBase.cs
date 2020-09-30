/*
 * Copyright 2020 Billy Rice. All rights reserved.
 */

using EDAutomate.Services;
using EDAutomate.Utilities;
using Moq;

namespace EDAutomate.UnitTests
{
    public class MockTestBase
    {
        public Mock<VoiceAttackProxy> Proxy { get; set; }
        public Mock<WebDriverService> WebDriverService { get; set; }

        public MockTestBase()
        {
            Proxy = new Mock<VoiceAttackProxy>();
            WebDriverService = new Mock<WebDriverService>();
        }
    }
}
