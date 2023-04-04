namespace Chatelain.Ian.RRCAGApp
{
    partial class SalesQuoteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SummarySalesTaxRate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.gbAccessories = new System.Windows.Forms.GroupBox();
            this.cbAccessoriesComputerNavigation = new System.Windows.Forms.CheckBox();
            this.cbAccessoriesLeatherInterior = new System.Windows.Forms.CheckBox();
            this.cbAccessoriesStereoSystem = new System.Windows.Forms.CheckBox();
            this.gbExteriorFinish = new System.Windows.Forms.GroupBox();
            this.rbExteriorFinishCustomizedDetailing = new System.Windows.Forms.RadioButton();
            this.rbExteriorFinishPearlized = new System.Windows.Forms.RadioButton();
            this.rbExteriorFinishStandard = new System.Windows.Forms.RadioButton();
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.lblSummaryAmountDue = new System.Windows.Forms.Label();
            this.lblSummaryTradeIn = new System.Windows.Forms.Label();
            this.lblSummaryTotal = new System.Windows.Forms.Label();
            this.lblSummarySalesTax = new System.Windows.Forms.Label();
            this.lblSummarySubtotal = new System.Windows.Forms.Label();
            this.lblSummaryOptions = new System.Windows.Forms.Label();
            this.lblSummarVehicleSalePrice = new System.Windows.Forms.Label();
            this.gbFinance = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFinanceMonthlyPayment = new System.Windows.Forms.Label();
            this.nudFinanceAnnualInterestRate = new System.Windows.Forms.NumericUpDown();
            this.nudFinanceNumberOfYears = new System.Windows.Forms.NumericUpDown();
            this.txtVehicleSalePrice = new System.Windows.Forms.TextBox();
            this.txtTradeInValue = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbAccessories.SuspendLayout();
            this.gbExteriorFinish.SuspendLayout();
            this.gbSummary.SuspendLayout();
            this.gbFinance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinanceAnnualInterestRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinanceNumberOfYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vehicle\'s Sale Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trade-in Value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vehicle\'s Sale Price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Options: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Subtotal:";
            // 
            // SummarySalesTaxRate
            // 
            this.SummarySalesTaxRate.AutoSize = true;
            this.SummarySalesTaxRate.Location = new System.Drawing.Point(54, 136);
            this.SummarySalesTaxRate.Name = "SummarySalesTaxRate";
            this.SummarySalesTaxRate.Size = new System.Drawing.Size(86, 13);
            this.SummarySalesTaxRate.TabIndex = 5;
            this.SummarySalesTaxRate.Text = "Sales Tax (13%):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Total:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Trade-in:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Amount Due:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "No. of Years";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(116, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Annual";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(203, 36);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Monthly Payment";
            // 
            // gbAccessories
            // 
            this.gbAccessories.Controls.Add(this.cbAccessoriesComputerNavigation);
            this.gbAccessories.Controls.Add(this.cbAccessoriesLeatherInterior);
            this.gbAccessories.Controls.Add(this.cbAccessoriesStereoSystem);
            this.gbAccessories.Location = new System.Drawing.Point(24, 91);
            this.gbAccessories.Name = "gbAccessories";
            this.gbAccessories.Size = new System.Drawing.Size(230, 145);
            this.gbAccessories.TabIndex = 3;
            this.gbAccessories.TabStop = false;
            this.gbAccessories.Text = "Accessories";
            // 
            // cbAccessoriesComputerNavigation
            // 
            this.cbAccessoriesComputerNavigation.AutoSize = true;
            this.cbAccessoriesComputerNavigation.Location = new System.Drawing.Point(23, 102);
            this.cbAccessoriesComputerNavigation.Name = "cbAccessoriesComputerNavigation";
            this.cbAccessoriesComputerNavigation.Size = new System.Drawing.Size(125, 17);
            this.cbAccessoriesComputerNavigation.TabIndex = 5;
            this.cbAccessoriesComputerNavigation.Text = "Computer Navigation";
            this.cbAccessoriesComputerNavigation.UseVisualStyleBackColor = true;
            // 
            // cbAccessoriesLeatherInterior
            // 
            this.cbAccessoriesLeatherInterior.AutoSize = true;
            this.cbAccessoriesLeatherInterior.Location = new System.Drawing.Point(23, 66);
            this.cbAccessoriesLeatherInterior.Name = "cbAccessoriesLeatherInterior";
            this.cbAccessoriesLeatherInterior.Size = new System.Drawing.Size(97, 17);
            this.cbAccessoriesLeatherInterior.TabIndex = 4;
            this.cbAccessoriesLeatherInterior.Text = "Leather Interior";
            this.cbAccessoriesLeatherInterior.UseVisualStyleBackColor = true;
            // 
            // cbAccessoriesStereoSystem
            // 
            this.cbAccessoriesStereoSystem.AutoSize = true;
            this.cbAccessoriesStereoSystem.Location = new System.Drawing.Point(23, 30);
            this.cbAccessoriesStereoSystem.Name = "cbAccessoriesStereoSystem";
            this.cbAccessoriesStereoSystem.Size = new System.Drawing.Size(94, 17);
            this.cbAccessoriesStereoSystem.TabIndex = 3;
            this.cbAccessoriesStereoSystem.Text = "Stereo System";
            this.cbAccessoriesStereoSystem.UseVisualStyleBackColor = true;
            // 
            // gbExteriorFinish
            // 
            this.gbExteriorFinish.Controls.Add(this.rbExteriorFinishCustomizedDetailing);
            this.gbExteriorFinish.Controls.Add(this.rbExteriorFinishPearlized);
            this.gbExteriorFinish.Controls.Add(this.rbExteriorFinishStandard);
            this.gbExteriorFinish.Location = new System.Drawing.Point(24, 259);
            this.gbExteriorFinish.Name = "gbExteriorFinish";
            this.gbExteriorFinish.Size = new System.Drawing.Size(230, 145);
            this.gbExteriorFinish.TabIndex = 4;
            this.gbExteriorFinish.TabStop = false;
            this.gbExteriorFinish.Text = "Exterior Finish";
            // 
            // rbExteriorFinishCustomizedDetailing
            // 
            this.rbExteriorFinishCustomizedDetailing.AutoSize = true;
            this.rbExteriorFinishCustomizedDetailing.Location = new System.Drawing.Point(23, 102);
            this.rbExteriorFinishCustomizedDetailing.Name = "rbExteriorFinishCustomizedDetailing";
            this.rbExteriorFinishCustomizedDetailing.Size = new System.Drawing.Size(123, 17);
            this.rbExteriorFinishCustomizedDetailing.TabIndex = 17;
            this.rbExteriorFinishCustomizedDetailing.TabStop = true;
            this.rbExteriorFinishCustomizedDetailing.Text = "Customized Detailing";
            this.rbExteriorFinishCustomizedDetailing.UseVisualStyleBackColor = true;
            // 
            // rbExteriorFinishPearlized
            // 
            this.rbExteriorFinishPearlized.AutoSize = true;
            this.rbExteriorFinishPearlized.Location = new System.Drawing.Point(23, 67);
            this.rbExteriorFinishPearlized.Name = "rbExteriorFinishPearlized";
            this.rbExteriorFinishPearlized.Size = new System.Drawing.Size(68, 17);
            this.rbExteriorFinishPearlized.TabIndex = 16;
            this.rbExteriorFinishPearlized.TabStop = true;
            this.rbExteriorFinishPearlized.Text = "Pearlized";
            this.rbExteriorFinishPearlized.UseVisualStyleBackColor = true;
            // 
            // rbExteriorFinishStandard
            // 
            this.rbExteriorFinishStandard.AutoSize = true;
            this.rbExteriorFinishStandard.Location = new System.Drawing.Point(23, 32);
            this.rbExteriorFinishStandard.Name = "rbExteriorFinishStandard";
            this.rbExteriorFinishStandard.Size = new System.Drawing.Size(68, 17);
            this.rbExteriorFinishStandard.TabIndex = 6;
            this.rbExteriorFinishStandard.TabStop = true;
            this.rbExteriorFinishStandard.Text = "Standard";
            this.rbExteriorFinishStandard.UseVisualStyleBackColor = true;
            // 
            // gbSummary
            // 
            this.gbSummary.Controls.Add(this.lblSummaryAmountDue);
            this.gbSummary.Controls.Add(this.lblSummaryTradeIn);
            this.gbSummary.Controls.Add(this.lblSummaryTotal);
            this.gbSummary.Controls.Add(this.lblSummarySalesTax);
            this.gbSummary.Controls.Add(this.lblSummarySubtotal);
            this.gbSummary.Controls.Add(this.lblSummaryOptions);
            this.gbSummary.Controls.Add(this.lblSummarVehicleSalePrice);
            this.gbSummary.Controls.Add(this.label9);
            this.gbSummary.Controls.Add(this.label8);
            this.gbSummary.Controls.Add(this.label7);
            this.gbSummary.Controls.Add(this.SummarySalesTaxRate);
            this.gbSummary.Controls.Add(this.label5);
            this.gbSummary.Controls.Add(this.label4);
            this.gbSummary.Controls.Add(this.label3);
            this.gbSummary.Location = new System.Drawing.Point(293, 12);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(310, 282);
            this.gbSummary.TabIndex = 21;
            this.gbSummary.TabStop = false;
            this.gbSummary.Text = "Summary";
            // 
            // lblSummaryAmountDue
            // 
            this.lblSummaryAmountDue.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblSummaryAmountDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSummaryAmountDue.Location = new System.Drawing.Point(146, 234);
            this.lblSummaryAmountDue.Name = "lblSummaryAmountDue";
            this.lblSummaryAmountDue.Size = new System.Drawing.Size(125, 20);
            this.lblSummaryAmountDue.TabIndex = 22;
            this.lblSummaryAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSummaryTradeIn
            // 
            this.lblSummaryTradeIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSummaryTradeIn.Location = new System.Drawing.Point(146, 200);
            this.lblSummaryTradeIn.Name = "lblSummaryTradeIn";
            this.lblSummaryTradeIn.Size = new System.Drawing.Size(125, 20);
            this.lblSummaryTradeIn.TabIndex = 21;
            this.lblSummaryTradeIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSummaryTotal
            // 
            this.lblSummaryTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSummaryTotal.Location = new System.Drawing.Point(146, 166);
            this.lblSummaryTotal.Name = "lblSummaryTotal";
            this.lblSummaryTotal.Size = new System.Drawing.Size(125, 20);
            this.lblSummaryTotal.TabIndex = 20;
            this.lblSummaryTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSummarySalesTax
            // 
            this.lblSummarySalesTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSummarySalesTax.Location = new System.Drawing.Point(146, 132);
            this.lblSummarySalesTax.Name = "lblSummarySalesTax";
            this.lblSummarySalesTax.Size = new System.Drawing.Size(125, 20);
            this.lblSummarySalesTax.TabIndex = 19;
            this.lblSummarySalesTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSummarySubtotal
            // 
            this.lblSummarySubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSummarySubtotal.Location = new System.Drawing.Point(146, 98);
            this.lblSummarySubtotal.Name = "lblSummarySubtotal";
            this.lblSummarySubtotal.Size = new System.Drawing.Size(125, 20);
            this.lblSummarySubtotal.TabIndex = 18;
            this.lblSummarySubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSummaryOptions
            // 
            this.lblSummaryOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSummaryOptions.Location = new System.Drawing.Point(146, 64);
            this.lblSummaryOptions.Name = "lblSummaryOptions";
            this.lblSummaryOptions.Size = new System.Drawing.Size(125, 20);
            this.lblSummaryOptions.TabIndex = 17;
            this.lblSummaryOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSummarVehicleSalePrice
            // 
            this.lblSummarVehicleSalePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSummarVehicleSalePrice.Location = new System.Drawing.Point(146, 30);
            this.lblSummarVehicleSalePrice.Name = "lblSummarVehicleSalePrice";
            this.lblSummarVehicleSalePrice.Size = new System.Drawing.Size(125, 20);
            this.lblSummarVehicleSalePrice.TabIndex = 0;
            this.lblSummarVehicleSalePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbFinance
            // 
            this.gbFinance.Controls.Add(this.label6);
            this.gbFinance.Controls.Add(this.lblFinanceMonthlyPayment);
            this.gbFinance.Controls.Add(this.nudFinanceAnnualInterestRate);
            this.gbFinance.Controls.Add(this.nudFinanceNumberOfYears);
            this.gbFinance.Controls.Add(this.label18);
            this.gbFinance.Controls.Add(this.label17);
            this.gbFinance.Controls.Add(this.label16);
            this.gbFinance.Location = new System.Drawing.Point(293, 300);
            this.gbFinance.Name = "gbFinance";
            this.gbFinance.Size = new System.Drawing.Size(310, 104);
            this.gbFinance.TabIndex = 5;
            this.gbFinance.TabStop = false;
            this.gbFinance.Text = "Finance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Interest Rate";
            // 
            // lblFinanceMonthlyPayment
            // 
            this.lblFinanceMonthlyPayment.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblFinanceMonthlyPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFinanceMonthlyPayment.Location = new System.Drawing.Point(203, 59);
            this.lblFinanceMonthlyPayment.Name = "lblFinanceMonthlyPayment";
            this.lblFinanceMonthlyPayment.Size = new System.Drawing.Size(88, 20);
            this.lblFinanceMonthlyPayment.TabIndex = 9;
            this.lblFinanceMonthlyPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudFinanceAnnualInterestRate
            // 
            this.nudFinanceAnnualInterestRate.Location = new System.Drawing.Point(118, 59);
            this.nudFinanceAnnualInterestRate.Name = "nudFinanceAnnualInterestRate";
            this.nudFinanceAnnualInterestRate.Size = new System.Drawing.Size(66, 20);
            this.nudFinanceAnnualInterestRate.TabIndex = 8;
            // 
            // nudFinanceNumberOfYears
            // 
            this.nudFinanceNumberOfYears.Location = new System.Drawing.Point(22, 59);
            this.nudFinanceNumberOfYears.Name = "nudFinanceNumberOfYears";
            this.nudFinanceNumberOfYears.Size = new System.Drawing.Size(66, 20);
            this.nudFinanceNumberOfYears.TabIndex = 7;
            // 
            // txtVehicleSalePrice
            // 
            this.txtVehicleSalePrice.Location = new System.Drawing.Point(129, 17);
            this.txtVehicleSalePrice.Name = "txtVehicleSalePrice";
            this.txtVehicleSalePrice.Size = new System.Drawing.Size(125, 20);
            this.txtVehicleSalePrice.TabIndex = 1;
            // 
            // txtTradeInValue
            // 
            this.txtTradeInValue.Location = new System.Drawing.Point(129, 52);
            this.txtTradeInValue.Name = "txtTradeInValue";
            this.txtTradeInValue.Size = new System.Drawing.Size(125, 20);
            this.txtTradeInValue.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(24, 419);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(86, 30);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(494, 419);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(109, 30);
            this.btnCalculate.TabIndex = 10;
            this.btnCalculate.Text = "Calculate Quote";
            this.btnCalculate.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SalesQuoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 461);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtTradeInValue);
            this.Controls.Add(this.txtVehicleSalePrice);
            this.Controls.Add(this.gbFinance);
            this.Controls.Add(this.gbSummary);
            this.Controls.Add(this.gbExteriorFinish);
            this.Controls.Add(this.gbAccessories);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SalesQuoteForm";
            this.Text = "Vehicle Sales Quote";
            this.gbAccessories.ResumeLayout(false);
            this.gbAccessories.PerformLayout();
            this.gbExteriorFinish.ResumeLayout(false);
            this.gbExteriorFinish.PerformLayout();
            this.gbSummary.ResumeLayout(false);
            this.gbSummary.PerformLayout();
            this.gbFinance.ResumeLayout(false);
            this.gbFinance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinanceAnnualInterestRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinanceNumberOfYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SummarySalesTaxRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbAccessories;
        private System.Windows.Forms.GroupBox gbExteriorFinish;
        private System.Windows.Forms.GroupBox gbSummary;
        private System.Windows.Forms.GroupBox gbFinance;
        private System.Windows.Forms.TextBox txtVehicleSalePrice;
        private System.Windows.Forms.TextBox txtTradeInValue;
        private System.Windows.Forms.CheckBox cbAccessoriesComputerNavigation;
        private System.Windows.Forms.CheckBox cbAccessoriesLeatherInterior;
        private System.Windows.Forms.CheckBox cbAccessoriesStereoSystem;
        private System.Windows.Forms.RadioButton rbExteriorFinishPearlized;
        private System.Windows.Forms.RadioButton rbExteriorFinishStandard;
        private System.Windows.Forms.RadioButton rbExteriorFinishCustomizedDetailing;
        private System.Windows.Forms.NumericUpDown nudFinanceAnnualInterestRate;
        private System.Windows.Forms.NumericUpDown nudFinanceNumberOfYears;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblSummaryAmountDue;
        private System.Windows.Forms.Label lblSummaryTradeIn;
        private System.Windows.Forms.Label lblSummaryTotal;
        private System.Windows.Forms.Label lblSummarySalesTax;
        private System.Windows.Forms.Label lblSummarySubtotal;
        private System.Windows.Forms.Label lblSummaryOptions;
        private System.Windows.Forms.Label lblSummarVehicleSalePrice;
        private System.Windows.Forms.Label lblFinanceMonthlyPayment;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label6;
    }
}