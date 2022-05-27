using System.Collections.Generic;

namespace TourPlanner.ViewModels {
    public class TourViewModel : BaseViewModel {
        
        public TourViewModel() {
            
            


            RouteCommand = new DelegateCommand(
                o => CanChangeToRoute(),
                o => { ViewModel = new RouteViewModel();
                }
                );

            DetailsCommand = new DelegateCommand(
                o => CanChangeToDetails(),
                o => {
                    ViewModel = new DetailsViewModel();
                }
                );


            ViewModel = new RouteViewModel();

        }



        public DelegateCommand RouteCommand { get; set; }
        public DelegateCommand DetailsCommand { get; set; }

        private BaseViewModel _viewModel;
        public BaseViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                OnPropertyChanged();
                DetailsCommand.RaiseCanExecuteChanged();
                RouteCommand.RaiseCanExecuteChanged();
            }
        }


        private bool CanChangeToDetails() {
            if(ViewModel is DetailsViewModel) {
                return false;
            }
            else {
                return true;
            }
        }

        public bool CanChangeToRoute() {
            if (ViewModel is RouteViewModel) {
                return false;
            }
            else {
                return true;
            }
        }


        private string _name;
        public string Name {
            get => _name;

            set {
                if (_name != value) {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        

        private object _selectedView;
        public object SelectedView {
            get { return _selectedView; }
            set {
                _selectedView = value;
                OnPropertyChanged();
            }
        }



    }

}
