using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class stud : Form
    {
        public stud()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Students obj = new Students();
            string studentq = $"INSERT INTO Students (Name,Last_Name) VALUES (' {textBox1.Text} ',' {textBox2.Text} ')";
            obj.ExecuteQuery(studentq);
            MessageBox.Show("Success");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Students obj = new Students();
            string studentq = $"DELETE FROM Students WHERE Student_ID = {textBox3.Text}";
            obj.ExecuteQuery(studentq);
            MessageBox.Show("Success");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
