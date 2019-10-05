using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
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
        public Form1()
        {
            InitializeComponent();

            

            PutArrayInDGV(datagrid_1,1);
            PutArrayInDGV(datagrid_2,2);
            PutArrayInDGV(datagrid_3,3);
            PutArrayInDGV(datagrid_4,4);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        #region Creating an array
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
        #endregion
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            encryption();
        }
        #region Encryption. 


        public void encryption()
        {
            string letters_2 = "";
            string letters_1 = "";
            string text = textBox1.Text;
            text = text.Replace(" ", "");
            char[] arr = text.ToUpper().ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (int x = 0; x < datagrid_1.GetLength(0); x++)
                    {
                        for (int y = 0; y < datagrid_1.GetLength(1); y++)
                        {
                            if (arr[i] == datagrid_1[x, y])
                            {
                                string coordinate_x = x.ToString();
                                string coordinate_y = y.ToString();

                                letters_1 += coordinate_x + " " + coordinate_y + " ";

                            }
                        }
                    }
                }
                if (i % 2 != 0)
                {
                    for (int x = 0; x < datagrid_4.GetLength(0); x++)
                    {

                        for (int y = 0; y < datagrid_4.GetLength(1); y++)
                        {
                            if (arr[i] == datagrid_4[x, y])
                            {
                                string coordinate_x = x.ToString();
                                string coordinate_y = y.ToString();

                                letters_2 += coordinate_x + " " + coordinate_y + " ";
                            }
                        }
                    }
                }

            }


            String[] words_1 = letters_1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            String[] words_2 = letters_2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //textBox4.Text = letters_1;
            //textBox3.Text = letters_2;
            string l = "";
            int j = -1;
            int s = -2;
            int k = -1;
            for (int i = 0; i < words_1.Length; i += 2)
            {
                //j += 2;
                for (j += 2; j < words_2.Length;)
                {
                    l += words_1[i] + " " + words_2[j] + " ";

                    for (k += 2; k < words_1.Length;)
                    {
                        for (s += 2; s < words_2.Length;)
                        {
                            l += words_2[s] + " " + words_1[k] + " ";
                            break;
                        }
                        break;
                    }
                    break;
                }

            }
            String[] coordinate_after = l.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int t = -2;
            for (int i = 0; i < coordinate_after.Length; i += 4)
            {

                int n = Convert.ToInt32(coordinate_after[i]);
                int m = Convert.ToInt32(coordinate_after[i + 1]);
                textBox4.Text += datagrid_2[n, m];
                for (t += 4; t < coordinate_after.Length;)
                {
                    int x = Convert.ToInt32(coordinate_after[t]);
                    int y = Convert.ToInt32(coordinate_after[t + 1]);
                    textBox4.Text += datagrid_3[x, y];
                    break;
                }
            }
        }
        #endregion


        #region Decryption
        public void decryption()
        {
            string letters_2 = "";
            string letters_1 = "";
            string text = textBox2.Text;
            char[] arr = text.ToUpper().ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (int x = 0; x < datagrid_2.GetLength(0); x++)
                    {
                        for (int y = 0; y < datagrid_2.GetLength(1); y++)
                        {
                            if (arr[i] == datagrid_2[x, y])
                            {
                                string coordinate_x = x.ToString();
                                string coordinate_y = y.ToString();

                                letters_1 += coordinate_x + " " + coordinate_y + " ";

                            }
                        }
                    }
                }
                if (i % 2 != 0)
                {
                    for (int x = 0; x < datagrid_3.GetLength(0); x++)
                    {

                        for (int y = 0; y < datagrid_3.GetLength(1); y++)
                        {
                            if (arr[i] == datagrid_3[x, y])
                            {
                                string coordinate_x = x.ToString();
                                string coordinate_y = y.ToString();

                                letters_2 += coordinate_x + " " + coordinate_y + " ";
                            }
                        }
                    }
                }

            }


            String[] words_1 = letters_1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            String[] words_2 = letters_2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //textBox4.Text = letters_1;
            //textBox3.Text = letters_2;
            string l = "";
            int j = -1;
            int s = -2;
            int k = -1;
            for (int i = 0; i < words_1.Length; i += 2)
            {
                //j += 2;
                for (j += 2; j < words_2.Length;)
                {
                    l += words_1[i] + " " + words_2[j] + " ";

                    for (k += 2; k < words_1.Length;)
                    {
                        for (s += 2; s < words_2.Length;)
                        {
                            l += words_2[s] + " " + words_1[k] + " ";
                            break;
                        }
                        break;
                    }
                    break;
                }

            }
            String[] coordinate_after = l.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int t = -2;
            for (int i = 0; i < coordinate_after.Length; i += 4)
            {

                int n = Convert.ToInt32(coordinate_after[i]);
                int m = Convert.ToInt32(coordinate_after[i + 1]);
                textBox3.Text += datagrid_1[n, m];
                for (t += 4; t < coordinate_after.Length;)
                {
                    int x = Convert.ToInt32(coordinate_after[t]);
                    int y = Convert.ToInt32(coordinate_after[t + 1]);
                    textBox3.Text += datagrid_4[x, y];
                    break;
                }
            }
        }



        #endregion


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            decryption();
        }
    }
}
