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
    public partial class Attendance_lectures : Form
    {
        public Attendance_lectures()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
            string studentq = $"INSERT INTO Attendance_lectures (Student_ID,Subject_ID,Day,Type) VALUES (' {textBox1.Text} ',' {textBox2.Text} ',' {textBox3.Text} ',' {textBox4.Text}')";
            obj.ExecuteQuery(studentq);
            MessageBox.Show("Success");

            obj.LoadData("Attendance_lectures");
        }

        private void Attendance_lectures_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
