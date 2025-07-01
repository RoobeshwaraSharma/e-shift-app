using e_shift_app.db;
using System.ComponentModel;

namespace e_shift_app.views.transportManagement.container
{
    public partial class ContainerGrid : Form
    {
        private readonly AppDbContext _appDbContext;
        private BindingList<models.Container>? containerBindingList;

        private int _hoveredRowIndex = -1;
        private int _hoveredButton = -1; // 0 = none, 1 = delete

        public ContainerGrid(AppDbContext context)
        {
            InitializeComponent();
            _appDbContext = context;
        }

        private void ContainerGrid_Load(object sender, EventArgs e)
        {
            containerGridView.AllowUserToAddRows = false;
            containerGridView.AllowUserToDeleteRows = false;
            containerGridView.ReadOnly = false;
            containerGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            containerGridView.DefaultCellStyle.SelectionBackColor = containerGridView.DefaultCellStyle.BackColor;
            containerGridView.DefaultCellStyle.SelectionForeColor = containerGridView.DefaultCellStyle.ForeColor;
            containerGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = containerGridView.ColumnHeadersDefaultCellStyle.BackColor;
            containerGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = containerGridView.ColumnHeadersDefaultCellStyle.ForeColor;

            LoadContainers();

            if (!containerGridView.Columns.Contains("Actions"))
            {
                var actionsCol = new DataGridViewTextBoxColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    ReadOnly = true
                };
                containerGridView.Columns.Add(actionsCol);
                containerGridView.Columns["Actions"].Width = 120;
            }
            else
            {
                containerGridView.Columns["Actions"].Width = 120;
            }

            containerGridView.CellPainting += containerGridView_CellPainting;
            containerGridView.CellClick += containerGridView_CellClick;
            containerGridView.CellEndEdit += containerGridView_CellEndEdit;
            containerGridView.CellDoubleClick += containerGridView_CellDoubleClick;
            containerGridView.MouseMove += containerGridView_MouseMove;
            containerGridView.MouseLeave += containerGridView_MouseLeave;
        }

        private void LoadContainers()
        {
            var containerList = _appDbContext.Containers.ToList();
            containerBindingList = new BindingList<models.Container>(containerList);
            containerGridView.DataSource = containerBindingList;
        }

        private void containerGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                containerGridView.CurrentCell = containerGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                containerGridView.BeginEdit(true);
            }
        }

        private void containerGridView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var container = containerGridView.Rows[e.RowIndex].DataBoundItem as models.Container;
            if (container != null)
            {
                _appDbContext.Containers.Update(container);
                _appDbContext.SaveChanges();
            }
        }

        private void containerGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == containerGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int deleteBtnWidth = 70;
                int spacing = 10;

                Rectangle deleteButton = new Rectangle(e.CellBounds.Left + spacing, e.CellBounds.Top + 5, deleteBtnWidth, e.CellBounds.Height - 8);

                var stateDelete = (_hoveredRowIndex == e.RowIndex && _hoveredButton == 1)
                    ? System.Windows.Forms.VisualStyles.PushButtonState.Hot
                    : System.Windows.Forms.VisualStyles.PushButtonState.Default;

                ButtonRenderer.DrawButton(e.Graphics, deleteButton, "Delete", containerGridView.Font, false, stateDelete);

                e.Handled = true;
            }
        }

        private void containerGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == containerGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cellRect = containerGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int deleteBtnWidth = 70;
                Rectangle deleteButton = new Rectangle(cellRect.Left, cellRect.Top + 7, deleteBtnWidth, cellRect.Height - 10);
                var mouse = containerGridView.PointToClient(Cursor.Position);

                if (deleteButton.Contains(mouse))
                {
                    var container = containerGridView.Rows[e.RowIndex].DataBoundItem as models.Container;
                    if (container != null)
                    {
                        var confirm = MessageBox.Show("Delete this container?", "Confirm", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            _appDbContext.Containers.Remove(container);
                            _appDbContext.SaveChanges();
                            containerBindingList?.Remove(container);
                        }
                    }
                }
            }
        }

        private void containerGridView_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = containerGridView.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == containerGridView.Columns["Actions"].Index && hit.RowIndex >= 0)
            {
                var cellRect = containerGridView.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false);
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
                    containerGridView.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
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
                        containerGridView.InvalidateCell(containerGridView.Columns["Actions"].Index, prevRow);
                }
            }
        }

        private void containerGridView_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex != -1 || _hoveredButton != -1)
            {
                int prevRow = _hoveredRowIndex;
                _hoveredRowIndex = -1;
                _hoveredButton = -1;
                if (prevRow >= 0)
                    containerGridView.InvalidateCell(containerGridView.Columns["Actions"].Index, prevRow);
            }
        }

        private void btnAddContainer_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Add Container";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(300, 150);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var label = new Label() { Left = 20, Top = 20, Text = "Capacity (KG)", AutoSize = true };
                var numericUpDown = new NumericUpDown() { Left = 20, Top = 50, Width = 200, Minimum = 1, Maximum = 1000000, DecimalPlaces = 2 };
                var buttonOk = new Button() { Text = "Submit", Left = 100, Width = 80, Top = 90, DialogResult = DialogResult.OK };
                form.Controls.Add(label);
                form.Controls.Add(numericUpDown);
                form.Controls.Add(buttonOk);
                form.AcceptButton = buttonOk;

                buttonOk.Click += (s, e) =>
                {
                    if (numericUpDown.Value <= 0)
                    {
                        MessageBox.Show("Capacity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                };

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var container = new models.Container
                    {
                        Capacity = numericUpDown.Value
                    };
                    _appDbContext.Containers.Add(container);
                    _appDbContext.SaveChanges();
                    LoadContainers();
                    MessageBox.Show("Container added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
