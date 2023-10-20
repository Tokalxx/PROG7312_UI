using PROG7312_UI.Core;
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
        Dictionary<string, string> checkDictionary = new Dictionary<string, string>();
        int TempNumScore = 0;

        public IdentifyAreaView()
        {
            InitializeComponent();
        }



        private void PopulateDesciptionTextBlock()
        {
            Dictionary<string, string> questionDic = GetUsableDictionary(idd.GetCallDefinition());
            Random ran = new Random();
            List<string> callNumbers = questionDic.Keys.ToList();
            List<string> calDescription = questionDic.Values.ToList();


            foreach (string x in callNumbers.OrderBy(x => ran.Next()))
            {
                TextBlock callTextBlock = new TextBlock
                {
                    Text = x,
                    Cursor = Cursors.Hand,
                    FontFamily = new FontFamily("Arial"),
                    FontSize = 20,
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(15),
                    TextAlignment = TextAlignment.Center,
                };
                callTextBlock.MouseLeftButtonDown += Call_MouseButtonClick;

                RightStackPanel.Children.Add(callTextBlock);

            }
            foreach (string x in calDescription.Take(4))
            {


                TextBlock definitionTextBlock = new TextBlock
                {
                    Text = x,
                    Cursor = Cursors.Hand,
                    FontFamily = new FontFamily("Arial"),
                    FontSize = 20,
                    Width = 400,
                    Height = 30,
                    Margin = new Thickness(15),
                    TextAlignment = TextAlignment.Center,
                };
                definitionTextBlock.MouseLeftButtonUp += Definition_MouseLeftButtonClick;

                LeftStackPanel.Children.Add(definitionTextBlock);
            }
        }
        private void PopulateCallNumberTextBlock()
        {
            Dictionary<string, string> questionDic = GetUsableDictionary(idd.GetCallDefinition());
            Random ran = new Random();
            List<string> callNumbers = questionDic.Keys.ToList();
            List<string> calDescription = questionDic.Values.ToList();


            foreach (string x in callNumbers.Take(4))
            {
                TextBlock callTextBlock = new TextBlock
                {
                    Text = x,
                    Cursor = Cursors.Hand,
                    FontFamily = new FontFamily("Arial"),
                    FontSize = 20,
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(15),
                    TextAlignment = TextAlignment.Center,
                };
                callTextBlock.MouseLeftButtonDown += Call_MouseButtonClick;

                LeftStackPanel.Children.Add(callTextBlock);

            }
            foreach (string x in calDescription.OrderBy(x => ran.Next()))
            {


                TextBlock definitionTextBlock = new TextBlock
                {
                    Text = x,
                    Cursor = Cursors.Hand,
                    FontFamily = new FontFamily("Arial"),
                    FontSize = 20,
                    Width = 400,
                    Height = 30,
                    Margin = new Thickness(15),
                    TextAlignment = TextAlignment.Center,
                };
                definitionTextBlock.MouseLeftButtonUp += Definition_MouseLeftButtonClick;

                RightStackPanel.Children.Add(definitionTextBlock);
            }
        }

        private TextBlock callNumberTextBlock = null;
        private void Call_MouseButtonClick(object sender, MouseButtonEventArgs e)
        {
            callNumberTextBlock = (TextBlock)sender;
            callNumberTextBlock.Background = Brushes.Yellow;
        }

        private void Definition_MouseLeftButtonClick(object sender, MouseButtonEventArgs e)
        {
            if (callNumberTextBlock != null)
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
                MessageBox.Show("Select Call Number First");
            }
        }

        private Dictionary<string, string> GetUsableDictionary(Dictionary<string, string> dic)
        {
            List<string> randomKeys = dic.Keys.OrderBy(x => Guid.NewGuid()).ToList();

            List<string> usedKeys = randomKeys.Take(7).ToList();

            Dictionary<string, string> usableDictionary = usedKeys.ToDictionary(key => key, key => dic[key]);

            return usableDictionary;
        }


        private void buttonAnswer_Click(object sender, RoutedEventArgs e)
        {
            foreach (KeyValuePair<string, string> x in checkDictionary)
            {
                foreach (KeyValuePair<string, string> y in idd.GetCallDefinition())
                {
                    if (x.Key == y.Key)
                    {
                        if (x.Value == y.Value)
                        {
                            ++TempNumScore;
                        }
                    }
                }
            }


            fillProgressBar(TempNumScore);
        }

        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            LeftStackPanel.Children.Clear();
            RightStackPanel.Children.Clear();
            checkDictionary.Clear();
            TempNumScore = 0;

            PopulateCallNumberTextBlock();
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

        public static void ShuffleArray<T>(T[] array)
        {
            Random random = new Random();
            int n = array.Length;

            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

    }
}
