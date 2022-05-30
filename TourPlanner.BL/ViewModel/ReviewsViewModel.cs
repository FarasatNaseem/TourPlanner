using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Client.BL.Command;
using TourPlanner.Model;

namespace TourPlanner.Client.BL.ViewModel
{
    public class ReviewsViewModel : BaseViewModel
    {
        private readonly MainViewModel mainViewModel;
        private readonly ITourPlannerCommand _loadReviewsCommand;

        private BaseCommand updateViewCommand;
        private ITourPlannerCommand _updateViewCommand;

        public ReviewsViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            this._loadReviewsCommand = new LoadReviewsCommand(this);
            this._updateViewCommand = new UpdateViewCommand(mainViewModel);
            this.Reviews = new ObservableCollection<Review>();
            this._loadReviewsCommand.Execute(null);
        }

        public ObservableCollection<Review> Reviews { get; }

        public ICommand UpdateViewCommand => updateViewCommand ??= new BaseCommand(this._updateViewCommand.Execute);
    }
}