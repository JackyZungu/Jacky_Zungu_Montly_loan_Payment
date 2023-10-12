using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Montly_loan_Payment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CenterToParent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double purchasePrice = 0.0;
            double downPayment = 0.0;
            double InterestRate = 0.0;
            int loanTerm = 0;

            if (string.IsNullOrEmpty(txtPurchaseAmount.Text))
            {
                MessageBox.Show("Purchase Price is required.", "Error");
                return;
            }

            if (string.IsNullOrEmpty(txtDownPayAmnt.Text))
            {
                MessageBox.Show("Down Payment amaount is required.", "Error");
                return;
            }

            if (string.IsNullOrEmpty(txtInterestRate.Text))
            {
                MessageBox.Show("Interest Rate is required.", "Error");
                return;
            }

            if (string.IsNullOrEmpty(txtLoanTerm.Text))
            {
                MessageBox.Show("Loan term is required.", "Error");
                return;
            }
            

            try
            {
                purchasePrice = Convert.ToDouble(txtPurchaseAmount.Text);
                downPayment = Convert.ToDouble(txtDownPayAmnt.Text);
                InterestRate = Convert.ToDouble(txtInterestRate.Text) / 100 /12;
                loanTerm = Convert.ToInt32(txtLoanTerm.Text);
            }
            catch 
            {
                MessageBox.Show("Invalid numeric entry.", "Error");
                return;
            }

            double amountToFinance = purchasePrice - downPayment;
            double monthlyPayment = (amountToFinance * InterestRate) / (1 - Math.Pow(1 + InterestRate, - loanTerm));

         
            txtAmntFinance.Text = amountToFinance.ToString("C");
            txtMonthlyPay.Text = monthlyPayment.ToString("C");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("dddd , MMM dd yyyy , hh:mm:ss:tt");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
