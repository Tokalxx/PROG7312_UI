using PROG7312_UI.Core;
using PROG7312_UI.DesignGenerate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PROG7312_UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for IdentifyAreaView.xaml
    /// </summary>
    public partial class IdentifyAreaView : UserControl
    {

        IdentifyingDefinitions idd = IdentifyingDefinitions.GetDefinition();
        ProgressReport report = ProgressReport.GetProgressReport();
        IdentifyAreaDesign idDesign = new IdentifyAreaDesign();
        Dictionary<string, string> checkDictionary = new Dictionary<string, string>();
        private TextBlock callNumberTextBlock = null;
        bool checkGenerateMethod = true;
        Random ran = new Random();
        int TempNumScore = 0;
        bool checkbutton1 = true;

        public IdentifyAreaView()
        {
            InitializeComponent();

            ReportsListView.ItemsSource = report.GetReprotIA();
        }



        private void PopulateDesciptionTextBlock()
        {
            Dictionary<string, string> tempDictionary = idd.GetShuffledDictionary();

            List<string> callNumbers = tempDictionary.Keys.ToList();
            List<string> calDescription = tempDictionary.Values.ToList();


            foreach (string x in callNumbers.OrderBy(x => ran.Next()))
            {
                TextBlock callTextBlock = idDesign.CallNumberTextBlock(x);
                callTextBlock.MouseLeftButtonDown += Definition_MouseLeftButtonClick;

                RightStackPanel.Children.Add(callTextBlock);
            }

            foreach (string x in calDescription.Take(4))
            {


                TextBlock definitionTextBlock = idDesign.DefinitionTextBlock(x);
                definitionTextBlock.MouseLeftButtonUp += Call_MouseButtonClick;

                LeftStackPanel.Children.Add(definitionTextBlock);

            }
            idDesign.changeStackPanel(LeftStackPanel, RightStackPanel, checkGenerateMethod);

            checkGenerateMethod = true;
        }
        private void PopulateCallNumberTextBlock()
        {

            Dictionary<string, string> tempDictionary = idd.GetShuffledDictionary();

            List<string> callNumbers = tempDictionary.Keys.ToList();
            List<string> calDescription = tempDictionary.Values.ToList();


            foreach (string x in callNumbers.Take(4))
            {
                TextBlock callTextBlock = idDesign.CallNumberTextBlock(x);
                callTextBlock.MouseLeftButtonDown += Call_MouseButtonClick;

                LeftStackPanel.Children.Add(callTextBlock);


            }
            foreach (string x in calDescription.OrderBy(x => ran.Next()))
            {


                TextBlock definitionTextBlock = idDesign.DefinitionTextBlock(x);
                definitionTextBlock.MouseLeftButtonUp += Definition_MouseLeftButtonClick;

                RightStackPanel.Children.Add(definitionTextBlock);

            }

            idDesign.changeStackPanel(LeftStackPanel, RightStackPanel, checkGenerateMethod);
            checkGenerateMethod = false;
        }


        private void Call_MouseButtonClick(object sender, MouseButtonEventArgs e)
        {
            callNumberTextBlock = (TextBlock)sender;
            callNumberTextBlock.Background = Brushes.Yellow;
        }

        private void Definition_MouseLeftButtonClick(object sender, MouseButtonEventArgs e)
        {
            if (callNumberTextBlock != null)
            {


                if (!checkGenerateMethod)
                {
                    TextBlock descriptTextBlock = (TextBlock)sender;
                    checkDictionary.Add(callNumberTextBlock.Text, descriptTextBlock.Text);
                    callNumberTextBlock.Background = Brushes.Gray;
                    callNumberTextBlock.IsHitTestVisible = false;
                    descriptTextBlock.Background = Brushes.Gray;
                    descriptTextBlock.IsHitTestVisible = false;

                    callNumberTextBlock = null;
                }
                else
                {
                    TextBlock descriptTextBlock = (TextBlock)sender;
                    checkDictionary.Add(descriptTextBlock.Text, callNumberTextBlock.Text);
                    callNumberTextBlock.Background = Brushes.Gray;
                    callNumberTextBlock.IsHitTestVisible = false;
                    descriptTextBlock.Background = Brushes.Gray;
                    descriptTextBlock.IsHitTestVisible = false;

                    callNumberTextBlock = null;
                }
            }
            else
            {
                MessageBox.Show("Select Call Number First");
            }
        }



        private void buttonAnswer_Click(object sender, RoutedEventArgs e)
        {
            buttonAnswer.IsEnabled = false;
            buttonClear.IsEnabled = false;
            buttonGenerate.IsEnabled = true;

            foreach (KeyValuePair<string, string> x in idd.GetDeweyDictionary())
            {
                if (checkDictionary.TryGetValue(x.Key, out string area))
                {
                    if (x.Value.Equals(area))
                    {
                        foreach (TextBlock tb in LeftStackPanel.Children)
                        {
                            if (tb.Text == x.Key || tb.Text == x.Value)
                            {
                                tb.Background = Brushes.LimeGreen;
                            }
                        }
                        TempNumScore++;
                    }
                }
            }


            bool status = false;
            if (TempNumScore >= 3)
            {
                status = true;
            }
            fillProgressBar(TempNumScore);
            report.GenerateIA(status, TempNumScore);
        }

        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            LeftStackPanel.Children.Clear();
            RightStackPanel.Children.Clear();
            checkDictionary.Clear();
            progressBarResults.Value = 0;
            textBlockScore.Text = "";
            buttonAnswer.IsEnabled = true;
            buttonClear.IsEnabled = true;
            buttonGenerate.IsEnabled = false;
            TempNumScore = 0;

            if (checkGenerateMethod)
            {
                PopulateCallNumberTextBlock();
            }
            else
            {
                PopulateDesciptionTextBlock();
            }

        }

        public void fillProgressBar(int score)
        {
            switch (score)
            {
                case 1:
                    progressBarResults.Value = 25;
                    progressBarResults.Foreground = Brushes.Red;
                    textBlockScore.Text = "25%";
                    break;
                case 2:
                    progressBarResults.Value = 50;
                    progressBarResults.Foreground = Brushes.Orange;
                    textBlockScore.Text = "50%";
                    break;
                case 3:
                    progressBarResults.Value = 75;
                    progressBarResults.Foreground = Brushes.Yellow;
                    textBlockScore.Text = "75%";
                    break;
                case 4:
                    progressBarResults.Value = 100;
                    progressBarResults.Foreground = Brushes.Green;
                    textBlockScore.Text = "100%";
                    break;
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            checkDictionary.Clear();
            foreach (TextBlock x in LeftStackPanel.Children)
            {
                x.Background = Brushes.Transparent;
                x.IsHitTestVisible = true;
            }
            foreach (TextBlock x in RightStackPanel.Children)
            {
                x.Background = Brushes.Transparent;
                x.IsHitTestVisible = true;
            }
        }
    }
}
