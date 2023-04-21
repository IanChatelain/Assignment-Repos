/*
 * Name: Ian Chatelain
 * Program: Business Information Technology
 * Course: ADEV-2008 (234110) Programming 2
 * Created: 08/03/2023
 * Updated: 07/04/2023
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ACE.BIT.ADEV.CarWash;
using ACE.BIT.ADEV.Forms;
using Chatelain.Ian.Business;

namespace Chatelain.Ian.RRCAGApp
{
    /// <summary>
    /// Represents a CarWashForm.
    /// </summary>
    public partial class CarWashForm : ACE.BIT.ADEV.Forms.CarWashForm
    {
        private BindingSource packageSource;
        private BindingSource fragranceSource;
        private BindingSource labelSource;
        private BindingList<Package> packageBinding;
        private BindingList<CarWashItem> fragranceBinding;
        private BindingList<CarWashInvoice> labelBinding;
        private CarWashInvoiceForm carWashInvoiceForm;
        private CarWashInvoice carWashInvoice;
        private List<string> description = new List<string>()
                {
                    "Standard",
                    "Deluxe",
                    "Executive",
                    "Luxury"
                };
        private List<string> interior = new List<string>()
                {
                    "Shampoo Carpets",
                    "Shampoo Upholstery",
                    "Interior Protection Coat",
                };
        private List<string> exterior = new List<string>()
                {
                    "Hand Wash",
                    "Hand Wax",
                    "Wheel Polish",
                    "Detail Engine Compartment"
                };
        private List<decimal> price = new List<decimal>()
                {
                    7.5M, 15M, 35M, 55M
                };

        /// <summary>
        /// Initializes the CarWashForm.
        /// </summary>
        public CarWashForm()
        {
            this.packageSource = new BindingSource();
            this.fragranceSource = new BindingSource();
            this.labelSource = new BindingSource();
            this.packageBinding = new BindingList<Package>();
            this.fragranceBinding = new BindingList<CarWashItem>();
            this.labelBinding = new BindingList<CarWashInvoice>();

            CreatePackages(this.description, this.price, this.interior, this.exterior);
            CreateCarWashItems();
            BindData();

            this.Load += CarWashForm_Load;
            this.mnuToolsGenerateInvoice.Click += MnuToolsGenerateInvoice_Click;
            this.mnuFileClose.Click += MnuFileClose_Click;
            this.cboPackage.SelectedIndexChanged += ComboBox_SelectionChanged;
            this.cboFragrance.SelectedIndexChanged += ComboBox_SelectionChanged;
        }

        /// <summary>
        /// Handles the CarWashForm load event.
        /// </summary>
        private void CarWashForm_Load(object sender, EventArgs e)
        {
            InitialState();
        }

        /// <summary>
        /// Handles the Tools Generate Invoice menu item click event.
        /// </summary>
        private void MnuToolsGenerateInvoice_Click(object sender, EventArgs e)
        {
            carWashInvoiceForm = new CarWashInvoiceForm(carWashInvoice);

            carWashInvoiceForm.FormClosed += CarWashInvoiceForm_FormClosed;
            carWashInvoiceForm.ShowDialog();
        }

        /// <summary>
        /// Handles the CarWashInvoiceForm closed event. 
        /// </summary>
        private void CarWashInvoiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            InitialState();
        }

        /// <summary>
        /// Handles the File Close menu item click event.
        /// </summary>
        private void MnuFileClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the selection changed events from both ComboBoxes.
        /// </summary>
        private void ComboBox_SelectionChanged(object sender, EventArgs e)
        {
            if (this.cboPackage.SelectedIndex != -1)
            {
                if (((ComboBox)sender).SelectedItem is Package)
                {
                    this.carWashInvoice = new CarWashInvoice(0.07M, 0.05M, ((Package)((ComboBox)sender).SelectedItem).Price, ((CarWashItem)this.cboFragrance.SelectedItem).Price);
                }

                else if (((ComboBox)sender).SelectedItem is CarWashItem)
                {
                    this.carWashInvoice = new CarWashInvoice(0.07M, 0.05M, ((Package)this.cboPackage.SelectedItem).Price, ((CarWashItem)((ComboBox)sender).SelectedItem).Price);
                }

                UpdateBinds();

                this.labelBinding.Clear();
                this.labelBinding.Add(carWashInvoice);

                this.mnuToolsGenerateInvoice.Enabled = true;
            }
        }

        /// <summary>
        /// Updates the list box binds.
        /// </summary>
        private void UpdateBinds()
        {
            string currentFragrance = ((CarWashItem)this.cboFragrance.SelectedItem).Description;
            List<string> currentServices = ((Package)cboPackage.SelectedItem).InteriorServices;

            currentServices.Insert(0, string.Format("Fragrance - {0}", currentFragrance));
            this.lstInterior.DataSource = currentServices;
            this.lstExterior.DataSource = ((Package)cboPackage.SelectedItem).ExteriorServices;
        }

        /// <summary>
        /// Sets the initial state of the CarWashForm.
        /// </summary>
        private void InitialState()
        {
            // Form
            this.Text = "Car Wash";

            // Menu Strip
            this.mnuToolsGenerateInvoice.Enabled = false;

            // Combo Boxes
            this.cboPackage.SelectedIndex = -1;
            this.cboFragrance.SelectedIndex = this.cboFragrance.FindStringExact("Pine");

            // DataSources
            this.lstInterior.DataSource = new List<object>();
            this.lstExterior.DataSource = new List<object>();
            this.lstInterior.SelectionMode = SelectionMode.None;
            this.lstExterior.SelectionMode = SelectionMode.None;

            // Binding Lists
            this.labelBinding.Clear();
        }

        private void BindData()
        {
            this.packageSource.DataSource = this.packageBinding;
            this.cboPackage.DataSource = this.packageSource;
            this.fragranceSource.DataSource = this.fragranceBinding;
            this.cboFragrance.DataSource = this.fragranceSource;
            this.labelSource.DataSource = this.labelBinding;

            // Labels
            this.lblGoodsAndServicesTax.DataBindings.Add("Text", labelSource, "GoodsAndServicesTaxCharged");
            this.lblProvincialSalesTax.DataBindings.Add("Text", labelSource, "ProvincialSalesTaxCharged");
            this.lblSubtotal.DataBindings.Add("Text", labelSource, "SubTotal", true, DataSourceUpdateMode.Never, null, "C");
            this.lblTotal.DataBindings.Add("Text", labelSource, "Total", true, DataSourceUpdateMode.Never, null, "C");
        }

        /// <summary>
        /// Creates packages and adds them to the binding list.
        /// </summary>
        private void CreatePackages(List<string> description, List<decimal> price, List<string> interior, List<string> exterior)
        {

            List<string> tempInterior = new List<string>();
            List<string> tempExterior = new List<string>();

            for (int i = 0; i < description.Count; i++)
            {
                if (i > 0 && i <= interior.Count)
                {
                    tempInterior.Add(interior[i - 1]);
                }

                if (i < exterior.Count)
                {
                    tempExterior.Add(exterior[i]);
                }

                Package package = new Package(description[i], price[i], tempInterior, tempExterior);
                packageBinding.Add(package);
            }
        }

        /// <summary>
        /// Reads a CSV file and outputs CarWashItems to a binding list in alphabetical order.
        /// </summary>
        private void CreateCarWashItems()
        {
            string filePath = "fragrances.txt";

            List<CarWashItem> temp = new List<CarWashItem>();
            CarWashItem pine = new CarWashItem("Pine", 0M);

            temp.Add(pine);

            try
            {
                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader fileReader = new StreamReader(fileStream);

                while (fileReader.Peek() != -1)
                {
                    string record = fileReader.ReadLine();
                    char delimiter = ',';
                    string[] fields = record.Split(delimiter);
                    string description = fields[0];
                    decimal price = decimal.Parse(fields[1]);

                    temp.Add(new CarWashItem(description, price));
                }

                fileReader.Close();
                fileReader.Dispose();
            }
            catch (IOException)
            {
                MessageBox.Show("Fragrances data file not found.");
            }
            catch (FormatException)
            {
                MessageBox.Show("An error occured while reading the data file.");
            }
            temp.Sort();

            foreach (CarWashItem item in temp)
            {
                fragranceBinding.Add(item);
            }
        }
    }
}
