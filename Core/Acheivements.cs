using System;
using System.Collections.Generic;

namespace PROG7312_UI.Core
{
    public class Acheivements
    {
        private static readonly Acheivements _instance = new Acheivements();
        TimeSpan timeCheckAcheivement1 = TimeSpan.FromSeconds(15);
        private List<AcheivementModels> acheivements = new List<AcheivementModels>();

        private Acheivements()
        {
            acheivements.Add(new AcheivementModels("Ach.001", "Faster Then Before", "Get a pass with a time of 15 seconds or less", false));
            acheivements.Add(new AcheivementModels("Ach.002", "Master 1 Kick", "Get 5 passes", false));
            acheivements.Add(new AcheivementModels("Ach.003", "Strick, Your Out!!!", "Get three passes in a row", false));
        }

        public static Acheivements GetAcheivements()
        {
            return _instance;
        }

        public void checkForAcheievements(List<ReportModel> list)
        {
            if (checkAcheivement1(list))
            {

            }
        }

        public bool checkAcheivement1(List<ReportModel> list)
        {
            foreach (ReportModel x in list)
            {
                if (x.endTime < timeCheckAcheivement1)
                {
                    acheivements[0].lockStatus = true;
                }
            }
            return false;
        }


    }

    public class AcheivementModels
    {


        public string acheiveId { get; set; }
        public string achieveName { get; set; }
        public string acheiveDescrip { get; set; }
        public bool lockStatus { get; set; }
        public AcheivementModels(string acheiveId, string achieveName, string acheiveDescrip, bool lockStatus)
        {
            this.acheiveId = acheiveId;
            this.achieveName = achieveName;
            this.acheiveDescrip = acheiveDescrip;
            this.lockStatus = lockStatus;
        }

    }
}
