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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIPaint
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         //   byte[] buffer = Guid.NewGuid().ToByteArray();
           // int iRoot = BitConverter.ToInt32(buffer, 0);
            rdmNum = new Random();
            p();
        }
        Random rdmNum;
        private async void p() {
            bt.IsEnabled = false;
            int num = 250000 / (size * size);
            for (int i = 0; i < num; i++)
            {
                Border b = new Border()
                {
                    Width = size,
                    Height = size
                };
                wp.Children.Add(b);
            }
            foreach (Border ac in wp.Children)
            {
                await Task.Delay(1);
                int o = rdmNum.Next(0, 5);
                ac.BorderThickness = new Thickness(0);
                Color color = Colors.White;
                if (o == 1)
                    color = Colors.SkyBlue;
                else if (o == 2)
                    color = Colors.GreenYellow;
                if (color != Colors.White)
                {
                    ac.Background = new SolidColorBrush(color);
                    ac.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(500)));
                }
            }
            bt.IsEnabled = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wp.Children.Clear();
            p();
        }
        int size = 50;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(tx.Text, out size))
                tb.Text = "Size: " + size;
        }
    }
}
