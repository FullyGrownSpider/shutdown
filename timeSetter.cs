using System.Runtime.InteropServices;

namespace shutdown
{
    public partial class timeSetter : Form
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        const UInt32 SWP_NOSIZE = 0x0001;

        const UInt32 SWP_NOMOVE = 0x0002;

        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public timeSetter()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            secondUpDown.Increment = 5;
            actionSelect.SelectedIndex = 0;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Hide();
            var form2 = new timerCounter(hourUpDown.Value * 3600 + minuteUpDown.Value * 60 + secondUpDown.Value, actionSelect.SelectedIndex);
            form2.Closed += (s, args) => Close();
            form2.Show();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            if (keyData == Keys.Enter)
            {
                StartButton.PerformClick();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        private void load(object sender, EventArgs e)
        {
            SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }
    }
}