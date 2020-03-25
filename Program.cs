using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll {
    class Program {
        static void Main(string[] args) {
            List<Staff> StaffList;
            FileReader fr = new FileReader();
            int year = GetInt("Enter valid year", 2020, 0);
            int month = GetInt("Enter valid month", 12, 1);

            // Get file and read contents into list.
            Console.WriteLine("Enter path of staff txt file: ");
            string path = Console.ReadLine();
            StaffList = fr.ReadFile(path);

            GetHoursWorked(StaffList);

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(StaffList);
            ps.PrintSummary(ps.GenerateSummary(StaffList));

            Console.ReadKey();   // Don't close console immediately
        }



        // Get hours worked for all staff.
        private static void GetHoursWorked(List<Staff> StaffList) {
            for (int i = 0; i < StaffList.Count; i++) {
                try {
                    Console.WriteLine($"Enter hours worked for {StaffList[i].HoursWorked}:  ");
                    StaffList[i].HoursWorked = int.Parse(Console.ReadLine());
                    StaffList[i].CalculatePay();
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                    Console.WriteLine("You have another chance.");
                    i--;
                }
            }
        }


        // Helper method to get input
        public static int GetInt(string msg, int upperBound, int lowerBound) {
            int result;
            string input;
            do {
                Console.WriteLine(msg);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out result) || !(result <= upperBound) || !(result >= lowerBound));
            return result;
        }
    }
}
