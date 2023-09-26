using PROG7312_UI.Core;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PROG7312_UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for ReplacingBooksView.xaml
    /// </summary>
    public partial class ReplacingBooksView : UserControl
    {
        Random random = new Random();
        ProgressReport pr = ProgressReport.GetProgressReport();
        private DateTime generateStart;
        private Stopwatch stopwatch;
        private DispatcherTimer timer;
        private ObservableCollection<string> unorderedBooks = new ObservableCollection<string>();
        private ObservableCollection<string> orderedBooks = new ObservableCollection<string>();
        private ObservableCollection<string> correctOrder = new ObservableCollection<string>();
        ProgressReport rp = ProgressReport.GetProgressReport();
        Acheivements ach = Acheivements.GetAcheivements();


        public ReplacingBooksView()
        {
            InitializeComponent();


            unorderedView.ItemsSource = unorderedBooks;
            orderedView.ItemsSource = orderedBooks;
            unorderedView.MouseDoubleClick += UnorderedView_MouseDoubleClick;
            orderedView.MouseDoubleClick += OrderedView_MouseDoubleClick;
            ReportsListView.ItemsSource = rp.GetReprot();
            AcheivementsView.ItemsSource = ach.GetAcheivementsList();
            stopwatch = new Stopwatch();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
        }

        private void UnorderedView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (unorderedView.SelectedItem != null)
            {
                string selectedItem = unorderedView.SelectedItem as string;
                unorderedBooks.Remove(selectedItem);
                orderedBooks.Add(selectedItem);
            }
        }

        private void OrderedView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (orderedView.SelectedItem != null)
            {
                string selectedItem = orderedView.SelectedItem as string;
                orderedBooks.Remove(selectedItem);
                unorderedBooks.Add(selectedItem);
            }
        }

        private void AcheivementsView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AcheivementsView.SelectedItem != null)
            {
                // Cast the selected item to your data type (AcheivementModels)
                AcheivementModels selectedItem = AcheivementsView.SelectedItem as AcheivementModels;

                if (selectedItem != null)
                {
                    MessageBox.Show($"Achievement Description: \n{selectedItem.AcheiveDescrip}");
                }
            }
        }

        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            timer.Stop();
            stopwatchTextBlock.Text = "00:00";

            stopwatch.Start();
            timer.Start();

            unorderedBooks.Clear();
            orderedBooks.Clear();
            generateStart = DateTime.Now;

            int num = 0;
            while (num < 10)
            {
                string tempDewey = generateBooks();
                if (!unorderedBooks.Contains(tempDewey))
                {
                    unorderedBooks.Add(tempDewey);
                    num++;
                }
            }


            buttonGenerate.IsEnabled = false;
            buttonCheck.IsEnabled = true;
        }


        private void buttonCheck_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            timer.Stop();

            int scoreCounter = 0;
            correctOrder = new ObservableCollection<string>(orderedBooks);
            int reportID = pr.GetReprot().Count;


            TimeSpan eTime = DateTime.Now - generateStart;
            double eSeconds = Math.Round(eTime.TotalSeconds, 2);

            for (int i = 0; i < correctOrder.Count; i++)
            {
                for (int j = i + 1; j < correctOrder.Count; j++)
                {
                    if (correctOrder[j].CompareTo(correctOrder[i]) < 0)
                    {
                        string temp = correctOrder[j];
                        correctOrder[j] = correctOrder[i];
                        correctOrder[i] = temp;
                    }
                }
            }

            //Gets the score of the user.
            for (int i = 0; i < orderedBooks.Count; i++)
            {

                if (orderedBooks[i] == correctOrder[i])
                {
                    scoreCounter++;
                }
            }

            //Generates the report for the user.
            if (scoreCounter == 10)
            {
                pr.GenerateReport(reportID + 1, eSeconds, true, scoreCounter);
                ach.checkForAcheievements(pr.GetReprot());

            }
            else
            {
                pr.GenerateReport(reportID + 1, eSeconds, false, scoreCounter);
                ach.checkForAcheievements(pr.GetReprot());
            }

            unorderedBooks.Clear();
            orderedBooks.Clear();
            buttonCheck.IsEnabled = false;
            buttonGenerate.IsEnabled = true;
        }



        public string generateBooks()
        {
            string ranDeweyNum = random.Next(1000).ToString("000");

            string ranAuther = generateAuther();

            return $"{ranDeweyNum}.{ranAuther}";

        }

        public string generateAuther()
        {
            string source = "ABCDEFGHIJKLMNOPRSTUVWXYZ";
            char[] ranChar = new char[3];

            for (int i = 0; i < 3; i++)
            {
                int ranIndex = random.Next(0, source.Length);
                ranChar[i] = source[ranIndex];
            }

            return new string(ranChar);
        }

        public int Compare(string other)
        {
            int results = this.ToString().CompareTo(other.ToString());

            return results;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = stopwatch.Elapsed;
            string formattedTime = string.Format("{0:00}:{1:00}", elapsed.Minutes, elapsed.Seconds);
            stopwatchTextBlock.Text = formattedTime;
        }


    }
}
