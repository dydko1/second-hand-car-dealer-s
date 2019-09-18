using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Komis_V002
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //Form2 form2 = new Form2();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetSQLData();
        }

        private void btnWstaw_Click(object sender, EventArgs e)
        {
            InsertIntoSQL();
            GetSQLData(); // odswiez
        }

        private void btnOdswiez_Click(object sender, EventArgs e)
        {
            GetSQLData();
        }

        private void btnOtworzFolder_Click(object sender, EventArgs e)
        {
            ZalozOtworzFolder();
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            string id = "";
            DialogResult dialogResult = MessageBox.Show("Czy chcesz usunąć wybrane rekordy ? ", "Czy usuwać ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["wybrane"].Value); // (row.Cells["checkBoxColumn"].Value
                    if (isSelected && !(row.Cells["id"].Value == System.DBNull.Value))
                    {
                        id = row.Cells["id"].Value.ToString();
                        //MessageBox.Show(id);
                        DeleteFromSQL(id);
                        // id += row.Cells[0].Value.ToString(); // row.Cells["Name"].Value.ToString();
                    }
                }
                GetSQLData(); // odswiez
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            DataGridViewColumn collumn = this.dataGridView1.Columns[e.ColumnIndex];
            string id = row.Cells[1].Value.ToString();
            string columnHeader = collumn.HeaderText;
            string cellValue = row.Cells[e.ColumnIndex].Value.ToString().Replace(",", ".");
            //
            //MessageBox.Show(.ToString());

            if (row.Cells[1].Value != System.DBNull.Value && e.ColumnIndex > 0)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                UpdateInSQL(id, columnHeader, cellValue);
            }
            //GetSQLData();

        }
    }
}
