using System.Windows;

namespace TourPlanner {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            DataContext = new MainViewModel(new Businesslogic());
            InitializeComponent();
            //Businesslogic bl = new Businesslogic();
            DataContext = new MainViewModel();
        }


    }
}
