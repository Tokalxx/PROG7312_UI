using System.Collections.Generic;

namespace PROG7312_UI.Core
{
    public class UserHelp
    {
        private static readonly UserHelp instance = new UserHelp();
        private List<helpModel> helpList = new List<helpModel>();

        private UserHelp()
        {
            helpList.Add(new helpModel("Neutral Screen", "This will be the default page that will be displayed for you. It by itself has no interactive features.", "C:\\Users\\tokal\\Desktop\\ToBeBetter\\Learning Projects\\10. C# Tutorial Files\\3. ASP.NET\\PROG7312_UI\\Images\\0.PNG"));
            helpList.Add(new helpModel("Replacing Books", "By clicking on the 'Replacing Books' tabs, you can navigate to that page and use the features on that page.", "C:\\Users\\tokal\\Desktop\\ToBeBetter\\Learning Projects\\10. C# Tutorial Files\\3. ASP.NET\\PROG7312_UI\\Images\\1.PNG"));
            helpList.Add(new helpModel("Generate Random Books", "The button circled in red when clicked will generate random numbers for you that you will need to sort in acsending order. Be aware that the timer will start as soon as you click the button.", "C:\\Users\\tokal\\Desktop\\ToBeBetter\\Learning Projects\\10. C# Tutorial Files\\3. ASP.NET\\PROG7312_UI\\Images\\2.PNG"));
            helpList.Add(new helpModel("Move Items", "By double clicking on any of the items in the table you can move them between each other. ", "C:\\Users\\tokal\\Desktop\\ToBeBetter\\Learning Projects\\10. C# Tutorial Files\\3. ASP.NET\\PROG7312_UI\\Images\\3.PNG"));
            helpList.Add(new helpModel("Checking", "When you have completed your sorting, by clicking the check btton you can compare you sorted table with the correct order and see if you got any of it right.", "C:\\Users\\tokal\\Desktop\\ToBeBetter\\Learning Projects\\10. C# Tutorial Files\\3. ASP.NET\\PROG7312_UI\\Images\\4.PNG"));
            helpList.Add(new helpModel("Acheivements & Reports", "The acheivement report will be there to see the possible one you can unlock, and reports is there to see if you improve or not. For more details relating to the acheivements, double click on it.", "C:\\Users\\tokal\\Desktop\\ToBeBetter\\Learning Projects\\10. C# Tutorial Files\\3. ASP.NET\\PROG7312_UI\\Images\\5.PNG"));
        }

        public static UserHelp GetUserHelp()
        {
            return instance;
        }

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
