using e_shift_app.db;
using System.ComponentModel;

namespace e_shift_app.views.transportManagement.Assistant
{
    public partial class AssistantGrid : Form
    {
        private readonly AppDbContext _appDbContext;
        private BindingList<models.Assistant>? assistantBindingList;

        private int _hoveredRowIndex = -1;
        private int _hoveredButton = -1; // 0 = none, 1 = delete

        public AssistantGrid(AppDbContext context)
        {
            InitializeComponent();
            _appDbContext = context;
        }

        private void AssistantGrid_Load(object sender, EventArgs e)
        {
            assistantGridView.AllowUserToAddRows = false;
            assistantGridView.AllowUserToDeleteRows = false;
            assistantGridView.ReadOnly = false;
            assistantGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            assistantGridView.DefaultCellStyle.SelectionBackColor = assistantGridView.DefaultCellStyle.BackColor;
            assistantGridView.DefaultCellStyle.SelectionForeColor = assistantGridView.DefaultCellStyle.ForeColor;
            assistantGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = assistantGridView.ColumnHeadersDefaultCellStyle.BackColor;
            assistantGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = assistantGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor;

            LoadAssistants();

            if (!assistantGridView.Columns.Contains("Actions"))
            {
                var actionsCol = new DataGridViewTextBoxColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    ReadOnly = true
                };
                assistantGridView.Columns.Add(actionsCol);
                assistantGridView.Columns["Actions"].Width = 120;
            }
            else
            {
                assistantGridView.Columns["Actions"].Width = 120;
            }

            assistantGridView.CellPainting += assistantGridView_CellPainting;
            assistantGridView.CellClick += assistantGridView_CellClick;
            assistantGridView.CellEndEdit += assistantGridView_CellEndEdit;
            assistantGridView.CellDoubleClick += assistantGridView_CellDoubleClick;
            assistantGridView.MouseMove += assistantGridView_MouseMove;
            assistantGridView.MouseLeave += assistantGridView_MouseLeave;
        }

        private void LoadAssistants()
        {
            var assistantList = _appDbContext.Assistants.ToList();
            assistantBindingList = new BindingList<models.Assistant>(assistantList);
            assistantGridView.DataSource = assistantBindingList;
        }

        private void assistantGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                assistantGridView.CurrentCell = assistantGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                assistantGridView.BeginEdit(true);
            }
        }

        private void assistantGridView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var assistant = assistantGridView.Rows[e.RowIndex].DataBoundItem as models.Assistant;
            if (assistant != null)
            {
                _appDbContext.Assistants.Update(assistant);
                _appDbContext.SaveChanges();
            }
        }

        private void assistantGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == assistantGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int deleteBtnWidth = 70;
                int spacing = 10;

                Rectangle deleteButton = new Rectangle(e.CellBounds.Left + spacing, e.CellBounds.Top + 5, deleteBtnWidth, e.CellBounds.Height - 8);

                var stateDelete = (_hoveredRowIndex == e.RowIndex && _hoveredButton == 1)
                    ? System.Windows.Forms.VisualStyles.PushButtonState.Hot
                    : System.Windows.Forms.VisualStyles.PushButtonState.Default;

                ButtonRenderer.DrawButton(e.Graphics, deleteButton, "Delete", assistantGridView.Font, false, stateDelete);

                e.Handled = true;
            }
        }

        private void assistantGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == assistantGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cellRect = assistantGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int deleteBtnWidth = 70;
                Rectangle deleteButton = new Rectangle(cellRect.Left, cellRect.Top + 7, deleteBtnWidth, cellRect.Height - 10);
                var mouse = assistantGridView.PointToClient(Cursor.Position);

                if (deleteButton.Contains(mouse))
                {
                    var assistant = assistantGridView.Rows[e.RowIndex].DataBoundItem as models.Assistant;
                    if (assistant != null)
                    {
                        var confirm = MessageBox.Show("Delete this assistant?", "Confirm", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            _appDbContext.Assistants.Remove(assistant);
                            _appDbContext.SaveChanges();
                            assistantBindingList?.Remove(assistant);
                        }
                    }
                }
            }
        }

        private void assistantGridView_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = assistantGridView.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == assistantGridView.Columns["Actions"].Index && hit.RowIndex >= 0)
            {
                var cellRect = assistantGridView.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false);
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
                    assistantGridView.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
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
                        assistantGridView.InvalidateCell(assistantGridView.Columns["Actions"].Index, prevRow);
                }
            }
        }

        private void assistantGridView_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex != -1 || _hoveredButton != -1)
            {
                int prevRow = _hoveredRowIndex;
                _hoveredRowIndex = -1;
                _hoveredButton = -1;
                if (prevRow >= 0)
                    assistantGridView.InvalidateCell(assistantGridView.Columns["Actions"].Index, prevRow);
            }
        }

        private void btnAddAssistant_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Add Assistant";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(320, 180);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var labelName = new Label() { Left = 20, Top = 20, Text = "Name", AutoSize = true };
                var textBoxName = new TextBox() { Left = 20, Top = 45, Width = 250 };

                var labelPhone = new Label() { Left = 20, Top = 80, Text = "Phone Number", AutoSize = true };
                var textBoxPhone = new TextBox() { Left = 20, Top = 105, Width = 250 };

                var buttonOk = new Button() { Text = "Submit", Left = 110, Width = 80, Top = 140, DialogResult = DialogResult.OK };
                form.Controls.Add(labelName);
                form.Controls.Add(textBoxName);
                form.Controls.Add(labelPhone);
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
                    if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
                    {
                        MessageBox.Show("Phone Number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                };

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var assistant = new models.Assistant
                    {
                        Name = textBoxName.Text.Trim(),
                        PhoneNumber = textBoxPhone.Text.Trim()
                    };
                    _appDbContext.Assistants.Add(assistant);
                    _appDbContext.SaveChanges();
                    LoadAssistants();
                    MessageBox.Show("Assistant added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
