using PROG7312_UI.Core;
using PROG7312_UI.DataTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace PROG7312_UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for FindingCallNumbersView.xaml
    /// </summary>
    public partial class FindingCallNumbersView : UserControl
    {
        List<RadioButton> multipleQuestion = new List<RadioButton>();
        FindingCallNumber cnObject = FindingCallNumber.GetInstance();
        CallNumberNode answerLevel3;
        CallNumberTree treeObject;
        static CallNumberNode answerValue;
        CallNumberNode callNum = null;
        bool check1 = true;
        int Level = 1;
        Random ran = new Random();


        public FindingCallNumbersView()
        {
            InitializeComponent();
            treeObject = cnObject.GetTree();

        }

        private void buttonAnswer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string answer2 = answerLevel3.Parent.Num + " " + answerLevel3.Parent.Des;
            string answer3 = answerLevel3.Parent.Parent.Num + " " + answerLevel3.Parent.Parent.Des;
            textBlockQuestion.Text = answerLevel3.Des;

            if (Level == 2)
            {
                foreach (RadioButton x in stackPanelMultiChoice.Children)
                {
                    if (x.IsChecked == true)
                    {
                        if (x.Content.ToString() == answer3)
                        {
                            cnObject.setScoreCounter(2);
                            textBlockScore.Text = cnObject.getScoreCounter().ToString();
                            textBlockCorrectAnswer.Text = "";
                            generateCallNumbers();
                        }
                        else
                        {

                            textBlockCorrectAnswer.Text = answer3;
                            Level = 1;
                            generateCallNumbers();

                        }
                    }
                }
            }
            else if (Level == 1)
            {
                foreach (RadioButton x in stackPanelMultiChoice.Children)
                {
                    if (x.IsChecked == true)
                    {
                        if (x.Content.ToString() == answer2)
                        {
                            cnObject.setScoreCounter(2);
                            textBlockScore.Text = cnObject.getScoreCounter().ToString();
                            textBlockCorrectAnswer.Text = "";
                            generateCallNumbers();
                        }
                        else
                        {

                            textBlockCorrectAnswer.Text = answer2;
                            Level = 1;
                            generateCallNumbers();
                        }
                    }
                }
            }
        }



        private void buttonGen_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            generateCallNumbers();
        }

        public void getCallNumnberAnswer()
        {
            answerLevel3 = treeObject.Root.Children[ran.Next(0, 10)].Children[ran.Next(0, 10)].Children[ran.Next(0, 9)];

            if (answerLevel3.Des.Contains(" [Unassigned]") || answerLevel3.Des.Contains(" (Optional number)"))
            {
                getCallNumnberAnswer();
            }
        }


        public void generateCallNumbers()
        {
            if (Level == 1)
            {
                getCallNumnberAnswer();
                textBlockRootQuestion.Text = answerLevel3.Num + " " + answerLevel3.Des;

                List<CallNumberNode> tempList = cnObject.genQuestion1(answerLevel3);

                List<CallNumberNode> level1List = tempList.OrderBy(x => ran.Next()).ToList();

                for (int i = 0; i < level1List.Count; ++i)
                {
                    ((RadioButton)stackPanelMultiChoice.Children[i]).Content = level1List[i].Num + " " + level1List[i].Des;
                }

                Level++;
            }
            else if (Level == 2)
            {
                List<CallNumberNode> tempList = cnObject.genQuestion2(answerLevel3);

                List<CallNumberNode> level2List = tempList.OrderBy(x => ran.Next()).ToList();


                for (int i = 0; i < level2List.Count; ++i)
                {
                    ((RadioButton)stackPanelMultiChoice.Children[i]).Content = level2List[i].Num + " " + level2List[i].Des;
                }

                Level = 1;
            }
        }

    }
}
