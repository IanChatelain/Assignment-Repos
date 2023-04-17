/*
 * Name: Ian Chatelain
 * Program: Business Information Technology
 * Course: ADEV-2008 (234110) Programming 2
 * Created: 08/03/2023
 * Updated: 19/03/2023
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatelain.Ian.RRCAGApp
{
    /// <summary>
    /// Represents a MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes the MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            this.mnuFileOpenSalesQuote.Click += MnuFileOpenSalesQuote_Click;
            this.mnuFileOpenCarWash.Click += MnuFileOpenCarWash_Click;
            this.mnuFileExit.Click += MnuFileExit_Click;
            this.mnuDataVehicles.Click += MnuDataVehicles_Click;
            this.mnuHelpAbout.Click += MnuHelpAbout_Click;
        }

        /// <summary>
        /// Handles the Help About menu click event.
        /// </summary>
        private void MnuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();

            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Data Vehicles menu click event.
        /// </summary>
        private void MnuDataVehicles_Click(object sender, EventArgs e)
        {
            bool formOpen = false;
            FormCollection formCollection = Application.OpenForms;

            foreach (Form form in formCollection)
            {
                if (form is VehicleDataForm)
                {
                    formOpen = true;
                    form.Activate();
                    break;
                }
            }

            if (!formOpen)
            {
                VehicleDataForm vehiclesForm = new VehicleDataForm();
                vehiclesForm.MdiParent = this;
                vehiclesForm.Show();
            }
        }

        /// <summary>
        /// Handles the File Exit menu click event.
        /// </summary>
        private void MnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the File Open CarWash menu click event.
        /// </summary>
        private void MnuFileOpenCarWash_Click(object sender, EventArgs e)
        {
            CarWashForm carWashForm = new CarWashForm();

            carWashForm.MdiParent = this;

            carWashForm.Show();
        }

        /// <summary>
        /// Handles the File Open Sales Quote menu click event.
        /// </summary>
        private void MnuFileOpenSalesQuote_Click(object sender, EventArgs e)
        {
            SalesQuoteForm salesQuoteForm = new SalesQuoteForm();

            salesQuoteForm.MdiParent = this;

            salesQuoteForm.Show();
        }
    }
}
