using e_shift_app.db;
using e_shift_app.lib;
using e_shift_app.models;
using e_shift_app.views.customer;
using Microsoft.Extensions.DependencyInjection;

namespace e_shift_app
{
    public partial class CustomerForm : Form
    {
        private readonly AppDbContext _appDbContext;
        private readonly IServiceProvider _provider;
        public CustomerForm(AppDbContext appDbContext, IServiceProvider provider)
        {
            InitializeComponent();
            _appDbContext = appDbContext;
            _provider = provider;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtUserPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate password match
            if (txtUserPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var customer = new Customer
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
                RegisteredDate = DateTime.Now,
                Username = txtUsername.Text,
                PasswordHash = PasswordHelper.Hash(txtUserPassword.Text),
                Role = "Customer"
            };

            try
            {
                _appDbContext.Customers.Add(customer);
                await _appDbContext.SaveChangesAsync();

                MessageBox.Show("Customer saved successfully!",
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
            txtName.Clear();
            txtAddress.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtUserPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }


        private void btnViewGrid_Click(object sender, EventArgs e)
        {

            // Resolve & show the grid form from DI
            var gridForm = _provider.GetRequiredService<CustomerGridView>();
            gridForm.Show();  // or ShowDialog() if you prefer modal
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
