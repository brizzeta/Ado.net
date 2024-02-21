using System.IO;
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

namespace Storage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

        private void AllInfo_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT * FROM Good";
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

        private void AllTypes_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT Good_type FROM Good";
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

        private void AllProviders_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT name FROM Good_Provider";
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

        private void MaxCount_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT TOP 1 WITH TIES\r\n    G.Name AS Good_Name,\r\n    S.Good_count\r\nFROM\r\n    storage AS S\r\nJOIN\r\n    Good AS G ON S.Good_id = G.id\r\nORDER BY\r\n    S.Good_count DESC;";
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

        private void MinCount_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT TOP 1 WITH TIES\r\n    G.Name AS Good_Name,\r\n    S.Good_count\r\nFROM\r\n    storage AS S\r\nJOIN\r\n    Good AS G ON S.Good_id = G.id\r\nORDER BY\r\n    S.Good_count ASC;";
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

        private void MaxPrice_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT TOP 1\r\n    G.name AS Good_Name,\r\n    P.price AS Good_Price\r\nFROM\r\n    storage AS S\r\nJOIN\r\n    Good AS G ON S.Good_id = G.id\r\nJOIN\r\n    Price AS P ON S.Price_id = P.id\r\nORDER BY\r\n    P.price DESC;";
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

        private void MinPrice_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT TOP 1\r\n    G.name AS Good_Name,\r\n    P.price AS Good_Price\r\nFROM\r\n    storage AS S\r\nJOIN\r\n    Good AS G ON S.Good_id = G.id\r\nJOIN\r\n    Price AS P ON S.Price_id = P.id\r\nORDER BY\r\n    P.price ASC;";
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

        private void GivenCategory_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            Category category = new Category();
            bool? res = category.ShowDialog();

            if (res == true)
            {
                try
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = $"SELECT\r\n    G.name AS Good_Name,\r\n    S.Good_count\r\nFROM\r\n    storage AS S\r\nJOIN\r\n    Good AS G ON S.Good_id = G.id\r\nWHERE\r\n    G.Good_type = '{category.textbox1.Text}';";
                    SqlDataReader reader = command.ExecuteReader();
                    int count = reader.FieldCount;
                    listbox1.Items.Clear();
                    while (reader.Read())
                    {
                        string? res_ = "", temp = "";
                        for (int i = 0; i < count; i++)
                        {
                            temp = reader[i].ToString();
                            res_ += temp + " ";
                        }
                        listbox1.Items.Add(res_);
                        res_ = "";
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
        }

        private void GivenProvider_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();

            Provider provider = new Provider();
            bool? res = provider.ShowDialog();

            if (res == true) 
            {
                try
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = $"SELECT\r\n    G.name AS Good_Name,\r\n    S.Good_count\r\nFROM\r\n    storage AS S\r\nJOIN\r\n    Good AS G ON S.Good_id = G.id\r\nJOIN\r\n    Good_Provider AS GP ON S.Provider_id = GP.id\r\nWHERE\r\n    GP.name = '{provider.textbox1.Text}';";
                    SqlDataReader reader = command.ExecuteReader();
                    int count = reader.FieldCount;
                    listbox1.Items.Clear();
                    while (reader.Read())
                    {
                        string? res_ = "", temp = "";
                        for (int i = 0; i < count; i++)
                        {
                            temp = reader[i].ToString();
                            res_ += temp + " ";
                        }
                        listbox1.Items.Add(res_);
                        res_ = "";
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
        }

        private void TheOldest_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT TOP 1\r\n    G.name AS Good_Name,\r\n    S.Delivery_date\r\nFROM\r\n    storage AS S\r\nJOIN\r\n    Good AS G ON S.Good_id = G.id\r\nORDER BY\r\n    S.Delivery_date ASC;";
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

        private void AverageCount_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = "SELECT\r\n    G.Good_type,\r\n    AVG(S.Good_count) AS Average_Count\r\nFROM\r\n    storage AS S\r\nJOIN\r\n    Good AS G ON S.Good_id = G.id\r\nGROUP BY\r\n    G.Good_type;";
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
    }
}