using e_shift_app.db;
using e_shift_app.lib;
using e_shift_app.models;
using e_shift_app.views.admin;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Linq;

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

        /// <summary>
        /// Initialize the customers grid UI and wire up event handlers.
        /// Loads customers from the database and configures the actions column.
        /// </summary>
        private void CustomerGrid_Load(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing customer grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void customerDatagrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    customerDatagrid.CurrentCell = customerDatagrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    customerDatagrid.BeginEdit(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load customers from the database into the grid's data source.
        /// </summary>
        private void LoadCustomers()
        {
            try
            {
                var customerList = _appDbContext.Customers.ToList();
                customerBindingList = new BindingList<Customer>(customerList);
                customerDatagrid.DataSource = customerBindingList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Persist edits for a customer row back to the database.
        /// </summary>
        private void customerDatagrid_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                var customer = customerDatagrid.Rows[e.RowIndex].DataBoundItem as Customer;
                if (customer != null)
                {
                    _appDbContext.Customers.Update(customer);
                    _appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Paint custom action buttons (Delete, Reset Password) inside the Actions column.
        /// </summary>
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error rendering customer action buttons: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle clicks on custom action buttons inside the Actions column.
        /// Delegates to delete or reset password flows.
        /// </summary>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling customer action click: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Show dialog to reset a customer's password and persist the hashed password.
        /// </summary>
        private void ShowResetPasswordDialog(Customer customer)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Track mouse movement to show hover state for action buttons.
        /// </summary>
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling mouse move on customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clear hover state when the mouse leaves the datagrid.
        /// </summary>
        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling mouse leave on customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Open the CustomerForm to create a new customer.
        /// </summary>
        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var customerForm = _provider.GetRequiredService<CustomerForm>();
                customerForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening customer form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reload the customers list from the database.
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export visible data columns (excluding Actions) to a CSV file.
        /// </summary>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (customerDatagrid.Columns.Count == 0 || customerDatagrid.Rows.Count == 0)
                {
                    MessageBox.Show("No data available to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Use SaveFileDialog to select destination
                using var sfd = new SaveFileDialog()
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    FileName = $"customers_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Export Customers to CSV"
                };

                if (sfd.ShowDialog(this) != DialogResult.OK) return;

                var sb = new StringBuilder();

                // Collect data columns only (have DataPropertyName) and exclude Actions
                var dataColumns = customerDatagrid.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible && !string.Equals(c.Name, "Actions", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(c.DataPropertyName))
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                // Header
                sb.AppendLine(string.Join(",", dataColumns.Select(c => EscapeForCsv(string.IsNullOrWhiteSpace(c.HeaderText) ? c.DataPropertyName : c.HeaderText))));

                // Rows
                foreach (DataGridViewRow row in customerDatagrid.Rows)
                {
                    if (row.IsNewRow) continue;

                    var values = new List<string>();
                    foreach (var col in dataColumns)
                    {
                        var cell = row.Cells[col.Index];
                        var val = cell?.Value;
                        if (val == null)
                        {
                            values.Add("");
                            continue;
                        }

                        string text;
                        if (val is DateTime dt)
                            text = dt.ToString("o");
                        else
                            text = val.ToString() ?? string.Empty;

                        values.Add(EscapeForCsv(text));
                    }

                    sb.AppendLine(string.Join(",", values));
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show($"Export completed: {sfd.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscapeForCsv(string input)
        {
            if (input == null) return string.Empty;
            var needsQuotes = input.Contains(',') || input.Contains('"') || input.Contains('\n') || input.Contains('\r');
            var escaped = input.Replace("\"", "\"\"");
            return needsQuotes ? $"\"{escaped}\"" : escaped;
        }
    }
}
