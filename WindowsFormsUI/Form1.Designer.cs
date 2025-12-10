namespace WindowsFormsUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            libraryTableControl1 = new WindowsFormsUI.UserElements.LibraryTableControl();
            SuspendLayout();
            // 
            // libraryTableControl1
            // 
            libraryTableControl1.Dock = DockStyle.Fill;
            libraryTableControl1.Location = new Point(0, 0);
            libraryTableControl1.Name = "libraryTableControl1";
            libraryTableControl1.Size = new Size(796, 628);
            libraryTableControl1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 628);
            Controls.Add(libraryTableControl1);
            Name = "Form1";
            Text = "Library";
            ResumeLayout(false);
        }

        #endregion

        private UserElements.LibraryTableControl libraryTableControl1;
    }
}
