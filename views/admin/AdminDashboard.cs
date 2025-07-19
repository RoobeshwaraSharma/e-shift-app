using e_shift_app.db;
using e_shift_app.models;
using e_shift_app.views.customer;
using e_shift_app.views.transportManagement.Assistant;
using e_shift_app.views.transportManagement.container;
using e_shift_app.views.transportManagement.driver;
using e_shift_app.views.transportManagement.lorry;
using e_shift_app.views.transportManagement.transportUnit;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Data;

namespace e_shift_app.views.admin
{
    public partial class AdminDashboard : Form
    {
        private int _hoveredRowIndex = -1;
        private int _hoveredButton = -1; // 0 = none, 1 = delete, 2 = add load, 3 = view load, 4 = approval

        private readonly IServiceProvider _provider;
        private readonly AppDbContext _appDbContext;
        private BindingList<Job>? jobBindingList;
        public AdminDashboard(IServiceProvider provider, AppDbContext dbContext)
        {
            InitializeComponent();
            _provider = provider;
            _appDbContext = dbContext;

        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            // Resolve & show the admin grid form from DI
            var adminGrid = _provider.GetRequiredService<AdminGrid>();
            adminGrid.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var customerGrid = _provider.GetRequiredService<CustomerGridView>();
            customerGrid.Show();
        }

        private void btnTransportUnit_Click(object sender, EventArgs e)
        {
            var transportUnit = _provider.GetRequiredService<TransportUnitGrid>();
            transportUnit.Show();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            jobsGridView.AllowUserToAddRows = false;
            jobsGridView.AllowUserToDeleteRows = false;
            jobsGridView.ReadOnly = false;
            jobsGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            jobsGridView.DefaultCellStyle.SelectionBackColor = jobsGridView.DefaultCellStyle.BackColor;
            jobsGridView.DefaultCellStyle.SelectionForeColor = jobsGridView.DefaultCellStyle.ForeColor;
            jobsGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = jobsGridView.ColumnHeadersDefaultCellStyle.BackColor;
            jobsGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = jobsGridView.ColumnHeadersDefaultCellStyle.ForeColor;

            LoadJobs();

            // Add Delete button column if not added

            if (!jobsGridView.Columns.Contains("Actions"))
            {
                var actionsCol = new DataGridViewTextBoxColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    ReadOnly = true
                };
                jobsGridView.Columns.Add(actionsCol);
                jobsGridView.Columns["Actions"].Width = 400;
            }
            else
            {
                jobsGridView.Columns["Actions"].Width = 400;
            }

