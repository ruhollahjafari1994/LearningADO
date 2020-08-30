using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Working_with_ADO.NET_Disconnected_Model.before
{

    public partial class Form1 : Form
    {            
        
        public Form1()
        {
            InitializeComponent();
        }
     
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=.;Initial Catalog=jafariir_ADW;Integrated Security=True;";
            DataSet ds = new DataSet();
            DataRow row;
            //   string cs = "Server=185.116.163.16,2016;Database=jafariir_DB;User Id=jafariir_ADW;Password=G@briel77;";
            SqlConnection cn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("select * from Employees", cn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Fill(ds, "Employees");// دیتا اداپتور پر میکنه جدول دیتا ست رو جدولی که نامش کارمندان هست 
            ds.Tables[0].Constraints.Add("Empno_PK", ds.Tables["Employees"].Columns["empno"], true);
            
            row = ds.Tables[0].NewRow();//added The row To the New Table 
            row["Empno"] = txtEmpno.Text;
            row["Ename"] = txtEname.Text;
            row["Salary"] = txtSalary.Text;
            row["Hiredate"] = dtpHireDate.MaxDate;
            ds.Tables[0].Rows.Add(row);
            da.Update(ds.Tables[0]);
            MessageBox.Show("Employee Recently Added",this.Text);
            dgvEmployees.DataSource = ds.Tables[0];
        }


        public void Form1_Load(object sender, EventArgs e)
        {
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection cn;
            SqlDataAdapter da;
            DataSet ds;

            string cs = "Data Source=.;Initial Catalog=jafariir_ADW;Integrated Security=True;";
            cn = new SqlConnection(cs);
            da = new SqlDataAdapter("select * from employees", cn);
            ds = new DataSet();
            da.Fill(ds, "employees");
            ds.Tables["employees"].Constraints.Add("Empno_PK", ds.Tables["employees"].Columns["empno"], true);
            int empno = int.Parse(txtEmpno.Text);
            if (ds.Tables["Employees"].Rows.Contains(empno)==true)
            {
                DataRow row;
                row = ds.Tables["employees"].Rows.Find(empno);
                txtEname.Text = row["ename"].ToString();
                txtSalary.Text = row["Salary"].ToString();
                dtpHireDate.Text = row["hiredate"].ToString();
            }
            else
            {
                MessageBox.Show("Record Doesn't Exist ...","Error");
                txtEname.Clear();
                txtSalary.Clear();
            }
        }
    }
    }

