using e_shift_app.db;
using e_shift_app.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace e_shift_app.views.transportManagement.lorry
{
    public partial class LorryForm : Form
    {
        private readonly AppDbContext _appDbContext;

        public LorryForm(AppDbContext dbContext)
        {
            InitializeComponent();
            _appDbContext = dbContext;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtModel.Text) ||
                string.IsNullOrWhiteSpace(txtRegistrationNumber.Text) ||
                string.IsNullOrWhiteSpace(txtYear.Text) || nCapacity.Value == 0)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var lorry = new Lorry()
            {
                Capacity = nCapacity.Value,
                Model = txtModel.Text,
                RegistrationNumber = txtRegistrationNumber.Text,
                Year = txtYear.Text,
            };
            try
            {
                _appDbContext.Lorries.Add(lorry);
                await _appDbContext.SaveChangesAsync();

                MessageBox.Show("Lorry details saved successfully!",
                   "Success",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }


        }
        private void ClearFields()
        {
            txtModel.Clear();
            txtRegistrationNumber.Clear();
            txtYear.Clear();
            nCapacity.Value = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