            jobsGridView.CellPainting += jobsGridView_CellPainting;
            jobsGridView.CellClick += jobsGridView_CellClick;
            jobsGridView.CellEndEdit += jobsGridView_CellEndEdit;
            jobsGridView.CellDoubleClick += jobsGridView_CellDoubleClick;
            jobsGridView.MouseMove += jobsGridView_MouseMove;
            jobsGridView.MouseLeave += jobsGridView_MouseLeave;
        }
        private void LoadJobs()
        {
            var jobList = _appDbContext.Jobs.ToList();
            jobBindingList = new BindingList<Job>(jobList);
            jobsGridView.DataSource = jobBindingList;
        }
        private void jobsGridView_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                jobsGridView.CurrentCell = jobsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                jobsGridView.BeginEdit(true);
            }
        }
        private void jobsGridView_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var job = jobsGridView.Rows[e.RowIndex].DataBoundItem as Job;
            if (job != null)
            {
                _appDbContext.Jobs.Update(job);
                _appDbContext.SaveChanges();
            }
        }

        // Helper to get all button rectangles for a given cell
        private List<(string Name, Rectangle Rect)> GetActionButtonRects(Rectangle cellBounds, Job job)
        {
            int btnWidth = 80, spacing = 10;
            int x = cellBounds.Left + spacing;
            int y = cellBounds.Top + 5;
            int h = cellBounds.Height - 10;
            var rects = new List<(string, Rectangle)>();

            if (job.Status == JobStatus.Submitted)
            {
                rects.Add(("Delete", new Rectangle(x, y, btnWidth, h)));
                x += btnWidth + spacing;
     
            }

            rects.Add(("ViewLoad", new Rectangle(x, y, btnWidth, h)));
            x += btnWidth + spacing;
            rects.Add(("AddLoad", new Rectangle(x, y, btnWidth, h)));
            x += btnWidth + spacing;

            if (job.Status == JobStatus.Submitted)
            {
                rects.Add(("Approval", new Rectangle(x, y, btnWidth + 20, h+3)));
            }
            return rects;
        }

        private void jobsGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == jobsGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var job = jobsGridView.Rows[e.RowIndex].DataBoundItem as Job;
                if (job == null) return;

                var rects = GetActionButtonRects(e.CellBounds, job);

                for (int i = 0; i < rects.Count; i++)
                {
                    var (name, rect) = rects[i];
                    var state = (_hoveredRowIndex == e.RowIndex && _hoveredButton == i + 1)
                        ? System.Windows.Forms.VisualStyles.PushButtonState.Hot
                        : System.Windows.Forms.VisualStyles.PushButtonState.Default;
                    string text = name switch
                    {
                        "Delete" => "Delete",
                        "AddLoad" => "Add Load",
                        "ViewLoad" => "View Load",
                        "Approval" => "Approval",
                        _ => name
                    };
                    ButtonRenderer.DrawButton(e.Graphics, rect, text, jobsGridView.Font, false, state);
                }

                e.Handled = true;
            }
        }

        private void jobsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == jobsGridView.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var job = jobsGridView.Rows[e.RowIndex].DataBoundItem as Job;
                if (job == null) return;

                var cellRect = jobsGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var rects = GetActionButtonRects(cellRect, job);
                var mouse = jobsGridView.PointToClient(Cursor.Position);

                for (int i = 0; i < rects.Count; i++)
                {
                    var (name, rect) = rects[i];
                    if (rect.Contains(mouse))
                    {
                        switch (name)
                        {
                            case "Delete":
                                var confirm = MessageBox.Show("Delete this job?", "Confirm", MessageBoxButtons.YesNo);
                                if (confirm == DialogResult.Yes)
                                {
                                    _appDbContext.Jobs.Remove(job);
                                    _appDbContext.SaveChanges();
                                    jobBindingList?.Remove(job);
                                }
                                break;
                            case "AddLoad":
                                ShowAddLoadDialog(job);
                                break;
                            case "ViewLoad":
                                ShowViewLoadDialog(job.JobId);
                                break;
                            case "Approval":
                                ShowApprovalPopup(job);
                                break;
                        }
                        break;
                    }
                }
            }
        }

        private void jobsGridView_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = jobsGridView.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == jobsGridView.Columns["Actions"].Index && hit.RowIndex >= 0)
            {
                var job = jobsGridView.Rows[hit.RowIndex].DataBoundItem as Job;
                if (job == null) return;

                var cellRect = jobsGridView.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false);
                var rects = GetActionButtonRects(cellRect, job);
                var mouse = new Point(e.X, e.Y);

                int hoveredButton = 0;
                for (int i = 0; i < rects.Count; i++)
                {
                    if (rects[i].Rect.Contains(mouse))
                    {
                        hoveredButton = i + 1;
                        break;
                    }
                }

                if (_hoveredRowIndex != hit.RowIndex || _hoveredButton != hoveredButton)
                {
                    _hoveredRowIndex = hit.RowIndex;
                    _hoveredButton = hoveredButton;
                    jobsGridView.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
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
                        jobsGridView.InvalidateCell(jobsGridView.Columns["Actions"].Index, prevRow);
                }
            }
        }

        private void jobsGridView_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex != -1 || _hoveredButton != -1)
            {
                int prevRow = _hoveredRowIndex;
                _hoveredRowIndex = -1;
                _hoveredButton = -1;
                if (prevRow >= 0)
                    jobsGridView.InvalidateCell(jobsGridView.Columns["Actions"].Index, prevRow);
            }
        }

        private void ShowAddLoadDialog(Job job)
        {
            using (var form = new Form())
            {
                form.Text = "Add Load";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(340, 220);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var labelWeight = new Label() { Left = 20, Top = 20, Text = "Weight (kg)", AutoSize = true };
                var textBoxWeight = new TextBox() { Left = 20, Top = 45, Width = 280 };

                var labelDescription = new Label() { Left = 20, Top = 80, Text = "Description", AutoSize = true };
                var textBoxDescription = new TextBox() { Left = 20, Top = 105, Width = 280 };

                var buttonOk = new Button() { Text = "Submit", Left = 120, Width = 80, Top = 160, DialogResult = DialogResult.OK };
                form.Controls.Add(labelWeight);
                form.Controls.Add(textBoxWeight);
                form.Controls.Add(labelDescription);
                form.Controls.Add(textBoxDescription);
                form.Controls.Add(buttonOk);
                form.AcceptButton = buttonOk;

                buttonOk.Click += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(textBoxWeight.Text))
                    {
                        MessageBox.Show("Weight is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                    if (!decimal.TryParse(textBoxWeight.Text, out var weight) || weight <= 0)
                    {
                        MessageBox.Show("Weight must be a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
                    {
                        MessageBox.Show("Description is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                };

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    var weight = decimal.Parse(textBoxWeight.Text);
                    var description = textBoxDescription.Text.Trim();

                    var load = new Load
                    {
                        JobId = job.JobId,
                        Weight = weight,
                        Description = description
                    };

                    _appDbContext.Loads.Add(load);
                    _appDbContext.SaveChanges();
                    MessageBox.Show("Load added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ShowViewLoadDialog(int jobId)
        {
            using (var form = new Form())
            {
                form.Text = "View Loads";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(500, 350);
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var grid = new DataGridView()
                {
                    Left = 10,
                    Top = 10,
                    Width = 400,
                    Height = 260,
                    ReadOnly = false,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    EditMode = DataGridViewEditMode.EditProgrammatically,
                    AutoGenerateColumns = true
                };

                var btnClose = new Button()
                {
                    Text = "Close",
                    Left = 200,
                    Top = 285,
                    Width = 100,
                    DialogResult = DialogResult.Cancel
                };

                form.Controls.Add(grid);
                form.Controls.Add(btnClose);
                form.AcceptButton = btnClose;
                form.CancelButton = btnClose;

                // Load data
                var loads = _appDbContext.Loads.Where(l => l.JobId == jobId).ToList();
                var bindingList = new BindingList<Load>(loads);
                grid.DataSource = bindingList;

                // Allow inline edit for Weight and Description only
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (col.Name == "Weight" || col.Name == "Description")
                        col.ReadOnly = false;
                    else
                        col.ReadOnly = true;

                    if (col.Name == "JobId" || col.Name == "TransportUnitId" || col.Name == "Job" || col.Name == "TransportUnit")
                    {
                        col.Visible = false; // Hide ID columns
                    }
                    if (col.Name == "LoadId")
                    {
                        col.HeaderText = "Load ID"; // Rename LoadId column
                        col.Width = 80; // Set a fixed width for LoadId column
                    }
                }

                grid.CellDoubleClick += (s, e) =>
                {
                    if (e.RowIndex >= 0 && (grid.Columns[e.ColumnIndex].Name == "Weight" || grid.Columns[e.ColumnIndex].Name == "Description"))
                    {
                        grid.CurrentCell = grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        grid.BeginEdit(true);
                    }
                };

                grid.CellEndEdit += (s, e) =>
                {
                    if (e.RowIndex < 0) return;
                    var load = grid.Rows[e.RowIndex].DataBoundItem as Load;
                    if (load != null)
                    {
                        _appDbContext.Loads.Update(load);
                        _appDbContext.SaveChanges();
                    }
                };

                form.ShowDialog(this);
            }
        }

        private void ShowApprovalPopup(Job job)
        {
            using (var form = new Form())
            {
                form.Text = "Approval";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(350, 200);

                var labelStatus = new Label() { Left = 20, Top = 20, Text = "Status", AutoSize = true };
                var comboStatus = new ComboBox() { Left = 20, Top = 45, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };
                comboStatus.Items.AddRange(new[] { "Approved", "Rejected" });
                comboStatus.SelectedIndex = 0;

                var labelTU = new Label() { Left = 20, Top = 80, Text = "Transport Unit", AutoSize = true, Visible = true };
                var comboTU = new ComboBox() { Left = 20, Top = 105, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList, Visible = true };

                // Load available transport units
                var availableTUs = _appDbContext.TransportUnits.Where(tu => (int)tu.Status == 0).ToList();
                comboTU.DataSource = availableTUs;
                comboTU.DisplayMember = "Id"; // Or any other display property
                comboTU.ValueMember = "Id";

                comboStatus.SelectedIndexChanged += (s, e) =>
                {
                    bool isApproved = comboStatus.SelectedItem?.ToString() == "Approved";
                    labelTU.Visible = comboTU.Visible = isApproved;
                };

                var buttonOk = new Button() { Text = "Submit", Left = 120, Width = 100, Top = 150, DialogResult = DialogResult.OK };
                form.Controls.Add(labelStatus);
                form.Controls.Add(comboStatus);
                form.Controls.Add(labelTU);
                form.Controls.Add(comboTU);
                form.Controls.Add(buttonOk);
                form.AcceptButton = buttonOk;

                buttonOk.Click += (s, e) =>
                {
                    if (comboStatus.SelectedItem?.ToString() == "Approved" && string.IsNullOrWhiteSpace(comboTU.Text))
                    {
                        MessageBox.Show("Transport Unit is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        form.DialogResult = DialogResult.None;
                        return;
                    }
                  
                };

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (comboStatus.SelectedItem?.ToString() == "Rejected")
                    {
                        job.Status = JobStatus.Rejected;
                    }
                    else if (comboStatus.SelectedItem?.ToString() == "Approved")
                    {
                        job.Status = JobStatus.Approved;
                        // Assign selected TransportUnit if needed
                        if (comboTU.SelectedItem is TransportUnit tu)
                        {
                            tu.Status = UnitStatus.Occupied; // Mark as assigned
                            // Optionally, associate the transport unit with the job or a load
                        }
                    }
                    _appDbContext.SaveChanges();
                    jobsGridView.Refresh();
                }
            }
        }

        private void btnLorry_Click(object sender, EventArgs e)
        {
            var lorryGrid = _provider.GetRequiredService<LorryGrid>();
            lorryGrid.Show();
        }

        private void btnContainer_Click(object sender, EventArgs e)
        {
            var container = _provider.GetRequiredService<ContainerGrid>();
            container.Show();
        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            var driver = _provider.GetRequiredService<DriverGrid>();
            driver.Show();
        }

        private void btnAssistant_Click(object sender, EventArgs e)
        {
            var assistant = _provider.GetRequiredService<AssistantGrid>();
            assistant.Show();
        }
    }
}
