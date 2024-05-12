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
    public partial class display : Form
    {
        public display()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryReader br = new BinaryReader(File.Open(Info.FileName, FileMode.Open, FileAccess.Read));
            int num_of_records = (int)br.BaseStream.Length / Info.RecordSize;
           
            if (num_of_records > 0) // If The file Not Empty
            {
                DisplayBtn.Text = "Next";// Change the Button Text

                br.BaseStream.Seek(Info.Count, SeekOrigin.Begin);


                IDBox.Text = br.ReadInt32().ToString();
                NameBox.Text = br.ReadString(); 
                TelBox.Text = br.ReadString(); 
                YearBox.Text = br.ReadInt32().ToString(); 
                GenderBox.Text = br.ReadString();
                

                NumOfRecLabel.Text = num_of_records.ToString();
                FileSizeLabel.Text = br.BaseStream.Length.ToString();

                if ((Info.Count / Info.RecordSize) >= (num_of_records - 1))
                    Info.Count = 0;
                else
                    Info.Count += Info.RecordSize;
            }
            else
                MessageBox.Show("Empty File");

            br.Close();

        }

        private void display_Load(object sender, EventArgs e)
        {
            textBox1.Text = Info.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
