using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace DSCEDemo2
{
    public partial class Form1 : Form
    {
        Bitmap originalImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            var returnValue = openDialog.ShowDialog();
            if(returnValue == DialogResult.OK)
            {
                originalImage = new Bitmap(openDialog.FileName);
                ColorImageBox.Image = originalImage;
            }
        }

        private void cannyEdgeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayscaleBT709 grayConverter = new GrayscaleBT709();
            Bitmap grayImage = grayConverter.Apply(originalImage);

            CannyEdgeDetector edgeDetector = new CannyEdgeDetector();
            Bitmap edgeImage = edgeDetector.Apply(grayImage);

            pictureBox1.Image = edgeImage;
        }
    }
}
