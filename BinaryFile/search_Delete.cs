using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BinaryFile
{
    public partial class search_Delete : Form
    {
        public search_Delete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int key = Int32.Parse(IDBox.Text);

            foreach (InsertForm.student item in InsertForm.studList)

            {
                if (key == item.id)
                {
                    MessageBox.Show("Student " + item.name + " Removed Successfully");


                    InsertForm.studList.RemoveAt(InsertForm.studList.IndexOf(item));
                    IDBox.Clear(); NameBox.Clear(); TelBox.Clear(); GenderBox.Clear();
                    break;
                }

            }

        }
            private void SearchBtn_Click(object sender, EventArgs e)
        {

            bool flag = false;
            if (NameBox.Text == "")
                MessageBox.Show(" Write Student Name ", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                foreach (InsertForm.student s in InsertForm.studList)
                {
                    if (NameBox.Text == s.name)
                    {
                        IDBox.Text = s.id.ToString();
                        TelBox.Text = s.tel.ToString();
                        YearBox.Text = s.year.ToString();
                        GenderBox.Text = s.gender.ToString();

                        MessageBox.Show("Found at index " +
                        InsertForm.studList.IndexOf(s) + " \t ID number =" + s.id);
                        flag = true;
                    }
                }
            }
            if (!flag && NameBox.Text != "")
                MessageBox.Show("Student Not Found", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void ModifyBtn_Click(object sender, EventArgs e)
        {
            /*  foreach (InsertForm.student s in InsertForm.studList)
            {
                if (IDBox.Text == s.id.ToString())
                {
                    InsertForm.studList.RemoveAt(InsertForm.studList.IndexOf(s));
                }
            }
            */
        }
    }
}
