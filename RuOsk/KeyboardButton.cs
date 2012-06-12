using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RuOsk
{
    public class KeyboardButton : Button
    {
        private string shiftText = null;
        
        public string ShiftText 
        { 
            get
            {
                if (!string.IsNullOrEmpty(shiftText))
                    return this.shiftText;
                else
                    return this.lowerText.ToUpper();
            }
            set { shiftText = value; }
        }

        private string lowerText = null;

        public string LowerText 
        {
            get { return lowerText; }
            set 
            { 
                this.lowerText = value;
                this.Text = value;
            }
        }

        public void ToggleCase()
        {
            this.Text = this.Text == LowerText ? ShiftText : LowerText;
        }
    }
}
