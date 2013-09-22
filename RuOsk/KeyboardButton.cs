using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RuOsk
{
	public class KeyboardButton : Button
	{
		private string upperCaseText;
		
		public string UpperCaseText 
		{
            get { return string.IsNullOrEmpty(upperCaseText) ? this.lowerCaseText.ToUpper() : this.upperCaseText; }
			set { upperCaseText = value; }
		}

		private string lowerCaseText;

		public string LowerCaseText 
		{
			get { return lowerCaseText; }
			set 
			{ 
				this.lowerCaseText = value;
				this.Text = value;
			}
		}

		public void ToggleCase(bool isUpperCase)
		{
            this.Text = isUpperCase ? UpperCaseText : LowerCaseText;
		}
	}
}
