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

        private static List<KeyboardButton> AllButtons = new List<KeyboardButton>();

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
                CreateButton("1", "!"),
                CreateButton("2", "\""),
                CreateButton("3", "№"),
                CreateButton("4", ";"),
                CreateButton("5", "%"),
                CreateButton("6", ":"), 
                CreateButton("7", "?"), 
                CreateButton("8", "*"), 
                CreateButton("9", "("), 
                CreateButton("0", ")"), 
                CreateButton("-", "_"), 
                CreateButton("=", "+"), 
                CreateButton("\\"),
                CreateButton("<-", "<-", (o, e) => { HandleKeyClick("\b", e); })
            });

            AddButtons(keyboardRow2, new List<Control>()
            {
                CreateButton("TAB", "TAB", (o, e) => { HandleKeyClick("\t", e); }),
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
                CreateCheckbox("CAPS LOCK", (o, e) => { CapsLockPressed = !CapsLockPressed; ChangeKeyboardCase(); }),
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
                CreateButton("ENTER", "ENTER", (o, e) => { HandleKeyClick("\n", e); }),
            });

            AddButtons(keyboardRow4, new List<Control>()
            {
                CreateButton("SHIFT", "SHIFT", (o, e) => { ShiftPressed = true; ChangeKeyboardCase(); }),
                CreateButton("я"),
                CreateButton("ч"),
                CreateButton("с"),
                CreateButton("м"),
                CreateButton("и"),
                CreateButton("т"),
                CreateButton("ь"),
                CreateButton("б"),
                CreateButton("ю"),
                CreateButton(".", ","),
                CreateButton("SHIFT", "SHIFT", (o, e) => { ShiftPressed = true; ChangeKeyboardCase(); })
            });

            AddButtons(keyboardRow5, new List<Control>()
            {
                CreateButton("SPACE", "SPACE", (o, e) => { HandleKeyClick(" ", e); }),
            });
        }

        private void ChangeKeyboardCase()
        {
            foreach (var button in AllButtons)
                button.ToggleCase();
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

        private void HandleKeyClick(string letter, EventArgs e)
        {
            if (ShiftPressed)
                ShiftPressed = false;

            IntPtr theHandle = NativeWin32.GetForegroundWindow();
            string windowText = "";
            if (theHandle != IntPtr.Zero)
            {
                NativeWin32.SetForegroundWindow(theHandle);
                windowText = NativeWin32.GetText(theHandle);

                if (!string.IsNullOrEmpty(windowText) && windowText != Labels.AppName)
                    this.Text = Labels.AppName + ": Adding text to " + windowText;
                else
                    this.Text = Labels.AppName;

                // About SendKeys:
                // http://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send.aspx

                if (letter == "\n")
                    SendKeys.Send("{ENTER}");
                else if (letter == "\b")
                    SendKeys.Send("{BACKSPACE}");
                else if (letter == "\t")
                    SendKeys.Send("{TAB}");
                else if (letter == "(")
                    SendKeys.Send("+9");
                else if (letter == ")")
                    SendKeys.Send("+0");
                else if (letter == "+")
                    SendKeys.Send("+=");
                else if (letter == "%")
                    SendKeys.Send("+5");
                else
                    SendKeys.Send(letter);
            }

            if (windowText != Labels.AppName)
            {
                if (letter == "\b" && textBox1.Text.Length > 0)
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                else if (letter == "\n")
                    textBox1.Text += "\r\n";
                else if (letter != "\b")
                    textBox1.Text += letter;
            }

            // Scroll down!
            if (textBox1.Text.Length > 1)
            {
                textBox1.Select(textBox1.Text.Length - 1, 0);
                textBox1.ScrollToCaret();
            }
        }

        private KeyboardButton CreateButton(string text, string shiftText, Action<object, EventArgs> handler)
        {
            var button = new KeyboardButton();
            button.LowerText = text;
            button.ShiftText = shiftText;

            SetCommonStyle(button);
            button.Font = new Font("Courier", 13.0f, FontStyle.Regular);
            
            button.Click += new EventHandler(handler);

            AllButtons.Add(button);

            return button;
        }

        private KeyboardButton CreateButton(string text, string shiftText)
        {
            return CreateButton(text, shiftText, (sender, e) => { HandleKeyClick(((Button)sender).Text, e); });
        }

        private KeyboardButton CreateButton(string text)
        {
            return CreateButton(text, null);
        }

        private CheckBox CreateCheckbox(string text, Action<object, EventArgs> handler)
        {
            CheckBox checkBox1 = new System.Windows.Forms.CheckBox();
            
            checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox1.Text = text;
            checkBox1.Font = new Font("Courier", 10.0f, FontStyle.Regular);
            checkBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.SlateGray;

            SetCommonStyle(checkBox1);            

            checkBox1.Click += new EventHandler(handler);

            return checkBox1;
        }

        private void SetCommonStyle(ButtonBase button)
        {
            button.BackColor = System.Drawing.Color.FromArgb(100, 99, 99, 99);
            button.ForeColor = System.Drawing.Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = System.Drawing.Color.White;

            button.Padding = new Padding(0);
            button.Margin = new Padding(0);
            button.Dock = DockStyle.Fill;
            button.AutoEllipsis = true;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
        }
    }
}
