using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
using RuOsk.Transliteration.Implenentations;
using TransliterationRU.Engine;

namespace RuOsk
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string ldWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        //Gets active window title
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hwnd, string lpString, int cch);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        public static string GetText(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        //Gets handle for active window
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetForegroundWindow();

        private const int WS_EX_NOACTIVATE = 0x08000000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= WS_EX_NOACTIVATE;
                return param;
            }
        }

        private const int WM_MOUSEACTIVATE = 0x0021;
        private const int MA_NOACTIVATE = 0x0003;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = new IntPtr(MA_NOACTIVATE);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private static bool CapsLockPressed = false;
        private static bool ShiftPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int offset = 46;
            int left = 16;
            int top = 13;

            #region Row #1
            var p1 = CreatePanel(top, left);
            p1.Click += new EventHandler(p1_Click);
            this.Controls.Add(p1);

            var p2 = CreatePanel(top, left += offset);
            p2.Click += new EventHandler(p2_Click);
            this.Controls.Add(p2);

            var p3 = CreatePanel(top, left += offset);
            p3.Click += new EventHandler(p3_Click);
            this.Controls.Add(p3);

            var p4 = CreatePanel(top, left += offset);
            p4.Click += new EventHandler(p4_Click);
            this.Controls.Add(p4);

            var p5 = CreatePanel(top, left += offset);
            p5.Click += new EventHandler(p5_Click);
            this.Controls.Add(p5);

            var p6 = CreatePanel(top, left += offset);
            p6.Click += new EventHandler(p6_Click);
            this.Controls.Add(p6);

            var p7 = CreatePanel(top, left += offset);
            p7.Click += new EventHandler(p7_Click);
            this.Controls.Add(p7);

            var p8 = CreatePanel(top, left += offset);
            p8.Click += new EventHandler(p8_Click);
            this.Controls.Add(p8);

            var p9 = CreatePanel(top, left += offset);
            p9.Click += new EventHandler(p9_Click);
            this.Controls.Add(p9);

            var p10 = CreatePanel(top, left += offset);
            p10.Click += new EventHandler(p10_Click);
            this.Controls.Add(p10);

            var p11 = CreatePanel(top, left += offset);
            p11.Click += new EventHandler(p11_Click);
            this.Controls.Add(p11);

            var p12 = CreatePanel(top, left += offset);
            p12.Click += new EventHandler(p12_Click);
            this.Controls.Add(p12);

            var p13 = CreatePanel(top, left += offset);
            p13.Click += new EventHandler(p13_Click);
            this.Controls.Add(p13);

            var p14 = CreatePanel(top, left += offset);
            p14.Click += new EventHandler(p14_Click);
            this.Controls.Add(p14);

            var p15 = CreatePanel(top, left += offset);
            p15.Click += new EventHandler(p15_Click);
            this.Controls.Add(p15); 
            #endregion

            left = 16;
            top = 60;

            #region Row #2
            var p16 = CreatePanel(top, left);
            p16.Width = 67;
            p16.Click += new EventHandler(p16_Click);
            this.Controls.Add(p16);

            var p17 = CreatePanel(top, left = left + offset + 30);
            p17.Click += new EventHandler(p17_Click);
            this.Controls.Add(p17);

            var p18 = CreatePanel(top, left += offset);
            p18.Click += new EventHandler(p18_Click);
            this.Controls.Add(p18);

            var p19 = CreatePanel(top, left += offset);
            p19.Click += new EventHandler(p19_Click);
            this.Controls.Add(p19);

            var p20 = CreatePanel(top, left += offset);
            p20.Click += new EventHandler(p20_Click);
            this.Controls.Add(p20);

            var p21 = CreatePanel(top, left += offset);
            p21.Click += new EventHandler(p21_Click);
            this.Controls.Add(p21);

            var p22 = CreatePanel(top, left += offset);
            p22.Click += new EventHandler(p22_Click);
            this.Controls.Add(p22);

            var p23 = CreatePanel(top, left += offset);
            p23.Click += new EventHandler(p23_Click);
            this.Controls.Add(p23);

            var p24 = CreatePanel(top, left += offset);
            p24.Click += new EventHandler(p24_Click);
            this.Controls.Add(p24);

            var p25 = CreatePanel(top, left += offset);
            p25.Click += new EventHandler(p25_Click);
            this.Controls.Add(p25);

            var p26 = CreatePanel(top, left += offset);
            p26.Click += new EventHandler(p26_Click);
            this.Controls.Add(p26);

            var p27 = CreatePanel(top, left += offset);
            p27.Click += new EventHandler(p27_Click);
            this.Controls.Add(p27);

            var p28 = CreatePanel(top, left += offset);
            p28.Click += new EventHandler(p28_Click);
            this.Controls.Add(p28);

            var p280 = CreatePanel(top, left += offset);
            p280.Width = 60;
            p280.Height = 50;
            p280.Click += new EventHandler(p41_Click);
            this.Controls.Add(p280);
            #endregion

            left = 16;
            top = 105;

            #region Row #3
            var p29 = CreatePanel(top, left);
            p29.Width = 75;
            p29.Click += new EventHandler(CapsLock_Click);
            this.Controls.Add(p29);

            var p30 = CreatePanel(top, left += offset + 40);
            p30.Click += new EventHandler(p30_Click);
            this.Controls.Add(p30);

            var p31 = CreatePanel(top, left += offset);
            p31.Click += new EventHandler(p31_Click);
            this.Controls.Add(p31);

            var p32 = CreatePanel(top, left += offset);
            p32.Click += new EventHandler(p32_Click);
            this.Controls.Add(p32);

            var p33 = CreatePanel(top, left += offset);
            p33.Click += new EventHandler(p33_Click);
            this.Controls.Add(p33);

            var p34 = CreatePanel(top, left += offset);
            p34.Click += new EventHandler(p34_Click);
            this.Controls.Add(p34);

            var p35 = CreatePanel(top, left += offset);
            p35.Click += new EventHandler(p35_Click);
            this.Controls.Add(p35);

            var p36 = CreatePanel(top, left += offset);
            p36.Click += new EventHandler(p36_Click);
            this.Controls.Add(p36);

            var p37 = CreatePanel(top, left += offset);
            p37.Click += new EventHandler(p37_Click);
            this.Controls.Add(p37);

            var p38 = CreatePanel(top, left += offset);
            p38.Click += new EventHandler(p38_Click);
            this.Controls.Add(p38);

            var p39 = CreatePanel(top, left += offset);
            p39.Click += new EventHandler(p39_Click);
            this.Controls.Add(p39);

            var p40 = CreatePanel(top, left += offset);
            p40.Click += new EventHandler(p40_Click);
            this.Controls.Add(p40);

            var p41 = CreatePanel(top, left += offset);
            p41.Width = 90;
            p41.Click += new EventHandler(p41_Click);
            this.Controls.Add(p41);
            #endregion

            left = 124;
            top = 150;

            #region Row #4
            var p411 = CreatePanel(top, 16);
            p411.Width = 100;
            p411.Click += new EventHandler(Shift_Click);
            this.Controls.Add(p411);

            var p42 = CreatePanel(top, left);
            p42.Click += new EventHandler(p42_Click);
            this.Controls.Add(p42);

            var p43 = CreatePanel(top, left += offset);
            p43.Click += new EventHandler(p43_Click);
            this.Controls.Add(p43);

            var p44 = CreatePanel(top, left += offset);
            p44.Click += new EventHandler(p44_Click);
            this.Controls.Add(p44);

            var p45 = CreatePanel(top, left += offset);
            p45.Click += new EventHandler(p45_Click);
            this.Controls.Add(p45);

            var p46 = CreatePanel(top, left += offset);
            p46.Click += new EventHandler(p46_Click);
            this.Controls.Add(p46);

            var p47 = CreatePanel(top, left += offset);
            p47.Click += new EventHandler(p47_Click);
            this.Controls.Add(p47);

            var p48 = CreatePanel(top, left += offset);
            p48.Click += new EventHandler(p48_Click);
            this.Controls.Add(p48);

            var p49 = CreatePanel(top, left += offset);
            p49.Click += new EventHandler(p49_Click);
            this.Controls.Add(p49);

            var p50 = CreatePanel(top, left += offset);
            p50.Click += new EventHandler(p50_Click);
            this.Controls.Add(p50);

            var p51 = CreatePanel(top, left += offset);
            p51.Click += new EventHandler(p51_Click);
            this.Controls.Add(p51);

            var p52 = CreatePanel(top, left += offset);
            p52.Width = 120;
            p52.Click += new EventHandler(Shift_Click);
            this.Controls.Add(p52);
            #endregion

            left = 198;
            top = 195;

            #region Row #5
            var p53 = CreatePanel(top, left);
            p53.Width = 260;
            p53.Click += new EventHandler(p53_Click);
            this.Controls.Add(p53);
            #endregion

            pictureBox1.SendToBack();
        }

        private TransPanel CreatePanel(int top, int left)
        {
            var panel = new TransPanel();
            panel.Width = 35;
            panel.Height = 37;
            panel.Top = top;
            panel.Left = left;
            panel.BackColor = Color.Red;
            return panel;
        }

        private void HandleKeyClick(string letter)
        {
            string letter2 = "";
            if (letter == "." && (CapsLockPressed || ShiftPressed))
                letter2 = ",";
            else if (CapsLockPressed || ShiftPressed)
                letter2 = letter.ToUpper();
            else
                letter2 = letter;

            if (ShiftPressed)
                ShiftPressed = false;

            IntPtr theHandle = GetForegroundWindow();
            string windowText = "";
            if (theHandle != IntPtr.Zero)
            {
                SetForegroundWindow(theHandle);
                windowText = GetText(theHandle);
                if (!string.IsNullOrEmpty(windowText) && windowText != "RuOsk")
                    this.Text = "Adding text to " + windowText;
                else
                    this.Text = "RuOsk";
                
                SendKeys.Send(letter2);
            }

            if (windowText != "RuOsk")
            {
                if (letter == "\b" && textBox1.Text.Length > 0)
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                else if (letter == "\n")
                    textBox1.Text += "\r\n";
                else if (letter != "\b")
                    textBox1.Text += letter2;
            }

            // Scroll down
            if (textBox1.Text.Length > 1)
            {
                textBox1.Select(textBox1.Text.Length - 1, 0);
                textBox1.ScrollToCaret();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.SelectedText))
                Clipboard.SetText(textBox1.SelectedText);
            else
                Clipboard.SetText(textBox1.Text);
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.SelectedText))
            {
                Clipboard.SetText(textBox1.SelectedText);
                textBox1.SelectedText = "";
            }
            else
            {
                Clipboard.SetText(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.SelectedText))
                textBox1.SelectedText = "";
            else
                textBox1.Text = "";
        }

        private void btnTranslit_Click(object sender, EventArgs e)
        {
            var entrans = new Transliteration_En();
            var trans = new Engine(entrans);

            if (string.IsNullOrEmpty(textBox1.SelectedText))
                Clipboard.SetText(trans.Trasliterate(textBox1.Text));
            else
                Clipboard.SetText(trans.Trasliterate(textBox1.SelectedText));
        }
    }
}
