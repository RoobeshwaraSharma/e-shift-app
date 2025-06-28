using e_shift_app.db;
using e_shift_app.lib;
using e_shift_app.models;
using e_shift_app.views.admin;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Forms;

namespace e_shift_app.views.customer
{
    public partial class CustomerGridView : Form
    {
        private readonly AppDbContext _appDbContext;
        private readonly IServiceProvider _provider;
        private BindingList<Customer>? customerBindingList;

        // Add these fields to your class
        private int _hoveredRowIndex = -1;
        private int _hoveredButton = -1; // 0 = none, 1 = delete, 2 = reset

        public CustomerGridView(AppDbContext db, IServiceProvider provider)
        {
            _appDbContext = db;
            InitializeComponent();
            _provider = provider;
        }

        private void CustomerGrid_Load(object sender, EventArgs e)
        {
            customerDatagrid.AllowUserToAddRows = false;
            customerDatagrid.AllowUserToDeleteRows = false;
            customerDatagrid.ReadOnly = false;
            customerDatagrid.EditMode = DataGridViewEditMode.EditProgrammatically;
            customerDatagrid.DefaultCellStyle.SelectionBackColor = customerDatagrid.DefaultCellStyle.BackColor;
            customerDatagrid.DefaultCellStyle.SelectionForeColor = customerDatagrid.DefaultCellStyle.ForeColor;
            customerDatagrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = customerDatagrid.ColumnHeadersDefaultCellStyle.BackColor;
            customerDatagrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = customerDatagrid.ColumnHeadersDefaultCellStyle.ForeColor;

            LoadCustomers();

            // Add Delete button column if not added

            if (!customerDatagrid.Columns.Contains("Actions"))
            {
                var actionsCol = new DataGridViewTextBoxColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    ReadOnly = true
                };
                customerDatagrid.Columns.Add(actionsCol);
                customerDatagrid.Columns["Actions"].Width = 240;
            }
            else
            {
                customerDatagrid.Columns["Actions"].Width = 240;
            }

            customerDatagrid.CellPainting += dataGridView1_CellPainting;
            customerDatagrid.CellClick += dataGridView1_CellClick;
            customerDatagrid.CellEndEdit += customerDatagrid_CellEndEdit;
            customerDatagrid.CellDoubleClick += customerDatagrid_CellDoubleClick;
            customerDatagrid.MouseMove += dataGridView1_MouseMove;
            customerDatagrid.MouseLeave += dataGridView1_MouseLeave;
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
            var customerList = _appDbContext.Customers.ToList();
            customerBindingList = new BindingList<Customer>(customerList);
            customerDatagrid.DataSource = customerBindingList;
        }


