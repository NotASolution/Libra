namespace WindowsFormsUI
{
    partial class AuthenticationForm
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
            NameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            EnterButton = new Button();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(60, 70);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(198, 23);
            NameTextBox.TabIndex = 0;
            NameTextBox.Text = "Name";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(61, 125);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(198, 23);
            PasswordTextBox.TabIndex = 1;
            PasswordTextBox.Text = "Password";
            // 
            // EnterButton
            // 
            EnterButton.Location = new Point(118, 197);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(75, 23);
            EnterButton.TabIndex = 2;
            EnterButton.Text = "Enter";
            EnterButton.UseVisualStyleBackColor = true;
            EnterButton.Click += EnterButton_Click;
            // 
            // AuthenticationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 273);
            Controls.Add(EnterButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(NameTextBox);
            Name = "AuthenticationForm";
            Text = "AuthenticationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextBox;
        private TextBox PasswordTextBox;
        private Button EnterButton;
    }
}