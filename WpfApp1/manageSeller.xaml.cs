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
    /// Puneet's Code block
    /// Interaction logic for manageSeller.xaml
    /// Used by Admin to manage Sellers in the supermarket
    public partial class manageSeller : Window
    {
        static string connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\surya\Desktop\Final Project_5PM\Final Project_5PM\Final Project\WpfApp1\market.mdf';Integrated Security=True;Connect Timeout=30";
        marketDataContext dc = new marketDataContext(connectString);
        public manageSeller()
        {
            InitializeComponent();

            load_Data();
        }
        private void load_Data() // for loading the data in the database
        {
            try
            {
              
                var sell = from x in dc.SellerTbls select x;

                sellerGrid.ItemsSource = sell;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void AddButton_Click(object sender, RoutedEventArgs e) // to add the seller details in the datagrid and seller table
        {
            try
            {
                SellerTbl obj = new SellerTbl();
                obj.SellerId = int.Parse(textID.Text);
                obj.SellerName = textName.Text;
                obj.SellerAge = int.Parse(textAge.Text);
                obj.SellerPhone = textPhone.Text;
                obj.SellerPassword = textPassword.Text;
                dc.SellerTbls.InsertOnSubmit(obj);
                dc.SubmitChanges();
                MessageBox.Show("Seller Added!");
                load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong.Check your details!!");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e) // to edit the data of the seller from the datagrid and database
        {
            SellerTbl obj = sellerGrid.SelectedItem as SellerTbl;
            if (obj != null)
            {
                try
                {

                    var category = (from c in dc.SellerTbls where c.SellerId == obj.SellerId select c).Single();
                    dc.SellerTbls.DeleteOnSubmit(obj);
                    dc.SubmitChanges();
                    SellerTbl nobj = new SellerTbl();
                    nobj.SellerId = int.Parse(textID.Text);
                    nobj.SellerName = textName.Text;
                    nobj.SellerAge = int.Parse(textAge.Text);
                    nobj.SellerPhone = textPhone.Text;
                    nobj.SellerPassword = textPassword.Text;
                    dc.SellerTbls.InsertOnSubmit(nobj);
                    dc.SubmitChanges();
                    MessageBox.Show("Category Edited");
                    load_Data();
                    textID.Text = "";
                    textName.Text = "";
                    textAge.Text = "";
                    textPhone.Text = "";
                    textPassword.Text = "";
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong.Try again!!");
                }

            }
            else
                MessageBox.Show("Please select a record for update");
        }
        
        private void DeleteButton_Click(object sender, RoutedEventArgs e) //to delete an entry from the datagrid and database
        {
            SellerTbl obj = sellerGrid.SelectedItem as SellerTbl;
            if (obj != null)
            {

                try
                {
                    var seller = (from s in dc.SellerTbls where s.SellerId == obj.SellerId select s).Single();//create refernce of object
                    dc.SellerTbls.DeleteOnSubmit(obj);//deleting the record
                    dc.SubmitChanges();//commit data
                    MessageBox.Show("Seller Deleted!");
                    load_Data();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else
            {
                MessageBox.Show("select an item to Delete");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e) // to clear any text written in text box
        {
            textID.Text = "";
            textName.Text = "";
            textAge.Text = "";
            textPhone.Text = "";
            textPassword.Text = "";
        }

        private void sellerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) // when a selection is changed in the datagrid the text gets displayed in the text box
        {
            SellerTbl sobj = sellerGrid.SelectedItem as SellerTbl;
            if (sobj != null)
            {

                textID.Text = sobj.SellerId.ToString();
                textName.Text = sobj.SellerName;
                textAge.Text = sobj.SellerAge.ToString();
                textPhone.Text = sobj.SellerPhone;
                textPassword.Text = sobj.SellerPassword;

            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void ProductButton_Click(object sender, RoutedEventArgs e) // to navigate to manage products form
        {
            this.Hide();
            Manage_Product  product = new Manage_Product();
            product.Show();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e) // to navigate to  manage category form
        {
            this.Hide();
            manageCategory category = new manageCategory();
            category.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // this shut downs the application and closes all the processes  running in the background
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e) // to navigate to login form
        {
            this.Hide();
            login l = new login();
            l.Show();
        }
    }

      
    }
    

