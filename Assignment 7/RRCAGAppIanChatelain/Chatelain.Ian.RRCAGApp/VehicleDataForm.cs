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
    public partial class VehicleDataForm : ACE.BIT.ADEV.Forms.VehicleDataForm
    {
        private BindingSource bindingSource = new BindingSource();
        private OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        private OleDbConnection connection;
        private DataSet dataSet;
        OleDbCommandBuilder builder = new OleDbCommandBuilder();
        private bool formLoaded = false;

        public VehicleDataForm()
        {
            this.Load += VehicleDataForm_Load;
        }

        private void VehicleDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.connection.Close();
            this.connection.Dispose();
        }

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

        private void DgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (((DataGridView)sender).SelectedRows.Count > 0)
            {
                this.mnuEditDelete.Enabled = true;
            }
            else
            {
                this.mnuEditDelete.Enabled = false;
            }
        }

        private void MnuFileSave_Click(object sender, EventArgs e)
        {
            
        }

        private void VehicleDataForm_Load(object sender, EventArgs e)
        {
            GetData();

            BindControls();

            InitialState();

            this.dgvVehicles.RowsRemoved += DgvVehicles_RowsRemoved;
            this.dgvVehicles.CellValueChanged += DgvVehicles_CellValueChanged;
            this.dgvVehicles.SelectionChanged += DgvVehicles_SelectionChanged;
            this.mnuFileSave.Click += MnuFileSave_Click;
            this.mnuEditDelete.Click += MnuEditDelete_Click;
            this.mnuFileSave.Click += MnuFileSave_Click1;
            this.FormClosing += VehicleDataForm_FormClosing;
        }

        private void DgvVehicles_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            MessageBox.Show("RowsRemoved event raised.");
            HandleChanges();
        }

        private void DgvVehicles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            HandleChanges();
        }

        private void MnuFileSave_Click1(object sender, EventArgs e)
        {
            try
            {
                this.dgvVehicles.EndEdit();
                this.bindingSource.EndEdit();

                this.dataAdapter.Update(this.dataSet.Tables["VehicleStock"]);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while saving changes to the vehicle data", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Text = "Vehicle Data";
            this.mnuFileSave.Enabled = false;
        }


        private void InitialState()
        {
            this.Text = "Vehicle Data";
            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.AllowUserToResizeRows = false;
            this.dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicles.MultiSelect = false;
            this.dgvVehicles.Columns["ID"].Visible = false;
            this.dgvVehicles.Columns["SoldBy"].Visible = false;
        }

        private void GetData()
        {
            try
            {
                string queryString = "SELECT * FROM VehicleStock";
                string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = AMDatabase.mdb";

                this.dataAdapter = new OleDbDataAdapter();
                this.connection = new OleDbConnection(connectionString);
                OleDbCommand selectCommand = new OleDbCommand(queryString, this.connection);

                this.connection.Open();

                this.dataAdapter.SelectCommand = selectCommand;

                this.builder.DataAdapter = this.dataAdapter;
                this.builder.ConflictOption = ConflictOption.OverwriteChanges;

                this.dataAdapter.InsertCommand = builder.GetInsertCommand();
                this.dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                this.dataAdapter.DeleteCommand = builder.GetDeleteCommand();

                this.dataSet = new DataSet();

                this.dataAdapter.Fill(this.dataSet, "VehicleStock");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load vehicle data", "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleChanges()
        {
            this.Text = "* Vehicle Data";
            this.mnuFileSave.Enabled = true;
        }

        private void BindControls()
        {
            this.bindingSource.DataSource = this.dataSet.Tables["VehicleStock"];
            this.dgvVehicles.DataSource = this.bindingSource;
        }
    }
}

