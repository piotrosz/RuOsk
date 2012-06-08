namespace RuOsk
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTranslit = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnTogglePanel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(625, 112);
            this.textBox1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-8, -9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(733, 268);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCopy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCopy.Location = new System.Drawing.Point(0, 84);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(93, 28);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            this.btnCopy.Resize += new System.EventHandler(this.btnCopy_Resize);
            // 
            // btnCut
            // 
            this.btnCut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnCut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnCut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCut.Location = new System.Drawing.Point(0, 28);
            this.btnCut.Margin = new System.Windows.Forms.Padding(4);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(93, 28);
            this.btnCut.TabIndex = 9;
            this.btnCut.UseVisualStyleBackColor = false;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Location = new System.Drawing.Point(0, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 28);
            this.btnClear.TabIndex = 10;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.Resize += new System.EventHandler(this.btnClear_Resize);
            // 
            // btnTranslit
            // 
            this.btnTranslit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnTranslit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTranslit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTranslit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTranslit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTranslit.Location = new System.Drawing.Point(0, 56);
            this.btnTranslit.Margin = new System.Windows.Forms.Padding(4);
            this.btnTranslit.Name = "btnTranslit";
            this.btnTranslit.Size = new System.Drawing.Size(93, 28);
            this.btnTranslit.TabIndex = 11;
            this.btnTranslit.UseVisualStyleBackColor = false;
            this.btnTranslit.Click += new System.EventHandler(this.btnTranslit_Click);
            this.btnTranslit.Resize += new System.EventHandler(this.btnTranslit_Resize);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 266);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCopy);
            this.splitContainer1.Panel2.Controls.Add(this.btnTranslit);
            this.splitContainer1.Panel2.Controls.Add(this.btnCut);
            this.splitContainer1.Panel2.Controls.Add(this.btnClear);
            this.splitContainer1.Size = new System.Drawing.Size(722, 113);
            this.splitContainer1.SplitterDistance = 625;
            this.splitContainer1.TabIndex = 12;
            // 
            // btnTogglePanel
            // 
            this.btnTogglePanel.AutoEllipsis = true;
            this.btnTogglePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnTogglePanel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnTogglePanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnTogglePanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(100)))));
            this.btnTogglePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTogglePanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTogglePanel.Location = new System.Drawing.Point(526, 199);
            this.btnTogglePanel.Margin = new System.Windows.Forms.Padding(0);
            this.btnTogglePanel.Name = "btnTogglePanel";
            this.btnTogglePanel.Size = new System.Drawing.Size(49, 32);
            this.btnTogglePanel.TabIndex = 13;
            this.btnTogglePanel.UseVisualStyleBackColor = false;
            this.btnTogglePanel.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // Form1
            // 
            this.AccessibleDescription = "RuOsk - Russian on-screen keyboard";
            this.AccessibleName = "RuOsk";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(957, 382);
            this.Controls.Add(this.btnTogglePanel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.Text = "RuOsk";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTranslit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnTogglePanel;
    }
}

