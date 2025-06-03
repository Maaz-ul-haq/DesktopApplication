using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.econtactClasses
{
    public class ContactClass
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        //static string myconnectionstring = ConfigrationManager.ConnectionString["DefaultConnection"].ConnectionString;
        //string conn = _config.GetConnectionString("DefaultConnection");

    }

    public class Repo
    {
        private readonly string _connStr;

        public Repo(string config)
        {
            _connStr = config;
        }

        private SqlConnection GetConnection() => new SqlConnection(_connStr);

        public void TestDatabaseConnection()
        {
            using SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                MessageBox.Show("Database connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }
        }

        public DataTable Select()
        {
            using SqlConnection connection = GetConnection();
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tbl_contact";
                using SqlCommand cmd = new SqlCommand(sql, connection);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd)
                {
                    MissingSchemaAction = MissingSchemaAction.AddWithKey
                };

                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return dt;
        }

        public DataTable SelectByID(string key)
        {
            using SqlConnection connection = GetConnection();
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tbl_contact WHERE FirstName LIKE '%"+key+ "%' OR LastName  LIKE '%" + key + "%' OR Address  LIKE '%" + key + "%'OR Gender LIKE '%" + key + "%' ";
                using SqlCommand cmd = new SqlCommand(sql, connection);
                using SqlDataAdapter adapter = new SqlDataAdapter(cmd)
                {
                    MissingSchemaAction = MissingSchemaAction.AddWithKey
                };

                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return dt;
        }

        public bool InsertRecord(ContactClass model)
        {
            string sql = @"INSERT INTO tbl_contact (FirstName, LastName, ContactNo, Address, Gender)
                       VALUES (@FirstName, @LastName, @ContactNo, @Address, @Gender)";
            return ExecuteNonQuery(sql, model);
        }

        public bool UpdateRecord(ContactClass model)
        {
            string sql = @"UPDATE tbl_contact 
                       SET FirstName = @FirstName, LastName = @LastName, ContactNo = @ContactNo, Address = @Address, Gender = @Gender 
                       WHERE ContactID = @ContactID";
            return ExecuteNonQuery(sql, model, true);
        }

        public bool DeleteRecord(ContactClass model)
        {
            string sql = "DELETE FROM tbl_contact WHERE ContactID = @ContactID";
            return ExecuteNonQuery(sql, model, deleteOnly: true);
        }

        private bool ExecuteNonQuery(string sql, ContactClass model, bool includeId = false, bool deleteOnly = false)
        {
            using SqlConnection connection = GetConnection();
            try
            {
                using SqlCommand command = new SqlCommand(sql, connection);
                if (!deleteOnly)
                {
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@ContactNo", model.ContactNo);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                }

                if (includeId || deleteOnly)
                {
                    command.Parameters.AddWithValue("@ContactID", model.ContactID);
                }

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
    }

}
