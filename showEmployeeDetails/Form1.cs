using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace showEmployeeDetails
{
    public partial class Form1 : Form
    {
        //Define twodimensional array for employee number and name
        private string[,] employeeDetails =
        {
            {"01",  "Namal" },
            {"02",  "Kamal" },
            {"03",  "Amal" },
            {"04",  "Nimal" },
            {"04",  "Nimal" },
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {/*
            for (int i = 0; i < employeeDetails.GetLength(0); i++)
            {
                dataGridView1.Rows.Add(employeeDetails[i, 0], employeeDetails[i, 1]);
            }*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            //load the data to text boxes
             for (int i = 0; i < employeeDetails.GetLength(0); i++)
             {
                 Control textBox = Controls.Find($"textBox{i + 1}", true)[0];
                 textBox.Text = employeeDetails[i, 0];
              ((TextBox)textBox).TextChanged += TextBox_TextChanged;
            }

              for (int j = 0; j < employeeDetails.GetLength(0); j++)
             {
                 Control textBox = Controls.Find($"textBox{j + employeeDetails.GetLength(0)+1}", true)[0];
                 textBox.Text = employeeDetails[j, 1];
                ((TextBox)textBox).TextChanged += TextBox_TextChanged;
            }

            //Load the data to data grid view
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = ConvertToDataTable(employeeDetails);

        }

        private DataTable ConvertToDataTable(string[,] array)
        {
            DataTable dataTable = new DataTable();

             // Add columns to DataTable based on the number of columns in the array
            for (int i = 0; i < array.GetLength(1); i++)
            {
                 dataTable.Columns.Add($"Column {i + 1}");
            }

            // Add rows to DataTable based on the number of rows in the array
            for (int i = 0; i < array.GetLength(0); i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row[j] = array[i, j];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
        private void changeButton_Click(object sender, EventArgs e)
        {
            updateEmlpoyeeDetails();
            dataGridView1.DataSource = ConvertToDataTable(employeeDetails);

            MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void updateEmlpoyeeDetails()
        {
            for (int i = 0; i < employeeDetails.GetLength(0); i++)
            {
                Control textBox = Controls.Find($"textBox{i + 1}", true)[0];
                employeeDetails[i, 0] = textBox.Text;

            }

            for (int j = 0; j < employeeDetails.GetLength(0); j++)
            {
                Control textBox = Controls.Find($"textBox{j + employeeDetails.GetLength(0) + 1}", true)[0];
                employeeDetails[j, 1] = textBox.Text;
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < employeeDetails.GetLength(0); i++)
            {
                for (int j = 0; j < employeeDetails.GetLength(1); j++)
                {
                    sb.Append(employeeDetails[i, j]);
                    if (j < employeeDetails.GetLength(1) - 1)
                    {
                        sb.Append(" , ");
                    }
                }
                sb.AppendLine();
            }

            MessageBox.Show(sb.ToString(), "Emlpoyee Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
