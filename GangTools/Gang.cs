using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GangTools
{
    public class Gang
    {

        public string GangLeader { get; set; }
        public DateTime FirstDateTimeStart { get; set; }
        public DateTime CurrentDateTimeStart { get; set; }

        public DateTime FirstDateTimeEnd
        {
            get
            {

                return FirstDateTimeStart.AddHours(12);
            }
            private set
            {
                ;
            }
        }

        public DateTime StepBackwardStart
        {
            get
            {
                switch (CurrentDateTimeStart.Hour)
                {
                    case 8:
                        return CurrentDateTimeStart.AddHours(-60);
                    case 20:
                        return CurrentDateTimeStart.AddHours(-36);
                }
                return CurrentDateTimeStart;
            }
            private set
            {
                ;
            }
        }

        public DateTime StepBackwardEnd
        {
            get
            {
                return StepBackwardStart.AddHours(12);
            }
            private set
            {
                ;
            }
        }

        public DateTime StepForward
        {
            get
            {
                switch (CurrentDateTimeStart.Hour)
                {
                    case 8:
                        return CurrentDateTimeStart.AddHours(36);
                    case 20:
                        return CurrentDateTimeStart.AddHours(60);
                }
                return CurrentDateTimeStart;
            }
            private set
            {
                ;
            }
        }

        public int CountOfShfts { get; private set; }

        public void addOneShiftPre()
        {
            switch (CurrentDateTimeStart.Hour)
            {
                case 8:
                    CurrentDateTimeStart = CurrentDateTimeStart.AddHours(36);
                    break;
                case 20:
                    CurrentDateTimeStart = CurrentDateTimeStart.AddHours(60);
                    break;
                default:
                    break;
            }
        }

        public void addOneShift()
        {
            switch (CurrentDateTimeStart.Hour)
            {
                    //если 8 утра, прибавляем 36 часов до начала следующей смены
                case 8:
                    CurrentDateTimeStart = CurrentDateTimeStart.AddHours(36);
                    CountOfShfts++;
                    break;
                //если 20 вечера, прибавляем 60 часов до начала следующей смены
                case 20:
                    CurrentDateTimeStart = CurrentDateTimeStart.AddHours(60);
                    CountOfShfts++;
                    break;
                default:
                    break;
            }
        }

    }
}
