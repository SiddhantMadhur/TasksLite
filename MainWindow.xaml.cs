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
using System.IO;

namespace RemindersLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void init ()
        {
            string[] tasks = File.ReadAllLines("data.txt");
            foreach (string task in tasks)
            {
                listOfReminders.Items.Add(task);
            }
        }

        private void addNewTask(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(reminderInput.Text) && (!listOfReminders.Items.Contains(reminderInput.Text))){
                listOfReminders.Items.Add(reminderInput.Text);
                reminderInput.Clear();
                if (listOfReminders.Items.Count > 0)
                {
                    using(TextWriter TW = new StreamWriter("data.txt"))
                    {
                        foreach(string itemText in listOfReminders.Items)
                        {
                            TW.WriteLine(itemText);
                        }
                    }

                    
                }
            }
        }

        private void deleteTask(object sender, RoutedEventArgs e)
        {
            listOfReminders.Items.RemoveAt(listOfReminders.Items.IndexOf(listOfReminders.SelectedItem));
            if (listOfReminders.Items.Count >= 0)
            {
                using (TextWriter TW = new StreamWriter("data.txt"))
                {
                    foreach (string itemText in listOfReminders.Items)
                    {
                        TW.WriteLine(itemText);
                    }
                }


            }
        }
    }
}
