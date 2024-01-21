namespace shutdown
{
    partial class timerCounter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(timerCounter));
            SuspendLayout();
            // 
            // timerCounter
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "timerCounter";
            MaximizeBox = false;
            DoubleBuffered = true;
            MdiChildrenMinimizedAnchorBottom = false;
            AutoScaleMode = AutoScaleMode.Font;
            MinimizeBox = false;
            Load += load;
            SizeGripStyle = SizeGripStyle.Hide;
            AutoScaleMode = AutoScaleMode.Font;
            ShowInTaskbar = false;
            ResumeLayout(false);
        }

        #endregion
    }
}