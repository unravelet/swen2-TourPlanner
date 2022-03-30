using System;
using System.Windows;
using TourPlanner.BL;

namespace TourPlanner {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            DataContext = new MainViewModel(new Businesslogic());
            InitializeComponent();
            
        }

        
    }
}
