using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll {
    class Admin : Staff {
        private const int OvertimeHours = 160;
        private const double overtimeRate = 15.5;
        private const double adminHourlyRate = 30.0;
        public double OvertimePay { get; private set; }

        // Constructor, takes name and calls parent.
        public Admin(string name) : base(name, adminHourlyRate) { }


        public override void CalculatePay() {
            base.CalculatePay();
            TotalPay += HoursWorked > OvertimeHours ? overtimeRate * (HoursWorked - 160) : 0;
        }

        public override string ToString() {
            return base.ToString() + "Admin class";
        }
    }
}
