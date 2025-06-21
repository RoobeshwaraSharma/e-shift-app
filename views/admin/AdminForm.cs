using e_shift_app.db;
using e_shift_app.lib;
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

namespace e_shift_app.views.admin
{
    public partial class AdminForm : Form
    {
        private readonly AppDbContext _appDbContext;
        private readonly IServiceProvider _provider;

        public AdminForm(AppDbContext appDbContext, IServiceProvider provider)
        {
            InitializeComponent();
            _appDbContext = appDbContext;
            _provider = provider;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate password match
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var admin = new Admins
            {
                FullName = txtFullName.Text,
                Username = txtUsername.Text,
                PasswordHash = PasswordHelper.Hash(txtPassword.Text),
                Role = "Admin",
                CreatedDate = DateTime.Now,
            };

            try
            {
                _appDbContext.Admins.Add(admin);
                await _appDbContext.SaveChangesAsync();

                MessageBox.Show("Admin saved successfully!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving admin: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void txtReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
