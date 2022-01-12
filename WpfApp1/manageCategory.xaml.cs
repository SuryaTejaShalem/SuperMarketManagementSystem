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
    /// Interaction logic for Managing Categories
    /// This page is used by the admin to manage the types of Categories in his supermarket

    public partial class manageCategory : Window
    {
        static string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\surya\Desktop\Final Project_5PM\Final Project_5PM\Final Project\WpfApp1\market.mdf';Integrated Security=True;Connect Timeout=30";
        marketDataContext dc = new marketDataContext(path); //created the connection to the database
        public manageCategory()
        {
            InitializeComponent();
          //  categoryGrid.ItemsSource = dc.CatTbls;
            load_data();
        }

        private void load_data()//When data needs to be refreshed
        {
            try
            {
                
                var cat = from x in dc.CatTbls select x;

                categoryGrid.ItemsSource = cat;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)//This is used to add new categories
        {
            try
            {
                CatTbl obj = new CatTbl();
                obj.CatId = int.Parse(catIdTb.Text);
                obj.CatName = catNameTb.Text;
                obj.CatDesc = catDescTb.Text;
                dc.CatTbls.InsertOnSubmit(obj);
                dc.SubmitChanges();
                MessageBox.Show("Category Added!");
                load_data();
                catIdTb.Text = "";
                catNameTb.Text = "";
                catDescTb.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong.Check your details!!");
            }

        }

        private void EditButton_Click_2(object sender, RoutedEventArgs e)//This is used to edit a category
        {
            CatTbl obj = categoryGrid.SelectedItem as CatTbl;
            if (obj != null)
            {
                try
                {
                    var category = (from c in dc.CatTbls where c.CatId == obj.CatId select c).Single();//creates a reference to the table
                    dc.CatTbls.DeleteOnSubmit(obj);
                    dc.SubmitChanges();
                    CatTbl nobj = new CatTbl();
                    nobj.CatId = int.Parse(catIdTb.Text);
                    nobj.CatName = catNameTb.Text;
                    nobj.CatDesc = catDescTb.Text;
                    dc.CatTbls.InsertOnSubmit(nobj);
                    dc.SubmitChanges();
                    MessageBox.Show("Category Edited");
                    load_data();
                    catIdTb.Text = "";
                    catNameTb.Text = "";
                    catDescTb.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong.Try again!!");
                }

            }
            else
            {
                MessageBox.Show("Select a Category to edit!");
            }
        }

        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)//Used to deleted a category
        {
            CatTbl obj = categoryGrid.SelectedItem as CatTbl;
            if (obj != null)
            {
                try
                {
                    var category = (from c in dc.CatTbls where c.CatId == obj.CatId select c).Single();
                    dc.CatTbls.DeleteOnSubmit(obj);
                    dc.SubmitChanges();
                    MessageBox.Show("Category Deleted!");
                    load_data();
                    catIdTb.Text = "";
                    catNameTb.Text = "";
                    catDescTb.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something wrong.Please try again!!");
                }
            }
            else
            {
                MessageBox.Show("select an item to Delete");
            }
        }

        private void Clear_button_Click(object sender, RoutedEventArgs e)//used to clear the contents of the text boxes
        {
            catIdTb.Text = "";
            catNameTb.Text = "";
            catDescTb.Text = "";

        }

        private void categoryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)//whenever we select something from the grid the contents of the grid are displayed into the text boxes
        {
            CatTbl sobj = categoryGrid.SelectedItem as CatTbl;
            if (sobj != null)
            {
                catIdTb.Text = sobj.CatId.ToString();
                catNameTb.Text = sobj.CatName;
                catDescTb.Text = sobj.CatDesc;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)//navigate to manage product page
        {
            this.Hide();
            Manage_Product product = new Manage_Product();
            product.Show();
        }

        private void SellerButton_Click(object sender, RoutedEventArgs e)//navigate to manage seller page
        {
            this.Hide();
            manageSeller seller = new manageSeller();
            seller.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)//used to shut down the app
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)//used to logout.Goes back to the login page
        {
            this.Hide();
            login l = new login();
            l.Show();
        }
    }
}
