using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ImageObjDetect
{
    public partial class Form1 : Form
    {
        Rectangle rect;
        int x, y, locationx, locationy;
        public Pen pen = new Pen(Color.White);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form_Load(object sender, EventArgs e)
        {


        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(ofd.FileName);
            }

            picImage.MouseDown += new MouseEventHandler(picImage_MouseDown);
            picImage.MouseMove += new MouseEventHandler(picImage_MouseMove);
            picImage.MouseEnter += new EventHandler(picImage_MouseEnter);
            Controls.Add(picImage);


        }



        

            private void picImage_MouseDown(object sender, MouseEventArgs e)
            {
            base.OnMouseDown(e);
                if (e.Button ==System.Windows.Forms.MouseButtons.Left)
                {
                Cursor = Cursors.Cross;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                locationx = e.X;
                locationy = e.Y;
               
                



                }
            }
        private void picImage_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Cross;
        }
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                picImage.Refresh();
                x = e.X - locationx;
                y = e.Y - locationx;
                Graphics g = picImage.CreateGraphics();
                g.DrawRectangle(pen, locationx, locationy, x, y);
                g.Dispose();

                label1.Text = "X" + locationx + "\nY" + locationy + "\nWidth" + x + "\nHeight" + y;


            }


        }
        
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Default;
        }






    }
          
    }


