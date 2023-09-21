using System;
using System.Collections.Generic;

namespace PROG7312_UI.Core
{
    public class ProgressReport
    {
        private static readonly ProgressReport _instance = new ProgressReport();
        private List<ReportModel> reprot = new List<ReportModel>();

        private ProgressReport()
        {

        }

        public static ProgressReport GetProgressReport()
        {
            return _instance;
        }

        //Might need to add more so that the reprot ids are not the same
        public void GenerateReport(int id, TimeSpan time, string score)
        {
            string reprotId = "RP." + id.ToString();
            reprot.Add(new ReportModel(reprotId, time, score));
        }

        public List<ReportModel> GetReprot()
        {
            return reprot;
        }
    }

    public class ReportModel
    {
        public string reprotID { get; set; }
        public TimeSpan endTime { get; set; }
        public string userScore { get; set; }

        public ReportModel(string id, TimeSpan time, string score)
        {
            reprotID = id;
            endTime = time;
            userScore = score;
        }
    }
}
