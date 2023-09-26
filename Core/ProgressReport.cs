using System.Collections.ObjectModel;

namespace PROG7312_UI.Core
{
    public class ProgressReport
    {
        private static readonly ProgressReport _instance = new ProgressReport();
        private ObservableCollection<ReportModel> reprot = new ObservableCollection<ReportModel>();

        private ProgressReport()
        {

        }

        public static ProgressReport GetProgressReport()
        {
            return _instance;
        }

        //Might need to add more so that the reprot ids are not the same
        public void GenerateReport(int id, double time, bool status, int score)
        {
            string reprotId = "RP." + id.ToString();
            reprot.Add(new ReportModel(reprotId, time, status, score));
        }

        public ObservableCollection<ReportModel> GetReprot()
        {
            return reprot;
        }
    }

    public class ReportModel
    {
        public string reprotID { get; set; }
        public double endTime { get; set; }
        public bool attemptStatus { get; set; }
        public int userScore { get; set; }

        public ReportModel(string id, double time, bool status, int score)
        {
            reprotID = id;
            endTime = time;
            attemptStatus = status;
            userScore = score;
        }
    }
}
