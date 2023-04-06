/*
 * Name: Ian Chatelain
 * Program: Business Information Technology
 * Course: ADEV-2008 (234110) Programming 2
 * Created: 08/03/2023
 * Updated: 03/04/2023
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        BindingSource packageSource;
        BindingSource fragranceSource;
        BindingSource interiorSource;
        BindingList<Package> packageBinding;
        BindingList<CarWashItem> fragranceBinding;
        BindingList<string> interiorBinding;
        CarWashInvoiceForm carWashInvoiceForm;
        CarWashInvoice carWashInvoice;

        /// <summary>
        /// Initializes the CarWashForm.
        /// </summary>
        public CarWashForm()
        {
            this.packageSource = new BindingSource();
            this.fragranceSource = new BindingSource();
            this.packageBinding = new BindingList<Package>();
            this.fragranceBinding = new BindingList<CarWashItem>();
            this.interiorSource = new BindingSource();
            this.interiorBinding = new BindingList<string>();

            CreateCarWashItems();
            CreatePackages();

            this.packageSource.DataSource = this.packageBinding;
            this.cboPackage.DataSource = this.packageSource;
            this.fragranceSource.DataSource = this.fragranceBinding;
            this.cboFragrance.DataSource = this.fragranceSource;

            this.interiorSource.DataSource = this.interiorBinding;
            this.lstInterior.DataSource = this.interiorSource;


            this.Load += CarWashForm_Load;
            this.mnuToolsGenerateInvoice.Click += MnuToolsGenerateInvoice_Click;
            this.mnuFileClose.Click += MnuFileClose_Click;
            // TODO: make handlers specific to the controls 
            this.cboPackage.SelectedIndexChanged += SelectionChanged;
            this.cboFragrance.SelectedIndexChanged += SelectionChanged;
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
            ClearLabels();
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
        private void SelectionChanged(object sender, EventArgs e)
        {
            if (this.cboPackage.SelectedIndex != -1)
            {
                // take this from event instead of selected item of cbopackage.
                this.carWashInvoice = new CarWashInvoice(0.07M, 0.05M, ((Package)this.cboPackage.SelectedItem).Price, ((CarWashItem)this.cboFragrance.SelectedItem).Price);

                ClearLabels();
                ComboBox comboBox = (ComboBox)sender;

                Package package = (Package)comboBox.SelectedItem;
                List<string> carWashItem = package.InteriorServices;

                // Find a data structure so I can get descriptoin and change whats there instead of clearing.
                // selection will send the current object here where I can access the property for it's value.
                this.interiorSource.Clear();
                // loop through list of strings in carwashitem and add each one to interior source.
                this.interiorSource.Add(carWashItem.ToString());
                
                this.lblGoodsAndServicesTax.DataBindings.Add("Text", carWashInvoice, "GoodsAndServicesTaxCharged");
                this.lblProvincialSalesTax.DataBindings.Add("Text", carWashInvoice, "ProvincialSalesTaxCharged");
                this.lblSubtotal.DataBindings.Add("Text", carWashInvoice, "SubTotal", true, DataSourceUpdateMode.Never, null, "C");
                this.lblTotal.DataBindings.Add("Text", carWashInvoice, "Total", true, DataSourceUpdateMode.Never, null, "C");

                this.mnuToolsGenerateInvoice.Enabled = true;
            }
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
        }

        /// <summary>
        /// Clears the output label's DataBindings and Text.
        /// </summary>
        private void ClearLabels()
        {
            this.lblGoodsAndServicesTax.DataBindings.Clear();
            this.lblGoodsAndServicesTax.Text = string.Empty;
            this.lblProvincialSalesTax.DataBindings.Clear();
            this.lblProvincialSalesTax.Text = string.Empty;
            this.lblSubtotal.DataBindings.Clear();
            this.lblSubtotal.Text = string.Empty;
            this.lblTotal.DataBindings.Clear();
            this.lblTotal.Text = string.Empty;
        }

        /// <summary>
        /// Creates Packages and adds them to a BindingList.
        /// </summary>
        private void CreatePackages()
        {
            // TODO: make a csv of these and read them into the list like fragrances.
            // Interior
            List<string> standardInterior = new List<string>();

            List<string> deluxeInterior = new List<string>()
            {
                "Shampoo Carpets"
            };

            List<string> executiveInterior = new List<string>()
            {
                "Shampoo Carpets",
                "Shampoo Upholstery"
            };

            List<string> luxuryInterior = new List<string>()
            {
                "Shampoo Carpets",
                "Shampoo Upholstery",
                "Interior Protection Coat",
            };

            // Exterior
            List<string> standardExterior = new List<string>()
            {
                "Hand Wash"
            };

            List<string> deluxeExterior = new List<string>()
            {
                "Hand Wash",
                "Hand Wax"
            };

            List<string> executiveExterior = new List<string>()
            {
                "Hand Wash",
                "Hand Wax",
                "Wheel Polish"
            };

            List<string> luxuryExterior = new List<string>()
            {
                "Hand Wash",
                "Hand Wax",
                "Wheel Polish",
                "Detail Engine Compartment"
            };

            Package standardPackage = new Package("Standard", 7.5M, standardInterior, standardExterior);
            Package deluxePackage = new Package("Deluxe", 15M, deluxeInterior, deluxeExterior);
            Package executivePackage = new Package("Executive", 35M, executiveInterior, executiveExterior);
            Package luxuryPackage = new Package("Luxury", 55M, luxuryInterior, luxuryExterior);

            packageBinding.Add(standardPackage);
            packageBinding.Add(deluxePackage);
            packageBinding.Add(executivePackage);
            packageBinding.Add(luxuryPackage);
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
