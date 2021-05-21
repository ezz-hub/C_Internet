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
using System.Net.Http;
using System.Diagnostics;
using System.Threading;
namespace THE_Internet
{
    



    /// <summary>
    /// Interaction logic for Internet.xaml
    /// </summary>
    public partial class Internet : Window
    {
        public static readonly DependencyProperty HtmlProperity = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(MainWindow), new FrameworkPropertyMetadata(OnChangingWeb));





        public Internet()
        {
            InitializeComponent();
        }

        private   async void MainInternet_Click_1(object sender, RoutedEventArgs e)
        {


            Debug.WriteLine("Thread Number is Now Before Downloading is ..."+Thread.CurrentThread.ManagedThreadId );

            string MyHtml="Denis";
            await Task.Run(async () =>
            {
                Debug.WriteLine("Thread Number is Now While Downloading is ..." + Thread.CurrentThread.ManagedThreadId);
                HttpClient WebClient = new HttpClient();
                string Httml = WebClient.GetStringAsync("Https://google.Com").Result;
                MyHtml = Httml;


            });

            Debug.WriteLine("Thread Number is Now After Downloading is ..." + Thread.CurrentThread.ManagedThreadId);
           
            MainInternet.Content = "Done Downloading";
            MyWeb.SetValue(HtmlProperity,MyHtml);
        }

        static void OnChangingWeb(DependencyObject dependencyObject ,DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;

            if(webBrowser!=null){

                webBrowser.NavigateToString(e.NewValue.ToString());

            }

        }












    }
}
