using System.Collections.Generic;

namespace PROG7312_UI.Core
{
    public class UserHelp
    {
        private static readonly UserHelp instance = new UserHelp();
        private List<helpModel> helpList = new List<helpModel>();

        private UserHelp()
        {
            helpList.Add(new helpModel("Neutral Screen", "This will be the default page that will be displayed for you. By itself it has no interactive features.", "\\Images\\0.PNG"));
            helpList.Add(new helpModel("Replacing Books", "By clicking on the 'Replacing Books' tabs, you can navigate to that page and use the features on that page.", "\\Images\\01.PNG"));
            helpList.Add(new helpModel("Generate Random Books", "The button circled in red when clicked will generate random numbers for you that you will need to sort in acsending order. Be aware that the timer will start as soon as you click the button.", "\\Images\\02.PNG"));
            helpList.Add(new helpModel("Move Items", "By double clicking on any of the items in the tables you can move them between each other. ", "\\Images\\03.PNG"));
            helpList.Add(new helpModel("Checking", "When you have completed your sorting, by clicking the check button you can compare your sorted table with the correct order and see if you got any of it right.", "\\Images\\04.PNG"));
            helpList.Add(new helpModel("Acheivements & Reports", "The acheivement table will be there to see the possible one you can unlock.. For more details relating to the acheivements, double click on it.", "\\Images\\05.PNG"));
            helpList.Add(new helpModel("Neutal Screen", "This will be the default page that will be displayed for you. By itself it has no interactive features.", "\\Images\\Identify\\01Home.PNG"));
            helpList.Add(new helpModel("Identify Area", "By clicking on the 'Identify Area' tabs, you can navigate to that page and use the features on that page.", "\\Images\\Identify\\02Base.PNG"));
            helpList.Add(new helpModel("Generate Items", "The Generate buttons when clicked will generate items on both panels for the user to match", "\\Images\\Identify\\03Generate.PNG"));
            helpList.Add(new helpModel("Answer Button", "After mactching all the items, by clicking the answer the score will appear.", "\\Images\\Identify\\04Answer.PNG"));
            helpList.Add(new helpModel("Clear Button", "If any items are match that you don't want, cliicking the clear button will clear the matches.", "\\Images\\Identify\\05Clear.PNG"));
            helpList.Add(new helpModel("Selecting Panel", "All items to the left panel must be matched to the correct item in the right panel.", "\\Images\\Identify\\06Select.PNG"));
            helpList.Add(new helpModel("Selected Items", "After matching the items it will be darked out so that it will not be selected again.", "\\Images\\Identify\\07SelectedItem.PNG"));
            helpList.Add(new helpModel("Right Items", "All right items will be green.", "\\Images\\Identify\\08Right.PNG"));
            helpList.Add(new helpModel("Wrong Items", "All wrong items will remain gray.", "\\Images\\Identify\\09Wrong.PNG"));
            helpList.Add(new helpModel("Prorgess Bar", "The progress bar will should the score to the game.", "\\Images\\Identify\\10ProgressBar.PNG"));
            helpList.Add(new helpModel("Report", "All attempts are record as a reprot.", "\\Images\\Identify\\11Report.PNG"));
            helpList.Add(new helpModel("Swapped Panel", "The Call Numbers and Description are swaaped to be matched.", "\\Images\\Identify\\12SwapedPanel.PNG"));
        }

        /// <summary>
        /// The GetAchievements method returns the created instance from the top of the class. 
        /// </summary>
        /// <returns>_instance</returns>
        public static UserHelp GetUserHelp()
        {
            return instance;
        }

        /// <summary>
        /// Method that will return the list to where it is being called
        /// </summary>
        /// <returns> List<helpModel>report helpList </returns>
        public List<helpModel> GetHelpList()
        {
            return helpList;
        }
    }

    public class helpModel
    {
        public string helpTitle { get; set; }
        public string helpDescription { get; set; }
        public string helpIamgePath { get; set; }

        public helpModel(string helpTitle, string helpDescription, string helpIamgePath)
        {
            this.helpTitle = helpTitle;
            this.helpDescription = helpDescription;
            this.helpIamgePath = helpIamgePath;
        }
    }
}
