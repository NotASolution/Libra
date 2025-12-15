namespace WindowsFormsUI.AdditionRedactionWindows
{
    partial class MembersARForm
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
            MemberPictureBox = new PictureBox();
            MemberIdTextBox = new TextBox();
            PassportNumberTextBox = new TextBox();
            AddressTextBox = new TextBox();
            BirthDateTextBox = new TextBox();
            EducationTextBox = new TextBox();
            FullnameTextBox = new TextBox();
            ReadingRoomTextBox = new TextBox();
            TelephoneNumberTextBox = new TextBox();
            LoadPictureButton = new Button();
            AcceptButton = new Button();
            ((System.ComponentModel.ISupportInitialize)MemberPictureBox).BeginInit();
            SuspendLayout();
            // 
            // MemberPictureBox
            // 
            MemberPictureBox.Location = new Point(411, 12);
            MemberPictureBox.Name = "MemberPictureBox";
            MemberPictureBox.Size = new Size(276, 359);
            MemberPictureBox.TabIndex = 0;
            MemberPictureBox.TabStop = false;
            // 
            // MemberIdTextBox
            // 
            MemberIdTextBox.ForeColor = SystemColors.InfoText;
            MemberIdTextBox.Location = new Point(40, 12);
            MemberIdTextBox.Name = "MemberIdTextBox";
            MemberIdTextBox.Size = new Size(299, 23);
            MemberIdTextBox.TabIndex = 1;
            MemberIdTextBox.Text = "Member Id number";
            // 
            // PassportNumberTextBox
            // 
            PassportNumberTextBox.Location = new Point(40, 58);
            PassportNumberTextBox.Name = "PassportNumberTextBox";
            PassportNumberTextBox.Size = new Size(299, 23);
            PassportNumberTextBox.TabIndex = 2;
            PassportNumberTextBox.Text = "Passport number ";
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(40, 153);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(299, 23);
            AddressTextBox.TabIndex = 4;
            AddressTextBox.Text = "Address";
            // 
            // BirthDateTextBox
            // 
            BirthDateTextBox.Location = new Point(40, 107);
            BirthDateTextBox.Name = "BirthDateTextBox";
            BirthDateTextBox.Size = new Size(299, 23);
            BirthDateTextBox.TabIndex = 3;
            BirthDateTextBox.Text = "Date of birth";
            // 
            // EducationTextBox
            // 
            EducationTextBox.Location = new Point(40, 348);
            EducationTextBox.Name = "EducationTextBox";
            EducationTextBox.Size = new Size(299, 23);
            EducationTextBox.TabIndex = 8;
            EducationTextBox.Text = "Education";
            // 
            // FullnameTextBox
            // 
            FullnameTextBox.Location = new Point(40, 302);
            FullnameTextBox.Name = "FullnameTextBox";
            FullnameTextBox.Size = new Size(299, 23);
            FullnameTextBox.TabIndex = 7;
            FullnameTextBox.Text = "Fullname";
            // 
            // ReadingRoomTextBox
            // 
            ReadingRoomTextBox.Location = new Point(40, 253);
            ReadingRoomTextBox.Name = "ReadingRoomTextBox";
            ReadingRoomTextBox.Size = new Size(299, 23);
            ReadingRoomTextBox.TabIndex = 6;
            ReadingRoomTextBox.Text = "Reading room";
            // 
            // TelephoneNumberTextBox
            // 
            TelephoneNumberTextBox.Location = new Point(40, 207);
            TelephoneNumberTextBox.Name = "TelephoneNumberTextBox";
            TelephoneNumberTextBox.Size = new Size(299, 23);
            TelephoneNumberTextBox.TabIndex = 5;
            TelephoneNumberTextBox.Text = "Telephone number";
            // 
            // LoadPictureButton
            // 
            LoadPictureButton.Location = new Point(411, 386);
            LoadPictureButton.Name = "LoadPictureButton";
            LoadPictureButton.Size = new Size(276, 23);
            LoadPictureButton.TabIndex = 9;
            LoadPictureButton.Text = "Load picture";
            LoadPictureButton.UseVisualStyleBackColor = true;
            LoadPictureButton.Click += ImageLoad_Click;
            // 
            // AcceptButton
            // 
            AcceptButton.Location = new Point(311, 463);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(75, 23);
            AcceptButton.TabIndex = 10;
            AcceptButton.Text = "Accept";
            AcceptButton.UseVisualStyleBackColor = true;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // MembersARForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 498);
            Controls.Add(AcceptButton);
            Controls.Add(LoadPictureButton);
            Controls.Add(EducationTextBox);
            Controls.Add(FullnameTextBox);
            Controls.Add(ReadingRoomTextBox);
            Controls.Add(TelephoneNumberTextBox);
            Controls.Add(AddressTextBox);
            Controls.Add(BirthDateTextBox);
            Controls.Add(PassportNumberTextBox);
            Controls.Add(MemberIdTextBox);
            Controls.Add(MemberPictureBox);
            Name = "MembersARForm";
            Text = "MembersARForm";
            ((System.ComponentModel.ISupportInitialize)MemberPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox MemberPictureBox;
        private TextBox MemberIdTextBox;
        private TextBox PassportNumberTextBox;
        private TextBox AddressTextBox;
        private TextBox BirthDateTextBox;
        private TextBox EducationTextBox;
        private TextBox FullnameTextBox;
        private TextBox ReadingRoomTextBox;
        private TextBox TelephoneNumberTextBox;
        private Button LoadPictureButton;
        private Button AcceptButton;
    }
}