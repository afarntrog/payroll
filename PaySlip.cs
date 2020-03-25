using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll {
    class PaySlip {

        private int month;
        private int year;

        // Is private by default inside class.
        enum MonthsOfYear {
            JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }

        public PaySlip(int payMonth, int payYear) {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> staffList) {
            string path;
            foreach (Staff staff in staffList) {
                path = $"{staff.NameOfStaff}.txt";

                // Generate/print Payslip for admin/manager
                using (StreamWriter sw = new StreamWriter(path)) {
                    sw.WriteLine($"PAYSLIP FOR {month} {year}");
                    sw.WriteLine("=============================");
                    sw.WriteLine($"Name of Staff: {staff.NameOfStaff}");
                    sw.WriteLine($"Hours Worked: {staff.HoursWorked}");
                    sw.WriteLine($"Basic Pay: ${staff.BasicPay}");
                    sw.WriteLine($" {(staff is Manager ? $"Allowance : ${((Manager)staff).Allowance}" : $"Overtime Pay: ${((Admin)staff).OvertimePay}")}");
                    sw.WriteLine("=============================");
                    sw.WriteLine($"Total Pay: {staff.TotalPay}");
                    sw.WriteLine("=============================");
                    sw.Close();
                }
            }
        }

        public StringBuilder GenerateSummary(List<Staff> staffList) {
            StringBuilder sb = new StringBuilder();
            // staff worked less than 10 hours, LINQ Extensions/lambdas
            var staff = staffList.Where(s => s.HoursWorked < 10).Select(s => new { s.NameOfStaff, s.HoursWorked }).OrderBy(s => s.NameOfStaff);
            sb.AppendLine("Staff with less than 10 working hours\n");
            foreach (var s in staff)
                sb.AppendLine($"Name of staff member: {s.NameOfStaff}, Hours Worked: {s.HoursWorked}");
            return sb;
        }

        public void PrintSummary(StringBuilder sb) {
            string path = "summary.txt";
            using (StreamWriter sw = new StreamWriter(path)) {
                   sw.WriteLine(sb.ToString());
                sw.Close();
            }
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
