using PROG7312_UI.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PROG7312_UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : UserControl
    {
        UserHelp uh = UserHelp.GetUserHelp();
        int imageNumber = 0;

        public HelpView()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (imageNumber > 0)
                {
                    imageNumber--;
                    buttonNext.IsEnabled = true;
                    string imagePath = uh.GetHelpList()[imageNumber].helpIamgePath;
                    Uri imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
                    BitmapImage bitmapImage = new BitmapImage(imageUri);

                    imageHelp.Source = bitmapImage;
                    textBlockHelpTitle.Text = uh.GetHelpList()[imageNumber].helpTitle;
                    textBlockHelpDescription.Text = uh.GetHelpList()[imageNumber].helpDescription;



                    imageHelp.InvalidateVisual();
                }
                else
                {
                    buttonBack.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        private void buttonNext_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (imageNumber < 5)
                {
                    imageNumber++;
                    buttonBack.IsEnabled = true;
                    string imagePath = uh.GetHelpList()[imageNumber].helpIamgePath;
                    Uri imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
                    BitmapImage bitmapImage = new BitmapImage(imageUri);

                    imageHelp.Source = bitmapImage;
                    textBlockHelpTitle.Text = uh.GetHelpList()[imageNumber].helpTitle;
                    textBlockHelpDescription.Text = uh.GetHelpList()[imageNumber].helpDescription;


                    imageHelp.InvalidateVisual();
                }
                else
                {
                    buttonNext.IsEnabled = false;
                }

                if (imageNumber == 5)
                {
                    buttonNext.IsEnabled = false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}