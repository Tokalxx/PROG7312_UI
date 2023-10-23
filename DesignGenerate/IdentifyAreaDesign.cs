using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PROG7312_UI.DesignGenerate
{
    public class IdentifyAreaDesign
    {
        public TextBlock CallNumberTextBlock(string x)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = x,
                Cursor = Cursors.Hand,
                FontFamily = new FontFamily("Arial"),
                FontSize = 20,
                Width = 100,
                Height = 35,
                Margin = new Thickness(5),
                TextAlignment = TextAlignment.Center,
            };
            return textBlock;
        }

        public TextBlock DefinitionTextBlock(string x)
        {
            TextBlock textBlock = new TextBlock()
            {

                Text = x,
                Cursor = Cursors.Hand,
                FontFamily = new FontFamily("Arial"),
                FontSize = 20,
                Width = 400,
                Height = 35,
                Margin = new Thickness(5),
                TextAlignment = TextAlignment.Center,
            };

            return textBlock;
        }

        public void changeStackPanel(StackPanel stack1, StackPanel stack2, bool check)
        {
            if (check)
            {
                stack1.Width = 100;

                stack2.Width = 500;
            }
            else
            {
                stack1.Width = 500;

                stack2.Width = 100;
            }
        }
    }
}
