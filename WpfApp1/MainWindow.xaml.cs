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



namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool clearbt1 = false;
        private bool clearSelectedButtonAdded = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(input1.Text))
            {

                CheckBox rb = new CheckBox();
                rb.Content = input1.Text;
                rb.Margin = new Thickness(0, 5, 0, 5);
                rb.Foreground = Brushes.White;
                rb.FontSize = 12;
                rb.Checked += Rb_Checked;
                rb.Unchecked += Rb_Unchecked;
                rb.FontFamily = new FontFamily("OCR A Extended");


                if (!clearbt1) {
                    Button bt1 = new Button();
                    bt1.Content = "Clear All Tasks";
                    bt1.Width = 120;
                    bt1.Height = 28;
                    bt1.Click += ClearAllTasks;
                    bt1.FontFamily = new FontFamily("OCR A Extended");
                    clearbt.Children.Add(bt1);
                    clearbt1 = true;
                }


                TasksPanel.Children.Add(rb); 
                

                input1.Clear();  

             
                
    }
            else
            {
                MessageBox.Show("You have to DO something!");
            }
        }

        private void Rb_Unchecked(object sender, RoutedEventArgs e)
        {
            bool anyChecked = TasksPanel.Children
            .OfType<CheckBox>()
            .Any(cb => cb.IsChecked == true);

            if (!anyChecked && clearSelectedButtonAdded)
            {
                clearItem.Children.Clear();
                clearSelectedButtonAdded = false;
            }
        }

        private void Rb_Checked(object sender, RoutedEventArgs e)
        {
            if (!clearSelectedButtonAdded)
            {
                Button bt2 = new Button();
                bt2.Content = "Clear Selected Item";
                bt2.Width = 148;
                bt2.Height = 28;
                bt2.Margin = new Thickness(0, 10, 0, 0);
                bt2.Click += ClearItem;
                bt2.FontFamily = new FontFamily("OCR A Extended");
                bt2.Background = (Brush)new BrushConverter().ConvertFrom("#ff03d1");

                clearItem.Children.Add(bt2);

                clearSelectedButtonAdded = true;
            }
        }

        private void ClearAllTasks(object sender, RoutedEventArgs e)
        {
            TasksPanel.Children.Clear();
            clearbt.Children.Clear();
            clearbt1 = false;
        }

        private void ClearItem(object sender, RoutedEventArgs e)
        {
            CheckBox selected = null;

            foreach (var child in TasksPanel.Children)
            {
                if (child is CheckBox cb && cb.IsChecked == true)
                {
                    selected = cb;
                    break;
                }
                
            }

            if (selected == null) { 
                clearItem.Children.Clear ();
            }

            if (selected != null)
            {
                TasksPanel.Children.Remove(selected);
                

            }


        }





    }


}
