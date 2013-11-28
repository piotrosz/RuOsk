using System;
using System.Drawing;
using System.Windows.Forms;

namespace RuOsk
{
    internal sealed class ButtonFactory
    {
        public KeyboardButton CreateButton(string lowerCaseText, string upperCaseText, Action<object, EventArgs> handler)
        {
            var button = new KeyboardButton
            {
                LowerCaseText = lowerCaseText,
                UpperCaseText = upperCaseText
            };
            
            SetCommonStyle(button);
            button.Font = new Font("Courier", 13.0f, FontStyle.Regular);

            button.Click += new EventHandler(handler);

            return button;
        }

        public CheckBox CreateCheckbox(string text, Action<object, EventArgs> handler)
        {
            var checkBox1 = new CheckBox
                {
                    Appearance = Appearance.Button,
                    Text = text,
                    Font = new Font("Courier", 10.0f, FontStyle.Regular)
                };

            checkBox1.FlatAppearance.CheckedBackColor = Color.SlateGray;

            SetCommonStyle(checkBox1);

            checkBox1.Click += new EventHandler(handler);

            return checkBox1;
        }

        private void SetCommonStyle(ButtonBase button)
        {
            button.BackColor = Color.FromArgb(100, 99, 99, 99);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.White;

            button.Padding = new Padding(0);
            button.Margin = new Padding(0);
            button.Dock = DockStyle.Fill;
            button.AutoEllipsis = true;
        }
    }
}
