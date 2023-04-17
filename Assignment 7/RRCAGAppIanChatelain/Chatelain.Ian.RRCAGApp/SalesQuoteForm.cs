/*
 * Name: Ian Chatelain
 * Program: Business Information Technology
 * Course: ADEV-2008 (234110) Programming 2
 * Created: 08/03/2023
 * Updated: 23/03/2023
 */

using Chatelain.Ian.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatelain.Ian.RRCAGApp
{
    /// <summary>
    /// Represents the Sales Quote form.
    /// </summary>
    public partial class SalesQuoteForm : Form
    {
        private SalesQuote salesQuote;

        /// <summary>
        /// Initializes a new Sales Quote form.
        /// </summary>
        public SalesQuoteForm()
        {
            InitializeComponent();
            SalesQuoteForm_InitialState();

            this.btnCalculate.Click += BtnCalculate_Click;
            this.btnReset.Click += BtnReset_Click;

            this.txtVehicleSalePrice.TextChanged += TxtBox_TextChanged;
            this.txtTradeInValue.TextChanged += TxtBox_TextChanged;

            this.nudFinanceNumberOfYears.ValueChanged += Options_ValueChanged;
            this.nudFinanceAnnualInterestRate.ValueChanged += Options_ValueChanged;
            this.cbAccessoriesComputerNavigation.CheckedChanged += Options_ValueChanged;
            this.cbAccessoriesLeatherInterior.CheckedChanged += Options_ValueChanged;
            this.cbAccessoriesStereoSystem.CheckedChanged += Options_ValueChanged;
            this.rbExteriorFinishCustomizedDetailing.CheckedChanged += Options_ValueChanged;
            this.rbExteriorFinishPearlized.CheckedChanged += Options_ValueChanged;
            this.rbExteriorFinishStandard.CheckedChanged += Options_ValueChanged;
        }

        /// <summary>
        /// Sets the initial state of the Sales Quote form.
        /// </summary>
        private void SalesQuoteForm_InitialState()
        {
            // Vehicle sales price state
            this.txtVehicleSalePrice.Text = string.Empty;
            this.txtVehicleSalePrice.Focus();
            this.txtVehicleSalePrice.TextAlign = HorizontalAlignment.Right;

            // Trade-in value state
            this.txtTradeInValue.Text = "0";
            this.txtTradeInValue.TextAlign = HorizontalAlignment.Right;

            // Accessories group state
            this.cbAccessoriesComputerNavigation.Checked = false;
            this.cbAccessoriesLeatherInterior.Checked = false;
            this.cbAccessoriesStereoSystem.Checked = false;

            // Exterior finish group state
            this.rbExteriorFinishStandard.Checked = true;

            // Summary group state
            this.SummarySalesTaxRate.Text = string.Format("Sales Tax ({0:P0}):", .12m);

            SummaryLabel_Empty();

            // Financing group state
            this.nudFinanceNumberOfYears.Value = 1;
            this.nudFinanceNumberOfYears.Minimum = 1;
            this.nudFinanceNumberOfYears.Maximum = 10;
            this.nudFinanceNumberOfYears.Increment = 1;

            this.nudFinanceAnnualInterestRate.Value = 5;
            this.nudFinanceAnnualInterestRate.Minimum = 0;
            this.nudFinanceAnnualInterestRate.Maximum = 25;
            this.nudFinanceAnnualInterestRate.DecimalPlaces = 2;
            this.nudFinanceAnnualInterestRate.Increment = .25m;

            // Error state
            ErrorProvider_TextBox_InitialState();

            // Button state
            this.AcceptButton = this.btnCalculate;
        }

        /// <summary>
        /// Sets ErrorProvider's intial state.
        /// </summary>
        private void ErrorProvider_TextBox_InitialState()
        {
            this.errorProvider.SetError(this.txtVehicleSalePrice, string.Empty);
            this.errorProvider.SetError(this.txtTradeInValue, string.Empty);
            this.errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            this.errorProvider.SetIconPadding(this.txtVehicleSalePrice, 3);
            this.errorProvider.SetIconPadding(this.txtTradeInValue, 3);
        }

        /// <summary>
        /// Clears dynamic label text.
        /// </summary>
        private void SummaryLabel_Empty()
        {
            List<Label> labels = gbSummary.Controls.OfType<Label>().Where(lbl => lbl.Name.Contains("lbl")).ToList();
            foreach (Label lbl in labels)
            {
                lbl.Text = string.Empty;
            }
        }

        /// <summary>
        /// Sets values of the labels in the Summary group.
        /// </summary>
        private void Labels_UpdateText()
        {
            this.lblSummarVehicleSalePrice.Text = string.Format("{0:C}", salesQuote.VehicleSalePrice);
            this.lblSummaryOptions.Text =  string.Format("{0:N}", salesQuote.TotalOptions);
            this.lblSummarySubtotal.Text = string.Format("{0:C}", salesQuote.SubTotal);
            this.lblSummarySalesTax.Text = string.Format("{0:N}", salesQuote.SalesTax);
            this.lblSummaryTotal.Text = string.Format("{0:C}", salesQuote.Total);
            this.lblSummaryTradeIn.Text = string.Format("-{0:N}", salesQuote.TradeInAmount);
            this.lblSummaryAmountDue.Text = string.Format("{0:C}", salesQuote.AmountDue);
            this.lblFinanceMonthlyPayment.Text = string.Format("{0:C}", Financial.GetPayment(this.nudFinanceAnnualInterestRate.Value / 1200, (int)this.nudFinanceNumberOfYears.Value * 12, salesQuote.AmountDue));
        }

        /// <summary>
        /// Returns the ExteriorFinish chosen.
        /// </summary>
        private ExteriorFinish GetExteriorFinish()
        {
            switch (true)
            {
                case bool standard when this.rbExteriorFinishStandard.Checked:
                    return ExteriorFinish.Standard;
                case bool pearlized when this.rbExteriorFinishPearlized.Checked:
                    return ExteriorFinish.Pearlized;
                case bool custom when this.rbExteriorFinishCustomizedDetailing.Checked:
                    return ExteriorFinish.Custom;
                default:
                    return ExteriorFinish.None;
            }
        }

        /// <summary>
        /// Returns the Accessories chosen.
        /// </summary>
        private Accessories GetAccessories()
        {
            switch (true)
            {
                case bool stereo when (this.cbAccessoriesStereoSystem.Checked && !this.cbAccessoriesLeatherInterior.Checked && !this.cbAccessoriesComputerNavigation.Checked):
                    return Accessories.StereoSystem;
                case bool stereoLeather when (this.cbAccessoriesStereoSystem.Checked && this.cbAccessoriesLeatherInterior.Checked && !this.cbAccessoriesComputerNavigation.Checked):
                    return Accessories.StereoAndLeather;
                case bool stereoNav when (this.cbAccessoriesStereoSystem.Checked && !this.cbAccessoriesLeatherInterior.Checked && this.cbAccessoriesComputerNavigation.Checked):
                    return Accessories.StereoAndNavigation;
                case bool leather when (!this.cbAccessoriesStereoSystem.Checked && this.cbAccessoriesLeatherInterior.Checked && !this.cbAccessoriesComputerNavigation.Checked):
                    return Accessories.LeatherInterior;
                case bool leatherNav when (!this.cbAccessoriesStereoSystem.Checked && this.cbAccessoriesLeatherInterior.Checked && this.cbAccessoriesComputerNavigation.Checked):
                 return Accessories.LeatherAndNavigation;
                case bool computerNav when (!this.cbAccessoriesStereoSystem.Checked && !this.cbAccessoriesLeatherInterior.Checked && this.cbAccessoriesComputerNavigation.Checked):
                    return Accessories.ComputerNavigation;
                case bool all when (this.cbAccessoriesStereoSystem.Checked && this.cbAccessoriesLeatherInterior.Checked && this.cbAccessoriesComputerNavigation.Checked):
                    return Accessories.All;
                default:
                    return Accessories.None;
            }
        }

        /// <summary>
        /// Validates user input.
        /// </summary>
        private bool Input_Validated()
        {
            bool result = false;
            bool vehicleSalePriceValid = true;
            bool tradeInAmountValid = true;
            bool tradeInValueEmpty = this.txtTradeInValue.Text.Equals(string.Empty);
            bool vehicleSalePriceEmpty = this.txtVehicleSalePrice.Text.Equals(string.Empty);
            decimal tradeInValueDecimal;
            decimal vehicleSalePriceDecimal;

            try
            {
                vehicleSalePriceDecimal = decimal.Parse(this.txtVehicleSalePrice.Text);
            }
            catch (FormatException)
            {
                if (!vehicleSalePriceEmpty)
                {
                    vehicleSalePriceValid = false;
                    this.errorProvider.SetError(this.txtVehicleSalePrice, "Vehicle price cannot contain letters or special characters.");
                }
                else
                {
                    vehicleSalePriceValid = false;
                    this.errorProvider.SetError(this.txtVehicleSalePrice, "Vehicle price is a required field.");
                }
            }

            try
            {
                tradeInValueDecimal = decimal.Parse(this.txtTradeInValue.Text);
            }
            catch (FormatException)
            {
                if (!tradeInValueEmpty)
                {
                    tradeInAmountValid = false;
                    this.errorProvider.SetError(this.txtTradeInValue, "Trade-in value cannot contain letters or special characters.");
                }
                else
                {
                    tradeInAmountValid = false;
                    this.errorProvider.SetError(this.txtTradeInValue, "Trade-in value is a required field.");
                }
            }

            if (!vehicleSalePriceEmpty && vehicleSalePriceValid)
            {
                if (decimal.Parse(this.txtVehicleSalePrice.Text) <= 0)
                {
                    vehicleSalePriceValid = false;
                    this.errorProvider.SetError(this.txtVehicleSalePrice, "Vehicle price cannot be less than or equal to 0.");
                }
            }

            if (!tradeInValueEmpty && tradeInAmountValid)
            {
                if (decimal.Parse(this.txtTradeInValue.Text) < 0)
                {
                    tradeInAmountValid = false;
                    this.errorProvider.SetError(this.txtTradeInValue, "Trade-in value cannot be less than 0.");
                }
            }

            if (!tradeInValueEmpty && tradeInAmountValid && vehicleSalePriceValid)
            {
                if (decimal.Parse(this.txtTradeInValue.Text) > decimal.Parse(this.txtVehicleSalePrice.Text))
                {
                    tradeInAmountValid = false;
                    this.errorProvider.SetError(this.txtTradeInValue, "Trade-in value cannot exceed the vehicle sale price.");
                }
            }

            if (tradeInAmountValid && vehicleSalePriceValid)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Handles the Calculate button click event.
        /// </summary>
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            ErrorProvider_TextBox_InitialState();

            if (Input_Validated())
            {
                salesQuote = new SalesQuote(decimal.Parse(this.txtVehicleSalePrice.Text), decimal.Parse(this.txtTradeInValue.Text), .12M, GetAccessories(), GetExteriorFinish());
                Labels_UpdateText();
            }
        }

        /// <summary>
        /// Handles the options value changed event.
        /// </summary>
        private void Options_ValueChanged(object sender, EventArgs e)
        {
            if (salesQuote != null)
            {
                salesQuote.AccessoriesChosen = GetAccessories();
                salesQuote.ExteriorFinishChosen = GetExteriorFinish();
                Labels_UpdateText();
            }
        }

        /// <summary>
        /// Handles the text changed event.
        /// </summary>
        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            SummaryLabel_Empty();

            this.lblFinanceMonthlyPayment.Text = string.Empty;
            salesQuote = null;
        }

        /// <summary>
        /// Handles the Reset button click event.
        /// </summary>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            string caption = "Reset Form";
            string message = "Do you want to reset the form?";
            DialogResult result = MessageBox.Show(this, message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                SalesQuoteForm_InitialState();
            }
        }
    }
}
