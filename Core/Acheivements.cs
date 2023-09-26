using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace PROG7312_UI.Core
{
    public class Acheivements
    {
        private static readonly Acheivements _instance = new Acheivements();
        TimeSpan timeCheckAcheivement1 = TimeSpan.FromSeconds(55);
        private ObservableCollection<AcheivementModels> acheivements = new ObservableCollection<AcheivementModels>();

        private Acheivements()
        {
            acheivements.Add(new AcheivementModels("Ach.001", "Faster Then Before", "Get a pass with a time of 15 seconds or less", "Locked"));
            acheivements.Add(new AcheivementModels("Ach.002", "Master 1 Kick", "Get 5 passes", "Locked"));
            acheivements.Add(new AcheivementModels("Ach.003", "Strick, Your Out!!!", "Get three passes in a row", "Locked"));
        }

        public static Acheivements GetAcheivements()
        {
            return _instance;
        }

        public ObservableCollection<AcheivementModels> GetAcheivementsList()
        {
            return acheivements;
        }

        public void checkForAcheievements(ObservableCollection<ReportModel> list)
        {


            if (acheivements[0].LockStatus.ToLower() == "locked" && checkAcheivement1(list))
            {
                MessageBox.Show("Acheivement 1 Unlocked");
            }

            if (acheivements[1].LockStatus.ToLower() == "locked" && checkAcheivement2(list))
            {
                MessageBox.Show("Acheivement 2 Unlocked");

            }
            if (acheivements[2].LockStatus.ToLower() == "locked" && checkAcheivement3(list))
            {
                MessageBox.Show("Acheivement 3 Unlocked");

            }
        }

        public bool checkAcheivement1(ObservableCollection<ReportModel> list)
        {
            foreach (ReportModel x in list)
            {
                if (x.endTime < timeCheckAcheivement1.TotalSeconds && x.attemptStatus == true)
                {

                    acheivements[0].LockStatus = "Unlocked";
                    return true;
                }
            }
            return false;
        }

        public bool checkAcheivement2(ObservableCollection<ReportModel> list)
        {
            int num = 0;

            foreach (ReportModel x in list)
            {
                if (x.attemptStatus)
                {
                    num++;
                }
            }

            if (num >= 5)
            {
                acheivements[1].LockStatus = "Unlocked";
                return true;
            }
            return false;
        }

        public bool checkAcheivement3(ObservableCollection<ReportModel> list)
        {
            int num = 0;

            foreach (ReportModel x in list)
            {
                if (x.attemptStatus)
                {
                    num++;
                }
                else
                {
                    num = 0;
                }
            }

            if (num >= 3)
            {
                acheivements[2].LockStatus = "Unlocked";
                return true;
            }
            else
            {
                num = 0;
            }

            return false;
        }


    }

    public class AcheivementModels : INotifyPropertyChanged
    {
        private string acheiveId;
        private string achieveName;
        private string acheiveDescrip;
        private string lockStatus;

        public string AcheiveId
        {
            get { return acheiveId; }
            set
            {
                if (acheiveId != value)
                {
                    acheiveId = value;
                    OnPropertyChanged(nameof(AcheiveId));
                }
            }
        }

        public string AchieveName
        {
            get { return achieveName; }
            set
            {
                if (achieveName != value)
                {
                    achieveName = value;
                    OnPropertyChanged(nameof(AchieveName));
                }
            }
        }

        public string AcheiveDescrip
        {
            get { return acheiveDescrip; }
            set
            {
                if (acheiveDescrip != value)
                {
                    acheiveDescrip = value;
                    OnPropertyChanged(nameof(AcheiveDescrip));
                }
            }
        }

        public string LockStatus
        {
            get { return lockStatus; }
            set
            {
                if (lockStatus != value)
                {
                    lockStatus = value;
                    OnPropertyChanged(nameof(LockStatus));
                }
            }
        }

        public AcheivementModels(string acheiveId, string achieveName, string acheiveDescrip, string lockStatus)
        {
            this.AcheiveId = acheiveId;
            this.AchieveName = achieveName;
            this.AcheiveDescrip = acheiveDescrip;
            this.LockStatus = lockStatus;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
