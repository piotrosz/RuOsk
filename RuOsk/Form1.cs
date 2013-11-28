using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RuOsk.Transliteration.Implementations;
using TransliterationRU.Engine;

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

        private KeyboardManager _keyboardManager;
            
		public Form1()
		{            
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Context menu must be empty. Standard context menu causes window to get focused
			textBox1.ContextMenu = new ContextMenu();

            _keyboardManager = new KeyboardManager(
                new List<TableLayoutPanel> { this.keyboardRow1, this.keyboardRow2, this.keyboardRow3, this.keyboardRow4, this.keyboardRow5 },
                this,
                textBox1);

			_keyboardManager.AddButtons();

            btnTranslit.Text = Labels.btnTranslitLong;
            btnCopy.Text = Labels.btnCopyLong;
            btnCut.Text = Labels.btnCutLong;
            btnClear.Text = Labels.btnClearLong;
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.SelectedText))
			{
				if(!string.IsNullOrEmpty(textBox1.Text))
				{
					Clipboard.SetText(textBox1.Text);
				}
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
			{
				textBox1.Text = "";
			}
			else
			{
				textBox1.SelectedText = "";
			}
		}

		private void btnTranslit_Click(object sender, EventArgs e)
		{
			var trans = new Engine(new Transliteration_En());

			string text = trans.Trasliterate(string.IsNullOrEmpty(textBox1.SelectedText) ? textBox1.Text : textBox1.SelectedText);

			if(!string.IsNullOrEmpty(text))
			{
				Clipboard.SetText(text);
			}
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
	}
}
