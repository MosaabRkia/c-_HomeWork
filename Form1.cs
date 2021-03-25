using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string pathit = @"../../file1.txt";
        public Form1()
        {
            InitializeComponent();
        }


        private void DoSomething(string str)
        {
            string conStr = @"Data Source=DESKTOP-JG3F6E8\SQLEXPRESS;Initial Catalog=ShopZoid;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);

            SqlCommand comm = new SqlCommand(str,con);
            con.Open();
            int Results = comm.ExecuteNonQuery();
            con.Close();
            if (Results == 1)
            {
                MessageBox.Show("Sucess!");
            }
            else
            {
                MessageBox.Show(" not Sucess!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.AppendAllText(pathit, txtBoxID.Text + "','" + txtBoxName.Text + "','" + txtBoxSrcImg.Text + "','" + txtBoxDescription.Text + "','" + txtBoxPrice.Text);
           // DoSomething("INSERT INTO itemsList(id,name,srcImg,description,price) VALUES('" + txtBoxID.Text + "','" + txtBoxName.Text + "','" + txtBoxSrcImg.Text + "','" + txtBoxDescription.Text + "','" + txtBoxPrice.Text + "') ");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText(pathit, "");
           // DoSomething($"DELETE itemsList WHERE id={txtBoxID.Text}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // DoSomething($"UPDATE itemsList SET  price={txtBoxPrice.Text}  WHERE id={txtBoxID.Text}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            string example = "";
            string conStr = @"Data Source=DESKTOP-JG3F6E8\SQLEXPRESS;Initial Catalog=ShopZoid;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);

            SqlCommand comm = new SqlCommand("SELECT * FROM itemsList", con);

            con.Open();
            SqlDataReader Reader = comm.ExecuteReader();
            while (Reader.Read())
            {
                example += "ID:" + Reader["id"] + " , Name:" + Reader["name"] + " , Desc:" + Reader["description"] + " , Price:" + Reader["price"] + "\n";
            }
            con.Close();*/
           string[] example = File.ReadAllLines(pathit);
            SelectList.Text = "";
            int counter = 1;
            foreach (string line in example){
                SelectList.Text += "\n" + counter + " :" +  line ;
                counter++;
            }

          //  SelectList.Text = example;
        }
    }
}

/*
if (/*txtBoxID.Text != "" && txtBoxName.Text != "" && txtBoxPrice.Text != "" && txtBoxSrcImg.Text != "" && txtBoxDescription.Text != "" /*&& txtBoxID.Text != null && txtBoxName.Text != null && txtBoxPrice.Text != null && txtBoxSrcImg.Text != null && txtBoxDescription.Text != null)
{
}
*/
