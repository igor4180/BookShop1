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

namespace BookShop1
{
	public partial class Form1 : Form
	{
		SqlConnection connection = new SqlConnection();
		private object dataSetBook;

		public Form1()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.ConnectionString = "server=(local);initial catalog=MyDB";
			builder.UserID = loginBox.Text;
			builder.Password = passwordBox.Text;

			using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
			{
				try
				{
					connection.Open();
					MessageBox.Show("Вы подкючены!", "Успешно!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
					connection.Close();
				}
				catch (Exception)
				{
					MessageBox.Show("неверный логин или пароль", "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
			}
	}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void добавитьtoolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (tabControl1.SelectedTab == tabPage1)
			{
				int lastid = 1;
				if (dataSetBook.Tables[0].Rows.Count > 0)
				{
					lastid = (int)dataSetBook.Tables[0].Rows[dataSetBook.Tables[0].Rows.Count - 1][0] + 1;
				}
				AddBook ac = new AddBook(lastid);
				if (ac.ShowDialog() == DialogResult.OK)
				{
					dataSetCategory.Tables[0].Rows.Add(Int32.Parse(ac.tb_id.Text), ac.tb_name.Text);
				}
				ac.Dispose();
			}
			else if (tabControl1.SelectedTab == tabPage2)
			{
				int lastid = 1;
				if (dataSetGoods.Tables[0].Rows.Count > 0)
				{
					lastid = (int)dataSetGoods.Tables[0].Rows[dataSetGoods.Tables[0].Rows.Count - 1][0] + 1;
				}
				AddGoods ag = new AddGoods(lastid);
				if (ag.ShowDialog() == DialogResult.OK)
				{
					dataSetGoods.Tables[0].Rows.Add(Int32.Parse(ag.tb_id.Text), ag.tb_name.Text);
				}
				ag.Dispose();
			}
	}
	}
