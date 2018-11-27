using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nikola_Nikolov_Employees
{
    class Program
    {
        static void FindBestTeam(List<ProjectData> Data)
        {
          
            ProjectData Emp1 = new ProjectData();
            ProjectData Emp2 = new ProjectData();
            TimeSpan BestTime = new TimeSpan();
            BestTime = TimeSpan.Zero;

            for (int i = 0; i < Data.Count; ++i)
            {
                for (int j = i + 1; j < Data.Count; j++)
                {
                    if (Data[i].IsOverlapping(Data[j])
                        && Data[i].OverlappingTime(Data[j]) > BestTime)
                    {
                        Emp1 = Data[i];
                        Emp2 = Data[j];
                        BestTime = Data[i].OverlappingTime(Data[j]);
                    }
                }
            }

            Emp1.Print();
            Emp2.Print();
            Console.WriteLine("Overlapping time: {0}", BestTime);
        }

        static List<ProjectData> ReadFile(string Input)
        {
            string[] TextData = System.IO.File.ReadAllLines(Input);
            List<ProjectData> Data = new List<ProjectData>();

            foreach (string Line in TextData)
            {
                ProjectData Entry = new ProjectData();
                string[] Words = Regex.Split(Line, ", ");

                Entry.EmployeeID = System.Convert.ToInt32(Words[0]);
                Entry.ProjectID = System.Convert.ToInt32(Words[1]);

                if (Words[2]!="NULL")
                {
                    Entry.DateFrom = DateTime.Parse(Words[2]);
                }
                else
                {
                    Entry.DateFrom = DateTime.Now;
                }

                if (Words[3] != "NULL")
                {
                    Entry.DateTo = DateTime.Parse(Words[3]);
                }
                else
                {
                    Entry.DateTo = DateTime.Now;
                }

                Data.Add(Entry);
            }

            return Data;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file:");
            string Input = Console.ReadLine();

            FindBestTeam(ReadFile(Input));
        }
    }
}
