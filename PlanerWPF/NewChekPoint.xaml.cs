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
using System.Windows.Shapes;

namespace PlanerWPF
{
    /// <summary>
    /// Логика взаимодействия для NewChekPoint.xaml
    /// </summary>
    public partial class NewChekPoint : Window
    {
        public NewChekPoint()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            Close();
        }
    }
}
