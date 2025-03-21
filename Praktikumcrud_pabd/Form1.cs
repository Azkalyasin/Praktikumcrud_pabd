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

namespace Praktikumcrud_pabd
{
    public partial class Form1: Form
    {
        static string connectionString = "Data Source=LAPTOP-PGU1KG1D\\AZKALADZKIA;Initial Catalog=OrganisasiMahasiswa;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtEmail.Clear();
            txtTelpon.Clear();
            txtAlamat.Clear();


            txtNim.Focus();
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT NIM AS [NIM], Nama, Email, Telpon, Alamat FROM Mahasiswa";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvMahasiswa.AutoGenerateColumns = true;
                    dgvMahasiswa.DataSource = dt;

                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
    }

}
