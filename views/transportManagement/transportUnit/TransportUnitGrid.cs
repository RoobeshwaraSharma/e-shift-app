using e_shift_app.db;
using e_shift_app.models;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace e_shift_app.views.transportManagement.transportUnit
{
    public partial class TransportUnitGrid : Form
    {
        private readonly AppDbContext _appDbContext;

        private int _hoveredRowIndex = -1;
        private int _hoveredButton = -1; // 0 = none, 1 = delete

        public TransportUnitGrid(AppDbContext dbContext)
        {
            InitializeComponent();
            _appDbContext = dbContext;
        }

        private void TransportUnitGrid_Load(object sender, EventArgs e)
        {
            transportUnitGridView.AllowUserToAddRows = false;
            transportUnitGridView.AllowUserToDeleteRows = false;
            transportUnitGridView.ReadOnly = false;
            transportUnitGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            transportUnitGridView.DefaultCellStyle.SelectionBackColor = transportUnitGridView.DefaultCellStyle.BackColor;
            transportUnitGridView.DefaultCellStyle.SelectionForeColor = transportUnitGridView.DefaultCellStyle.ForeColor;
            transportUnitGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = transportUnitGridView.ColumnHeadersDefaultCellStyle.BackColor;
            transportUnitGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = transportUnitGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor;

            LoadTransportUnits();

            // Add Actions column if not present
            if (!transportUnitGridView.Columns.Contains("Actions"))
            {
                var actionsCol = new DataGridViewTextBoxColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    ReadOnly = true
                };
                transportUnitGridView.Columns.Add(actionsCol);
                transportUnitGridView.Columns["Actions"].Width = 120;
            }
            else
            {
                transportUnitGridView.Columns["Actions"].Width = 120;
            }


            transportUnitGridView.CellPainting += transportUnitGridView_CellPainting;
            transportUnitGridView.CellClick += transportUnitGridView_CellClick;
            transportUnitGridView.CellEndEdit += transportUnitGridView_CellEndEdit;
            transportUnitGridView.CellDoubleClick += transportUnitGridView_CellDoubleClick;
            transportUnitGridView.MouseMove += transportUnitGridView_MouseMove;
            transportUnitGridView.MouseLeave += transportUnitGridView_MouseLeave;
        }

        private void LoadTransportUnits()
        {
            var list = _appDbContext.TransportUnits
                .Include(tu => tu.Driver)
                .Include(tu => tu.Container)
                .Include(tu => tu.Assistant)
                .Include(tu => tu.Lorry)
                .Select(tu => new
                {
                    tu.Id,
                    tu.LorryId,
                    tu.DriverId,
                    tu.AssistantId,
                    tu.ContainerId,
                    tu.Status,
                    DriverName = tu.Driver != null ? tu.Driver.Name : "",
                    ContainerCapacity = tu.Container != null ? tu.Container.Capacity : 0,
                    AssistantName = tu.Assistant != null ? tu.Assistant.Name : "",
                    LorryNumber = tu.Lorry != null ? tu.Lorry.RegistrationNumber : ""
                })
                .ToList();

            transportUnitGridView.AutoGenerateColumns = false;
            transportUnitGridView.Columns.Clear();
            transportUnitGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID" });
            transportUnitGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "Status", HeaderText = "Status" });

            transportUnitGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "LorryId", DataPropertyName = "LorryId", HeaderText = "Lorry ID" });
            transportUnitGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "LorryNumber", DataPropertyName = "LorryNumber", HeaderText = "Lorry Number" });

            transportUnitGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "DriverId", DataPropertyName = "DriverId", HeaderText = "Driver ID" });
            transportUnitGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "DriverName", DataPropertyName = "DriverName", HeaderText = "Driver Name" });

            transportUnitGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "ContainerId", DataPropertyName = "ContainerId", HeaderText = "Container ID" });
            transportUnitGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "ContainerCapacity", DataPropertyName = "ContainerCapacity", HeaderText = "Container Capacity" });

            transportUnitGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "AssistantId", DataPropertyName = "AssistantId", HeaderText = "Assistant ID" });
            transportUnitGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "AssistantName", DataPropertyName = "AssistantName", HeaderText = "Assistant Name" });
 
            transportUnitGridView.DataSource = list;
        }

        private void transportUnitGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                transportUnitGridView.CurrentCell = transportUnitGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                transportUnitGridView.BeginEdit(true);
            }
        }

        private void transportUnitGridView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = transportUnitGridView.Rows[e.RowIndex];
            var id = (int)row.Cells["Id"].Value;
            var tu = _appDbContext.TransportUnits.FirstOrDefault(x => x.Id == id);
            if (tu != null)
            {
                // Only allow editing of Status
                if (transportUnitGridView.Columns[e.ColumnIndex].Name == "Status")
                {
                    tu.Status = (UnitStatus)row.Cells["Status"].Value;
                    _appDbContext.TransportUnits.Update(tu);
                    _appDbContext.SaveChanges();
                }
            }
        }

        private void transportUnitGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == transportUnitGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int deleteBtnWidth = 70;
                int spacing = 10;

                Rectangle deleteButton = new Rectangle(e.CellBounds.Left + spacing, e.CellBounds.Top + 5, deleteBtnWidth, e.CellBounds.Height - 8);

                var stateDelete = (_hoveredRowIndex == e.RowIndex && _hoveredButton == 1)
                    ? System.Windows.Forms.VisualStyles.PushButtonState.Hot
                    : System.Windows.Forms.VisualStyles.PushButtonState.Default;

                ButtonRenderer.DrawButton(e.Graphics, deleteButton, "Delete", transportUnitGridView.Font, false, stateDelete);

                e.Handled = true;
            }
        }

        private void transportUnitGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == transportUnitGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cellRect = transportUnitGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int deleteBtnWidth = 70;
                Rectangle deleteButton = new Rectangle(cellRect.Left, cellRect.Top + 7, deleteBtnWidth, cellRect.Height - 10);
                var mouse = transportUnitGridView.PointToClient(Cursor.Position);

                if (deleteButton.Contains(mouse))
                {
                    var id = (int)transportUnitGridView.Rows[e.RowIndex].Cells["Id"].Value;
                    var tu = _appDbContext.TransportUnits.FirstOrDefault(x => x.Id == id);
                    if (tu != null)
                    {
                        var confirm = MessageBox.Show("Delete this transport unit?", "Confirm", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            _appDbContext.TransportUnits.Remove(tu);
                            _appDbContext.SaveChanges();
                            LoadTransportUnits();
                        }
                    }
                }
            }
        }

        private void transportUnitGridView_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = transportUnitGridView.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == transportUnitGridView.Columns["Actions"].Index && hit.RowIndex >= 0)
            {
                var cellRect = transportUnitGridView.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false);
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
                    transportUnitGridView.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
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
                        transportUnitGridView.InvalidateCell(transportUnitGridView.Columns["Actions"].Index, prevRow);
                }
            }
        }

        private void transportUnitGridView_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex != -1 || _hoveredButton != -1)
            {
                int prevRow = _hoveredRowIndex;
                _hoveredRowIndex = -1;
                _hoveredButton = -1;
                if (prevRow >= 0)
                    transportUnitGridView.InvalidateCell(transportUnitGridView.Columns["Actions"].Index, prevRow);
            }
        }

        private void btnAddTransportUnit_Click(object sender, EventArgs e)
        {
            using (var form = new Form())
            {
                form.Text = "Add Transport Unit";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(400, 320);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var labelLorry = new Label() { Left = 20, Top = 20, Text = "Lorry", AutoSize = true };
                var comboLorry = new ComboBox() { Left = 20, Top = 45, Width = 340, DropDownStyle = ComboBoxStyle.DropDownList };
                var labelDriver = new Label() { Left = 20, Top = 80, Text = "Driver", AutoSize = true };
                var comboDriver = new ComboBox() { Left = 20, Top = 105, Width = 340, DropDownStyle = ComboBoxStyle.DropDownList };
                var labelAssistant = new Label() { Left = 20, Top = 140, Text = "Assistant", AutoSize = true };
                var comboAssistant = new ComboBox() { Left = 20, Top = 165, Width = 340, DropDownStyle = ComboBoxStyle.DropDownList };
                var labelContainer = new Label() { Left = 20, Top = 200, Text = "Container", AutoSize = true };
                var comboContainer = new ComboBox() { Left = 20, Top = 225, Width = 340, DropDownStyle = ComboBoxStyle.DropDownList };

                var buttonOk = new Button() { Text = "Submit", Left = 140, Width = 100, Top = 265, DialogResult = DialogResult.OK };
                form.Controls.Add(labelLorry);
                form.Controls.Add(comboLorry);
                form.Controls.Add(labelDriver);
                form.Controls.Add(comboDriver);
                form.Controls.Add(labelAssistant);
                form.Controls.Add(comboAssistant);
                form.Controls.Add(labelContainer);
                form.Controls.Add(comboContainer);
                form.Controls.Add(buttonOk);
                form.AcceptButton = buttonOk;

                // Populate dropdowns with available items
                var lorries = _appDbContext.Lorries.Where(l => (int)l.Status == 0).ToList();
                var drivers = _appDbContext.Drivers.Where(d => (int)d.Status == 0).ToList();
                var assistants = _appDbContext.Assistants.Where(a => (int)a.Status == 0).ToList();
                var containers = _appDbContext.Containers.Where(c => (int)c.Status == 0).ToList();

                comboLorry.DataSource = lorries;
                comboLorry.DisplayMember = "RegistrationNumber";
                comboLorry.ValueMember = "Id";
                comboLorry.SelectedIndex = -1;

                comboDriver.DataSource = drivers;
                comboDriver.DisplayMember = "Name";
                comboDriver.ValueMember = "Id";
                comboDriver.SelectedIndex = -1;

                comboAssistant.DataSource = assistants;
                comboAssistant.DisplayMember = "Name";
                comboAssistant.ValueMember = "Id";
                comboAssistant.SelectedIndex = -1;

                comboContainer.DataSource = containers;
                comboContainer.DisplayMember = "Capacity";
                comboContainer.ValueMember = "Id";
                comboContainer.SelectedIndex = -1;

                buttonOk.Click += (s, e) =>
                {
                    if (comboLorry.SelectedIndex < 0 || comboDriver.SelectedIndex < 0 ||
                        comboAssistant.SelectedIndex < 0 || comboContainer.SelectedIndex < 0)
                    {
                        MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                };

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var tu = new TransportUnit
                    {
                        LorryId = (int)comboLorry.SelectedValue,
                        DriverId = (int)comboDriver.SelectedValue,
                        AssistantId = (int)comboAssistant.SelectedValue,
                        ContainerId = (int)comboContainer.SelectedValue,
                        Status = UnitStatus.Available
                    };
                    _appDbContext.TransportUnits.Add(tu);
                    _appDbContext.SaveChanges();
                    LoadTransportUnits();
                    MessageBox.Show("Transport unit added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}