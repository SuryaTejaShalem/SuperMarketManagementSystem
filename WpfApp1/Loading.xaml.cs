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
using System.Threading;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LoadingForm.xaml
    /// </summary>
    public partial class Loading : Window
    {
        DispatcherTimer dT = new DispatcherTimer();
        public Loading()
        {

            InitializeComponent();
            dT.Tick += new EventHandler(dt_Tick);
            dT.Interval = new TimeSpan(0, 0, 10);
            dT.Start();
        }

        private void dt_Tick(object sender, EventArgs e)
        {

            login mw = new login();
            mw.Show();

            dT.Stop();
            this.Close();

        }


    }
}

