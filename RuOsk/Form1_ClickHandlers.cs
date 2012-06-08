using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RuOsk
{
    public partial class Form1 : Form
    {
        private void HandleKeyClick(string letter, EventArgs e)
        {
            if (e is MouseEventArgs &&  ((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left)
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

                IntPtr theHandle = NativeWin32.GetForegroundWindow();
                string windowText = "";
                if (theHandle != IntPtr.Zero)
                {
                    NativeWin32.SetForegroundWindow(theHandle);
                    windowText = NativeWin32.GetText(theHandle);

                    if (!string.IsNullOrEmpty(windowText) && windowText != Labels.AppName)
                        this.Text = "Adding text to: " + windowText;
                    else
                        this.Text = Labels.AppName;

                    SendKeys.Send(letter2);
                }

                if (windowText != Labels.AppName)
                {
                    if (letter == "\b" && textBox1.Text.Length > 0)
                        textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                    else if (letter == "\n")
                        textBox1.Text += "\r\n";
                    else if (letter != "\b")
                        textBox1.Text += letter2;
                }

                // Scroll down!
                if (textBox1.Text.Length > 1)
                {
                    textBox1.Select(textBox1.Text.Length - 1, 0);
                    textBox1.ScrollToCaret();
                }
            }
        }

        private void p1_Click(object sender, EventArgs e)
        {
            HandleKeyClick("ё", e);
        }

        private void p2_Click(object sender, EventArgs e)
        {
            HandleKeyClick("1", e);
        }

        void p3_Click(object sender, EventArgs e)
        {
            HandleKeyClick("2", e);
        }

        void p4_Click(object sender, EventArgs e)
        {
            HandleKeyClick("3", e);
        }

        void p5_Click(object sender, EventArgs e)
        {
            HandleKeyClick("4", e);
        }

        void p6_Click(object sender, EventArgs e)
        {
            HandleKeyClick("5", e);
        }

        void p7_Click(object sender, EventArgs e)
        {
            HandleKeyClick("6", e);
        }

        void p8_Click(object sender, EventArgs e)
        {
            HandleKeyClick("7", e);
        }

        void p9_Click(object sender, EventArgs e)
        {
            HandleKeyClick("8", e);
        }

        void p10_Click(object sender, EventArgs e)
        {
            HandleKeyClick("9", e);
        }

        void p11_Click(object sender, EventArgs e)
        {
            HandleKeyClick("0", e);
        }

        void p12_Click(object sender, EventArgs e)
        {
            HandleKeyClick("-", e);
        }

        void p13_Click(object sender, EventArgs e)
        {
            HandleKeyClick("=", e);
        }

        void p14_Click(object sender, EventArgs e)
        {
            HandleKeyClick("\\", e);
        }

        void p15_Click(object sender, EventArgs e)
        {
            HandleKeyClick("\b", e);
        }

        void p16_Click(object sender, EventArgs e)
        {
            HandleKeyClick("\t", e);
        }

        void p17_Click(object sender, EventArgs e)
        {
            HandleKeyClick("й", e);
        }

        void p18_Click(object sender, EventArgs e)
        {
            HandleKeyClick("ц", e);
        }

        void p19_Click(object sender, EventArgs e)
        {
            HandleKeyClick("у", e);
        }

        void p20_Click(object sender, EventArgs e)
        {
            HandleKeyClick("к", e);
        }

        void p21_Click(object sender, EventArgs e)
        {
            HandleKeyClick("е", e);
        }

        void p22_Click(object sender, EventArgs e)
        {
            HandleKeyClick("н", e);
        }

        void p23_Click(object sender, EventArgs e)
        {
            HandleKeyClick("г", e);
        }

        void p24_Click(object sender, EventArgs e)
        {
            HandleKeyClick("ш", e);
        }

        void p25_Click(object sender, EventArgs e)
        {
            HandleKeyClick("щ", e);
        }

        void p26_Click(object sender, EventArgs e)
        {
            HandleKeyClick("з", e);
        }

        void p27_Click(object sender, EventArgs e)
        {
            HandleKeyClick("х", e);
        }

        void p28_Click(object sender, EventArgs e)
        {
            HandleKeyClick("ъ", e);
        }

        void CapsLock_Click(object sender, EventArgs e)
        {
            if(e is MouseEventArgs && ((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left)
                CapsLockPressed = !CapsLockPressed;
        }

        void Shift_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs && ((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left)
                ShiftPressed = true;
        }

        void p30_Click(object sender, EventArgs e)
        {
            HandleKeyClick("ф", e);
        }

        void p31_Click(object sender, EventArgs e)
        {
            HandleKeyClick("ы", e);
        }

        void p32_Click(object sender, EventArgs e)
        {
            HandleKeyClick("в", e);
        }

        void p33_Click(object sender, EventArgs e)
        {
            HandleKeyClick("а", e);
        }

        void p34_Click(object sender, EventArgs e)
        {
            HandleKeyClick("п", e);
        }

        void p35_Click(object sender, EventArgs e)
        {
            HandleKeyClick("р", e);
        }

        void p36_Click(object sender, EventArgs e)
        {
            HandleKeyClick("о", e);
        }

        void p37_Click(object sender, EventArgs e)
        {
            HandleKeyClick("л", e);
        }

        void p38_Click(object sender, EventArgs e)
        {
            HandleKeyClick("д", e);
        }

        void p39_Click(object sender, EventArgs e)
        {
            HandleKeyClick("ж", e);
        }

        void p40_Click(object sender, EventArgs e)
        {
            HandleKeyClick("э", e);
        }

        void p41_Click(object sender, EventArgs e)
        {
            HandleKeyClick("\n", e);
        }

        void p42_Click(object sender, EventArgs e)
        {
            HandleKeyClick("я", e);
        }

        void p43_Click(object sender, EventArgs e)
        {
            HandleKeyClick("ч", e);
        }

        void p44_Click(object sender, EventArgs e)
        {
            HandleKeyClick("с", e);
        }

        void p45_Click(object sender, EventArgs e)
        {
            HandleKeyClick("м", e);
        }

        void p46_Click(object sender, EventArgs e)
        {
            HandleKeyClick("и", e);
        }

        void p47_Click(object sender, EventArgs e)
        {
            HandleKeyClick("т", e);
        }

        void p48_Click(object sender, EventArgs e)
        {
            HandleKeyClick("ь", e);
        }

        void p49_Click(object sender, EventArgs e)
        {
            HandleKeyClick("б", e);
        }

        void p50_Click(object sender, EventArgs e)
        {
            HandleKeyClick("ю", e);
        }

        void p51_Click(object sender, EventArgs e)
        {
            HandleKeyClick(".", e);
        }

        void p53_Click(object sender, EventArgs e)
        {
            HandleKeyClick(" ", e);
        }
    }
}
