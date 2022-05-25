using System.Collections.Generic;

namespace TourPlanner.ViewModels {
    public class TourViewModel : BaseViewModel {

        public TourViewModel() {



            RouteCommand = new DelegateCommand(
                o => { ViewModel = new RouteViewModel();
                }
                );

            DetailsCommand = new DelegateCommand(
                o => {
                    ViewModel = new DetailsViewModel();
                }
                );


            ChangeViewCommand = new DelegateCommand(
                o => ChangeView(o)

                ) ;


        }



        public List<BaseViewModel> NavItems { get; set; }
        public DelegateCommand ChangeViewCommand { get; set; }

        public DelegateCommand RouteCommand { get; set; }
        public DelegateCommand DetailsCommand { get; set; }

        private BaseViewModel _viewModel;
        public BaseViewModel ViewModel {
            get { return _viewModel; }
            set {
                _viewModel = value;
                OnPropertyChanged();
            }
        }


        void ChangeView(object param) {
            SelectedView = param;
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
