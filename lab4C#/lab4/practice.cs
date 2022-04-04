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
    public partial class practice : Form
    {
        public practice()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Students obj = new Students();
            string studentq = $"INSERT INTO Attendance_practics (Student_ID,Subject_ID,Day,Type) VALUES (' {textBox1.Text} ',' {textBox2.Text} ',' {textBox3.Text} ',' {textBox4.Text}')";
            obj.ExecuteQuery(studentq);
            MessageBox.Show("Success");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
