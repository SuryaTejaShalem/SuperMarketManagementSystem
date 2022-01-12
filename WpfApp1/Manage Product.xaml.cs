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
    /// Author: Rupa Gopu
    /// Interaction logic for Manage Products Page
    /// Used by admin to manage products in his supermarket
    public partial class Manage_Product : Window
    {
        static string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\surya\Desktop\Final Project_5PM\Final Project_5PM\Final Project\WpfApp1\market.mdf';Integrated Security=True;Connect Timeout=30";
        marketDataContext dc = new marketDataContext(path);
        private object constring;

        public Manage_Product()
        {
            InitializeComponent();
            productGrid.ItemsSource = dc.ProdTbls;
            catGrid.ItemsSource = dc.CatTbls;
            //load_data();
        }

        public void load_data()//this will load the data again
        {
            try
            {
                // var products = from s in dc.ProdTbls select s;
                var prod = from x in dc.ProdTbls select x;

                productGrid.ItemsSource = prod;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)//Used to add new products
        {
            try
            {
                if (productName.Text != "" && productID.Text != "" && productPrice.Text != "" && productQty.Text != "" && Productcategory.Text != "") { 
                ProdTbl obj = new ProdTbl();
                    obj.ProdId = int.Parse(productID.Text);
                    obj.ProdName = productName.Text;
                    obj.ProdPrice = int.Parse(productPrice.Text);
                    obj.ProdQty = int.Parse(productQty.Text);
                    obj.ProdCat = Productcategory.Text;

                    dc.ProdTbls.InsertOnSubmit(obj);
                    dc.SubmitChanges();
                    MessageBox.Show("Product Added!");
                    load_data();
                    productName.Text = "";
                    productID.Text = "";
                    productPrice.Text = "";
                    productQty.Text = "";
                    Productcategory.Text = "";
                }
                else
                {
                    MessageBox.Show("Some details are missing.Please Check!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)//Edit existing products
        {
            ProdTbl obj = productGrid.SelectedItem as ProdTbl;
            if (obj != null)
            {
                try
                {
                    if(productName.Text != "" && productID.Text != "" && productPrice.Text != "" && productQty.Text != "" && Productcategory.Text != "")
                    {
                        object ProdTbl = dc.ProdTbls;
                        var category = (from p in dc.ProdTbls where p.ProdId == obj.ProdId select p).Single();
                        dc.ProdTbls.DeleteOnSubmit(obj);
                        dc.SubmitChanges();
                        ProdTbl nobj = new ProdTbl();
                        nobj.ProdId = int.Parse(productID.Text);
                        nobj.ProdName = productName.Text;
                        nobj.ProdPrice = int.Parse(productPrice.Text);
                        nobj.ProdQty = int.Parse(productQty.Text);
                        nobj.ProdCat = Productcategory.Text;
                        dc.ProdTbls.InsertOnSubmit(nobj);
                        dc.SubmitChanges();
                        MessageBox.Show("Product Edited");
                        load_data();
                        productName.Text = "";
                        productID.Text = "";
                        productPrice.Text = "";
                        productQty.Text = "";
                        Productcategory.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Some details are missing.Please Check!!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something wrong.Try again!!");
                }
            }
            else
            {
                MessageBox.Show("Select a product to edit!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)//Delete Existing products
        {
            ProdTbl obj = productGrid.SelectedItem as ProdTbl;
            if (obj != null)
            {
                try
                {
                    var product = (from p in dc.ProdTbls where p.ProdId == obj.ProdId select p).Single();
                    dc.ProdTbls.DeleteOnSubmit(obj);
                    dc.SubmitChanges();
                    MessageBox.Show("item deleted");
                    load_data();
                    productName.Text = "";
                    productID.Text = "";
                    productPrice.Text = "";
                    productQty.Text = "";
                    Productcategory.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)//Clear the text boxes
        {
            productName.Text = "";
            productID.Text = "";
            productPrice.Text = "";
            productQty.Text = "";
            Productcategory.Text = ""; 
        }

        private void catGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)//When the category is selected the category name is displayed in the Product category text box
        {
            CatTbl sobj = catGrid.SelectedItem as CatTbl;
            if (sobj != null)
            {
                Productcategory.Text = sobj.CatName;
            }
        }

        private void productGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)//When a product is selected the respective details are displayed in the text boxes
        {
            ProdTbl sobj = productGrid.SelectedItem as ProdTbl;
            if (sobj != null)
            {
                Productcategory.Text = sobj.ProdCat.ToString();
                productID.Text = sobj.ProdId.ToString();
                productName.Text = sobj.ProdName;
                productPrice.Text = sobj.ProdPrice.ToString();
                productQty.Text = sobj.ProdQty.ToString();
            }
        }

        private void SellerButton_Click(object sender, RoutedEventArgs e)//Navigate to manage seller page
        {
            this.Hide();
            manageSeller seller = new manageSeller();
            seller.Show();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)//navigate to manage category page
        {
            this.Hide();
            manageCategory category = new manageCategory();
            category.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)//app will shut down 
        {
            System.Windows.Application.Current.Shutdown();
                        
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)//goes back to login page
        {
            this.Hide();
            login l = new login();
            l.Show();
        }
    }
    }
    
    

