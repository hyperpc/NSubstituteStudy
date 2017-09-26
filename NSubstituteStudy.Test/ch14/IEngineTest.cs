using NSubstitute;
using NSubstituteStudy.ch14;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;

namespace NSubstituteStudy.Test.ch14
{
    public class IEngineTest
    {
        [TestMethod]
        public void IEngine_idling_RaiseEvent()
        {
            var engine = Substitute.For<IEngine>();

            var wasCalled = false;
            engine.idling += (sender, args) => wasCalled = true;
            engine.idling += Raise.EventWith(new object(), new EventArgs());

            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void IEngine_idling_RaiseEventNoMindSenderAndArgs()
        {
            var engine = Substitute.For<IEngine>();

            var wasCalled = false;
            engine.idling += (sender, args) => wasCalled = true;
            engine.idling += Raise.Event();

            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void IEngine_idling_RaiseEventArgsHaveNoDefaultCtor()
        {
            var engine = Substitute.For<IEngine>();
            
            int numberOfEvents = 0;
            engine.LowFuelWarning += (sender, args) => numberOfEvents++;

            //发送事件，并携带指定的事件参数，未指定发送者
            engine.LowFuelWarning += Raise.EventWith(new LowFuelWarningEventArgs(10));
            //发送事件，并携带指定的事件参数，并指定发送者
            engine.LowFuelWarning += Raise.EventWith(new object(), new LowFuelWarningEventArgs(10));

            Assert.AreEqual(numberOfEvents, 2);
        }

        /// <summary>
        /// 引发INotifyPropertyChanged事件，
        /// 该事件使用PropertyChangedEventHandler委托，并需要2个参数
        /// </summary>
        [TestMethod]
        public void INotifyPropertyChanged_PropertyChanged_RaiseDelegateEvent()
        {
            var sub = Substitute.For<INotifyPropertyChanged>();
            bool wasCalled = false;

            sub.PropertyChanged += (sender, args) => wasCalled = true;

            sub.PropertyChanged += Raise.Event<PropertyChangedEventHandler>(this, new PropertyChangedEventArgs("test"));

            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void IEngine_RevvedAt_RaiseActionEvent()
        {
            var engine = Substitute.For<IEngine>();

            int revvedAt = 0;
            engine.RevvedAt += rpm => revvedAt = rpm;

            engine.RevvedAt += Raise.Event<Action<int>>(123);

            Assert.AreEqual(revvedAt, 123);

        }
    }
}
