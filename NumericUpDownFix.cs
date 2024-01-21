namespace HumbleWidgets
{
    public class NumericUpDownFix : Label
    {
        readonly NumericUpDownBase father = new();

        public NumericUpDownFix()
        {
            AutoSize = false;
            Location = father.Location;
            BorderStyle = father.BorderStyle;
            father.BorderStyle = BorderStyle.None;
            father.Controls.RemoveAt(0);
            father.Parent = this;
            father.Location = Point.Empty;
            ClientSize = father.Size;
            Width -= 25;

            //code for this program
            Minimum = -100;
            Maximum = 600;
            father.GotFocus += Father_GotFocus;
            father.LostFocus += Father_LostFocus; 
        }

        string oldValue = "0";

        private void Father_LostFocus(object? sender, EventArgs e)
        {
            if (father.Controls[0].Text == "")
                father.Controls[0].Text = oldValue;
        }

        private void Father_GotFocus(object? sender, EventArgs e)
        {
            oldValue = father.Controls[0].Text;
            father.Controls[0].Text = "";
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                father.BackColor = value;
            }
        }
        public decimal Value { get { return father.Value; } set { father.Value = value; } }
        public decimal Increment { get { return father.Increment; } set { father.Increment = value; } }
        public decimal Maximum { get { return father.Maximum; } set { father.Maximum = value; } }
        public decimal Minimum { get { return father.Minimum; } set { father.Minimum = value; } }
        public override Color ForeColor { get { return father.ForeColor; } set { father.ForeColor = value; } }

        private class NumericUpDownBase : NumericUpDown
        {
            protected override void OnMouseWheel(MouseEventArgs e)
            {
                if (e is HandledMouseEventArgs hme)
                {
                    hme.Handled = true;
                }
                if (e.Delta > 0)
                {
                    decimal test = this.Value + Increment;
                    if (test <= Maximum)
                    {
                        Value = test;
                    }
                    else
                    {
                        Value = Maximum;
                    }
                }
                else if (e.Delta < 0)
                {
                    decimal test = Value - Increment;
                    if (test <= Minimum)
                    {
                        Value = Minimum;
                    }
                    else
                    {
                        Value = test;
                    }
                }
            }
        }
    }
}
