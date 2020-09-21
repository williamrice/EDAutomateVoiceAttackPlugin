/*
 * Copyright 2020 Billy Rice. All rights reserved.
 */

using EDAutomate.Utilities;
using Moq;

namespace EDAutomate.UnitTests
{
    public class MockProxyTestBase
    {
        public Mock<VoiceAttackProxy> Proxy { get; set; }

        public MockProxyTestBase()
        {
            Proxy = new Mock<VoiceAttackProxy>();
        }
    }
}
