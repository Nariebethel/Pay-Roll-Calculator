#region Heading info
/**********************************************************************/
/*                                                                    */
/* Program Name: program03 - Payroll Calculator                       */
/* Author:       Senario Bethel                                       */
/* Installation: Pensacola Christian College, Pensacola, Florida      */
/* Course:       CS364 .NET Programming                               */
/* Date Written: February 19, 2019                                    */
/*                                                                    */

/**********************************************************************/
/*                                                                    */
/* This program allows the user to enter in an employee payroll       */
/* information. A calculation is then performed to display the        */
/* employee's ID number, full name, standard pay, overtime pay and    */
/* their gross pay.                                                   */
/*                                                                    */
/**********************************************************************/
#endregion

using System;
using System.Windows;

namespace PayRoll_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtFirst_name.Focus();
        }

        private void Calculate_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int    employee_id       = (Int32.Parse (txtID_number.Text));
                double pay_rate          = (double.Parse(txtPay_rate.Text));
                double hours_work        = (double.Parse(txtHours_worked.Text));

                EmployeePay employee_info = new EmployeePay(txtFirst_name.Text, txtLast_name.Text, employee_id, pay_rate);
                Employee_ID.Text          = employee_id.ToString();
                Fullname.Text             = employee_info.First_Name + " " + employee_info.Last_Name;
                Standard_Amount.Text      = employee_info.standard_Pay(hours_work);
                Overtime_Amount.Text      = employee_info.Overtime_Pay(hours_work);
                Total_Amount.Text         = employee_info.Gross_Pay();
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Error_Message.Content    = ex.ParamName;
                Error_Message.Visibility = Visibility.Visible;
            }
            catch (FormatException fex)
            {
                if (txtFirst_name.Text == string.Empty && txtLast_name.Text == string.Empty &&
                   txtID_number.Text == string.Empty && txtPay_rate.Text == string.Empty &&
                   txtHours_worked.Text == string.Empty)
                {
                    Error_Message.Content = fex.Message;
                    Error_Message.Content = "Please enter in the employee's information!";
                }
                else
                {
                    Error_Message.Content = "Please re-enter the ID number. Numbers only!";
                    Error_Message.Visibility = Visibility.Visible;
                }
            }
            catch(Exception Eex)
            {
                Error_Message.Content    = Eex.Message;
                Error_Message.Visibility = Visibility.Visible;
            }
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            // Clear each text box
            this.txtFirst_name.Text   = string.Empty;
            this.txtLast_name.Text    = string.Empty;
            this.txtID_number.Text    = string.Empty;
            this.txtPay_rate.Text     = string.Empty;
            this.txtHours_worked.Text = string.Empty;
            this.Employee_ID.Text     = string.Empty;
            this.Fullname.Text        = string.Empty;
            this.Standard_Amount.Text = string.Empty;
            this.Overtime_Amount.Text = string.Empty;
            this.Total_Amount.Text    = string.Empty;

            // Place the cursor back into first name text box
            txtFirst_name.Focus();
            Error_Message.Visibility = Visibility.Hidden;
        }
    }
}