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

namespace dz3l3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заповніть всі поля.", "Помилка.");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[1].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[2].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[3].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[0].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[4].Value = comboBox2.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Оберіть рядок для видалення.", "Помилка.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
            numericUpDown1.Value = n;
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[1].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[2].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[3].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[0].Value = comboBox1.Text;
                dataGridView1.Rows[n].Cells[4].Value = comboBox2.Text;
            }
            else
            {
                MessageBox.Show("Оберіть рядок для редагування", "Помилка.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Магазин азіатських коміксів";
                dt.Columns.Add("Вид коміксу");
                dt.Columns.Add("Назва");
                dt.Columns.Add("Жанр");
                dt.Columns.Add("Ціна");
                dt.Columns.Add("Наявність");
                ds.Tables.Add(dt);
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataRow row = ds.Tables["Магазин азіатських коміксів"].NewRow();
                    row["Вид коміксу"] = r.Cells[0].Value;
                    row["Назва"] = r.Cells[1].Value;
                    row["Жанр"] = r.Cells[2].Value;
                    row["Ціна"] = r.Cells[3].Value;
                    row["Наявність"] = r.Cells[4].Value;
                    ds.Tables["Магазин азіатських коміксів"].Rows.Add(row);
                }
                ds.WriteXml("F:\\Shop.xml");
                MessageBox.Show("XML файл успішно збережений.", "Виконано.");
            }
            catch
            {
                MessageBox.Show("Неможливо зберегти XML файл.", "Помилка.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1) // Замість нуля поставив 1 бо при запускі програми автоматично з'являється перший рядок
                                              // і тому команда не працює
            {
                MessageBox.Show("Очистіть поле перед завантаженням нового файла.", "Помилка.");
            }
            else
            {
                if (File.Exists("F:\\Shop.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("F:\\Shop.xml");
                    foreach (DataRow item in ds.Tables["Магазин азіатських коміксів"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = item["Вид коміксу"];
                        dataGridView1.Rows[n].Cells[1].Value = item["Назва"];
                        dataGridView1.Rows[n].Cells[2].Value = item["Жанр"];
                        dataGridView1.Rows[n].Cells[3].Value = item["Ціна"];
                        dataGridView1.Rows[n].Cells[4].Value = item["Наявність"];
                    }
                }
                else
                {
                    MessageBox.Show("XML файл не знайдено.", "Помилка.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Таблиця порожня.", "Помилка.");
            }
        }

      
    }
}
