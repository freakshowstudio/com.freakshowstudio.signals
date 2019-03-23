
using FreakshowStudio.Signaling.Runtime;

using NUnit.Framework;

using Assert = UnityEngine.Assertions.Assert;


namespace FreakshowStudio.Signaling.Tests.Runtime
{
    public class SignalsTests
    {
        private class TestSignalBase : Signal {}
        private class TestSignalDerived : TestSignalBase {}

        [Test]
        public void TestInstantiate()
        {
            var s = new Signals();
            Assert.IsNotNull(s);
        }

        [Test]
        public void TestFire()
        {
            bool didFire = false;

            void Callback()
            {
                didFire = true;
            }

            var s = new Signals();
            s.Get<TestSignalBase>().AddListener(Callback);
            s.Get<TestSignalBase>().Dispatch();
            Assert.IsTrue(didFire);
            s.Get<TestSignalBase>().RemoveListener(Callback);
        }
    }
}
