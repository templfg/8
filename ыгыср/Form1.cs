using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ыгыср
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Model1 db = new Model1();

        private void Form1_Load(object sender, EventArgs e)
        {
            computersBindingSource.DataSource = db.Computers.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            Computers cmp = (Computers)computersBindingSource.Current;

            frm.db = db;
            frm.cmp = cmp;

            DialogResult dr = frm.ShowDialog();

            if (dr == DialogResult.OK)
            {
                computersBindingSource.DataSource = db.Computers.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Computers cmp = (Computers)computersBindingSource.Current;
            DialogResult dr = MessageBox.Show(
"Вы действительно хотите удалить роль - " + cmp.Model.ToString(),
"Удаление роли", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Computers.Remove(cmp);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                computersBindingSource.DataSource = db.Computers.ToList();
            }
        }
    }
}
