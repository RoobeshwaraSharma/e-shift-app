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

namespace e_shift_app.views.job
{
    public partial class JobForm : Form
    {
        private readonly AppDbContext _appDbContext;
        private readonly IServiceProvider _provider;
        public JobForm(AppDbContext context, IServiceProvider service)
        {
            InitializeComponent();
            _appDbContext = context;
            _provider = service;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtStartLocationAddress.Text) ||
                string.IsNullOrWhiteSpace(txtEndLocationAddress.Text) ||
                dtpStart.Value == null ||
                dtpEnd.Value == null)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Session.LoggedInUser is not Customer customer)
            {
                MessageBox.Show("No logged in customer found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Additional validation: EndDate should not be before StartDate
            if (dtpEnd.Value < dtpStart.Value)
            {
                MessageBox.Show("End date cannot be before start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var job = new Job
            {
                CustomerId = customer.Id,
                StartLocation = txtStartLocationAddress.Text,
                EndLocation = txtEndLocationAddress.Text,
                StartDate = dtpStart.Value,
                EndDate = dtpEnd.Value,
                // Status will default to Submitted
            };

            try
            {
                _appDbContext.Jobs.Add(job);
                _appDbContext.SaveChanges();

                MessageBox.Show("Job submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtStartLocationAddress.Clear();
            txtEndLocationAddress.Clear();
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
        }
    }
}
