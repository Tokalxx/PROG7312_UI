using System;
using System.Windows;
using System.Windows.Controls;

namespace PROG7312_UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for ReplacingBooksView.xaml
    /// </summary>
    public partial class ReplacingBooksView : UserControl
    {
        public ReplacingBooksView()
        {
            InitializeComponent();
        }
        Random ran = new Random();
        int[] arr1 = new int[10];
        int[] arr2 = new int[10];

        //This works
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {

            int num1 = ran.Next(1, 10);
            int num2 = ran.Next(1, 10);
            int num3 = ran.Next(1, 10);
            int num4 = ran.Next(1, 10);
            int num5 = ran.Next(1, 10);
            int num6 = ran.Next(1, 10);
            int num7 = ran.Next(1, 10);
            int num8 = ran.Next(1, 10);
            int num9 = ran.Next(1, 10);
            int num10 = ran.Next(1, 10);

            arr1[0] = num1;
            arr1[1] = num2;
            arr1[2] = num3;
            arr1[3] = num4;
            arr1[4] = num5;
            arr1[5] = num6;
            arr1[6] = num7;
            arr1[7] = num8;
            arr1[8] = num9;
            arr1[9] = num10;

            tbUnordered1.Text = num1.ToString();
            tbUnordered2.Text = num2.ToString();
            tbUnordered3.Text = num3.ToString();
            tbUnordered4.Text = num4.ToString();
            tbUnordered5.Text = num5.ToString();
            tbUnordered6.Text = num6.ToString();
            tbUnordered7.Text = num7.ToString();
            tbUnordered8.Text = num8.ToString();
            tbUnordered9.Text = num9.ToString();
            tbUnordered10.Text = num10.ToString();

            tbUserOrder1.Clear();
            tbUserOrder2.Clear();
            tbUserOrder3.Clear();
            tbUserOrder4.Clear();
            tbUserOrder5.Clear();
            tbUserOrder6.Clear();
            tbUserOrder7.Clear();
            tbUserOrder8.Clear();
            tbUserOrder9.Clear();
            tbUserOrder10.Clear();

        }


        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            sortMethod(arr1);
            bool check = true;

            tbOrdered1.Text = arr1[0].ToString();
            tbOrdered2.Text = arr1[1].ToString();
            tbOrdered3.Text = arr1[2].ToString();
            tbOrdered4.Text = arr1[3].ToString();
            tbOrdered5.Text = arr1[4].ToString();
            tbOrdered6.Text = arr1[5].ToString();
            tbOrdered7.Text = arr1[6].ToString();
            tbOrdered8.Text = arr1[7].ToString();
            tbOrdered9.Text = arr1[8].ToString();
            tbOrdered10.Text = arr1[9].ToString();

            arr2[0] = Convert.ToInt32(tbUserOrder1.Text);
            arr2[1] = Convert.ToInt32(tbUserOrder2.Text);
            arr2[2] = Convert.ToInt32(tbUserOrder3.Text);
            arr2[3] = Convert.ToInt32(tbUserOrder4.Text);
            arr2[4] = Convert.ToInt32(tbUserOrder5.Text);
            arr2[5] = Convert.ToInt32(tbUserOrder6.Text);
            arr2[6] = Convert.ToInt32(tbUserOrder7.Text);
            arr2[7] = Convert.ToInt32(tbUserOrder8.Text);
            arr2[8] = Convert.ToInt32(tbUserOrder9.Text);
            arr2[9] = Convert.ToInt32(tbUserOrder10.Text);



            Console.WriteLine();

            for (int j = 0; j < arr1.Length; j++)
            {
                if (arr1[j] == arr2[j])
                {
                    check = true;
                }
                else
                {
                    check = false;
                    break;
                }
            }

            if (check == false)
            {
                MessageBox.Show("Fail");
            }
            else
            {
                MessageBox.Show("Correct");
            }

        }

        public static void sortMethod(int[] array)
        {
            for (int x = 0; x < array.Length - 1; x++)
            {
                for (int y = 0; y < array.Length - x - 1; y++)
                {
                    if (array[y] > array[y + 1])
                    {
                        int tempValue = array[y];
                        array[y] = array[y + 1];
                        array[y + 1] = tempValue;
                    }
                }
            }
        }
    }
}
