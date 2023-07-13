namespace JobHunt
{
    public partial class NullableDateControl : UserControl
    {

        Rectangle clearButtonRectangle;
        Bitmap clearImage = null;
        //Bitmap clearImagePressed = null;

        public NullableDateControl()
        {
            InitializeComponent();
            clearImage = (Bitmap)Image.FromStream(GetType().Assembly.GetManifestResourceStream("JobHunt.Resources.Erase2.bmp"));
            clearImage.MakeTransparent(Color.Magenta);


            //clearImagePressed = (Bitmap)Bitmap.FromStream(this.GetType().Assembly.GetManifestResourceStream("PoolStatControls.Resources.ErasePressed.bmp"));
            //((Bitmap)clearImagePressed).MakeTransparent(Color.Magenta);
        }

        Rectangle drawableRectangle = new Rectangle();
        Rectangle dropDownButtonRectangle = new Rectangle();
        Bitmap dropDownImage = null;
        Bitmap dropDownImagePressed = null;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            drawableRectangle = ClientRectangle;
            drawableRectangle.Height--;
            drawableRectangle.Width--;

            //dropDownButtonRectangle = new Rectangle(drawableRectangle.Right - 32, drawableRectangle.Top + 2, 15, 15);
            clearButtonRectangle = new Rectangle(drawableRectangle.Right - 16, drawableRectangle.Top + 5, 15, 15);

            e.Graphics.FillRectangle(SystemBrushes.Window, drawableRectangle);
            ControlPaint.DrawVisualStyleBorder(e.Graphics, drawableRectangle);
            e.Graphics.DrawImageUnscaled(clearImage, clearButtonRectangle);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            //textBox1.Top = Bounds.Top + 1;
            textBox1.Width = Bounds.Width - 48;
            dateTimePicker1.Width = Bounds.Width - 19;

            drawableRectangle = Bounds;
            drawableRectangle.Height--;
            drawableRectangle.Width--;

            //            dropDownButtonRectangle = new Rectangle(drawableRectangle.Right - 32, drawableRectangle.Top + 2, 15, 15);
            clearButtonRectangle = new Rectangle(drawableRectangle.Right - 16, drawableRectangle.Top + 2, 15, 15);
            Invalidate();
        }

        private void ClearValue()
        {
            textBox1.Text = string.Empty;
            //            _InternalValues = string.Empty;
            try
            {
                dateTimePicker1.Value = DateTime.Now;
                //(DropDownControl as PopupControlDropDown).ClearSelection();
                //SelectionChanged(this, new EventArgs());
            }
            catch { }
        }

        DateTime? selectedDate = null;

        public DateTime? SelectedDate
        {
            get
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    selectedDate = dateTimePicker1.Value;
                }
                else
                {
                    selectedDate = null;
                }
                return selectedDate;
            }
            set
            {
                selectedDate = value;
                if (selectedDate.HasValue)
                {
                    dateTimePicker1.Value = (DateTime)selectedDate;

                    dateTimePicker1.CustomFormat = @"M/d/yyyy";
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    textBox1.Text = dateTimePicker1.Text;
                }
                else
                {
                    dateTimePicker1.Text = string.Empty;
                    textBox1.Text = string.Empty;
                }
            }
        }

        public string Text
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                dateTimePicker1.Text = value;
            }
        }


        private void NullableDateControl_MouseDown(object sender, MouseEventArgs e)
        {
            drawableRectangle = ClientRectangle;
            drawableRectangle.Height--;
            drawableRectangle.Width--;

            //dropDownButtonRectangle = new Rectangle(drawableRectangle.Right - 32, drawableRectangle.Top + 2, 15, 15);
            clearButtonRectangle = new Rectangle(drawableRectangle.Right - 16, drawableRectangle.Top + 2, 15, 15);

            if (clearButtonRectangle.Contains(e.Location))
            {
                ClearValue();
            }
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            //if (!InternalUpdate)
            //{
            //    InternalUpdate = true;

            // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datetimepicker.customformat?view=windowsdesktop-7.0
            dateTimePicker1.CustomFormat = @"M/d/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            //            dateTimePicker1.Format = DateTimePickerFormat.Short;
            textBox1.Text = dateTimePicker1.Text;
            System.Diagnostics.Debug.WriteLine(dateTimePicker1.Text);
            //    InternalUpdate = false;
            //}
        }
    }
}
