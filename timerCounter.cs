using HumbleWidgets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shutdown
{
    public partial class timerCounter : Form
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        const UInt32 SWP_NOSIZE = 0x0001;

        const UInt32 SWP_NOMOVE = 0x0002;

        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;
        private System.Windows.Forms.Timer timer;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public decimal totalTime;
        Label[] labels;
        DateTime lastUpdateTime = DateTime.Now;
        int selection;
        bool hasHours;

        public timerCounter() : this(10, 2)
        {
        }

        public timerCounter(decimal time, int selection)
        {
            byte[] fontData = resources.novem__;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, resources.novem__.Length);
            AddFontMemResourceEx(fontPtr, (uint)resources.novem__.Length, IntPtr.Zero, ref dummy);
            Marshal.FreeCoTaskMem(fontPtr);
            myFont = new Font(fonts.Families[0], 50.0F);

            totalTime = Math.Max(time, 10);

            InitializeComponent();
            this.selection = selection;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            hasHours = time >= 3600;

            BackColor = Color.Black;
            timer = new()
            {
                Interval = 100
            };
            timer.Tick += Timer_Elapsed;

            if (hasHours)
            {
                ClientSize = new Size(210, 80);
                labels = new Label[5];
            }
            else
            {
                ClientSize = new Size(150, 80);
                labels = new Label[4];
            }
            FillWithTimer();
            if (hasHours)
            {
                labels[4].MouseWheel += (s, e) => TimerCounter_MouseWheel(e.Delta > 0, 3600);
            }
            labels[3].MouseWheel += (s, e) => TimerCounter_MouseWheel(e.Delta > 0, 600);
            labels[2].MouseWheel += (s, e) => TimerCounter_MouseWheel(e.Delta > 0, 60);
            labels[1].MouseWheel += (s, e) => TimerCounter_MouseWheel(e.Delta > 0, 10);
            labels[0].MouseWheel += (s, e) => TimerCounter_MouseWheel(e.Delta > 0, 1);
            SetTimer();
            timer.Start();

        }

        private void Timer_Elapsed(object sender, object e)
        {
            TimerTick();
        }

        private void FillWithTimer()
        {
            int discount = 0;
            if (hasHours)
                for (int i = 0; i < 7; i++)
                {
                    var item = CreateItem(i);
                    if (i == 1 || i == 4)
                    {
                        item.Text = ":";
                        discount++;
                        item.Location = new Point(-20 * discount + item.Location.X + 10, 10);
                    }
                    else
                    {
                        labels[4 - i + discount] = item;
                        item.Text = "0";
                        item.Location = new Point(-20 * discount + item.Location.X, 10);
                    }
                    Controls.Add(item);
                }
            else
                for (int i = 0; i < 5; i++)
                {
                    var item = CreateItem(i);
                    if (i == 2)
                    {
                        item.Text = ":";
                        discount++;
                        item.Location = new Point(item.Location.X - 10, 10);
                    }
                    else
                    {
                        labels[3 - i + discount] = item;
                        item.Text = "0";
                        item.Location = new Point(-20 * discount + item.Location.X, 10);
                    }
                    Controls.Add(item);
                }
        }

        private void TimerCounter_MouseWheel(bool up, int scroll)
        {
            if (up)
            {
                if (hasHours && totalTime < 3600 * 8 || !hasHours && totalTime < 600 * 8)
                    totalTime += scroll;
            }
            else if (totalTime > scroll)
            {
                totalTime -= scroll;
            }
            Console.WriteLine(totalTime);
            SetTimer();
        }

        public Label CreateItem(int from)
        {
            var item = new Label
            {
                Location = new Point(-10 + from * 35, 10),
                Size = new Size(40, 90),
                ForeColor = Color.Lime,
                BackColor = Color.Black,
                BorderStyle = BorderStyle.None,
                Font = myFont,
                Enabled = true
            };
            return item;
        }

        public void TimerTick()
        {
            var result = (DateTime.Now - lastUpdateTime).TotalSeconds;
            if (totalTime <= 0)
            {
                if (selection == 0)
                {
                    Process.Start("shutdown", "/s /t 0");
                    Close();
                }
                else if (selection == 1)
                {
                    Process.Start("shutdown", "/h /t 0");
                    Close();
                }
                else
                {
                    timer.Stop();
                    Controls.Clear();
                    FillWithTimer();
                }
            }
            if (result >= 1)
            {
                lastUpdateTime = DateTime.Now;
                totalTime--;
                SetTimer();
            }
        }

        public void SetTimer()
        {
            if (hasHours)
            {
                labels[4].Text = "" + totalTime / 3600;
                labels[3].Text = "" + totalTime / 60 / 10 % 6;
            }
            else
                labels[3].Text = "" + totalTime / 60 / 10;
            labels[2].Text = "" + totalTime / 60 % 10;
            labels[1].Text = "" + totalTime % 60 / 10;
            labels[0].Text = "" + totalTime % 10;
        }

        private void load(object sender, EventArgs e)
        {
            SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
