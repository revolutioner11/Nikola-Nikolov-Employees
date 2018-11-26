using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikola_Nikolov_Employees
{
    class ProjectData
    {
        public ProjectData()
        {
            EmployeeID = 0;
            ProjectID = 0;
            DateFrom = default(DateTime);
            DateTo = default(DateTime);
            TimeElapsed = TimeSpan.Zero;
        }
        public ProjectData(int EmployeeID, int ProjectID, DateTime DateFrom, DateTime DateTo)
        {
            this.EmployeeID = EmployeeID;
            this.ProjectID = ProjectID;
            this.DateFrom = DateFrom;
            this.DateTo = DateTo;
            CalculateTimeElapsed();
        }

        public void Print()
        {
            Console.WriteLine("{0}, {1}, from {2} to {3}, time: {4}",
                EmployeeID, ProjectID, DateFrom, DateTo, TimeElapsed);
        }
        private void CalculateTimeElapsed()
        {
            timeElapsed = dateTo - dateFrom;
        }
        public bool IsOverlapping(ProjectData OtherData)
        {
            if (this.ProjectID != OtherData.ProjectID)
            {
                return false;
            }

            if (this.DateFrom <= OtherData.DateTo 
                && this.DateTo >= OtherData.DateFrom)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public TimeSpan OverlappingTime(ProjectData OtherData)
        {
            DateTime Beginning;
            DateTime End;

            if (this.DateFrom > OtherData.DateFrom)
            {
                Beginning = this.DateFrom;
            }
            else
            {
                Beginning = OtherData.DateFrom;
            }

            if (this.DateTo < OtherData.DateTo)
            {
                End = this.DateTo;
            }
            else
            {
                End = OtherData.DateTo;
            }

            return End - Beginning;
        }

        private int employeeID;
        private int projectID;
        private DateTime dateFrom;
        private DateTime dateTo;
        private TimeSpan timeElapsed;

        public int EmployeeID
        {
            get
            {
                return employeeID;
            }

            set
            {
                employeeID = value;
            }
        }
        public int ProjectID
        {
            get
            {
                return projectID;
            }

            set
            {
                projectID = value;
            }
        }
        public DateTime DateFrom
        {
            get
            {
                return dateFrom;
            }

            set
            {
                dateFrom = value;
                CalculateTimeElapsed();
            }
        }
        public DateTime DateTo
        {
            get
            {
                return dateTo;
            }

            set
            {
                dateTo = value;
                CalculateTimeElapsed();
            }
        }
        public TimeSpan TimeElapsed
        {
            get
            {
                return timeElapsed;
            }

            set
            {
                timeElapsed = value;
            }
        }
    }
}
