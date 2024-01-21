using HumbleWidgets;

namespace shutdown
{
    partial class timeSetter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(timeSetter));
            hourUpDown = new NumericUpDownFix();
            hourLabel = new Label();
            minuteLabel = new Label();
            minuteUpDown = new NumericUpDownFix();
            secondLabel = new Label();
            secondUpDown = new NumericUpDownFix();
            StartButton = new Button();
            actionSelect = new ComboBox();
            SuspendLayout();
            // 
            // hourUpDown
            // 
            hourUpDown.BorderStyle = BorderStyle.Fixed3D;
            hourUpDown.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            hourUpDown.Location = new Point(21, 12);
            hourUpDown.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            hourUpDown.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            hourUpDown.Name = "hourUpDown";
            hourUpDown.Size = new Size(34, 23);
            hourUpDown.TabIndex = 0;
            hourUpDown.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // hourLabel
            // 
            hourLabel.AutoSize = true;
            hourLabel.Location = new Point(16, 42);
            hourLabel.Name = "hourLabel";
            hourLabel.Size = new Size(39, 16);
            hourLabel.TabIndex = 1;
            hourLabel.Text = "Hours";
            // 
            // minuteLabel
            // 
            minuteLabel.AutoSize = true;
            minuteLabel.Location = new Point(61, 42);
            minuteLabel.Name = "minuteLabel";
            minuteLabel.Size = new Size(50, 16);
            minuteLabel.TabIndex = 3;
            minuteLabel.Text = "Minutes";
            // 
            // minuteUpDown
            // 
            minuteUpDown.BorderStyle = BorderStyle.Fixed3D;
            minuteUpDown.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            minuteUpDown.Location = new Point(71, 12);
            minuteUpDown.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            minuteUpDown.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            minuteUpDown.Name = "minuteUpDown";
            minuteUpDown.Size = new Size(34, 23);
            minuteUpDown.TabIndex = 2;
            minuteUpDown.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // secondLabel
            // 
            secondLabel.AutoSize = true;
            secondLabel.Location = new Point(114, 42);
            secondLabel.Name = "secondLabel";
            secondLabel.Size = new Size(51, 16);
            secondLabel.TabIndex = 5;
            secondLabel.Text = "Seconds";
            // 
            // secondUpDown
            // 
            secondUpDown.BorderStyle = BorderStyle.Fixed3D;
            secondUpDown.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            secondUpDown.Location = new Point(121, 12);
            secondUpDown.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            secondUpDown.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            secondUpDown.Name = "secondUpDown";
            secondUpDown.Size = new Size(34, 23);
            secondUpDown.TabIndex = 4;
            secondUpDown.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // StartButton
            // 
            StartButton.Location = new Point(114, 63);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(57, 23);
            StartButton.TabIndex = 6;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // actionSelect
            // 
            actionSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            actionSelect.FormattingEnabled = true;
            actionSelect.Items.AddRange(new object[] { "Shutdown", "Hibernate", "Nothing" });
            actionSelect.Location = new Point(12, 63);
            actionSelect.Name = "actionSelect";
            actionSelect.Size = new Size(93, 24);
            actionSelect.TabIndex = 0;
            actionSelect.TabStop = false;
            // 
            // timeSetter
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(180, 98);
            Controls.Add(actionSelect);
            Controls.Add(StartButton);
            Controls.Add(secondLabel);
            Controls.Add(secondUpDown);
            Controls.Add(minuteLabel);
            Controls.Add(minuteUpDown);
            Controls.Add(hourLabel);
            Controls.Add(hourUpDown);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "timeSetter";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Shutdown";
            TopMost = true;
            Load += load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label hourLabel;
        private Label minuteLabel;
        private Label secondLabel;
        private NumericUpDownFix hourUpDown;
        private NumericUpDownFix minuteUpDown;
        private NumericUpDownFix secondUpDown;
        private Button StartButton;
        private ComboBox actionSelect;
    }
}