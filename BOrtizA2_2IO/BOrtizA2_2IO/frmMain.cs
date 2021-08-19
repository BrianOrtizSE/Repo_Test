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
namespace BOrtizA2_2IO
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
           
            InitializeComponent();
            
        }
        StreamReader sr = new StreamReader("sales.txt");
        StreamWriter sw = new StreamWriter("out.txt");
        double[] nums = new double[9];
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = double.Parse(sr.ReadLine());
                lbxList.Items.Add(nums[i].ToString());
            }
        }

        private void mouse_click(object sender, MouseEventArgs e)
        {
            if(e.X > 250 && e.Y > 250){
                MessageBox.Show("Clicked In Lower Right Quadrant");
            }else if(e.X <= 250 && e.Y <= 250)
            {
                MessageBox.Show("Clicked In Top Left Quandrant");
            }
            else if(e.X > 250 && e.Y <= 250)
            {
                MessageBox.Show("Clicked In Top Right Quandrant");
            }
            else if (e.X <= 250 && e.Y > 250)
            {
                MessageBox.Show("Clicked In Lower Left Quandrant");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            double total = 0.0;
            double average = 0.0;
            double big = nums[0];
            double small = nums[0];

            foreach (double n in nums)
            {
                total += n;
                              
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if(small > nums[i])
                {
                    small = nums[i];
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (big < nums[i])
                {
                    big = nums[i];
                }
            }
            average = total / nums.Length;

            sw.WriteLine("Total : " + total.ToString());
            sw.WriteLine("Average : " + average.ToString("n2"));
            sw.WriteLine("Biggest Number : " + big.ToString());
            sw.WriteLine("Smallest Number : " + small.ToString());
            sw.Close();
        }
    }
}
