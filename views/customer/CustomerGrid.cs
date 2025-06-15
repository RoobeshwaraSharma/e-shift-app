using e_shift_app.db;
using e_shift_app.models;
using System.ComponentModel;

namespace e_shift_app.views.customer
{
    public partial class CustomerGridView : Form
    {
        private readonly AppDbContext _db;
        private BindingList<Customer>? customerBindingList;

        public CustomerGridView(AppDbContext db)
        {
            _db = db;
            InitializeComponent();
        }

        private void CustomerGrid_Load(object sender, EventArgs e)
        {
            customerDatagrid.AllowUserToAddRows = false;
            customerDatagrid.AllowUserToDeleteRows = false;
            customerDatagrid.ReadOnly = false;
            customerDatagrid.EditMode = DataGridViewEditMode.EditProgrammatically;
            LoadCustomers();

            // Add Delete button column if not added
            if (!customerDatagrid.Columns.Contains("Delete"))
            {
                var deleteBtn = new DataGridViewButtonColumn
                {
                    Name = "Action",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                customerDatagrid.Columns.Add(deleteBtn);
            }

            customerDatagrid.CellClick += customerDatagrid_CellClick;
            customerDatagrid.CellEndEdit += customerDatagrid_CellEndEdit;
            customerDatagrid.CellDoubleClick += customerDatagrid_CellDoubleClick;
        }
        private void customerDatagrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                customerDatagrid.CurrentCell = customerDatagrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                customerDatagrid.BeginEdit(true);
            }
        }

        private void LoadCustomers()
        {
            var customerList = _db.Customers.ToList();
            customerBindingList = new BindingList<Customer>(customerList);
            customerDatagrid.DataSource = customerBindingList;
        }


        private void customerDatagrid_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var customer = customerDatagrid.Rows[e.RowIndex].DataBoundItem as Customer;
            if (customer != null)
            {
                _db.Customers.Update(customer);
                _db.SaveChanges();
            }
        }

        private void customerDatagrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on headers or out-of-bounds indices
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Ensure the column exists and is valid
            if (e.ColumnIndex >= customerDatagrid.Columns.Count)
                return;

            var column = customerDatagrid.Columns[e.ColumnIndex];

            if (column.Name == "Delete")
            {
                var customer = customerDatagrid.Rows[e.RowIndex].DataBoundItem as Customer;

                if (customer != null)
                {
                    var confirm = MessageBox.Show("Delete this customer?", "Confirm", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        _db.Customers.Remove(customer);
                        _db.SaveChanges();

                        customerBindingList?.Remove(customer);
                    }
                }
            }
        }


    }
}
