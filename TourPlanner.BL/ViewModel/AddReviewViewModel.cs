using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Client.BL.Command;

namespace TourPlanner.Client.BL.ViewModel
{
    public class AddReviewViewModel : BaseViewModel
    {
        private string _name;
        private string _feedback;
        private readonly MainViewModel mainViewModel;
        private BaseCommand _addCommand;
        private ITourPlannerCommand _addReviewCommand;

        private BaseCommand updateViewCommand;
        private ITourPlannerCommand _updateViewCommand;

        public AddReviewViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.MessageViewModel = new MessageViewModel();
            this._addReviewCommand = new AddReviewCommand(this);
            this._updateViewCommand = new UpdateViewCommand(mainViewModel);
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;

                OnPropertyChanged();
            }
        }

        public string Feedback
        {
            get => _feedback;
            set
            {
                if (_feedback == value)
                {
                    return;
                }

                _feedback = value;

                OnPropertyChanged();
            }
        }

        public MessageViewModel MessageViewModel { get; }

        public string Message
        {
            set => MessageViewModel.Message = value;
        }


        public ICommand AddCommand => _addCommand ??= new BaseCommand(this._addReviewCommand.Execute);
        public ICommand UpdateViewCommand => updateViewCommand ??= new BaseCommand(this._updateViewCommand.Execute);
    }
}
