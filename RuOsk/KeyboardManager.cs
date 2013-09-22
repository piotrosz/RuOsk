using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RuOsk
{
    internal sealed class KeyboardManager
    {
        private static bool CapsLockPressed = false;
        private static bool ShiftPressed = false;

        private ButtonFactory buttonFactory = new ButtonFactory();
        private static List<KeyboardButton> AllButtons = new List<KeyboardButton>();
        private Form form;
        private TextBox textBox;
        private List<TableLayoutPanel> kbRows;

        public KeyboardManager(List<TableLayoutPanel> kbRows, Form form, TextBox textBox)
        {
            Debug.Assert(kbRows.Count == 5);
            this.kbRows = kbRows;
            this.form = form;
            this.textBox = textBox;
        }

        public KeyboardButton CreateButton(string lowerCaseText, string upperCaseText)
        {
            return CreateButton(lowerCaseText, upperCaseText, (sender, e) => { HandleKeyClick(((Button)sender).Text, e); });
        }

        public KeyboardButton CreateButton(string lowerCaseText)
        {
            return CreateButton(lowerCaseText, upperCaseText:null);
        }

        public KeyboardButton CreateButton(string lowerCaseText, string upperCaseText, Action<object, EventArgs> handler)
        {
            var button = buttonFactory.CreateButton(lowerCaseText, upperCaseText, handler);
            AllButtons.Add(button);
            return button;
        }

        public void AddButtons()
        {
            AddButtons(kbRows[0], new List<Control>
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

            AddButtons(kbRows[1], new List<Control>
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

            AddButtons(kbRows[2], new List<Control>
			{
				buttonFactory.CreateCheckbox("CAPS LOCK", (o, e) => { CapsLockPressed = !CapsLockPressed; ChangeKeyboardCase(CapsLockPressed); }),
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

            AddButtons(kbRows[3], new List<Control>
			{
				CreateButton("SHIFT", "SHIFT", (o, e) => { ShiftPressed = true; if(!CapsLockPressed) ChangeKeyboardCase(true); }),
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
				CreateButton("SHIFT", "SHIFT", (o, e) => { ShiftPressed = true; if(!CapsLockPressed) ChangeKeyboardCase(true); })
			});

            AddButtons(kbRows[4], new List<Control>
			{
				CreateButton("SPACE", "SPACE", (o, e) => { HandleKeyClick(" ", e); }),
			});
        }

        private void AddButtons(TableLayoutPanel row, List<Control> list)
        {
            for (int columnIndex = 0; columnIndex < list.Count; columnIndex++)
            {
                row.Controls.Add(list[columnIndex], columnIndex, row: 0);
            }
        }

        private void ChangeKeyboardCase(bool isUpperCase)
        {
            AllButtons.ForEach(b => b.ToggleCase(isUpperCase));
        }

        private void HandleKeyClick(string character, EventArgs e)
        {
            if (ShiftPressed && !CapsLockPressed)
            {
                ShiftPressed = false;
                ChangeKeyboardCase(false);
            }

            IntPtr windowHandle = NativeWin32.GetForegroundWindow();
            string windowText = "";

            if (windowHandle != IntPtr.Zero)
            {
                windowText = SetWindowText(windowHandle);
                SendKey(character);
            }

            if (windowText != Labels.AppName)
            {
                if (character == "\b" && textBox.Text.Length > 0)
                {
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                }
                else if (character == "\n")
                {
                    textBox.Text += "\r\n";
                }
                else if (character != "\b")
                {
                    textBox.Text += character;
                }
            }

            // Scroll down!
            if (textBox.Text.Length > 1)
            {
                textBox.Select(textBox.Text.Length - 1, 0);
                textBox.ScrollToCaret();
            }
        }

        private string SetWindowText(IntPtr windowHandle)
        {
            string windowText = "";
            NativeWin32.SetForegroundWindow(windowHandle);
            windowText = NativeWin32.GetText(windowHandle);

            if (!string.IsNullOrEmpty(windowText) && windowText != Labels.AppName && windowText != "Program Manager")
            {
                form.Text = Labels.AppName + ": Adding text to " + windowText;
            }
            else
            {
                form.Text = Labels.AppName;
            }

            return windowText;
        }

        private void SendKey(string character)
        {
            // About SendKeys:
            // http://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send.aspx
            switch (character)
            {
                case "\n":
                    SendKeys.Send("{ENTER}");
                    break;
                case "\b":
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "\t":
                    SendKeys.Send("{TAB}");
                    break;
                case "(":
                    SendKeys.Send("+9");
                    break;
                case ")":
                    SendKeys.Send("+0");
                    break;
                case "+":
                    SendKeys.Send("+=");
                    break;
                case "%":
                    SendKeys.Send("+5");
                    break;
                default:
                    SendKeys.Send(character);
                    break;
            }
        }
    }
}
