using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DesktopApplication
{
    partial class Form1 : Form
    {
        private readonly IConfiguration _config;
        private readonly string _connStr;

        public Form1(IConfiguration config)
        {
            InitializeComponent();
            _config = config;

            // Get the connection string from appsettings.json
            _connStr = _config.GetConnectionString("DefaultConnection");
        }
        // test comment
        private void TestDatabaseConnection(string connStr)
        {
            using SqlConnection connection = new SqlConnection(connStr);
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

        public DataTable Select(string connStr)
        {
            using SqlConnection connection = new SqlConnection(connStr);
            DataTable dt = new DataTable();
            try
            {

                string sql = "SELECT * FROM tbl_contact";
                SqlCommand cmd = new SqlCommand(sql, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            IblContactID = new Label();
            txtboxContactID = new TextBox();
            txtboxLastName = new TextBox();
            lblLastName = new Label();
            txtboxFirstName = new TextBox();
            lblFirstName = new Label();
            txtboxContactNo = new TextBox();
            lblContactNo = new Label();
            txtboxAddress = new TextBox();
            lblAddress = new Label();
            cmbGender = new ComboBox();
            lblGender = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            txtboxSearch = new TextBox();
            lblSearch = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(354, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(88, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // IblContactID
            // 
            IblContactID.AutoSize = true;
            IblContactID.BackColor = Color.Transparent;
            IblContactID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            IblContactID.Location = new Point(25, 125);
            IblContactID.Name = "IblContactID";
            IblContactID.Size = new Size(82, 21);
            IblContactID.TabIndex = 1;
            IblContactID.Text = "Contact ID";
            // 
            // txtboxContactID
            // 
            txtboxContactID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxContactID.Location = new Point(154, 117);
            txtboxContactID.Name = "txtboxContactID";
            txtboxContactID.Size = new Size(205, 29);
            txtboxContactID.TabIndex = 2;
            // 
            // txtboxLastName
            // 
            txtboxLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxLastName.Location = new Point(154, 187);
            txtboxLastName.Name = "txtboxLastName";
            txtboxLastName.Size = new Size(205, 29);
            txtboxLastName.TabIndex = 4;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.BackColor = Color.Transparent;
            lblLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLastName.Location = new Point(25, 195);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(84, 21);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Last Name";
            // 
            // txtboxFirstName
            // 
            txtboxFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxFirstName.Location = new Point(154, 152);
            txtboxFirstName.Name = "txtboxFirstName";
            txtboxFirstName.Size = new Size(205, 29);
            txtboxFirstName.TabIndex = 6;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.BackColor = Color.Transparent;
            lblFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblFirstName.Location = new Point(25, 160);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(86, 21);
            lblFirstName.TabIndex = 5;
            lblFirstName.Text = "First Name";
            // 
            // txtboxContactNo
            // 
            txtboxContactNo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxContactNo.Location = new Point(154, 222);
            txtboxContactNo.Name = "txtboxContactNo";
            txtboxContactNo.Size = new Size(205, 29);
            txtboxContactNo.TabIndex = 8;
            // 
            // lblContactNo
            // 
            lblContactNo.AutoSize = true;
            lblContactNo.BackColor = Color.Transparent;
            lblContactNo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblContactNo.Location = new Point(25, 230);
            lblContactNo.Name = "lblContactNo";
            lblContactNo.Size = new Size(88, 21);
            lblContactNo.TabIndex = 7;
            lblContactNo.Text = "Contact No";
            // 
            // txtboxAddress
            // 
            txtboxAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxAddress.Location = new Point(154, 265);
            txtboxAddress.Multiline = true;
            txtboxAddress.Name = "txtboxAddress";
            txtboxAddress.Size = new Size(205, 96);
            txtboxAddress.TabIndex = 10;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.Transparent;
            lblAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAddress.Location = new Point(25, 265);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(66, 21);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Address";
            // 
            // cmbGender
            // 
            cmbGender.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbGender.Location = new Point(154, 376);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(205, 29);
            cmbGender.TabIndex = 11;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.BackColor = Color.Transparent;
            lblGender.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblGender.Location = new Point(25, 378);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(61, 21);
            lblGender.TabIndex = 12;
            lblGender.Text = "Gender";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.MenuHighlight;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdd.ForeColor = SystemColors.Control;
            btnAdd.Location = new Point(103, 439);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 37);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.ControlDarkDark;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.ForeColor = SystemColors.Control;
            btnUpdate.Location = new Point(264, 439);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 37);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DarkOrange;
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.ForeColor = SystemColors.Control;
            btnClear.Location = new Point(588, 439);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(145, 37);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(427, 439);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 37);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(427, 152);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(411, 247);
            dataGridView1.TabIndex = 17;
            // 
            // txtboxSearch
            // 
            txtboxSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtboxSearch.Location = new Point(490, 117);
            txtboxSearch.Name = "txtboxSearch";
            txtboxSearch.Size = new Size(348, 29);
            txtboxSearch.TabIndex = 19;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.BackColor = Color.Transparent;
            lblSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSearch.Location = new Point(427, 120);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(57, 21);
            lblSearch.TabIndex = 18;
            lblSearch.Text = "Search";
            lblSearch.Click += label1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(840, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 514);
            Controls.Add(pictureBox2);
            Controls.Add(txtboxSearch);
            Controls.Add(lblSearch);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblGender);
            Controls.Add(cmbGender);
            Controls.Add(txtboxAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtboxContactNo);
            Controls.Add(lblContactNo);
            Controls.Add(txtboxFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtboxLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtboxContactID);
            Controls.Add(IblContactID);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "EContact";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label IblContactID;
        private TextBox txtboxContactID;
        private TextBox txtboxLastName;
        private Label lblLastName;
        private TextBox txtboxFirstName;
        private Label lblFirstName;
        private TextBox txtboxContactNo;
        private Label lblContactNo;
        private TextBox txtboxAddress;
        private Label lblAddress;
        private ComboBox cmbGender;
        private Label lblGender;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private TextBox txtboxSearch;
        private Label lblSearch;
        private PictureBox pictureBox2;
    }
}
