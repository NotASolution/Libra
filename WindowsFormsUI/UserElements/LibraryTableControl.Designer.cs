namespace WindowsFormsUI.UserElements
{
    partial class LibraryTableControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            AddMenuButton = new ToolStripMenuItem();
            RedactMenuButton = new ToolStripMenuItem();
            DeleteMenuButton = new ToolStripMenuItem();
            SelectTableMenuButton = new ToolStripMenuItem();
            BooksTableSelectButton = new ToolStripMenuItem();
            BookTokensSelectButton = new ToolStripMenuItem();
            BookLeasesSelectButton = new ToolStripMenuItem();
            MemberTableSelectButton = new ToolStripMenuItem();
            ReadingRoomsTableSelectButton = new ToolStripMenuItem();
            EmployeesTableSelectTable = new ToolStripMenuItem();
            DataTableView = new DataGridView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataTableView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { AddMenuButton, RedactMenuButton, DeleteMenuButton, SelectTableMenuButton });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(942, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // AddMenuButton
            // 
            AddMenuButton.Name = "AddMenuButton";
            AddMenuButton.Size = new Size(41, 20);
            AddMenuButton.Text = "Add";
            AddMenuButton.Click += AddMenuButton_Click;
            // 
            // RedactMenuButton
            // 
            RedactMenuButton.Name = "RedactMenuButton";
            RedactMenuButton.Size = new Size(55, 20);
            RedactMenuButton.Text = "Redact";
            // 
            // DeleteMenuButton
            // 
            DeleteMenuButton.Name = "DeleteMenuButton";
            DeleteMenuButton.Size = new Size(52, 20);
            DeleteMenuButton.Text = "Delete";
            DeleteMenuButton.Click += DeleteMenuButton_Click;
            // 
            // SelectTableMenuButton
            // 
            SelectTableMenuButton.DropDownItems.AddRange(new ToolStripItem[] { BooksTableSelectButton, BookTokensSelectButton, BookLeasesSelectButton, MemberTableSelectButton, ReadingRoomsTableSelectButton, EmployeesTableSelectTable });
            SelectTableMenuButton.Name = "SelectTableMenuButton";
            SelectTableMenuButton.Size = new Size(81, 20);
            SelectTableMenuButton.Text = "Select Table";
            // 
            // BooksTableSelectButton
            // 
            BooksTableSelectButton.Name = "BooksTableSelectButton";
            BooksTableSelectButton.Size = new Size(157, 22);
            BooksTableSelectButton.Text = "Books";
            BooksTableSelectButton.Click += BooksTableSelectButton_Click;
            // 
            // BookTokensSelectButton
            // 
            BookTokensSelectButton.Name = "BookTokensSelectButton";
            BookTokensSelectButton.Size = new Size(157, 22);
            BookTokensSelectButton.Text = "Book Tokens";
            BookTokensSelectButton.Click += BookTokensSelectButton_Click;
            // 
            // BookLeasesSelectButton
            // 
            BookLeasesSelectButton.Name = "BookLeasesSelectButton";
            BookLeasesSelectButton.Size = new Size(157, 22);
            BookLeasesSelectButton.Text = "Book Leases";
            BookLeasesSelectButton.Click += BookLeasesSelectButton_Click;
            // 
            // MemberTableSelectButton
            // 
            MemberTableSelectButton.Name = "MemberTableSelectButton";
            MemberTableSelectButton.Size = new Size(157, 22);
            MemberTableSelectButton.Text = "Members";
            MemberTableSelectButton.Click += MemberTableSelectButton_Click;
            // 
            // ReadingRoomsTableSelectButton
            // 
            ReadingRoomsTableSelectButton.Name = "ReadingRoomsTableSelectButton";
            ReadingRoomsTableSelectButton.Size = new Size(157, 22);
            ReadingRoomsTableSelectButton.Text = "Reading Rooms";
            ReadingRoomsTableSelectButton.Click += ReadingRoomsTableSelectButton_Click;
            // 
            // EmployeesTableSelectTable
            // 
            EmployeesTableSelectTable.Name = "EmployeesTableSelectTable";
            EmployeesTableSelectTable.Size = new Size(157, 22);
            EmployeesTableSelectTable.Text = "Employees";
            EmployeesTableSelectTable.Click += EmployeesTableSelectTable_Click;
            // 
            // DataTableView
            // 
            DataTableView.AllowUserToAddRows = false;
            DataTableView.AllowUserToDeleteRows = false;
            DataTableView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataTableView.Dock = DockStyle.Fill;
            DataTableView.Location = new Point(0, 24);
            DataTableView.Name = "DataTableView";
            DataTableView.ReadOnly = true;
            DataTableView.Size = new Size(942, 517);
            DataTableView.TabIndex = 1;
            DataTableView.SelectionChanged += DataTableView_SelectionChanged;
            // 
            // LibraryTableControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DataTableView);
            Controls.Add(menuStrip1);
            Name = "LibraryTableControl";
            Size = new Size(942, 541);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataTableView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem AddMenuButton;
        private ToolStripMenuItem RedactMenuButton;
        private ToolStripMenuItem DeleteMenuButton;
        private DataGridView DataTableView;
        private ToolStripMenuItem SelectTableMenuButton;
        private ToolStripMenuItem BooksTableSelectButton;
        private ToolStripMenuItem BookTokensSelectButton;
        private ToolStripMenuItem BookLeasesSelectButton;
        private ToolStripMenuItem MemberTableSelectButton;
        private ToolStripMenuItem ReadingRoomsTableSelectButton;
        private ToolStripMenuItem EmployeesTableSelectTable;
    }
}
