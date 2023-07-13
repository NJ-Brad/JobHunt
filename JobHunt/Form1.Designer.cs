namespace JobHunt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            toolStrip1 = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            nullableDateControl4 = new NullableDateControl();
            nullableDateControl3 = new NullableDateControl();
            nullableDateControl2 = new NullableDateControl();
            nullableDateControl1 = new NullableDateControl();
            textBox6 = new TextBox();
            label11 = new Label();
            textBox5 = new TextBox();
            label10 = new Label();
            comboBox1 = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            splitContainer1.Panel1.Controls.Add(toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(nullableDateControl4);
            splitContainer1.Panel2.Controls.Add(nullableDateControl3);
            splitContainer1.Panel2.Controls.Add(nullableDateControl2);
            splitContainer1.Panel2.Controls.Add(nullableDateControl1);
            splitContainer1.Panel2.Controls.Add(textBox6);
            splitContainer1.Panel2.Controls.Add(label11);
            splitContainer1.Panel2.Controls.Add(textBox5);
            splitContainer1.Panel2.Controls.Add(label10);
            splitContainer1.Panel2.Controls.Add(comboBox1);
            splitContainer1.Panel2.Controls.Add(label9);
            splitContainer1.Panel2.Controls.Add(label8);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(textBox4);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(textBox3);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(textBox2);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(864, 450);
            splitContainer1.SplitterDistance = 288;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 25);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(288, 425);
            dataGridView1.TabIndex = 1;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonDelete });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(288, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonAdd.Image = (Image)resources.GetObject("toolStripButtonAdd.Image");
            toolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new Size(36, 22);
            toolStripButtonAdd.Text = "Add";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonDelete.Enabled = false;
            toolStripButtonDelete.Image = (Image)resources.GetObject("toolStripButtonDelete.Image");
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(49, 22);
            toolStripButtonDelete.Text = "Delete";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // button3
            // 
            button3.Location = new Point(488, 168);
            button3.Name = "button3";
            button3.Size = new Size(28, 23);
            button3.TabIndex = 12;
            button3.Text = "...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(488, 135);
            button2.Name = "button2";
            button2.Size = new Size(28, 23);
            button2.TabIndex = 9;
            button2.Text = "...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(488, 106);
            button1.Name = "button1";
            button1.Size = new Size(28, 23);
            button1.TabIndex = 6;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // nullableDateControl4
            // 
            nullableDateControl4.Location = new Point(122, 302);
            nullableDateControl4.Margin = new Padding(4);
            nullableDateControl4.Name = "nullableDateControl4";
            nullableDateControl4.SelectedDate = null;
            nullableDateControl4.Size = new Size(192, 26);
            nullableDateControl4.TabIndex = 20;
            // 
            // nullableDateControl3
            // 
            nullableDateControl3.Location = new Point(122, 268);
            nullableDateControl3.Margin = new Padding(4);
            nullableDateControl3.Name = "nullableDateControl3";
            nullableDateControl3.SelectedDate = null;
            nullableDateControl3.Size = new Size(192, 26);
            nullableDateControl3.TabIndex = 18;
            // 
            // nullableDateControl2
            // 
            nullableDateControl2.Location = new Point(122, 234);
            nullableDateControl2.Margin = new Padding(4);
            nullableDateControl2.Name = "nullableDateControl2";
            nullableDateControl2.SelectedDate = null;
            nullableDateControl2.Size = new Size(192, 26);
            nullableDateControl2.TabIndex = 16;
            // 
            // nullableDateControl1
            // 
            nullableDateControl1.Location = new Point(122, 198);
            nullableDateControl1.Margin = new Padding(4);
            nullableDateControl1.Name = "nullableDateControl1";
            nullableDateControl1.SelectedDate = null;
            nullableDateControl1.Size = new Size(192, 26);
            nullableDateControl1.TabIndex = 14;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(122, 66);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(409, 25);
            textBox6.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(29, 68);
            label11.Name = "label11";
            label11.Size = new Size(66, 17);
            label11.TabIndex = 2;
            label11.Text = "Company:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(122, 366);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(409, 25);
            textBox5.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(29, 363);
            label10.Name = "label10";
            label10.Size = new Size(67, 17);
            label10.TabIndex = 23;
            label10.Text = "Comment:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(122, 335);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(199, 25);
            comboBox1.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(56, 333);
            label9.Name = "label9";
            label9.Size = new Size(46, 17);
            label9.TabIndex = 21;
            label9.Text = "Status:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 282);
            label8.Name = "label8";
            label8.Size = new Size(71, 34);
            label8.TabIndex = 19;
            label8.Text = "No Longer\r\nAccepting:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 265);
            label7.Name = "label7";
            label7.Size = new Size(101, 17);
            label7.TabIndex = 17;
            label7.Text = "They Contacted:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(50, 234);
            label6.Name = "label6";
            label6.Size = new Size(53, 17);
            label6.TabIndex = 15;
            label6.Text = "Viewed:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 199);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 13;
            label5.Text = "Applied:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(122, 166);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(360, 25);
            textBox4.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 168);
            label4.Name = "label4";
            label4.Size = new Size(86, 17);
            label4.TabIndex = 10;
            label4.Text = "Tracking URL:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(122, 135);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(360, 25);
            textBox3.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 137);
            label3.Name = "label3";
            label3.Size = new Size(86, 17);
            label3.TabIndex = 7;
            label3.Text = "Listing URL 2:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(122, 104);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(360, 25);
            textBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 106);
            label2.Name = "label2";
            label2.Size = new Size(86, 17);
            label2.TabIndex = 4;
            label2.Text = "Listing URL 1:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(122, 35);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(409, 25);
            textBox1.TabIndex = 1;
            textBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 37);
            label1.Name = "label1";
            label1.Size = new Size(48, 17);
            label1.TabIndex = 0;
            label1.Text = "Job ID:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Job Hunt";
            FormClosing += Form1_FormClosing;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonAdd;
        private TextBox textBox6;
        private Label label11;
        private TextBox textBox5;
        private Label label10;
        private ComboBox comboBox1;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private NullableDateControl nullableDateControl4;
        private NullableDateControl nullableDateControl3;
        private NullableDateControl nullableDateControl2;
        private NullableDateControl nullableDateControl1;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button2;
        private Button button1;
        private ToolStripButton toolStripButtonDelete;
    }
}