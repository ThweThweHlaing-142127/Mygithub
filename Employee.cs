using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employeepj
{
    public partial class Employee : Form
    {
        SqlConnection conn =new SqlConnection(@" Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\305\3CS-10 Thwe Thwe Hlaing\Project.mdf;Integrated Security=True;Connect Timeout=30");
  
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
            dgvShow.Rows.Clear();
            Form1 frm = new Form1("insert");
            if(frm.ShowDialog()==DialogResult.Yes)
            {
                btnDisplay.PerformClick();
            }
            

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dgvShow.Rows.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Employee",conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                dgvShow.Rows.Add(dr["Id"],dr["EmployeeID"], dr["EmployeeName"], dr["EmployeeDOB"], dr["EmployeeAddress"],dr["Role"],dr["Gender"], dr["BasicSalary"], dr["Tax"],
                    dr["Date"], dr["TotalAmount"]);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
               int  id = Convert.ToInt32(dgvShow.SelectedRows[0].Cells["Id"].Value);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from Employee where Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                Form1 frm = new Form1("update");
                frm.id = Convert.ToInt32(dgvShow.SelectedRows[0].Cells["Id"].Value);
                frm.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
        private void dgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            dgvShow.Rows.Clear();
            Form1 frm = new Form1("insert");
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                btnDisplay.PerformClick();
            }
            
        }

        private void btnDisplay_Click_1(object sender, EventArgs e)
        {
            dgvShow.Rows.Clear();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Employee", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                dgvShow.Rows.Add(dr["Id"], dr["EmployeeID"], dr["EmployeeName"], dr["EmployeeDOB"], dr["EmployeeAddress"], dr["Role"], dr["Gender"], dr["BasicSalary"], dr["Tax"],
                    dr["Date"], dr["TotalAmount"]);
            }

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                Form1 frm = new Form1("update");
                frm.id = Convert.ToInt32(dgvShow.SelectedRows[0].Cells["Id"].Value);
                frm.ShowDialog();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvShow.SelectedRows[0].Cells["Id"].Value);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from Employee where Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
