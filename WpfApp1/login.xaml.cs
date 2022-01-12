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



namespace WpfApp1
{
    /// Author: Surya Teja Bhimavarapu
    /// Interaction logic for login page
    /// This page is used by the user-Admin/Seller to login
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }



        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {




                if (Role.Text == "Admin")//if role is selected as Admin
                {
                    if (UnameBox.Text == "Admin" && PasswordBox.Password == "AdminPassword")//If password and username match
                    {
                        manageSeller manageSellerObj = new manageSeller();
                        manageSellerObj.Show();//it opens manage sellers page(Admin will manage the sellers)
                        this.Hide();



                    }
                    else//If password and username don't match
                    {
                        MessageBox.Show("Invalid Login");
                    }



                }
                else if (Role.Text == "Seller")//If role selected is Seller
                {
                    if (UnameBox.Text == "Seller" && PasswordBox.Password == "SellerPassword")//if password and username match
                    {
                        MainWindow MainWindowObj = new MainWindow();
                        MainWindowObj.Show();//This will open seller page for making sales(Seller will make sales in that page)
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login");
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter the details and try again");
            }
        }



        private void ClearButton_Click_1(object sender, RoutedEventArgs e)//This is to clear the page
        {
            Role.Text = "";
            UnameBox.Text = "";
            PasswordBox.Password = "";
        }



        private void AdminSelected(object sender, RoutedEventArgs e)//When combobox is selected as admin
        {
            Role.Text = "Admin";
        }



        private void SellerSelected(object sender, RoutedEventArgs e)//when combobox is selected as seller
        {
            Role.Text = "Seller";
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}