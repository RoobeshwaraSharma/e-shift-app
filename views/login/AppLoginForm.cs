using e_shift_app.db;
using e_shift_app.lib;
using e_shift_app.models;
using e_shift_app.views.admin;
using e_shift_app.views.customer;
using Microsoft.Extensions.DependencyInjection;

namespace e_shift_app.views.login
{
    public partial class AppLoginForm : Form
    {
        private readonly AppDbContext _appDbContext;
        private readonly IServiceProvider _provider;
        public AppLoginForm(AppDbContext appDbContext, IServiceProvider provider)
        {
            InitializeComponent();
            _appDbContext = appDbContext;
            _provider = provider;

            // Set AcceptButton to trigger login on Enter key
            this.AcceptButton = btnLogin; // btnLogin is the login button
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            User? user = _appDbContext.Customers.FirstOrDefault(u => u.Username == username) as User
                                ?? _appDbContext.Admins.FirstOrDefault(u => u.Username == username);


            if (user != null && PasswordHelper.Verify(password, user.PasswordHash))
            {
                Session.LoggedInUser = user;

                if (user.Role == "Customer")
                {
                    // Resolve & show the grid form from DI
                    var customerDashboard = _provider.GetRequiredService<CustomerDashboard>();
                    customerDashboard.Show();
                }
                else if (user.Role == "Admin")
                {
                    // Resolve & show the grid form from DI
                    var adminDashboard = _provider.GetRequiredService<AdminDashboard>();
                    adminDashboard.Show();
                }

                this.Hide(); // Close login form
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Resolve & show the grid form from DI
            var customerForm = _provider.GetRequiredService<CustomerForm>();
            customerForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var adminLogin = _provider.GetRequiredService<AdminLogin>();
            adminLogin.Show();
            this.Hide(); // Close login form
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
