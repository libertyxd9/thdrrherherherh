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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Dobav = new SqlConnection(Connection.connectionStr);
            try
            {
                Dobav.Open();
                string SqlExp = "insert into [dbo].[Authors] ([Surname],[Name],[MiddleName],[Nickname]) values (@Surname, @Name, @MiddleName, @Nickname)";
                SqlCommand cmd = new SqlCommand(SqlExp, Dobav);
                cmd.Parameters.AddWithValue("@Surname", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@MiddleName", textBox3.Text);
                cmd.Parameters.AddWithValue("@Nickname", textBox4.Text);
                int y = cmd.ExecuteNonQuery();
                MessageBox.Show("Данные добавились");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
