using System;
using System.Windows;
using TourPlanner.BL;

namespace TourPlanner {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            //Businesslogic bl = new Businesslogic();
            DataContext = new MainViewModel();
        }

        
    }
}
