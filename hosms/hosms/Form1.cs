using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hosms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            PatientInfo P = new PatientInfo();
            //to get the inputs from textbox
            P.Patient = textBox1.Text.Trim();
            P.Doctor = textBox2.Text.Trim();
            P.Appointment = textBox3.Text.Trim();
            P.Prescription = textBox6.Text.Trim();
            P.Ward = textBox5.Text.Trim();
            P.MedicalRec = textBox4.Text.Trim();

            // Check if the DataGridView's DataSource is null
            if (dataGridView1.DataSource == null)
            {
                // Create a new DataTable and set it as the DataSource
                DataTable table = new DataTable();
                table.Columns.Add("Patient", typeof(string));
                table.Columns.Add("Doctor", typeof(string));
                table.Columns.Add("Appointment", typeof(string));
                table.Columns.Add("Prescription", typeof(string));
                table.Columns.Add("Ward", typeof(string));
                table.Columns.Add("Medical Records", typeof(string));
                dataGridView1.DataSource = table;
            }

            // Add the new row to the DataTable
            DataTable tblModel = (DataTable)dataGridView1.DataSource;
            tblModel.Rows.Add(P.Patient, P.Doctor, P.Appointment, P.Prescription, P.Ward, P.MedicalRec);
            // remove text from text box
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            MessageBox.Show("New Patient has been added!", "Success");
        }

        public class PatientInfo
        {
            public string Patient { get; set; }
            public string Doctor { get; set; }
            public string Appointment { get; set; }
            public string Prescription { get; set; }
            public string Ward { get; set; }
            public string MedicalRec { get; set; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                MessageBox.Show("Selected row deleted successfully!", "Success");
            }
            else if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Table is Empty.", "Error");
            }
            else
            {
                MessageBox.Show("Please select a single row for deletion.", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming the columns in your DataGridView are in the order: Patient, Doctor, Appointment, Prescription, Ward, Medical Records
                selectedRow.Cells[0].Value = textBox1.Text.Trim(); // Assuming patient is a TextBox for editing
                selectedRow.Cells[1].Value = textBox2.Text.Trim(); // Assuming doctor is a TextBox for editing
                selectedRow.Cells[2].Value = textBox3.Text.Trim(); // Assuming appointment is a TextBox for editing
                selectedRow.Cells[3].Value = textBox6.Text.Trim(); // Assuming prescription is a TextBox for editing
                selectedRow.Cells[4].Value = textBox5.Text.Trim(); // Assuming ward is a TextBox for editing
                selectedRow.Cells[5].Value = textBox4.Text.Trim(); // Assuming medicalrec is a TextBox for editing

                MessageBox.Show("Selected row updated successfully!", "Success");
            }
            else
            {
                MessageBox.Show("Please select a single row to update!", "Error");
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["Patient"].Value.ToString();
                textBox2.Text = row.Cells["Doctor"].Value.ToString();
                textBox3.Text = row.Cells["Appointment"].Value.ToString();
                textBox4.Text = row.Cells["Prescription"].Value.ToString();
                textBox5.Text = row.Cells["Ward"].Value.ToString();
                textBox6.Text = row.Cells["Medical Records"].Value.ToString();
            }
        }
    }

}
