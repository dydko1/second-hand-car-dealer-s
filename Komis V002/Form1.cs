using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Komis_V002
{
    public partial class Form1 : Form
    {
        public static string imagesPath = @"C:\tmp";
        public static string connstring = @"server=localhost;userid=root;password=tajnePassword;database=miro";
        // private BindingSource bindingSource1 = new BindingSource();
        public static string mainTabele = "komis"; //glowna tabela
        int iPos = -1;
        MySqlConnection connection = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetSQLData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            //form2.TopMost = true;
            form2.Show();
            //form2.SendToBack()
        }

        private void GetFile(string s, bool direction) // true gora false dol
        {
            int iZdjec = 0;         //liczba zdjec

            FileInfo[] listaP;      // lista plikow
                                    //FileInfo plik;      //= new FileInfo();


            // tu juz powinno zaczynac sie try catch
            DirectoryInfo katalog = new DirectoryInfo(imagesPath); // folder
            listaP = katalog.GetFiles("*.jpg"); //rozszerzenie plikow, mozna inaczej
            iZdjec = listaP.Count();
            //MessageBox.Show(listaP[0].ToString());

            if (iZdjec > 0)
            {

                if (direction == true)
                {
                    iPos++;
                    if (iPos == iZdjec)
                        iPos = 0;
                    pictureBox1.Image = Image.FromFile(listaP[iPos].FullName.ToString());
                }
                else
                {
                    iPos--;
                    if (iPos < 0)
                        iPos = iZdjec - 1;
                    //MessageBox.Show(iPos.ToString());
                    pictureBox1.Image = Image.FromFile(listaP[iPos].FullName.ToString());
                }

            }
            else
            {
                MessageBox.Show("Dodaj zdjecia samochodów do katalogu.", "Brak zdjec aut", MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                GetFile(imagesPath, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Tu wystapil wyjatek.", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }

        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton =  false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                imagesPath = folderBrowserDialog1.SelectedPath;
                folderBrowserDialog1.ShowNewFolderButton = false;
                try
                {
                    GetFile(imagesPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Tu wystapil wyjatek.", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                GetFile(imagesPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Tu wystapil wyjatek.", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
        }

        private void GetSQLData()
        {
            try
            {
                connection = new MySqlConnection(connstring);
                connection.Open();
                string query = "SELECT * FROM " + mainTabele + ";";
                MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                da.Fill(ds, mainTabele);
                DataTable dt = ds.Tables[mainTabele];
                //************
                listBox1.DataSource = dt;
                listBox1.DisplayMember = dt.Columns[1].ColumnName;
                listBox2.DataSource = dt;
                listBox2.DisplayMember = dt.Columns[2].ColumnName;
                listBox3.DataSource = dt;
                listBox3.DisplayMember = dt.Columns[3].ColumnName;
                listBox4.DataSource = dt;
                listBox4.DisplayMember = dt.Columns[4].ColumnName;
                listBox5.DataSource = dt;
                listBox5.DisplayMember = dt.Columns[5].ColumnName;
                listBox6.DataSource = dt;
                listBox6.DisplayMember = dt.Columns[6].ColumnName;
                listBox7.DataSource = dt;
                listBox7.DisplayMember = dt.Columns[7].ColumnName;
                listBox8.DataSource = dt;
                listBox8.DisplayMember = dt.Columns[8].ColumnName;
                listBox9.DataSource = dt;
                listBox9.DisplayMember = dt.Columns[9].ColumnName;
                listBox10.DataSource = dt;
                listBox10.DisplayMember = dt.Columns[10].ColumnName;
                listBox11.DataSource = dt;
                listBox11.DisplayMember = dt.Columns[11].ColumnName;
                //**************

                // dt.Select.
                //MessageBox.Show(dt.ToString());

                // Dodanie kolumny jeśli nie ma to dodaj

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wyjatek, Zapytannie do MySQL" +
                    "+",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button1);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
