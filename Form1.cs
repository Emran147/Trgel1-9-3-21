using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qedan
{
    public partial class Form1 : Form
    {
        string inputfile = @"../../file1.txt";

        public Form1()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            int flag = 0;
            foreach (var line in File.ReadAllLines(inputfile))//עוברים על כל שורה 
            {
                string[] inputs = line.Split(',');//מחלקים לפי הפסיק
                if(inputs[3]==txtBarcode.Text)
                {
                    MessageBox.Show("this Barcode in use");
                    flag = 1;
                }
            }

            if (txtBarcode.Text==""||txtDesc.Text==""||txtName.Text==""||txtPrice.Text=="")
            {
                MessageBox.Show("Fill All the inputs");
                flag = 1;
            }
           if(flag==0)
            {
                //מוספים את פרטי המוצר בנוסף פסיק ביניהם
                File.AppendAllText(inputfile, txtName.Text + "," + txtPrice.Text + "," + txtDesc.Text + "," + txtBarcode.Text + "\n");
                //משתנה שמכיל הטקסת שבקובץ
                String input = File.ReadAllText(inputfile);
                //הצגה
                lblViewr.Text = input;
                MessageBox.Show("item added successfully");
            }
        }

        private void btnTotalPrice_Click(object sender, EventArgs e)
        {
            int sum = 0;//משתנה להמחיר הסופי
            foreach (var line in File.ReadAllLines(inputfile))//עוברים על המחירים לפי שורה
            {
                string[] inputs = line.Split(',');
                sum += int.Parse(inputs[1]);
            }
            if (RbtnVip.Checked)
                sum = sum -(sum*10/100);
            lblTotal.Text = sum.ToString();
        }

 

        private void btnbuy_Click(object sender, EventArgs e)
        {
             File.WriteAllText(inputfile, "");//איפוס file
            String input = File.ReadAllText(inputfile);  //משתנה שמכיל הטקסת שבקובץ
            lblViewr.Text = input;//הצגה

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.Location = new Point(250, 20);
            pb.Size = new Size(800, 1350);
            pb.Image = Image.FromFile(@"../../33.JPEG");
            pb.Visible = true;
            this.Controls.Add(pb);
        }

        
    }
}
