namespace WindowsFormsUI.NewFolder
{
    partial class ReadingRoomsARForm
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
            RoomNumberTextBox = new TextBox();
            RoomNameTextBox = new TextBox();
            RoomCapacityTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // RoomNumberTextBox
            // 
            RoomNumberTextBox.Location = new Point(60, 58);
            RoomNumberTextBox.Name = "RoomNumberTextBox";
            RoomNumberTextBox.Size = new Size(254, 23);
            RoomNumberTextBox.TabIndex = 0;
            RoomNumberTextBox.Text = "Room Number";
            // 
            // RoomNameTextBox
            // 
            RoomNameTextBox.Location = new Point(60, 104);
            RoomNameTextBox.Name = "RoomNameTextBox";
            RoomNameTextBox.Size = new Size(254, 23);
            RoomNameTextBox.TabIndex = 1;
            RoomNameTextBox.Text = "Room Name";
            // 
            // RoomCapacityTextBox
            // 
            RoomCapacityTextBox.Location = new Point(60, 150);
            RoomCapacityTextBox.Name = "RoomCapacityTextBox";
            RoomCapacityTextBox.Size = new Size(254, 23);
            RoomCapacityTextBox.TabIndex = 2;
            RoomCapacityTextBox.Text = "Room Capacity";
            // 
            // button1
            // 
            button1.Location = new Point(145, 223);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Finish";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Finish_Click;
            // 
            // ReadingRoomsARForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 275);
            Controls.Add(button1);
            Controls.Add(RoomCapacityTextBox);
            Controls.Add(RoomNameTextBox);
            Controls.Add(RoomNumberTextBox);
            Name = "ReadingRoomsARForm";
            Text = "ReadingRoomsARForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox RoomNumberTextBox;
        private TextBox RoomNameTextBox;
        private TextBox RoomCapacityTextBox;
        private Button button1;
    }
}