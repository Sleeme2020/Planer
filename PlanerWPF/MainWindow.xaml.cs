using PlanerWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlanerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewHuman newHuman = new NewHuman();
            newHuman.DataContext = viewModel;
            newHuman.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewEvent newEvent = new NewEvent();
            newEvent.DataContext = new EventViewModel() {OwnerContext=viewModel};
            newEvent.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NewChekPoint newChekPoint = new NewChekPoint();
            newChekPoint.DataContext = new ChekPointViewModel() { OwnerContext = viewModel, TaskId = viewModel.SelectedItem.Id };
            newChekPoint.ShowDialog();
        }
    }
}
