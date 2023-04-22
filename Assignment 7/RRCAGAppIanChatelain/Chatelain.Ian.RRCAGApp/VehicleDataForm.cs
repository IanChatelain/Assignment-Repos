/*
 * Name: Ian Chatelain
 * Program: Business Information Technology
 * Course: ADEV-2008 (234110) Programming 2
 * Created: 08/03/2023
 * Updated: 21/04/2023
 */

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACE.BIT.ADEV.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Chatelain.Ian.RRCAGApp
{
    /// <summary>
    /// Represents a VehicleDataForm.
    /// </summary>
    public partial class VehicleDataForm : ACE.BIT.ADEV.Forms.VehicleDataForm
    {
        private BindingSource bindingSource;
        private OleDbDataAdapter dataAdapter;
        private OleDbConnection connection;
        private DataSet dataSet;

        /// <summary>
        /// Initializes an instance of the VehicleDataForm.
        /// </summary>
        public VehicleDataForm()
        {
            this.dataAdapter = new OleDbDataAdapter();
            this.bindingSource = new BindingSource();

            GetData();

            DataBind();

            this.Load += VehicleDataForm_Load;
        }

        /// <summary>
        /// Handles the VehicleDataForm Load event.
        /// </summary>
        private void VehicleDataForm_Load(object sender, EventArgs e)
        {
            this.Text = "Vehicle Data";
            this.mnuFileSave.Enabled = false;
            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.AllowUserToResizeRows = false;
            this.dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.WindowState = FormWindowState.Maximized;
            this.dgvVehicles.MultiSelect = false;

            this.dataAdapter.RowUpdated += new OleDbRowUpdatedEventHandler(DataAdapter_RowUpdated);
            this.dgvVehicles.RowsRemoved += new DataGridViewRowsRemovedEventHandler(ChangesMade);
            this.dgvVehicles.CellValueChanged += new DataGridViewCellEventHandler(ChangesMade);
            this.dgvVehicles.SelectionChanged += DgvVehicles_SelectionChanged;
            this.mnuEditDelete.Click += MnuEditDelete_Click;
            this.mnuFileSave.Click += MnuFileSave_Click1;
            this.mnuFileClose.Click += MnuFileClose_Click;
            this.FormClosing += new FormClosingEventHandler(VehicleDataForm_FormClosing);
        }

        /// <summary>
        /// Handles the data adapters RowUpdated event.
        /// </summary>
        private void DataAdapter_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", connection);

                e.Row["ID"] = (int)cmd.ExecuteScalar();
                e.Row["SoldBy"] = 0;
            }
        }

        /// <summary>
        /// Handles changes made in the DGV Cell or Row event.
        /// </summary>
        private void ChangesMade(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handles the DataGridView SelectionChanged event.
        /// </summary>
        private void DgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (((DataGridView)sender).SelectedRows.Count > 0)
            {
                if (!((DataGridView)sender).SelectedRows[0].IsNewRow)
                {
                    this.mnuEditDelete.Enabled = true;
                }
                else
                {
                    this.mnuEditDelete.Enabled = false;
                }
            }
            else
            {
                this.mnuEditDelete.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Menu Edit Delete
        /// </summary>
        private void MnuEditDelete_Click(object sender, EventArgs e)
        {
            string message = String.Format("Are you sure you want to permanently delete stock item {0}", this.dgvVehicles.CurrentRow.Cells[this.dgvVehicles.CurrentCell.ColumnIndex].Value.ToString());
            DialogResult result = MessageBox.Show(message, "Delete Stock Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    this.dgvVehicles.Rows.RemoveAt(this.dgvVehicles.CurrentRow.Index);
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occurred while deleting the selected vehicle", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.mnuEditDelete.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the menu strip File Save click event.
        /// </summary>
        private void MnuFileSave_Click1(object sender, EventArgs e)
        {
            try
            {
                UpdateAdapter();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while saving changes to the vehicle data", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateUI();
        }


        /// <summary>
        /// Handles the Menu File Close click event.
        /// </summary>
        private void MnuFileClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the VehicleDataForm FormClosing event.
        /// </summary>
        private void VehicleDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dataSet.HasChanges())
            {
                DialogResult result = MessageBox.Show("Do you wish to save changes?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        UpdateAdapter();
                    }
                    catch (Exception)
                    {
                        DialogResult closeResult = MessageBox.Show("An error occurred while saving. Do you still wish to close?", "Save Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (closeResult == DialogResult.Yes)
                        {
                            this.connection.Close();
                            this.connection.Dispose();
                        }
                        if (closeResult == DialogResult.No)
                        {
                            e.Cancel = (closeResult == DialogResult.No);
                        }
                    }
                }

                if (result == DialogResult.No)
                {
                    this.connection.Close();
                    this.connection.Dispose();
                }

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = (result == DialogResult.Cancel);
                }
            }
        }

        /// <summary>
        /// Gets data from the database.
        /// </summary>
        private void GetData()
        {
            try
            {
                string queryString = "SELECT * FROM VehicleStock";
                string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = AMDatabase.mdb";

                this.connection = new OleDbConnection(connectionString);
                OleDbCommand selectCommand = new OleDbCommand(queryString, this.connection);

                this.connection.Open();

                this.dataAdapter = new OleDbDataAdapter();
                this.dataAdapter.SelectCommand = selectCommand;

                OleDbCommandBuilder builder = new OleDbCommandBuilder();
                builder.DataAdapter = this.dataAdapter;
                builder.ConflictOption = ConflictOption.OverwriteChanges;

                this.dataAdapter.InsertCommand = builder.GetInsertCommand();
                this.dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                this.dataAdapter.DeleteCommand = builder.GetDeleteCommand();

                this.dataSet = new DataSet();

                this.dataAdapter.Fill(this.dataSet, "VehicleStock");
                this.dataSet.AcceptChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load vehicle data", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Sets the DataGridView data binding.
        /// </summary>
        private void DataBind()
        {
            if (!(this.dataSet == null))
            {
                this.bindingSource.DataSource = this.dataSet.Tables["VehicleStock"];
                this.dgvVehicles.DataSource = this.bindingSource;
                this.dgvVehicles.Columns["ID"].Visible = false;
                this.dgvVehicles.Columns["SoldBy"].Visible = false;
            }
        }

        /// <summary>
        /// Sets the Menu File Save item to enabled and changes the VehicleDataForm text.
        /// </summary>
        private void UpdateUI()
        {
            bindingSource.EndEdit();

            if (this.dataSet.HasChanges())
            {
                this.Text = "* Vehicle Data";
                this.mnuFileSave.Enabled = true;
            }
            else
            {
                this.Text = "Vehicle Data";
                this.mnuFileSave.Enabled = false;
            }
        }

        /// <summary>
        /// Updates the data adapter.
        /// </summary>
        private void UpdateAdapter()
        {
            this.dgvVehicles.EndEdit();
            this.bindingSource.EndEdit();

            this.dataAdapter.Update(this.dataSet.Tables["VehicleStock"]);
        }
    }
}

