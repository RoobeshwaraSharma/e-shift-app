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
    public partial class AdminDashboard : Form
    {
        private readonly IServiceProvider _provider;
        public AdminDashboard(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            // Resolve & show the admin grid form from DI
            var adminGrid = _provider.GetRequiredService<AdminGrid>();
            adminGrid.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var customerGrid = _provider.GetRequiredService<CustomerGridView>();
            customerGrid.Show();
        }
    }
}
