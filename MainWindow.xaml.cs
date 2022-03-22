using System;
using System.Windows;

namespace swen2_TourPlanner {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void Loupe_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("I was clicked");
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e) {
            string s = null;
            try {
                s.Trim();
            }
            catch (Exception ex) {
                MessageBox.Show("Handled exception occured:" + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
