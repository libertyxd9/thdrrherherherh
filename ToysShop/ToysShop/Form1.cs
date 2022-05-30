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

namespace ToysShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dataoutput();
        }
        void Dataoutput()
        {
            SqlConnection vivod = new SqlConnection(Connection.connectionStr);
            try
            {
                vivod.Open();
                string SqlExp = "SELECT dbo.Authors.SurName, dbo.Authors.Name, dbo.Authors.MiddleName, dbo.Books.Name AS Expr1, dbo.Authors.NickName, dbo.Books.PublicationYear, " +
                    "dbo.Books.Amount FROM dbo.Authors INNER JOIN dbo.Books ON dbo.Authors.Id = dbo.Books.AuthorId";
                SqlCommand cmd = new SqlCommand(SqlExp, vivod);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        dataGridView1.Rows.Add(sqlDataReader[0], sqlDataReader[1], sqlDataReader[2], sqlDataReader[3], sqlDataReader[4], sqlDataReader[5], sqlDataReader[6]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Глуховский":
                    SqlConnection vivod = new SqlConnection(Connection.connectionStr);
                    try
                    {
                        vivod.Open();
                        string SqlExp = "SELECT dbo.Authors.SurName, dbo.Authors.Name, dbo.Authors.MiddleName, dbo.Authors.NickName, dbo.Books.Name AS Expr1," +
                            "dbo.Books.PublicationYear, dbo.Books.Amount FROM dbo.Authors INNER JOIN dbo.Books ON dbo.Authors.Id = dbo.Books.AuthorId WHERE (dbo.Authors.SurName = N'Глуховский')";
                        SqlCommand cmd = new SqlCommand(SqlExp, vivod);
                        SqlDataReader sqlDataReader = cmd.ExecuteReader();
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                dataGridView1.Rows.Add(sqlDataReader[0], sqlDataReader[1], sqlDataReader[2], sqlDataReader[3], sqlDataReader[4], sqlDataReader[5], sqlDataReader[6]);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Брэдбери":
                SqlConnection vivod1 = new SqlConnection(Connection.connectionStr);
                    try
                    {
                        vivod1.Open();
                        string SqlExp = "SELECT dbo.Authors.SurName, dbo.Authors.Name, dbo.Authors.MiddleName, dbo.Books.Name AS Expr1, dbo.Authors.NickName, dbo.Books.PublicationYear," +
                            " dbo.Books.Amount FROM dbo.Authors INNER JOIN dbo.Books ON dbo.Authors.Id = dbo.Books.AuthorId WHERE(dbo.Authors.SurName = N'Брэдбери')";
                        SqlCommand cmd = new SqlCommand(SqlExp, vivod1);
                        SqlDataReader sqlDataReader = cmd.ExecuteReader();
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                dataGridView1.Rows.Add(sqlDataReader[0], sqlDataReader[1], sqlDataReader[2], sqlDataReader[3], sqlDataReader[4], sqlDataReader[5], sqlDataReader[6]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;  
                    default:
                    Dataoutput();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
