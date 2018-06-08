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

namespace ISBN_Check
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public static int Isbncheck(string chk)
        {
            //Console.WriteLine(chk);
            if (chk.Length == 10)
            {
                string temp = chk.Substring(0, 9);
                int checknum = 0;
                for (int i = 0; i < 9; i++)
                {
                    checknum = checknum + Convert.ToInt32(Convert.ToString(chk[i])) * (10 - i);
                }
                int checkdigit = checknum % 11;
                checkdigit = 11 - checkdigit;
                if (Convert.ToInt32(Convert.ToString(chk[9])) == checkdigit)
                {
                    return 1;
                }
                return 0;
            }
            else if(chk.Length == 13)
            {
                int num = 0;
                for (int flag = 0; flag < 12; flag++)
                {
                    if (flag % 2 == 1)
                        num += (Convert.ToInt32(Convert.ToString(chk[flag])) * 3);
                    else
                        num += (Convert.ToInt32(Convert.ToString(chk[flag])));
                }
                num = num % 10;
                num = 10 - num;
                //Console.WriteLine(num);
                //Console.WriteLine(Convert.ToInt32(chk[12]));
                //Console.WriteLine(Convert.ToInt16(Convert.ToString(chk[12])));
                if (num != Convert.ToInt32(Convert.ToString(chk[12])))
                    return 0;
                return 1;
            }
            return 2;
        }
        private void IsbnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (IsbnText.Text.Length != 0)
            {
                int test = Isbncheck(IsbnText.Text);
                if (test == 1)
                    IsbnTextBlock.Text = "Valid";
                else if (test == 0)
                    IsbnTextBlock.Text = "Invalid";
                else
                    IsbnTextBlock.Text = "Wrong Length";
            }
            else
            {
                IsbnTextBlock.Text = "Enter ISBN!";
            }

        }
        private void IsbnText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                e.Handled = true;
                IsbnCheck_Click(sender, e);
            }
        }
    }
}
