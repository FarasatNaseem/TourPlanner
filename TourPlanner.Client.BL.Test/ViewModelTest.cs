using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TourPlanner.Client.BL.Command;
using TourPlanner.Client.BL.ViewModel;

namespace TourPlanner.Client.BL.Test
{
    public class ViewModelTest
    {
        private AddTourViewModel _addTourViewModel;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddCommand_Test()
        {
            var mainViewModelMock = new Mock<MainViewModel>();

            this._addTourViewModel = new AddTourViewModel(mainViewModelMock.Object);

            var result = this._addTourViewModel.AddCommand.CanExecute(null);

            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateViewCommand_Test()
        {
            var mainViewModelMock = new Mock<MainViewModel>().Object;
            var tourPlannerCommand = new UpdateViewCommand(mainViewModelMock);

            tourPlannerCommand.Execute("Go Home");
            
            Assert.IsTrue(!mainViewModelMock.SelectedViewModel.Equals(new HomeViewModel(mainViewModelMock)));
        }
    }
}
