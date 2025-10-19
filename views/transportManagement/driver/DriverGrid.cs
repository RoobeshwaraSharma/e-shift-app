using e_shift_app.db;
using e_shift_app.models;
using System.ComponentModel;

namespace e_shift_app.views.transportManagement.driver
{
    public partial class DriverGrid : Form
    {
        private readonly AppDbContext _appDbContext;
        private BindingList<Driver>? driverBindingList;

        private int _hoveredRowIndex = -1;
        private int _hoveredButton = -1; // 0 = none, 1 = delete

        public DriverGrid(AppDbContext dbContext)
        {
            InitializeComponent();
            _appDbContext = dbContext;
        }

        private void DriverGrid_Load(object sender, EventArgs e)
        {
            driverGridView.AllowUserToAddRows = false;
            driverGridView.AllowUserToDeleteRows = false;
            driverGridView.ReadOnly = false;
            driverGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            driverGridView.DefaultCellStyle.SelectionBackColor = driverGridView.DefaultCellStyle.BackColor;
            driverGridView.DefaultCellStyle.SelectionForeColor = driverGridView.DefaultCellStyle.ForeColor;
            driverGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = driverGridView.ColumnHeadersDefaultCellStyle.BackColor;
            driverGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = driverGridView.ColumnHeadersDefaultCellStyle.ForeColor;

            LoadDrivers();

            if (!driverGridView.Columns.Contains("Actions"))
            {
                var actionsCol = new DataGridViewTextBoxColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    ReadOnly = true
                };
                driverGridView.Columns.Add(actionsCol);
                driverGridView.Columns["Actions"].Width = 120;
            }
            else
            {
                driverGridView.Columns["Actions"].Width = 120;
            }

            driverGridView.CellPainting += driverGridView_CellPainting;
            driverGridView.CellClick += driverGridView_CellClick;
            driverGridView.CellEndEdit += driverGridView_CellEndEdit;
            driverGridView.CellDoubleClick += driverGridView_CellDoubleClick;
            driverGridView.MouseMove += driverGridView_MouseMove;
            driverGridView.MouseLeave += driverGridView_MouseLeave;
        }

        private void LoadDrivers()
        {
            var driverList = _appDbContext.Drivers.ToList();
            driverBindingList = new BindingList<Driver>(driverList);
            driverGridView.DataSource = driverBindingList;
        }

        private void driverGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                driverGridView.CurrentCell = driverGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                driverGridView.BeginEdit(true);
            }
        }

        private void driverGridView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var driver = driverGridView.Rows[e.RowIndex].DataBoundItem as Driver;
            if (driver != null)
            {
                _appDbContext.Drivers.Update(driver);
                _appDbContext.SaveChanges();
            }
        }

        private void driverGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == driverGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int deleteBtnWidth = 70;
                int spacing = 10;

                Rectangle deleteButton = new Rectangle(e.CellBounds.Left + spacing, e.CellBounds.Top + 5, deleteBtnWidth, e.CellBounds.Height - 8);

                var stateDelete = (_hoveredRowIndex == e.RowIndex && _hoveredButton == 1)
                    ? System.Windows.Forms.VisualStyles.PushButtonState.Hot
                    : System.Windows.Forms.VisualStyles.PushButtonState.Default;

                ButtonRenderer.DrawButton(e.Graphics, deleteButton, "Delete", driverGridView.Font, false, stateDelete);

                e.Handled = true;
            }
        }

        private void driverGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == driverGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cellRect = driverGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int deleteBtnWidth = 70;
                Rectangle deleteButton = new Rectangle(cellRect.Left, cellRect.Top + 7, deleteBtnWidth, cellRect.Height - 10);
                var mouse = driverGridView.PointToClient(Cursor.Position);

                if (deleteButton.Contains(mouse))
                {
                    var driver = driverGridView.Rows[e.RowIndex].DataBoundItem as Driver;
                    if (driver != null)
                    {
                        var confirm = MessageBox.Show("Delete this driver?", "Confirm", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            _appDbContext.Drivers.Remove(driver);
                            _appDbContext.SaveChanges();
                            driverBindingList?.Remove(driver);
                        }
                    }
                }
            }
        }

        private void driverGridView_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = driverGridView.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == driverGridView.Columns["Actions"].Index && hit.RowIndex >= 0)
            {
                var cellRect = driverGridView.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false);
                int deleteBtnWidth = 70;
                Rectangle deleteButton = new Rectangle(cellRect.Left, cellRect.Top + 5, deleteBtnWidth, cellRect.Height - 10);
                var mouse = new Point(e.X, e.Y);

                int hoveredButton = 0;
                if (deleteButton.Contains(mouse))
                    hoveredButton = 1;

                if (_hoveredRowIndex != hit.RowIndex || _hoveredButton != hoveredButton)
                {
                    _hoveredRowIndex = hit.RowIndex;
                    _hoveredButton = hoveredButton;
                    driverGridView.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
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
                        driverGridView.InvalidateCell(driverGridView.Columns["Actions"].Index, prevRow);
                }
            }
        }

        private void driverGridView_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex != -1 || _hoveredButton != -1)
            {
                int prevRow = _hoveredRowIndex;
                _hoveredRowIndex = -1;
                _hoveredButton = -1;
                if (prevRow >= 0)
                    driverGridView.InvalidateCell(driverGridView.Columns["Actions"].Index, prevRow);
            }
        }

        private void btnAddDriver_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Add Driver";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(320, 240);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var labelName = new Label() { Left = 20, Top = 20, Text = "Name", AutoSize = true };
                var textBoxName = new TextBox() { Left = 20, Top = 45, Width = 250 };

                var labelLicense = new Label() { Left = 20, Top = 80, Text = "License Number", AutoSize = true };
                var textBoxLicense = new TextBox() { Left = 20, Top = 105, Width = 250 };

                var labelPhoneNumber = new Label() { Left = 20, Top = 140, Text = "Phone Number", AutoSize = true };
                var textBoxPhone = new TextBox() { Left = 20, Top = 165, Width = 250 };

                var buttonOk = new Button() { Text = "Submit", Left = 110, Width = 80, Top = 200, DialogResult = DialogResult.OK };
                form.Controls.Add(labelName);
                form.Controls.Add(textBoxName);
                form.Controls.Add(labelLicense);
                form.Controls.Add(textBoxLicense);
                form.Controls.Add(labelPhoneNumber);
                form.Controls.Add(textBoxPhone);
                form.Controls.Add(buttonOk);
                form.AcceptButton = buttonOk;

                buttonOk.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(textBoxName.Text))
                    {
                        MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxLicense.Text))
                    {
                        MessageBox.Show("License Number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
                    {
                        MessageBox.Show("Phone Number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                };

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var driver = new Driver
                    {
                        Name = textBoxName.Text.Trim(),
                        LicenseNumber = textBoxLicense.Text.Trim(),
                        PhoneNumber = textBoxPhone.Text.Trim()
                    };
                    _appDbContext.Drivers.Add(driver);
                    _appDbContext.SaveChanges();
                    LoadDrivers();
                    MessageBox.Show("Driver added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
