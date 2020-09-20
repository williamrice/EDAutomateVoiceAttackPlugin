/*
 * Copyright 2020 Billy Rice. All rights reserved.
 */

using EDAutomate.Utilities;
using Moq;

namespace EDAutomate.UnitTests
{
    public class TestBase
    {
        public Mock<VoiceAttackProxy> Proxy { get; set; }

        public TestBase()
        {
            Proxy = new Mock<VoiceAttackProxy>();
        }
    }
}
