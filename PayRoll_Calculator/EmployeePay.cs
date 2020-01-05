using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PayRoll_Calculator
{
    class EmployeePay
    {
        private const double Starting_Pay  = 10.00; /* Minimum employee pay rate           */
        private const double Maximum_hours = 40.00; /* Maximum hour employee work per week */
        private string       first_name;            /* First name of the employee          */
        private string       last_name;             /* Last name of the employee           */
        private int          id_number;             /* The ID number of the employee       */
        private double       pay_rate;              /* The pay rate of the employee        */

        double overtime_Hours = 0;
        double stdPay         = 0;
        double otPay          = 0;


        // Default constructor
        public EmployeePay()
        {
            first_name = null;
            last_name  = null;
            id_number  = 0;
            pay_rate   = Starting_Pay;
        }
       
        // Non-default constructor
        public EmployeePay(string fName, string lName, int IDnum, double pRate)
        {
            first_name = fName;
            last_name  = lName;
            id_number  = IDnum;
            if( pRate >= Starting_Pay)
                pay_rate = pRate;
            else
                throw new ArgumentOutOfRangeException("Pay rate must be $10.00 or more!");
        }

        // Get and set  the employee first name
        public string First_Name
        {
            get
            {
                return first_name;
            }
            set
             {
                this.first_name = value;
             }
        }

        // Get and set the employee last name
        public string Last_Name
        {
            get
            {
                return last_name;
            }
            set
            {
                this.last_name = value;
            }
        }

        // Get and set the employee id number
        public int ID_Number
        {
            get
            {
                return id_number;
            }
            set
            {
                if(char.IsDigit((char)id_number))
                   this.id_number = value;
                else
                    throw new FormatException("Invalid data! Please re-enter the information.Numbers only!");
            }
        }

        // Get and set the employee pay rate
        public double Pay_Rate
        {
            get
            {
                return pay_rate;
            }
            set
            {
                if (pay_rate >= Starting_Pay)
                    this.pay_rate = value;
                else
                    throw new ArgumentOutOfRangeException("Pay rate must be $10.00 or more!");
            }
        }

        // Calculate the employee standard amount
        public string standard_Pay(double hours_Worked)
        {
            if (hours_Worked > Maximum_hours)
            {
                overtime_Hours = hours_Worked - Maximum_hours;
                stdPay         = pay_rate * Maximum_hours;
            }
            else if (hours_Worked < 0)
            {
                throw new ArgumentOutOfRangeException("Work hours can not be a negative value!");
            }
            else
            {
                stdPay = pay_rate * hours_Worked;
            }
            return stdPay.ToString("c2");
        }

        // Calculate the employee overtime pay
        public string Overtime_Pay (double hours_Worked)
        {
            otPay = pay_rate * 1.5 * overtime_Hours;
            return otPay.ToString("c2");
        }

        // Calculate the gross pay
       public string Gross_Pay()
        {
            double total_Amount = stdPay + otPay;
            return total_Amount.ToString("c2");
        }
    }
}