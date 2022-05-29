using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Test.Mocks;

namespace TourPlanner.Test {
    public class NotifyableBaseObjectTests {

        [Test]
        public void PropertyChangedTest() {
            bool wasFired = false;


            DummyViewModel vm = new DummyViewModel();
            vm.PropertyChanged += (sender, e) => {
                Assert.AreSame(vm, sender);
                Assert.NotNull(e);   
                Assert.AreEqual(nameof(vm.Name), e.PropertyName);
                wasFired = true;
            };

            vm.Name = "Tourname";

            Assert.IsTrue(wasFired);
            
        }
    }
}
