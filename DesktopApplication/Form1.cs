using DesktopApplication.econtactClasses;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DesktopApplication
{
    public partial class Form1 : Form
    {
        //public static IConfiguration Configuration { get; private set; }
        private readonly string _connStr;
        private readonly Repo _repo;
        public Form1(IConfiguration config)
        {
            InitializeComponent();
            _connStr = config.GetConnectionString("DefaultConnection");
            _repo = new Repo(_connStr);
        }
        ContactClass c = new ContactClass();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtboxContactNo.Text;
            c.Address = txtboxAddress.Text;
            c.Gender = cmbGender.Text;

            //Insert Data in Database
            bool success = _repo.InsertRecord(c);

            if (success)
            {
                MessageBox.Show("The Contact Successfully Inserted");
                Clear();
            }
            else
            {
                MessageBox.Show("The Contact Could Not be Submitted");
            }
            DataTable dt = _repo.Select();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = _repo.Select();
            dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            c.ContactID = Convert.ToInt32(txtboxContactID.Text);
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtboxContactNo.Text;
            c.Address = txtboxAddress.Text;
            c.Gender = cmbGender.Text;

            //Insert Data in Database
            bool success = _repo.UpdateRecord(c);

            if (success)
            {
                MessageBox.Show("The Contact Successfully Updated");
                Clear();
            }
            else
            {
                MessageBox.Show("The Contact Could Not be Updated");
            }
            DataTable dt = _repo.Select();
            dataGridView1.DataSource = dt;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtboxContactID.Text = "";
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtboxContactNo.Text = "";
            txtboxAddress.Text = "";
            cmbGender.Text = "";

        }
        private void Clear()
        {
            txtboxContactID.Text = "";
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtboxContactNo.Text = "";
            txtboxAddress.Text = "";
            cmbGender.Text = "";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtboxContactID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            txtboxContactNo.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            txtboxAddress.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            c.ContactID = Convert.ToInt32(txtboxContactID.Text);
            //Insert Data in Database
            bool success = _repo.DeleteRecord(c);

            if (success)
            {
                MessageBox.Show("The Contact Successfully Deleted");
                Clear();
            }
            else
            {
                MessageBox.Show("The Contact Could Not be Deleted");
            }
            DataTable dt = _repo.Select();
            dataGridView1.DataSource = dt;
        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtboxSearch.Text;
            DataTable dt = _repo.SelectByID(keyword);
            dataGridView1.DataSource = dt;
        }
    }
}
