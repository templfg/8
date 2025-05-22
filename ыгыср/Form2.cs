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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Model1 db { get; set; }
        public Computers cmp {  get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = cmp.Id.ToString();
            textBox2.Text = cmp.Model.ToString();
            textBox3.Text = cmp.Ves.ToString();
            textBox4.Text = cmp.Memory.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmp.Id = Convert.ToInt32(textBox1.Text);
            cmp.Model = textBox2.Text;
            cmp.Ves = Convert.ToInt32(textBox3.Text);
            cmp.Memory = Convert.ToInt32(textBox4.Text);

            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }
    }
}
