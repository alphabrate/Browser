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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp.Wpf;

namespace BROWSER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> WebPages; // list of webpages visited since the browser was opened
        int Current = 0; // to keep track of the current index of the webpages
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WebPages = new List<string>();
            GoHome();
        }

        void GoHome()
        {
            area.Text = "https://xchuangc.github.io/start";
            chrome.Address = "https://xchuangc.github.io/start";
            WebPages.Add("https://xchuangc.github.io/start");
        }

        void LoadWebPages(string Link, bool addToList = true)
        {
            area.Text = Link;
            chrome.Address = Link;

            MenuItem item = new MenuItem();
            item.Click += MenuClicked;
            item.Header = Link;
            item.Width = 184;

            if (addToList)
            {
                Current++;
                WebPages.Add(Link);
            }
        }

        void ToggleWebPages(string Option)
        {
            if(Option== "→")
            {
                if ((WebPages.Count - Current - 1) != 0)
                {
                    Current++; 
                    LoadWebPages(WebPages[Current], false);
                }
            }

            else
            {
                if((WebPages.Count+Current-1) >= WebPages.Count)
                {
                    Current--;
                    LoadWebPages(WebPages[Current], false);
                }
            }
        }

        //back forw btns
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            ToggleWebPages(btn.Content.ToString());
        }

        //refresh
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoadWebPages(WebPages[Current]);
        }

        //home
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoadWebPages(WebPages[0]);
        }

        private void MenuClicked(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            LoadWebPages(item.Header.ToString());
        }

        private void area_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string str = area.Text;

                // .com
                if (str.Contains(".com")) {
                    LoadWebPages(str);
                }

                //.net
                else if (str.Contains(".net"))
                {
                    LoadWebPages(str);
                }

                //.gov
                else if (str.Contains(".gov"))
                {
                    LoadWebPages(str);
                }
                
                //.io
                else if (str.Contains(".io"))
                {
                    LoadWebPages(str);
                }

                //.cn
                else if (str.Contains(".cn"))
                {
                    LoadWebPages(str);
                }

                //.hk
                else if (str.Contains(".hk"))
                {
                    LoadWebPages(str);
                }

                //.
                else if (str.Contains(".jp"))
                {
                    LoadWebPages(str);
                }

                //.
                else if (str.Contains("www."))
                {
                    LoadWebPages(str);
                }

                // https://
                else if (str.Contains("https://"))
                {
                    LoadWebPages(str);
                }

                else if (str.Contains("http://"))
                {
                    LoadWebPages(str);
                }

                else {
                    LoadWebPages("https://www.google.com/search?q=" + str);
                }
            }
        }

        private void LoadWebPages(object p, string text)
        {
            throw new NotImplementedException();
        }

        private void Button_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true; //disable an event
        }
    }
}
