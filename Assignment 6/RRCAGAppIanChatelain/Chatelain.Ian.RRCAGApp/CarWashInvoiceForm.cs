/*
 * Name: Ian Chatelain
 * Program: Business Information Technology
 * Course: ADEV-2008 (234110) Programming 2
 * Created: 29/03/2023
 * Updated: 03/04/2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACE.BIT.ADEV.Forms;
using Chatelain.Ian.Business;

namespace Chatelain.Ian.RRCAGApp
{
    /// <summary>
    /// Represents a CarWashInvoiceForm.
    /// </summary>
    public partial class CarWashInvoiceForm : ACE.BIT.ADEV.Forms.CarWashInvoiceForm
    {
        public CarWashInvoice CarWashInvoice { get;set; }

        /// <summary>
        /// Initializes the CarWashInvoiceForm.
        /// </summary>
        public CarWashInvoiceForm(CarWashInvoice carWashInvoice)
        {
            CarWashInvoice = carWashInvoice;

            this.lblTotal.Text = string.Format("{0:C}", CarWashInvoice.Total);
            this.lblSubtotal.Text = string.Format("{0:C}", CarWashInvoice.SubTotal);
            this.lblFragrancePrice.Text = string.Format("{0:N}", CarWashInvoice.FragranceCost);
            this.lblPackagePrice.Text = string.Format("{0:C}", CarWashInvoice.PackageCost);
            this.lblProvincialSalesTax.Text = string.Format("{0:N}", CarWashInvoice.ProvincialSalesTaxCharged);
            this.lblGoodsAndServicesTax.Text = string.Format("{0:N}", CarWashInvoice.GoodsAndServicesTaxCharged);
            this.Text = "Car Wash Invoice";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CarWashInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(619, 393);
            this.Name = "CarWashInvoiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}