using System;
using System.Collections;
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
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// Daksh's code block
    /// Interaction logic for MainWindow.xaml
    /// Used by seller to add products and do the billings
    public partial class MainWindow : Window
    {

        static string connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\surya\Desktop\Final Project_5PM\Final Project_5PM\Final Project\WpfApp1\market.mdf';Integrated Security=True;Connect Timeout=30";
        marketDataContext dc = new marketDataContext(connectString);

        public MainWindow()
        {
            InitializeComponent();
            
            lblDate.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
            textProductQuanty.Text = "1";

              loadProducts();
              loadBills();
        }
        
        public void loadProducts()
        {
            try
            {       
                var products = from s in dc.ProdTbls select s;

                productsGrid.ItemsSource = products;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void loadBills()
        {
            try
            {
                var bills = from bill in dc.BillTbls select bill;
                Orders_bills.ItemsSource = bills;   
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



        private void textProductQuanty_TextChanged(object sender, TextChangedEventArgs e)
        {
            var q = this.textProductQuanty.Text;
            if(q == "" || q == "0")
            {
                textProductQuanty.Text = "1";
            }
        }

        int n = 0;
        int grandTotal = 0;
        ArrayList selectedProducts = new ArrayList();
        
        private void add_product(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if(textProductName.Text == "" || textProductQuanty.Text == "")
                {
                    MessageBox.Show("Missing Data");
                    return;
                }
                else
                {

                    int total = int.Parse(textProductPrice.Text) * int.Parse(textProductQuanty.Text);

                    var data = new { 
                        No = ++n, 
                        Price = Convert.ToDouble(textProductPrice.Text), 
                        ProdName = textProductName.Text, 
                        ProdQty = Convert.ToInt32(textProductQuanty.Text),
                        Total = total
                    };

                    selectedProducts.Add(new KeyValuePair<int, int>(int.Parse(textProductId.Text), Convert.ToInt32(textProductQuanty.Text)));

                    Order_Products.Items.Add(data);

                    grandTotal += total;
                    lblGrandTotal.Text = ""+grandTotal;

                    textProductId.Text = "";
                    textProductName.Text = "";
                    textProductPrice.Text = "";
                    textProductQuanty.Text = "1";
                }
            }
            catch(InvalidCastException ice)
            {

            }
            catch(FormatException fe)
            { 
            }
          
            
        }

        private void add_selles(object sender, RoutedEventArgs e)
        {
            if(textBillId.Text == "") 
            {
                MessageBox.Show("Missing Bill Id");
            }
            else if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Atleast select one product");
                return;
            }
            else
            {
                try
                {

                            BillTbl bill = new BillTbl();
                            bill.BillId = int.Parse(textBillId.Text);
                            bill.BillDate = lblDate.Text;
                            bill.TotAmt = grandTotal;
                            bill.SellerName = lblSeller.Text;
                            
                            
                        dc.BillTbls.InsertOnSubmit(bill);

                            dc.SubmitChanges();

                            MessageBox.Show("Order Added Successfully");

                            foreach (KeyValuePair<int, int> item in selectedProducts)
                            {
                                ProdTbl product = dc.ProdTbls.Single(x => x.ProdId == item.Key);
                                product.ProdQty = product.ProdQty - item.Value;
                                dc.SubmitChanges();
                            }

                            loadProducts();
                            loadBills();

                            Order_Products.Items.Clear();
                        
                            lblGrandTotal.Text = "0";
                            grandTotal = 0;
                            textBillId.Text = "";
                    
                }
                catch (SqlException ice)
                {
                    MessageBox.Show(ice.Message);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                 
                }
            }

        }

        private void productsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                ProdTbl product = (ProdTbl) productsGrid.SelectedItem;

                textProductId.Text = product.ProdId.ToString();
                textProductName.Text = product.ProdName;
                textProductPrice.Text = product.ProdPrice.ToString();
            }
            catch(InvalidCastException ice)
            {
               // MessageBox.Show(ice.Message);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
