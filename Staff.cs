using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll {
    class Staff {

        private double _hourlyRate;
        private int _hWorked;
        public int HoursWorked {
            get { return _hWorked; }
            set { _hWorked = _hWorked > 0 ? value : 0; }
        }

        public double TotalPay { get; protected set; }
        public double BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public Staff(string name, double rate) {
            this.NameOfStaff = name;
            this._hourlyRate = rate;
        }

        public virtual void CalculatePay() {
            Console.WriteLine("Calculating pay...");
            BasicPay = HoursWorked * _hourlyRate;
        }

        public override string ToString() {
            return $"HoursWorked: {HoursWorked}\nName of staff: {NameOfStaff}";
        }
    }
}
