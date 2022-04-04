using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace lab4
{
    public partial class Students : Form
    {
        private SQLiteConnection sqlconn;
        private SQLiteCommand sqlCmd;
        private DataTable dataTable = new DataTable();
        private DataSet ds = new DataSet();
        private SQLiteDataAdapter db = new SQLiteDataAdapter();

        public Students()
        {
            InitializeComponent();
        }

        private void SetConnection()
        {
            sqlconn = new SQLiteConnection("Data Source = C:\\Users\\Nelik\\Desktop\\4course\\prog\\lab4C#\\lab4\\bin\\Debug\\register.db");
        }

        public void ExecuteQuery(string StudIdq)
        {
            SetConnection();
            sqlconn.Open();
            sqlCmd = sqlconn.CreateCommand();
            sqlCmd.CommandText = StudIdq;
            sqlCmd.ExecuteNonQuery();
            sqlCmd.Dispose();
            sqlconn.Close();
        }

        public void LoadData(string column)
        {
            SetConnection();
            sqlconn.Open();

            sqlCmd = sqlconn.CreateCommand();
            string CommandText = "SELECT * FROM " + column;
            db = new SQLiteDataAdapter(CommandText,sqlconn);
            ds.Reset();
            db.Fill(ds);
            dataTable = ds.Tables[0];
            dataGridView1.DataSource = dataTable;
            sqlconn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit.", "Attendance Database", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
                Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = comboBox1.SelectedItem;
            string column = selectedItem.ToString();
            LoadData(column);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (((string)comboBox1.SelectedItem) == "Students")
            {
                stud form2 = new stud();
                form2.Show();
            }

            if (((string)comboBox1.SelectedItem) == "Professors")
            {
                Professor form3 = new Professor();
                form3.Show();
            }

            if (((string)comboBox1.SelectedItem) == "Attendance_labs")
            {
                labs form4 = new labs();
                form4.Show();
            }

            if (((string)comboBox1.SelectedItem) == "Attendance_practics")
            {
                practice form5 = new practice();
                form5.Show();
            }

            if (((string)comboBox1.SelectedItem) == "Attendance_lectures")
            {
                Attendance_lectures form6 = new Attendance_lectures();
                form6.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SetConnection();
            sqlconn.Open();

            sqlCmd = sqlconn.CreateCommand();
            string CommandText = richTextBox1.Text;
            db = new SQLiteDataAdapter(CommandText, sqlconn);
            ds.Reset();
            try
            {
                db.Fill(ds);
                dataTable = ds.Tables[0];
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception err)
            {
                MessageBox.Show("Query Error");
            }
            
            sqlconn.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
