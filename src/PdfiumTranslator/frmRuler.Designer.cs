namespace PdfiumTranslator
{
    partial class frmRuler
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
            this.rulerControl = new Lyquidity.UtilityLibrary.Controls.RulerControl();
            this.SuspendLayout();
            // 
            // rulerControl
            // 
            this.rulerControl.ActualSize = true;
            this.rulerControl.DivisionMarkFactor = 5;
            this.rulerControl.Divisions = 10;
            this.rulerControl.ForeColor = System.Drawing.Color.Black;
            this.rulerControl.Location = new System.Drawing.Point(0, 0);
            this.rulerControl.MajorInterval = 72;
            this.rulerControl.Margin = new System.Windows.Forms.Padding(0);
            this.rulerControl.MiddleMarkFactor = 3;
            this.rulerControl.MouseTrackingOn = false;
            this.rulerControl.Name = "rulerControl";
            this.rulerControl.Orientation = Lyquidity.UtilityLibrary.Controls.enumOrientation.orHorizontal;
            this.rulerControl.RulerAlignment = Lyquidity.UtilityLibrary.Controls.enumRulerAlignment.raTopOrLeft;
            this.rulerControl.ScaleMode = Lyquidity.UtilityLibrary.Controls.enumScaleMode.smPoints;
            this.rulerControl.Size = new System.Drawing.Size(600, 23);
            this.rulerControl.StartValue = 0D;
            this.rulerControl.TabIndex = 0;
            this.rulerControl.Text = "rulerControl";
            this.rulerControl.VerticalNumbers = true;
            this.rulerControl.ZoomFactor = 1D;
            this.rulerControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rulerControl_MouseDown);
            // 
            // frmRuler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(600, 32);
            this.Controls.Add(this.rulerControl);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRuler";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRuler";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRuler_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRuler_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmRuler_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Lyquidity.UtilityLibrary.Controls.RulerControl rulerControl;
    }
}