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
using RuOsk.Transliteration.Implementations;
using TransliterationRU.Engine;
using RuOsk.Properties;

namespace RuOsk
{
    public partial class Form1 : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= NativeWin32.WS_EX_NOACTIVATE;
                return param;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeWin32.WM_MOUSEACTIVATE)
            {
                m.Result = new IntPtr(NativeWin32.MA_NOACTIVATE);
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
            AddButtons();
            AssingLabels();
        }

        private void AddButtons()
        {
            AddButtons(keyboardRow1, new List<Control>()
            {
                CreateButton("ё"),
                CreateButton("1"),
                CreateButton("2"),
                CreateButton("3"),
                CreateButton("4"),
                CreateButton("5"),
                CreateButton("6"), 
                CreateButton("7"), 
                CreateButton("8"), 
                CreateButton("9"), 
                CreateButton("0"), 
                CreateButton("-"), 
                CreateButton("="), 
                CreateButton("\\"),
                CreateButton("<-", (o, e) => { HandleKeyClick("\b", e); })
            });

            AddButtons(keyboardRow2, new List<Control>()
            {
                CreateButton("TAB", (o, e) => { HandleKeyClick("\t", e); }),
                CreateButton("й"),
                CreateButton("ц"),
                CreateButton("у"),
                CreateButton("к"),
                CreateButton("е"),
                CreateButton("н"),
                CreateButton("г"),
                CreateButton("ш"),
                CreateButton("щ"),
                CreateButton("з"),
                CreateButton("х"),
                CreateButton("ъ")
            });

            AddButtons(keyboardRow3, new List<Control>()
            {
                CreateCheckbox("CAPS LOCK", (o, e) => { CapsLockPressed = !CapsLockPressed; }),
                CreateButton("ф"),
                CreateButton("ы"),
                CreateButton("в"),
                CreateButton("а"),
                CreateButton("п"),
                CreateButton("р"),
                CreateButton("о"),
                CreateButton("л"),
                CreateButton("д"),
                CreateButton("ж"),
                CreateButton("э"),
                CreateButton("ENTER", (o, e) => { HandleKeyClick("\n", e); }),
            });

            AddButtons(keyboardRow4, new List<Control>()
            {
                CreateButton("SHIFT", (o, e) => { ShiftPressed = true; }),
                CreateButton("я"),
                CreateButton("ч"),
                CreateButton("с"),
                CreateButton("м"),
                CreateButton("и"),
                CreateButton("т"),
                CreateButton("ь"),
                CreateButton("б"),
                CreateButton("ю"),
                CreateButton("."),
                CreateButton("SHIFT", (o, e) => { ShiftPressed = true; })
            });

            AddButtons(keyboardRow5, new List<Control>()
            {
                CreateButton("SPACE", (o, e) => { HandleKeyClick(" ", e); }),
                //CreateButton(Labels.btnToggleHide, (o, e) => { btnToggle_Click(o, e); })
            });
        }

        private void AddButtons(TableLayoutPanel row, List<Control> list)
        {
            for (int i = 0; i < list.Count; i++)
                row.Controls.Add(list[i], i, 0);
        }

        private void AssingLabels()
        {
            btnTranslit.Text = Labels.btnTranslitLong;
            btnCopy.Text = Labels.btnCopyLong;
            btnCut.Text = Labels.btnCutLong;
            btnClear.Text = Labels.btnClearLong;
            //btnTogglePanel.Text = Labels.btnToggleHide;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.SelectedText))
            {
                if(!string.IsNullOrEmpty(textBox1.Text))
                    Clipboard.SetText(textBox1.Text);
            }
            else
            {
                Clipboard.SetText(textBox1.SelectedText);
            }
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.SelectedText))
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    Clipboard.SetText(textBox1.Text);
                    textBox1.Text = "";
                }
            }
            else
            {
                Clipboard.SetText(textBox1.SelectedText);
                textBox1.SelectedText = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.SelectedText))
                textBox1.Text = "";
            else
                textBox1.SelectedText = "";
        }

        private void btnTranslit_Click(object sender, EventArgs e)
        {
            var trans = new Engine(new Transliteration_En());

            string text = trans.Trasliterate(
                string.IsNullOrEmpty(textBox1.SelectedText) ? textBox1.Text : textBox1.SelectedText);

            if(!string.IsNullOrEmpty(text))
                Clipboard.SetText(text);
        }

        private void btnTranslit_Resize(object sender, EventArgs e)
        {
            btnTranslit.Text = (btnTranslit.Width < 100) ? Labels.btnTranslitShort : Labels.btnTranslitLong;
        }

        private void btnClear_Resize(object sender, EventArgs e)
        {
            btnClear.Text = (btnClear.Width < 70) ? Labels.btnClearShort : Labels.btnClearLong;
        }

        private void btnCopy_Resize(object sender, EventArgs e)
        {
            btnCopy.Text = (btnCopy.Width < 70) ? Labels.btnCopyShort : Labels.btnCopyLong;
        }

        //private void btnToggle_Click(object sender, EventArgs e)
        //{
        //    splitContainerMain.Panel2.Hide();
        //    //splitContainerMain.SplitterDistance = 0;

        //    Button button = (Button)sender;
        //    button.Text = (button.Text == Labels.btnToggleHide) ? Labels.btnToggleShow : Labels.btnToggleHide;
        //}

        private void HandleKeyClick(string letter, EventArgs e)
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

        private Button CreateButton(string text, Action<object, EventArgs> handler)
        {
            var button = new Button();
            button.Text = text;

            button.BackColor = System.Drawing.Color.FromArgb(100, 99, 99, 99);
            button.ForeColor = System.Drawing.Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = System.Drawing.Color.White;

            button.Font = new Font("Times New Roman", 12.0f, FontStyle.Regular);
            button.Padding = new Padding(0);
            button.Margin = new Padding(0);
            button.Dock = DockStyle.Fill;

            button.Click += new EventHandler(handler);

            return button;
        }

        private Button CreateButton(string text)
        {
            return CreateButton(text, (sender, e) => { HandleKeyClick(((Button)sender).Text, e); });
        }

        private CheckBox CreateCheckbox(string text, Action<object, EventArgs> handler)
        {
            CheckBox checkBox1 = new System.Windows.Forms.CheckBox();
            checkBox1.Appearance = System.Windows.Forms.Appearance.Button;

            checkBox1.Text = text;

            checkBox1.BackColor = System.Drawing.Color.FromArgb(100, 99, 99, 99);
            checkBox1.ForeColor = System.Drawing.Color.White;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.FlatAppearance.BorderSize = 1;
            checkBox1.FlatAppearance.BorderColor = System.Drawing.Color.White;

            checkBox1.Font = new Font("Times New Roman", 12.0f, FontStyle.Regular);
            checkBox1.Padding = new Padding(0);
            checkBox1.Margin = new Padding(0);
            checkBox1.Dock = DockStyle.Fill;

            checkBox1.Click += new EventHandler(handler);

            return checkBox1;
        }
    }
}
