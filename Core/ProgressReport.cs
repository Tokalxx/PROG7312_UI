using System.Collections.ObjectModel;

namespace PROG7312_UI.Core
{
    public class ProgressReport
    {
        private static readonly ProgressReport _instance = new ProgressReport();
        private ObservableCollection<ReportRBModel> reportRB = new ObservableCollection<ReportRBModel>();
        private ObservableCollection<ReportIAModel> reportIA = new ObservableCollection<ReportIAModel>();

        private ProgressReport()
        {

        }

        /// <summary>
        /// The GetAchievements method returns the created instance from the top of the class. 
        /// </summary>
        /// <returns>_instance</returns>
        public static ProgressReport GetProgressReport()
        {
            return _instance;
        }

        //Might need to add more so that the reprot ids are not the same

        /// <summary>
        /// Generates the report of the players score and saves that information
        /// </summary>
        /// <param name="id"></param>Report ID
        /// <param name="time"></param> Time it took the player to complete the game
        /// <param name="status"></param> Status of the report to see if the player passed or not
        /// <param name="score"></param> The player's score
        public void GenerateReport(int id, double time, bool status, int score)
        {
            string reprotId = "RP." + id.ToString();
            reportRB.Add(new ReportRBModel(reprotId, time, status, score));
        }

        public void GenerateIA(int id, bool status, string score)
        {

        }

        /// <summary>
        /// Method that will return the list to where it is being called
        /// </summary>
        /// <returns> ObservableCollection<ReportModel> report </returns>
        public ObservableCollection<ReportRBModel> GetReprot()
        {
            return reportRB;
        }
    }

    public class ReportRBModel
    {
        public string reprotID { get; set; }
        public double endTime { get; set; }
        public bool attemptStatus { get; set; }
        public int userScore { get; set; }

        public ReportRBModel(string id, double time, bool status, int score)
        {
            reprotID = id;
            endTime = time;
            attemptStatus = status;
            userScore = score;
        }
    }

    public class ReportIAModel
    {
        public string reprotID { get; set; }
        public bool attemptStatus { get; set; }
        public int userScore { get; set; }

        public ReportIAModel(string reprotID, bool attemptStatus, int userScore)
        {
            this.reprotID = reprotID;
            this.attemptStatus = attemptStatus;
            this.userScore = userScore;
        }
    }
}
