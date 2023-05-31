using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

namespace балтика_5ка
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime datka = DateTime.Today;
        List<chel> hz = new List<chel>();
        public MainWindow()
        {
            InitializeComponent();
            data.SelectedDate = datka;



        }
        private void dab_Click(object sender, RoutedEventArgs e)
        {
            if (money.Text == "" || name.Text == ""|| chtodob == null) 
            {
                MessageBox.Show("напиши что-то плиз");
            }


            double buk;
            if (double.TryParse(money.Text, out buk) )
            {
                hz.Add(new chel(box.Text, money.Text, chtodob.Text));
                dg.ItemsSource = null;
                dg.ItemsSource = hz;
            }
            else
            {
                MessageBox.Show("как ты цифры в буквы превратил?");
            }
            
        }

        private void dobav_Click(object sender, RoutedEventArgs e)
        {
            box.Items.Add(chtodob.Text);
        }

        private void name_GotFocus(object sender, RoutedEventArgs e)
        {
            name.Text = "";
        }

        private void money_GotFocus(object sender, RoutedEventArgs e)
        {
            
            money.Text = "";

            
        }

        private void chtodob_GotFocus(object sender, RoutedEventArgs e)
        {
            chtodob.Text = "";
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }
        private void proverka()
        {
            if (dg.SelectedItem == null)
            {
                MessageBox.Show("ничегошеньки не выбрано");
                return;
            }
        }


        internal class chel {
            public string im { get; set; }
            public string mon { get; set; }
            public string tip { get; set; }


            public chel(string Im,string Mon,string Tip)
            {
                im = Im;
                mon = Mon;
                tip = Tip;
 
            }
        }
        private void data_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            datka = Convert.ToDateTime(data.Text);
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            proverka();
            int index = 0;
            foreach (var item in hz)
            {
                if (item != null)
                {
                    hz.RemoveAt(index);
                    return;
                }
               
            }
            index++;
            //MessageBox.Show("он не может получить номер строки для ее удаления(p.s. Пытался сделать как на практике))))");

        }

        private void izm_Click(object sender, RoutedEventArgs e)
        {
            if (money.Text == "" || name.Text == "" || chtodob == null)
            {
                MessageBox.Show("напиши что-то плиз");
            }
            else
            {
                proverka();
                int index = 0;
                foreach (var item in hz)
                {
                    if (item != null)
                    {
                        hz.RemoveAt(index);
                        hz.Add(new chel(box.Text, money.Text, chtodob.Text));
                        dg.ItemsSource = null;
                        dg.ItemsSource = hz;
                        return;
                    }

                }
            }

            
        }
       

       
        
    }
}