        private void customerDatagrid_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var customer = customerDatagrid.Rows[e.RowIndex].DataBoundItem as Customer;
            if (customer != null)
            {
                _appDbContext.Customers.Update(customer);
                _appDbContext.SaveChanges();
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == customerDatagrid.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int deleteBtnWidth = 70;
                int spacing = 10;
                int resetBtnWidth = e.CellBounds.Width - deleteBtnWidth - (3 * spacing);

                Rectangle deleteButton = new Rectangle(e.CellBounds.Left + spacing, e.CellBounds.Top + 5, deleteBtnWidth, e.CellBounds.Height - 8);
                Rectangle resetButton = new Rectangle(e.CellBounds.Left + deleteBtnWidth + (2 * spacing), e.CellBounds.Top + 5, resetBtnWidth, e.CellBounds.Height - 8);

                var stateDelete = (_hoveredRowIndex == e.RowIndex && _hoveredButton == 1)
                    ? System.Windows.Forms.VisualStyles.PushButtonState.Hot
                    : System.Windows.Forms.VisualStyles.PushButtonState.Default;
                var stateReset = (_hoveredRowIndex == e.RowIndex && _hoveredButton == 2)
                    ? System.Windows.Forms.VisualStyles.PushButtonState.Hot
                    : System.Windows.Forms.VisualStyles.PushButtonState.Default;

                ButtonRenderer.DrawButton(e.Graphics, deleteButton, "Delete", customerDatagrid.Font, false, stateDelete);
                ButtonRenderer.DrawButton(e.Graphics, resetButton, "Reset Password", customerDatagrid.Font, false, stateReset);

                e.Handled = true;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == customerDatagrid.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cellRect = customerDatagrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                int deleteBtnWidth = 70;
                int spacing = 10;
                int resetBtnWidth = cellRect.Width - deleteBtnWidth - (3 * spacing);

                Rectangle deleteButton = new Rectangle(
                    cellRect.Left + spacing,
                    cellRect.Top + 7,
                    deleteBtnWidth,
                    cellRect.Height - 10);

                Rectangle resetButton = new Rectangle(
                    cellRect.Left + deleteBtnWidth + (2 * spacing),
                    cellRect.Top + 7,
                    resetBtnWidth,
                    cellRect.Height - 10);

                var mouse = customerDatagrid.PointToClient(Cursor.Position);

                if (deleteButton.Contains(mouse))
                {
                    var customer = customerDatagrid.Rows[e.RowIndex].DataBoundItem as Customer;
                    if (customer != null)
                    {
                        var confirm = MessageBox.Show("Delete this customer?", "Confirm", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            _appDbContext.Customers.Remove(customer);
                            _appDbContext.SaveChanges();
                            customerBindingList?.Remove(customer);
                        }
                    }
                }
                else if (resetButton.Contains(mouse))
                {
                    var customer = customerDatagrid.Rows[e.RowIndex].DataBoundItem as Customer;
                    if (customer != null)
                    {
                        ShowResetPasswordDialog(customer);
                    }
                }
            }
        }
        private void ShowResetPasswordDialog(Customer customer)
        {
            using (var form = new Form())
            {
                form.Text = "Reset Password";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(320, 180);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var labelPassword = new Label() { Left = 20, Top = 20, Text = "New Password", AutoSize = true };
                var textBoxPassword = new TextBox() { Left = 20, Top = 45, Width = 260, UseSystemPasswordChar = true };

                var labelConfirm = new Label() { Left = 20, Top = 80, Text = "Confirm Password", AutoSize = true };
                var textBoxConfirm = new TextBox() { Left = 20, Top = 105, Width = 260, UseSystemPasswordChar = true };

                var buttonOk = new Button() { Text = "Submit", Left = 110, Width = 80, Top = 140, DialogResult = DialogResult.OK };
                form.Controls.Add(labelPassword);
                form.Controls.Add(textBoxPassword);
                form.Controls.Add(labelConfirm);
                form.Controls.Add(textBoxConfirm);
                form.Controls.Add(buttonOk);
                form.AcceptButton = buttonOk;

                buttonOk.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
                    {
                        MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                    if (textBoxPassword.Text != textBoxConfirm.Text)
                    {
                        MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                };

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var newPassword = textBoxPassword.Text;
                    customer.PasswordHash = PasswordHelper.Hash(newPassword);
                    _appDbContext.Customers.Update(customer);
                    _appDbContext.SaveChanges();
                    MessageBox.Show("Password reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = customerDatagrid.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == customerDatagrid.Columns["Actions"].Index && hit.RowIndex >= 0)
            {
                var cellRect = customerDatagrid.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false);
                int deleteBtnWidth = 70;
                int spacing = 10;
                int resetBtnWidth = cellRect.Width - deleteBtnWidth - (3 * spacing);

                Rectangle deleteButton = new Rectangle(cellRect.Left + spacing, cellRect.Top + 5, deleteBtnWidth, cellRect.Height - 10);
                Rectangle resetButton = new Rectangle(cellRect.Left + deleteBtnWidth + (2 * spacing), cellRect.Top + 5, resetBtnWidth, cellRect.Height - 10);

                var mouse = new Point(e.X, e.Y);

                int hoveredButton = 0;
                if (deleteButton.Contains(mouse))
                    hoveredButton = 1;
                else if (resetButton.Contains(mouse))
                    hoveredButton = 2;

                if (_hoveredRowIndex != hit.RowIndex || _hoveredButton != hoveredButton)
                {
                    _hoveredRowIndex = hit.RowIndex;
                    _hoveredButton = hoveredButton;
                    customerDatagrid.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
                }
            }
            else
            {
                if (_hoveredRowIndex != -1 || _hoveredButton != -1)
                {
                    int prevRow = _hoveredRowIndex;
                    _hoveredRowIndex = -1;
                    _hoveredButton = -1;
                    if (prevRow >= 0)
                        customerDatagrid.InvalidateCell(customerDatagrid.Columns["Actions"].Index, prevRow);
                }
            }
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex != -1 || _hoveredButton != -1)
            {
                int prevRow = _hoveredRowIndex;
                _hoveredRowIndex = -1;
                _hoveredButton = -1;
                if (prevRow >= 0)
                    customerDatagrid.InvalidateCell(customerDatagrid.Columns["Actions"].Index, prevRow);
            }
        }

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            var customerForm = _provider.GetRequiredService<CustomerForm>();
            customerForm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }
    }
}
