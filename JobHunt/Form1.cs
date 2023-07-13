using JobHunt;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JobHunt
{
    public partial class Form1 : Form
    {
        IJobBoardDataService dataService;

        //List<JobListingItem> jobs = new();
        BindingList<JobListingItem> jobs = new();

        BindingSource bs = new BindingSource();

        List<KeyValuePair<string, string>> Statuses = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Looking", "01. Looking"),
            new KeyValuePair<string, string>("Saved", "02. Saved"),
            new KeyValuePair<string, string>("Applied", "03. Applied"),
            new KeyValuePair<string, string>("They Viewed", "04. They Viewed"),
            new KeyValuePair<string, string>("They Reached Out", "05. They Reached Out"),
            new KeyValuePair<string, string>("First Round Interview", "06. First Round Interview"),
            new KeyValuePair<string, string>("Second Round Interview", "07. Second Round Interview"),
            new KeyValuePair<string, string>("Not Moving Forward", "08. Not Moving Forward"),
            new KeyValuePair<string, string>("Offered", "09. Offered"),
            new KeyValuePair<string, string>("Cancelled", "10. Cancelled")
        };

        public JobListingItem Item { get; set; }

        public Form1(IJobBoardDataService dataService)
        {
            InitializeComponent();

            this.dataService = dataService;
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //await dataService.CreateJobListingItem(new JobListingItem() { Company = "Brads Co.", Applied = DateTime.Now, LinkOne = "https://www.cnn.com", Status = "Applied", Comment = "This is a sample listing" });

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Company", DataPropertyName = "Company", ReadOnly = true, Visible = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Status", DataPropertyName = "Status", ReadOnly = true, Visible = true });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Applied", DataPropertyName = nameof(JobListingItem.Applied_DO), ReadOnly = true, Visible = true });

            dataGridView1.Columns[0].SortMode =
                        DataGridViewColumnSortMode.Programmatic;
            dataGridView1.Columns[1].SortMode =
                DataGridViewColumnSortMode.Programmatic;
            dataGridView1.Columns[2].SortMode =
                DataGridViewColumnSortMode.Programmatic;

            comboBox1.DataSource = Statuses;
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            Item = new();
            bs.DataSource = Item;
            //            bs.ListChanged += Bs_ListChanged;

            textBox1.DataBindings.Add(nameof(textBox1.Text), bs, nameof(JobListingItem.JobId), false, DataSourceUpdateMode.OnPropertyChanged);
            textBox6.DataBindings.Add(nameof(textBox6.Text), bs, nameof(JobListingItem.Company), false, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add(nameof(textBox2.Text), bs, nameof(JobListingItem.LinkOne), false, DataSourceUpdateMode.OnPropertyChanged);
            textBox3.DataBindings.Add(nameof(textBox3.Text), bs, nameof(JobListingItem.LinkTwo), false, DataSourceUpdateMode.OnPropertyChanged);
            textBox4.DataBindings.Add(nameof(textBox4.Text), bs, nameof(JobListingItem.TrackingUrl), false, DataSourceUpdateMode.OnPropertyChanged);
            textBox5.DataBindings.Add(nameof(textBox5.Text), bs, nameof(JobListingItem.Comment), false, DataSourceUpdateMode.OnPropertyChanged);

            nullableDateControl1.DataBindings.Add(nameof(nullableDateControl1.SelectedDate), bs, nameof(JobListingItem.Applied), true, DataSourceUpdateMode.OnPropertyChanged);
            nullableDateControl2.DataBindings.Add(nameof(nullableDateControl2.SelectedDate), bs, nameof(JobListingItem.Viewed), true, DataSourceUpdateMode.OnPropertyChanged);
            nullableDateControl3.DataBindings.Add(nameof(nullableDateControl3.SelectedDate), bs, nameof(JobListingItem.TheyContacted), true, DataSourceUpdateMode.OnPropertyChanged);
            nullableDateControl4.DataBindings.Add(nameof(nullableDateControl4.SelectedDate), bs, nameof(JobListingItem.NoLongerAccepting), true, DataSourceUpdateMode.OnPropertyChanged);
            //            comboBox1.DataBindings.Add(nameof(comboBox1.SelectedItem), Item, nameof(JobListingItem.Status), false, DataSourceUpdateMode.OnPropertyChanged);
            comboBox1.DataBindings.Add(nameof(comboBox1.SelectedValue), bs, nameof(JobListingItem.Status), false, DataSourceUpdateMode.OnPropertyChanged);

            var v = await dataService.Select(null);

            foreach (JobListingItem item in v)
            {
                jobs.Add(item);
            }
            dataGridView1.DataSource = jobs;
        }

        int idxRowBeingEdited = -1;

        private async Task SaveEdits()
        {
            if (idxRowBeingEdited != -1)
            {
                await dataService.UpdateJobListingItem(Item);
                idxRowBeingEdited = -1;
            }
        }

        private async void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            await SaveEdits();

            if (dataGridView1.CurrentRow != null)
            {
                Item = (JobListingItem)dataGridView1.CurrentRow.DataBoundItem;
                bs.DataSource = Item;
                idxRowBeingEdited = dataGridView1.CurrentRow.Index;
            }

            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    Item = (JobListingItem)dataGridView1.SelectedRows[0].DataBoundItem;
            //    bs.DataSource = Item;
            //    idxRowBeingEdited = dataGridView1.SelectedRows[0].Index;
            //    //textBox1.DataBindings[0].ReadValue();

            //    //textBox6.DataBindings.Clear();
            //    //textBox6.DataBindings.Add(nameof(textBox6.Text), bs, nameof(JobListingItem.Company), false, DataSourceUpdateMode.OnPropertyChanged);
            //}
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            await SaveEdits();
        }

        string prevOrderBy = "";
        bool descending = false;

        private async void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            await SaveEdits();
            string name = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
            if (name != prevOrderBy)
            {

                prevOrderBy = name;
                descending = false;
            }
            else
            {
                descending = !descending;
            }

            var v = await dataService.Select(name, descending);
            jobs.Clear();
            foreach (JobListingItem item in v)
            {
                jobs.Add(item);
            }
            dataGridView1.DataSource = jobs;
        }

        // https://stackoverflow.com/questions/8396331/glyph-not-displayed-on-datagridview#8412704
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Put each of the columns into programmatic sort mode.
            foreach (DataGridViewColumn column in ((DataGridView)sender).Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;

                if (column.DataPropertyName != prevOrderBy)
                    column.HeaderCell.SortGlyphDirection = SortOrder.None;
                else
                    column.HeaderCell.SortGlyphDirection = descending ? SortOrder.Ascending : SortOrder.Descending;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(textBox2.Text) { UseShellExecute = true });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(textBox3.Text) { UseShellExecute = true });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(textBox4.Text) { UseShellExecute = true });
        }

        private async void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            await SaveEdits();

            JobListingItem newJob = new JobListingItem();
            jobs.Add(newJob);
            await dataService.CreateJobListingItem(newJob);

            //Item = newJob;
            //bs.DataSource = Item;

            dataGridView1.CurrentCell = dataGridView1.Rows[idxNewRow].Cells[0];
            dataGridView1.CurrentRow.Selected = true;

            dataGridView1_SelectionChanged(sender, EventArgs.Empty);
        }

        int idxNewRow = -1;

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            idxNewRow = e.RowIndex;
            //            dataGridView1.Rows[e.RowIndex].Selected = true;

            //dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
            //dataGridView1.CurrentRow.Selected = true;

        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            JobListingItem job = (JobListingItem)(dataGridView1.SelectedRows[0].DataBoundItem);
            var v = await dataService.DeleteJobListingItem(job.JobId);
            jobs.Remove(job);
            //Item = new();
            //bs.DataSource = Item;


            ////int idx = dataGridView1.CurrentRow.Index;
            //if (idx < dataGridView1.Rows.Count)
            //{
            //}
            //else if (idx > 1)
            //{
            //    idx--;
            //}

            ////dataGridView1.CurrentRow = idx;

            //dataGridView1.CurrentCell = dataGridView1.Rows[idx].Cells[0];


        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx < dataGridView1.Rows.Count)
            {
            }
            else if (idx > 1)
            {
                idx--;
            }

            if (dataGridView1.Rows.Count == 0)
                return;

            // https://social.msdn.microsoft.com/Forums/azure/en-US/556f528b-4583-4be2-bb42-487ad2c96532/how-to-set-the-currentrow-of-a-datagridview?forum=winformsdatacontrols
            // You can NOT set the current row, BUT you can set the current cell
            dataGridView1.CurrentCell = dataGridView1.Rows[idx].Cells[0];
            dataGridView1.CurrentRow.Selected = true;
            Item = (JobListingItem)dataGridView1.CurrentRow.DataBoundItem;
            bs.DataSource = Item;
            idxRowBeingEdited = idx;
        }
    }
}

