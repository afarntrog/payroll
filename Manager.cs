using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll {
    class Manager : Staff {
        private const double managerHourlyRate = 50.0;
        private const int OverTime = 160;
        public int Allowance { get; private set; }

        public Manager(string name) : base(name, managerHourlyRate) {
            // Empty, just calls parent
        }

        public override void CalculatePay() {
            base.CalculatePay(); // calculate the  pay and sets the necessary values
            Allowance = 1000;
            TotalPay += HoursWorked > OverTime ? Allowance : 0;
        }

        public override string ToString() {
            return $"{base.ToString()}\nAllowance: {Allowance}";
        }
    }
}
