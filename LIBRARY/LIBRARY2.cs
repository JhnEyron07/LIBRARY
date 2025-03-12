using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRARY
{
    public partial class LIBRARY2 : Form
    {
        public LIBRARY2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AUTHORcs aUTHO = new AUTHORcs();
            aUTHO.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BOOKS bOOKS = new BOOKS();
            bOOKS.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BORROWINGRECORDS bORROWINGRECORDS = new BORROWINGRECORDS();
            bORROWINGRECORDS.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MEMBERS mEMBERS = new MEMBERS();
            mEMBERS.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (button5.Text.Trim().ToUpper() == "LOGOUT")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to logout", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    Form1 loginForm = new Form1();
                    loginForm.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please type'Logout' to confirm.", "Logout Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
