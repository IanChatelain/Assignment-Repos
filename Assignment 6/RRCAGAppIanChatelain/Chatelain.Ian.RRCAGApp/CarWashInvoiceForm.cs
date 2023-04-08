/*
 * Name: Ian Chatelain
 * Program: Business Information Technology
 * Course: ADEV-2008 (234110) Programming 2
 * Created: 29/03/2023
 * Updated: 07/04/2023
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            this.lblGoodsAndServicesTax.DataBindings.Add("Text", carWashInvoice, "GoodsAndServicesTaxCharged");
            this.lblProvincialSalesTax.DataBindings.Add("Text", carWashInvoice, "ProvincialSalesTaxCharged");
            this.lblSubtotal.DataBindings.Add("Text", carWashInvoice, "SubTotal", true, DataSourceUpdateMode.Never, null, "C");
            this.lblTotal.DataBindings.Add("Text", carWashInvoice, "Total", true, DataSourceUpdateMode.Never, null, "C");
            this.lblFragrancePrice.Text = string.Format("{0:N}", CarWashInvoice.FragranceCost);
            this.lblPackagePrice.Text = string.Format("{0:C}", CarWashInvoice.PackageCost);
            this.Text = "Car Wash Invoice";
        }
    }
}