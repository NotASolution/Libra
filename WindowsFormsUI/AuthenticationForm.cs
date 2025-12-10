using ADO_Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class AuthenticationForm : Form
    {
        DataSourceManager man;

        public AuthenticationForm()
        {
            man = DataSourceManager.GetDataSourceManager();
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (man.SetUsernameAndPassword(NameTextBox.Text, PasswordTextBox.Text))
            {
                Form1 form = new Form1();
                form.Show();
            }
            else 
            {
                MessageBox.Show("Неверное имя или пароль");
            }
        }
    }
}
