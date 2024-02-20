using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Windows.Controls.Primitives;
using System.Drawing;


namespace _7._02._2024_Product
{
    public partial class MainWindow : Window
    {
        string? connectionString;
        public MainWindow()
        {
            InitializeComponent();
            var builder = new ConfigurationBuilder();
            string path = Directory.GetCurrentDirectory();
            builder.SetBasePath(path);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        void Execute (string commands)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = commands;
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                listbox1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + " ";
                    }
                    listbox1.Items.Add(res);
                    res = "";
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Execute("SELECT * FROM Products");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Execute("SELECT name FROM Products");
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Execute("SELECT color FROM Products");
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Execute("SELECT MAX(calories) FROM Products");
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Execute("SELECT MIN(calories) FROM Products");
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Execute("SELECT AVG(calories) FROM Products");
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            Execute("SELECT COUNT(*) FROM Products WHERE type = 'Овощ'");
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            Execute("SELECT COUNT(*) FROM Products WHERE type = 'Фрукт'");
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            InputColor color = new InputColor();
            bool? result = color.ShowDialog();
            if (result == true)
            {
                Execute($"SELECT COUNT(*) FROM Products WHERE color = '{color.color}'");
            }
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            Execute("SELECT color,COUNT(*) FROM Products GROUP BY color ORDER BY color");
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            InputCalories calories = new InputCalories();
            bool? result = calories.ShowDialog();
            if (result == true)
            {
                Execute($"SELECT * FROM Products WHERE calories < {calories.Calories}");
            }
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            InputCalories calories = new InputCalories();
            bool? result = calories.ShowDialog();
            if (result == true)
            {
                Execute($"SELECT * FROM Products WHERE calories > {calories.Calories}");
            }
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            InputRange range = new InputRange();
            bool? result = range.ShowDialog();
            if (result == true)
            {
                Execute($"SELECT * FROM Products WHERE calories > {range.Range1} AND calories < {range.Range2}");
            }
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            Execute("SELECT * FROM Products WHERE color IN ('Красный', 'Желтый') ORDER BY name");
        }
    }
}