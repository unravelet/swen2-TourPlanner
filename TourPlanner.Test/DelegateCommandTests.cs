using NUnit.Framework;
using System;

namespace TourPlanner.Test {
    public class DelegateCommandTests {

        [Test]
        public void ActionOnlyTest() {
            //does delegatecommand execute

            //arrange
            bool wasExecuted = false;
            object objectSend = new object();
            DelegateCommand cmd = new((o) => {
                wasExecuted = true;
                Assert.AreSame(objectSend, o);

            });

            //act
            cmd.Execute(objectSend);

            //assert
            Assert.IsTrue(wasExecuted);
        }

        [Test]
        public void ActionOnlyTestNull() {
            //action is null -> throw null execption

            Assert.Throws<ArgumentNullException>(() => {
                DelegateCommand cmd = new(null);
            });


        }

        [Test]
        public void ActionOnlyTestNullExecute() {


            Assert.Throws<ArgumentNullException>(() => {
                new DelegateCommand((o) => true, null);
            });
        }

        [Test]
        public void CanExecuteTest() {
            bool canExecResult = true;
            object objectSend = new object();

            DelegateCommand cmd = new DelegateCommand(
                (o) => canExecResult
                ,
                (o) => { }
            );

            Assert.AreEqual(canExecResult, cmd.CanExecute(objectSend));

        }

        [Test]
        public void CanExecuteTestSameObject() {
            bool canExecResult = true;
            object objectSend = new object();

            DelegateCommand cmd = new DelegateCommand(
                (o) => {
                    Assert.AreSame(objectSend, o);
                    return canExecResult;
                },
                (o) => { }
            );

        }

        [Test]
        public void RaiseCanExecuteChangedTest() {

            DelegateCommand cmd = new DelegateCommand((o) => { });

            bool wasEventFired = false;
            cmd.CanExecuteChanged += (sender, eventArgs) => {
                Assert.AreSame(cmd, sender);
                Assert.AreEqual(eventArgs, EventArgs.Empty);
                wasEventFired = true;
            };

            cmd.RaiseCanExecuteChanged();

            Assert.IsTrue(wasEventFired);
        }

    }
}
