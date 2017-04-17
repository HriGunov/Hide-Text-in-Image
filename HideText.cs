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

namespace HideTextInImage
{
    public partial class HideText : Form
    {
        public HideText()
        {
            InitializeComponent();
        }

        private void bt_OpenText_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = dia_OpenText.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {

                tb_textPath.Text = dia_OpenText.FileName;
               
            }
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void bt_OpenImage_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = dia_OpenImage.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {

                tb_imagePath.Text = dia_OpenImage.FileName;
                
            }
            Console.WriteLine(result); // <-- For debugging use.
        }
         
        private void bt_HideTextInImage_Click(object sender, EventArgs e)
        {
            string originalImagePath = tb_imagePath.Text;
            string originalTextPath = tb_textPath.Text;
                        
                DialogResult result = dia_BlenedImageLocation.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    Console.WriteLine(result); // <-- For debugging use.
                    bt_HideTextInImage.Enabled = false;
                    bt_ExtractText.Enabled = false;
                    
                    Bitmap originalImage = new Bitmap(originalImagePath);
                    string orginalImageHash = Sha256.Hash(originalImagePath);

                    Hide(originalImage, originalTextPath);

                   //tb_textPath.Text = "";
                   //tb_imagePath.Text = "";
                    MessageBox.Show("Job's done!");
                    bt_HideTextInImage.Enabled = true;                    
                    bt_ExtractText.Enabled = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
                      

        }

        void Hide(Bitmap originalImage,string originalTextPath)
        {

            Bitmap textBitmap = TextToBitmap.Create(originalImage, originalTextPath);
            Bitmap blendedImage = Blender.Blend(originalImage, textBitmap);
            blendedImage.Save(dia_BlenedImageLocation.FileName,System.Drawing.Imaging.ImageFormat.Png);
            
        }



        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void bt_OpenBlendedImage_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = dia_OpenImage.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {

                tb_BlendedImagePath.Text = dia_OpenImage.FileName;
            }
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void bt_OpenOriginalImage_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = dia_OpenImage.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {

                tb_originalImagePath.Text = dia_OpenImage.FileName;
            }
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void bt_ExtractText_Click(object sender, EventArgs e)
        {

            string originalImagePath = tb_originalImagePath.Text;
            string blendedImagetPath = tb_BlendedImagePath.Text;


            DialogResult result = dia_SaveTextLocation.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {

                try
                {
                    Console.WriteLine(result); // <-- For debugging use.

                    bt_HideTextInImage.Enabled = false;
                    bt_ExtractText.Enabled = false;
                    Bitmap originalImageBitmap = new Bitmap(originalImagePath);
                    Bitmap blended = new Bitmap(blendedImagetPath);



                    Bitmap unblendedTextBitmap = Blender.UnBlend(blended, originalImageBitmap);
                    string orginalImageHash = Sha256.Hash(originalImagePath);
                    using (StreamWriter sr = new StreamWriter(dia_SaveTextLocation.FileName))
                    {
                        string text = BitmapToText.Extract(unblendedTextBitmap, orginalImageHash);
                        
                        sr.Write(text);
                    }
                     
                    tb_originalImagePath.Text ="";
                    tb_BlendedImagePath.Text = "";

                    MessageBox.Show("Job's done!");
                    bt_HideTextInImage.Enabled = true;
                    bt_ExtractText.Enabled = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        //

    }
}
