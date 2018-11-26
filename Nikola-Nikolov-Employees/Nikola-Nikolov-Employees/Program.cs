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
        static void BestTeam(List<ProjectData> Data)
        {

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

            foreach (ProjectData item in Data)
            {
                item.Print();
            }

            Data.Sort((x, y) => x.ProjectID.CompareTo(y.ProjectID));

            return Data;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file:");
            string Input = Console.ReadLine();

            BestTeam(ReadFile(Input));
        }
    }
}
