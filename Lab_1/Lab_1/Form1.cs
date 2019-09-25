using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            char[,] datagrid_1 = new char[,] {
                { 'Q', 'A', 'Z', 'W', 'S' },
                { 'X', 'C', 'D', 'E', 'R' },
                { 'F', 'V', 'B', 'G', 'T' },
                { 'Y', 'H', 'N', 'M', 'U' },
                { 'I', 'K', 'L', 'O', 'P' },
            };
            char[,] datagrid_2 = new char[,] {
                { 'P', 'L', 'M', 'K', 'O' },
                { 'I', 'N', 'U', 'H', 'B' },
                { 'Y', 'G', 'V', 'T', 'F' },
                { 'C', 'X', 'D', 'R', 'E' },
                { 'W', 'S', 'Q', 'A', 'Z' },
            };
            char[,] datagrid_3 = new char[,] {
                { 'A', 'Q', 'B', 'L', 'Z' },
                { 'S', 'D', 'C', 'F', 'X' },
                { 'P', 'V', 'W', 'R', 'N' },
                { 'M', 'Y', 'T', 'E', 'G' },
                { 'I', 'U', 'O', 'K', 'H' },
            };
            char[,] datagrid_4 = new char[,] {
                { 'Q', 'W', 'E', 'R', 'T' },
                { 'A', 'S', 'D', 'F', 'Z' },
                { 'P', 'O', 'I', 'U', 'Y' },
                { 'L', 'K', 'H', 'M', 'N' },
                { 'X', 'C', 'V', 'B', 'G' },
            };

            PutArrayInDGV(datagrid_1,1);
            PutArrayInDGV(datagrid_2,2);
            PutArrayInDGV(datagrid_3,3);
            PutArrayInDGV(datagrid_4,4);


            //string text = textBox1.Text;
            //char[] textboxchar = text.ToCharArray();
            //List<string> list = SplitString(text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        static List<string> SplitString(string str)
        {
            List<string> list = new List<string>();
            int i = 0;
            while (i < str.Length - 1)
            {
                list.Add(str.Substring(i, 2));
                i += 2;
            }
            return list;
        }

        void PutArrayInDGV(char[,] array, int number)
        {
            DataGridView[] data = new DataGridView[] { dataGridView1, dataGridView2, dataGridView3, dataGridView4 };
            for (int l = number-1;l <  number; l++)
            {
                int m = array.GetLength(0);
                int n = array.GetLength(1);
                data[l].ColumnCount = n;
                data[l].RowCount = m;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        data[l].Rows[i].Cells[j].Value = array[i, j];
                    }
                }
            }          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            //char[] textboxchar = text.ToCharArray();
            List<string> list = list.Add(text);
            for (int i = 0; i < list.Count; i++)
            {
                textBox2.Lines[i] = list[i].ToString() + "\r\n";
            }
        }
    }
}
