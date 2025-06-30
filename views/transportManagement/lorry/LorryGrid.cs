using e_shift_app.db;
using e_shift_app.models;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace e_shift_app.views.transportManagement.lorry
{
    public partial class LorryGrid : Form
    {
        private readonly AppDbContext _appDbContext;
        private readonly IServiceProvider _provider;
        private BindingList<Lorry>? lorryBindingList;

        private int _hoveredRowIndex = -1;
        private int _hoveredButton = -1; // 0 = none, 1 = delete, 2 = add load, 3 = view load

        public LorryGrid(AppDbContext context, IServiceProvider provider)
        {
            InitializeComponent();
            _appDbContext = context;
            _provider = provider;
        }

        private void LorryGrid_Load(object sender, EventArgs e)
        {
            lorryGridView.AllowUserToAddRows = false;
            lorryGridView.AllowUserToDeleteRows = false;
            lorryGridView.ReadOnly = false;
            lorryGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            lorryGridView.DefaultCellStyle.SelectionBackColor = lorryGridView.DefaultCellStyle.BackColor;
            lorryGridView.DefaultCellStyle.SelectionForeColor = lorryGridView.DefaultCellStyle.ForeColor;
            lorryGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = lorryGridView.ColumnHeadersDefaultCellStyle.BackColor;
            lorryGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = lorryGridView.ColumnHeadersDefaultCellStyle.ForeColor;

            LoadLorries();

            // Add Delete button column if not added

            if (!lorryGridView.Columns.Contains("Actions"))
            {
                var actionsCol = new DataGridViewTextBoxColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    ReadOnly = true
                };
                lorryGridView.Columns.Add(actionsCol);
                lorryGridView.Columns["Actions"].Width = 120;
            }
            else
            {
                lorryGridView.Columns["Actions"].Width = 120;
            }

            lorryGridView.CellPainting += lorryGridView_CellPainting;
            lorryGridView.CellClick += lorryGridView_CellClick;
            lorryGridView.CellEndEdit += lorryGridView_CellEndEdit;
            lorryGridView.CellDoubleClick += lorryGridView_CellDoubleClick;
            lorryGridView.MouseMove += lorryGridView_MouseMove;
            lorryGridView.MouseLeave += lorryGridView_MouseLeave;
        }

        private void btnLorry_Click(object sender, EventArgs e)
        {
            var lorryForm = _provider.GetRequiredService<LorryForm>();
            lorryForm.Show();
        }
        private void LoadLorries()
        {

            var lorryList = _appDbContext.Lorries.ToList();
            lorryBindingList = new BindingList<Lorry>(lorryList);
            lorryGridView.DataSource = lorryBindingList;
        }
        private void lorryGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                lorryGridView.CurrentCell = lorryGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                lorryGridView.BeginEdit(true);
            }
        }
        private void lorryGridView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var job = lorryGridView.Rows[e.RowIndex].DataBoundItem as Job;
            if (job != null)
            {
                _appDbContext.Jobs.Update(job);
                _appDbContext.SaveChanges();
            }
        }
        private void lorryGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == lorryGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int deleteBtnWidth = 70;
                int spacing = 10;

                Rectangle deleteButton = new Rectangle(e.CellBounds.Left + spacing, e.CellBounds.Top + 5, deleteBtnWidth, e.CellBounds.Height - 8);

                var stateDelete = (_hoveredRowIndex == e.RowIndex && _hoveredButton == 1)
                    ? System.Windows.Forms.VisualStyles.PushButtonState.Hot
                    : System.Windows.Forms.VisualStyles.PushButtonState.Default;

                ButtonRenderer.DrawButton(e.Graphics, deleteButton, "Delete", lorryGridView.Font, false, stateDelete);

                e.Handled = true;
            }
        }

        private void lorryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == lorryGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cellRect = lorryGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                int deleteBtnWidth = 70;



                Rectangle deleteButton = new Rectangle(cellRect.Left, cellRect.Top + 7, deleteBtnWidth, cellRect.Height - 10);

                var mouse = lorryGridView.PointToClient(Cursor.Position);

                if (deleteButton.Contains(mouse))
                {
                    var lorry = lorryGridView.Rows[e.RowIndex].DataBoundItem as Lorry;
                    if (lorry != null)
                    {
                        var confirm = MessageBox.Show("Delete this lorry?", "Confirm", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            _appDbContext.Lorries.Remove(lorry);
                            _appDbContext.SaveChanges();
                            lorryBindingList?.Remove(lorry);
                        }
                    }
                }
            }
        }

        private void lorryGridView_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = lorryGridView.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == lorryGridView.Columns["Actions"].Index && hit.RowIndex >= 0)
            {
                var cellRect = lorryGridView.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false);
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
                    lorryGridView.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
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
                        lorryGridView.InvalidateCell(lorryGridView.Columns["Actions"].Index, prevRow);
                }
            }
        }

        private void lorryGridView_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex != -1 || _hoveredButton != -1)
            {
                int prevRow = _hoveredRowIndex;
                _hoveredRowIndex = -1;
                _hoveredButton = -1;
                if (prevRow >= 0)
                    lorryGridView.InvalidateCell(lorryGridView.Columns["Actions"].Index, prevRow);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLorries();
        }
    }
}
