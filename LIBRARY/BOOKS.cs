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
    public partial class BOOKS : Form
    {
        public BOOKS()
        {
            InitializeComponent();
        }
        QUERIES queries = new QUERIES();
        private void BOOKS_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = queries.FetchBooks();
        }
    }
}
