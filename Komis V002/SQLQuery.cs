using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Komis_V002
{
    partial class Form2
    {
        // Zmienne zassane z 
        string connstring = Form1.connstring;
        string mainTabele = Form1.mainTabele;
        string imagesPath = Form1.imagesPath;

        MySqlConnection connection = null;

        private void GetSQLData()
        {
            string checkBoxName = "wybrane"; //Dodatkowa kolumna , wyboru
            try
            {
                connection = new MySqlConnection(connstring);
                connection.Open();
                string query = "SELECT * FROM " + mainTabele + ";";
                MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                da.Fill(ds, mainTabele);
                DataTable dt = ds.Tables[mainTabele];
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["id"].ReadOnly = true;
                dataGridView1.Columns["id"].DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;

                // Dodanie kolumny jeśli nie ma to dodaj
                DataGridViewColumn collumn = this.dataGridView1.Columns[0];
                if (collumn.HeaderCell.Value.ToString() != checkBoxName)
                {
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = checkBoxName;
                    checkBoxColumn.Width = 20;
                    checkBoxColumn.Name = checkBoxName;
                    dataGridView1.Columns.Insert(0, checkBoxColumn);
                }
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

        private void InsertIntoSQL()
        {
            int iRows = dataGridView1.Rows.Count - 2;
            int iColumn = dataGridView1.Columns.Count;
            int i = 2;
            string query = "", sTabela = "", sValues = ""; // "INSERT INTO " + mainTabele +" (marka, pojemnosc, moc, rok, kolor) VALUES ";
            bool isEmptyCell = true; //Sprawdza puste komorki i daje )
            // Jeśli
            bool isLastCellsEmpty = (dataGridView1.Rows[iRows].Cells[1].Value == System.DBNull.Value) && !(dataGridView1.Rows[iRows].Cells[2].Value == System.DBNull.Value);
            
            // int iColumn = dataGridView1.Columns.Count;
            DataGridViewRow row = this.dataGridView1.Rows[iRows];
            // DataGridViewColumn column = this.dataGridView1.Columns[1];
            
            do
            {
                // Sprawdza czy jest pusta komorka
                if (row.Cells[i].Value == System.DBNull.Value)
                {
                    if (isEmptyCell)
                        MessageBox.Show("Prosze uzupełnić wszystkie parametry !", "Ostrzeżenie");
                    row.Cells[i].Value = 0;
                    isEmptyCell = false;
                }

                sTabela += dataGridView1.Columns[i].HeaderText;
                sValues += "'" + row.Cells[i].Value.ToString().Replace(',', '.') + "'";

                if (i < iColumn - 1)
                {
                    sTabela += ", ";
                    sValues += ", ";
                }
                //sTabela += column.CellType.ToString() + "\n";
                i++;
            }
            while (i < iColumn);

            //  && isEmptyCell
            //MessageBox.Show(sTabela + "\n" + sValues);

            query = "INSERT INTO " + mainTabele + " (" + sTabela + ") VALUES (" + sValues + ")";

            //MessageBox.Show(isLastCellEmpty.ToString());
            //MessageBox.Show((dataGridView1.Rows[iRows + 1].Cells[1].Value== System.DBNull.Value).ToString());

            if (isLastCellsEmpty)
                try
            {
                connection = new MySqlConnection(connstring);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
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
           // if (isEmptyCell)
        }

        private void DeleteFromSQL(string id)
        {
            //DataGridView dt = dataGridView1;
            //DataGridViewRow row = this.dataGridView1.Rows[0];
            //MessageBox.Show(row.Cells[0].Value.ToString()); //aktualny id

            try
            {
                connection = new MySqlConnection(connstring);
                connection.Open();
                string query = "DELETE FROM komis WHERE id=" + id;
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wyjatek, Delete z MySQL" +
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

        // -------------------

        private void UpdateInSQL(string id, string columnHeader, string cellValue)
        {

            string query = "UPDATE komis SET " + columnHeader +" = '" +cellValue +"' WHERE id=" + id;
            //MessageBox.Show(query);
            try
            {
                connection = new MySqlConnection(connstring);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
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
            // if (isEmptyCell)
        }

        private void ZalozOtworzFolder()
        {
            string id = "";
            string imagesFolder = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["wybrane"].Value); // (row.Cells["checkBoxColumn"].Value
                if (isSelected && !(row.Cells["id"].Value == System.DBNull.Value))
                {
                    imagesFolder = "";
                    id = row.Cells["id"].Value.ToString();
                    imagesFolder = imagesPath + @"\" + id;

                    try
                    {
                        bool folderExists = Directory.Exists(imagesFolder);
                        if (!folderExists)
                        {
                            Directory.CreateDirectory(imagesFolder);
                            // MessageBox.Show(imagesFolder);
                        }
                        System.Diagnostics.Process.Start(imagesFolder);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Tworznie folderu", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                    }

                }
            }
        }
    }
        
}
