using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GatePass
{
    internal class DatabaseOperation
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=AJAY\\SQLEXPRESS;Initial Catalog=gatepass;Integrated Security=True";//"Data Source = (LocalDB)\\MSSQLLocalDB;database=gatepass;integrated=true";
            return con;
        }

        public DataSet GetData(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }catch(Exception ex)
            {
                Console.WriteLine("Exception in getData : " + ex);
            }
            return ds;
        }

        public void setData(string query,string msg)
        {
            try
            {
                SqlConnection con = getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
                if (msg != null)
                    MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}