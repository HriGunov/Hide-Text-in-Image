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
using HideTextInImage.Blenders.CharToPixel;
using HideTextInImage.Interfaces;
namespace HideTextInImage
{
    public partial class HideText : Form
    {
        IBlendable blender;
        public HideText()
        {
            InitializeComponent();

            blender = new Blenders.CharToPixel.PixelToChar(new CharToPixelBlend());

        }

        private void bt_OpenText_Click(object sender, EventArgs e)
        {   //Text path Dialog
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
            //Image path Dialog
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
                
            // Path to blended image
             DialogResult result = dia_BlenedImageLocation.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                   
                    //locks originalImage and text paths  also provies a visual cue that the program is working
                    bt_HideTextInImage.Enabled = false;
                    bt_ExtractText.Enabled = false;

                    var mixedImage = blender.BlendWhole(originalImagePath, originalTextPath);

                    mixedImage.Save(dia_BlenedImageLocation.FileName, System.Drawing.Imaging.ImageFormat.Png);
                                       
                    //clears the ext fields
                    tb_textPath.Text = "";
                    tb_imagePath.Text = "";

                    bt_HideTextInImage.Enabled = true;
                    bt_ExtractText.Enabled = true;

                    MessageBox.Show("Text has been hidden!");
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }
                      

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
            string blendedImagePath = tb_BlendedImagePath.Text;


            DialogResult result = dia_SaveTextLocation.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {

                try
                {
                    Console.WriteLine(result); // <-- For debugging use.

                    bt_HideTextInImage.Enabled = false;
                    bt_ExtractText.Enabled = false;

                  string extractedText =  blender.UnblendWhole(originalImagePath, blendedImagePath);



                    
                    using (StreamWriter sr = new StreamWriter(dia_SaveTextLocation.FileName))
                    {                                              
                        sr.Write(extractedText);
                    }
                    
                    tb_originalImagePath.Text ="";
                    tb_BlendedImagePath.Text = "";

                    bt_HideTextInImage.Enabled = true;
                    bt_ExtractText.Enabled = true;
                    MessageBox.Show("Text extracted at {0}", dia_SaveTextLocation.FileName);
                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        //

    }
}
