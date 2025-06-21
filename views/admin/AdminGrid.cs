using e_shift_app.db;
using e_shift_app.models;
using e_shift_app.views.customer;
using e_shift_app.lib;
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
    public partial class AdminGrid : Form
    {
        private readonly AppDbContext _appDbContext;
        private readonly IServiceProvider _provider;
        private BindingList<Admins>? adminBindingList;

        // Add these fields to your class
        private int _hoveredRowIndex = -1;
        private int _hoveredButton = -1; // 0 = none, 1 = delete, 2 = reset

        public AdminGrid(IServiceProvider provider, AppDbContext context)
        {
            InitializeComponent();
            _provider = provider;
            _appDbContext = context;
        }

        private void AdminGrid_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridView1.ColumnHeadersDefaultCellStyle.BackColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor = dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor;

            LoadAdmins();

            if (!dataGridView1.Columns.Contains("Actions"))
            {
                var actionsCol = new DataGridViewTextBoxColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    ReadOnly = true
                };
                dataGridView1.Columns.Add(actionsCol);
                dataGridView1.Columns["Actions"].Width = 240;
            }
            else
            {
                dataGridView1.Columns["Actions"].Width = 240;
            }

            dataGridView1.CellPainting += dataGridView1_CellPainting;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.MouseMove += dataGridView1_MouseMove;
            dataGridView1.MouseLeave += dataGridView1_MouseLeave;
        }

        private void LoadAdmins()
        {
            var adminList = _appDbContext.Admins.ToList();
            adminBindingList = new BindingList<Admins>(adminList);
            dataGridView1.DataSource = adminBindingList;
        }

        private void dataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView1.BeginEdit(true);
            }
        }

        private void dataGridView1_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var admin = dataGridView1.Rows[e.RowIndex].DataBoundItem as Admins;
            if (admin != null)
            {
                _appDbContext.Admins.Update(admin);
                _appDbContext.SaveChanges();
            }
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == dataGridView1.Columns["Actions"].Index && hit.RowIndex >= 0)
            {
                var cellRect = dataGridView1.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false);
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
                    dataGridView1.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
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
                        dataGridView1.InvalidateCell(dataGridView1.Columns["Actions"].Index, prevRow);
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
                    dataGridView1.InvalidateCell(dataGridView1.Columns["Actions"].Index, prevRow);
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Actions"].Index && e.RowIndex >= 0)
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

                ButtonRenderer.DrawButton(e.Graphics, deleteButton, "Delete", dataGridView1.Font, false, stateDelete);
                ButtonRenderer.DrawButton(e.Graphics, resetButton, "Reset Password", dataGridView1.Font, false, stateReset);

                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

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

                var mouse = dataGridView1.PointToClient(Cursor.Position);

                if (deleteButton.Contains(mouse))
                {
                    var admin = dataGridView1.Rows[e.RowIndex].DataBoundItem as Admins;
                    if (admin != null)
                    {
                        var confirm = MessageBox.Show("Delete this admin?", "Confirm", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            _appDbContext.Admins.Remove(admin);
                            _appDbContext.SaveChanges();
                            adminBindingList?.Remove(admin);
                        }
                    }
                }
                else if (resetButton.Contains(mouse))
                {
                    var admin = dataGridView1.Rows[e.RowIndex].DataBoundItem as Admins;
                    if (admin != null)
                    {
                        ShowResetPasswordDialog(admin);
                    }
                }
            }
        }

        private void ShowResetPasswordDialog(Admins admin)
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
                    admin.PasswordHash = PasswordHelper.Hash(newPassword);
                    _appDbContext.Admins.Update(admin);
                    _appDbContext.SaveChanges();
                    MessageBox.Show("Password reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            var adminForm = _provider.GetRequiredService<AdminForm>();
            adminForm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAdmins();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
