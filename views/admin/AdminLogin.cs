using e_shift_app.db;
using e_shift_app.lib;
using e_shift_app.models;
using e_shift_app.views.customer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_shift_app.views.admin
{
    public partial class AdminLogin : Form
    {
        private readonly AppDbContext _appDbContext;
        private readonly IServiceProvider _provider;
        public AdminLogin(AppDbContext appDbContext, IServiceProvider provider)
        {
            InitializeComponent();
            _appDbContext = appDbContext;
            _provider = provider;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            Admins? admin = _appDbContext.Admins.FirstOrDefault(u => u.Username == username);


            if (admin != null && PasswordHelper.Verify(password, admin.PasswordHash))
            {
                Session.LoggedInUser = admin;

                if (admin.Role == "Admin")
                {
                    // Resolve & show the grid form from DI
                    var gridView = _provider.GetRequiredService<CustomerGridView>();
                    gridView.Show();
                }


                this.Hide(); // Close login form
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Resolve & show the grid form from DI
            var adminForm = _provider.GetRequiredService<AdminForm>();
            adminForm.Show();
            this.Hide();
        }
    }
}
