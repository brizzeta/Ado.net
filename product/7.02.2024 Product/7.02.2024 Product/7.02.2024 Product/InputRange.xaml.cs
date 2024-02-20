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
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _7._02._2024_Product
{
    public partial class InputRange : Window
    {
        public int Range1 { get; set; }
        public int Range2 { get; set; }
        public InputRange()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int value1,value2;
                if(int.TryParse(textbox1.Text, out value1) == true &&  int.TryParse(textbox2.Text, out value2) == true)
                {
                    Range1 = value1;
                    Range2 = value2;
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    throw new Exception("Введите число!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
