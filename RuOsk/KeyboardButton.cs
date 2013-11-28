using System.Windows.Forms;

namespace RuOsk
{
	public class KeyboardButton : Button
	{
		private string _upperCaseText;
		
		public string UpperCaseText 
		{
            get { return string.IsNullOrEmpty(_upperCaseText) ? _lowerCaseText.ToUpper() : _upperCaseText; }
			set { _upperCaseText = value; }
		}

		private string _lowerCaseText;

		public string LowerCaseText 
		{
			get { return _lowerCaseText; }
			set 
			{ 
				_lowerCaseText = value;
				Text = value;
			}
		}

		public void ToggleCase(bool isUpperCase)
		{
            Text = isUpperCase ? UpperCaseText : LowerCaseText;
		}
	}
}
