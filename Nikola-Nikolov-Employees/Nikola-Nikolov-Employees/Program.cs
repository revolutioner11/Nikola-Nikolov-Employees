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
        static void BestTeam()
        {

        }

        static void ReadFile(string Input)
        {
            string[] TextData = System.IO.File.ReadAllLines(Input);
            SortedList<int, ProjectData> Data = new SortedList<int, ProjectData>();
            ProjectData Entry = new ProjectData();

            foreach (string Line in TextData)
            {
                string[] Words = Regex.Split(Line, ", ");
                Entry.EmployeeID = System.Convert.ToInt32(Words[0]);
                Entry.ProjectID = System.Convert.ToInt32(Words[1]);
                if (Words[2]!="NULL")
                {
                    Entry.DateFrom = DateTime.ParseExact(Words[2], "d", null);
                }
                else
                {
                    Entry.DateFrom = DateTime.Now;
                }

                if (Words[3] != "NULL")
                {
                    Entry.DateTo = DateTime.ParseExact(Words[3], "d", null);
                }
                else
                {
                    Entry.DateTo = DateTime.Now;
                }

                Entry.Print();
                Console.WriteLine();
            }

          
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file:");
            string Input = Console.ReadLine();
            Console.WriteLine(Input);
            ReadFile(Input);
        }
    }
}
