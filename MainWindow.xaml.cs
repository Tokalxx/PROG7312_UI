using PROG7312_UI.Core;
using System.Windows;

namespace PROG7312_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProgressReport rp = ProgressReport.GetProgressReport();
        Acheivements ach = Acheivements.GetAcheivements();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonReport_Click(object sender, RoutedEventArgs e)
        {
            foreach (var x in rp.GetReprot())
            {
                MessageBox.Show($"{x.reprotID}{x.endTime}{x.userScore}");
            }
        }

        private void buttonAcheivement_Click(object sender, RoutedEventArgs e)
        {
            ach.checkForAcheievements(rp.GetReprot());
        }
    }
}
