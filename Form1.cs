using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // making object of sqlconnection is like getting a mobile no of other party to be contacted

            SqlConnection con=new SqlConnection("Server=HSA-PC\\SQLEXPRESS; Database=School; Integrated Security=true");
           // con.ConnectionString = "Server=HSA-PC\\SQLEXPRESS; Database=School; Integrated Security=true ";

            //This is like determining what to say to the other party
            String n = textBox1.Text;
            int r = Convert.ToInt32(textBox2.Text);
            int a = Convert.ToInt32(textBox2.Text);

            
            string Sqlstatement = "insert into Student (age,roll,name) values(@a,@r,@n)";
            
            //string Sqlstatement = "insert into Student (age,roll,name) values(" + a + "," + r + ",'" + n + "')";
            SqlCommand cmd=new SqlCommand(Sqlstatement,con);
            //cmd.CommandText = "Insert into ";
            //cmd.Connection = con;               
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@r", r);
            cmd.Parameters.AddWithValue("@n", n);

           // SqlDataReader r = null;
            int res = -1;
            try
            {
                //This is like dialing the mobile no to be contacted
                con.Open();
                 res= cmd.ExecuteNonQuery();


            }

            catch(SqlException se)
            {
                MessageBox.Show(se.Message);

            }

            if(res<0)
            {
                MessageBox.Show("cannot insert");

            }

            else
            {
                MessageBox.Show(res + " rows inserted");
            }


        }

    }
}
