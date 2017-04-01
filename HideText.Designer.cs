namespace HideTextInImage
{
    partial class HideText
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dia_OpenImage = new System.Windows.Forms.OpenFileDialog();
            this.dia_OpenText = new System.Windows.Forms.OpenFileDialog();
            this.dia_BlenedImageLocation = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gb_HideText = new System.Windows.Forms.GroupBox();
            this.bt_HideTextInImage = new System.Windows.Forms.Button();
            this.bt_OpenText = new System.Windows.Forms.Button();
            this.lb_EnterTextLocation = new System.Windows.Forms.Label();
            this.tb_textPath = new System.Windows.Forms.TextBox();
            this.tb_imagePath = new System.Windows.Forms.TextBox();
            this.lb_enterImage = new System.Windows.Forms.Label();
            this.bt_OpenImage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_ExtractText = new System.Windows.Forms.Button();
            this.bt_OpenOriginalImage = new System.Windows.Forms.Button();
            this.tb_originalImagePath = new System.Windows.Forms.TextBox();
            this.tb_BlendedImagePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_OpenBlendedImage = new System.Windows.Forms.Button();
            this.dia_SaveTextLocation = new System.Windows.Forms.SaveFileDialog();
            this.gb_HideText.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dia_OpenText
            // 
            this.dia_OpenText.Filter = "Text Files(.txt)|*.txt";
            // 
            // dia_BlenedImageLocation
            // 
            this.dia_BlenedImageLocation.Filter = "Bitmap(.bmp)|*.bmp";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // gb_HideText
            // 
            this.gb_HideText.Controls.Add(this.bt_HideTextInImage);
            this.gb_HideText.Controls.Add(this.bt_OpenText);
            this.gb_HideText.Controls.Add(this.lb_EnterTextLocation);
            this.gb_HideText.Controls.Add(this.tb_textPath);
            this.gb_HideText.Controls.Add(this.tb_imagePath);
            this.gb_HideText.Controls.Add(this.lb_enterImage);
            this.gb_HideText.Controls.Add(this.bt_OpenImage);
            this.gb_HideText.Location = new System.Drawing.Point(27, 12);
            this.gb_HideText.Name = "gb_HideText";
            this.gb_HideText.Size = new System.Drawing.Size(712, 183);
            this.gb_HideText.TabIndex = 16;
            this.gb_HideText.TabStop = false;
            this.gb_HideText.Text = "Hide Text.";
            // 
            // bt_HideTextInImage
            // 
            this.bt_HideTextInImage.Location = new System.Drawing.Point(317, 115);
            this.bt_HideTextInImage.Name = "bt_HideTextInImage";
            this.bt_HideTextInImage.Size = new System.Drawing.Size(138, 60);
            this.bt_HideTextInImage.TabIndex = 19;
            this.bt_HideTextInImage.Text = "Hide Text in Image";
            this.bt_HideTextInImage.UseVisualStyleBackColor = true;
            this.bt_HideTextInImage.Click += new System.EventHandler(this.bt_HideTextInImage_Click);
            // 
            // bt_OpenText
            // 
            this.bt_OpenText.Location = new System.Drawing.Point(614, 90);
            this.bt_OpenText.Name = "bt_OpenText";
            this.bt_OpenText.Size = new System.Drawing.Size(75, 23);
            this.bt_OpenText.TabIndex = 18;
            this.bt_OpenText.Text = "Open";
            this.bt_OpenText.UseVisualStyleBackColor = true;
            this.bt_OpenText.Click += new System.EventHandler(this.bt_OpenText_Click);
            // 
            // lb_EnterTextLocation
            // 
            this.lb_EnterTextLocation.AutoSize = true;
            this.lb_EnterTextLocation.Location = new System.Drawing.Point(17, 90);
            this.lb_EnterTextLocation.Name = "lb_EnterTextLocation";
            this.lb_EnterTextLocation.Size = new System.Drawing.Size(125, 17);
            this.lb_EnterTextLocation.TabIndex = 17;
            this.lb_EnterTextLocation.Text = "Enter text location:";
            // 
            // tb_textPath
            // 
            this.tb_textPath.Location = new System.Drawing.Point(151, 87);
            this.tb_textPath.Name = "tb_textPath";
            this.tb_textPath.Size = new System.Drawing.Size(438, 22);
            this.tb_textPath.TabIndex = 16;
            // 
            // tb_imagePath
            // 
            this.tb_imagePath.Location = new System.Drawing.Point(151, 30);
            this.tb_imagePath.Name = "tb_imagePath";
            this.tb_imagePath.Size = new System.Drawing.Size(438, 22);
            this.tb_imagePath.TabIndex = 15;
            // 
            // lb_enterImage
            // 
            this.lb_enterImage.AutoSize = true;
            this.lb_enterImage.Location = new System.Drawing.Point(17, 36);
            this.lb_enterImage.Name = "lb_enterImage";
            this.lb_enterImage.Size = new System.Drawing.Size(108, 17);
            this.lb_enterImage.TabIndex = 14;
            this.lb_enterImage.Text = "Enter an image:";
            // 
            // bt_OpenImage
            // 
            this.bt_OpenImage.Location = new System.Drawing.Point(614, 30);
            this.bt_OpenImage.Name = "bt_OpenImage";
            this.bt_OpenImage.Size = new System.Drawing.Size(75, 23);
            this.bt_OpenImage.TabIndex = 13;
            this.bt_OpenImage.Text = "Open";
            this.bt_OpenImage.UseVisualStyleBackColor = true;
            this.bt_OpenImage.Click += new System.EventHandler(this.bt_OpenImage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bt_ExtractText);
            this.groupBox1.Controls.Add(this.bt_OpenOriginalImage);
            this.groupBox1.Controls.Add(this.tb_originalImagePath);
            this.groupBox1.Controls.Add(this.tb_BlendedImagePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bt_OpenBlendedImage);
            this.groupBox1.Location = new System.Drawing.Point(27, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 183);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extract Text.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Enter original image location:";
            // 
            // bt_ExtractText
            // 
            this.bt_ExtractText.Location = new System.Drawing.Point(317, 115);
            this.bt_ExtractText.Name = "bt_ExtractText";
            this.bt_ExtractText.Size = new System.Drawing.Size(138, 60);
            this.bt_ExtractText.TabIndex = 19;
            this.bt_ExtractText.Text = "Extract Text";
            this.bt_ExtractText.UseVisualStyleBackColor = true;
            this.bt_ExtractText.Click += new System.EventHandler(this.bt_ExtractText_Click);
            // 
            // bt_OpenOriginalImage
            // 
            this.bt_OpenOriginalImage.Location = new System.Drawing.Point(614, 90);
            this.bt_OpenOriginalImage.Name = "bt_OpenOriginalImage";
            this.bt_OpenOriginalImage.Size = new System.Drawing.Size(75, 23);
            this.bt_OpenOriginalImage.TabIndex = 18;
            this.bt_OpenOriginalImage.Text = "Open";
            this.bt_OpenOriginalImage.UseVisualStyleBackColor = true;
            this.bt_OpenOriginalImage.Click += new System.EventHandler(this.bt_OpenOriginalImage_Click);
            // 
            // tb_originalImagePath
            // 
            this.tb_originalImagePath.Location = new System.Drawing.Point(211, 87);
            this.tb_originalImagePath.Name = "tb_originalImagePath";
            this.tb_originalImagePath.Size = new System.Drawing.Size(378, 22);
            this.tb_originalImagePath.TabIndex = 16;
            // 
            // tb_BlendedImagePath
            // 
            this.tb_BlendedImagePath.Location = new System.Drawing.Point(211, 30);
            this.tb_BlendedImagePath.Name = "tb_BlendedImagePath";
            this.tb_BlendedImagePath.Size = new System.Drawing.Size(378, 22);
            this.tb_BlendedImagePath.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Enter an image:";
            // 
            // bt_OpenBlendedImage
            // 
            this.bt_OpenBlendedImage.Location = new System.Drawing.Point(614, 30);
            this.bt_OpenBlendedImage.Name = "bt_OpenBlendedImage";
            this.bt_OpenBlendedImage.Size = new System.Drawing.Size(75, 23);
            this.bt_OpenBlendedImage.TabIndex = 13;
            this.bt_OpenBlendedImage.Text = "Open";
            this.bt_OpenBlendedImage.UseVisualStyleBackColor = true;
            this.bt_OpenBlendedImage.Click += new System.EventHandler(this.bt_OpenBlendedImage_Click);
            // 
            // HideText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 396);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_HideText);
            this.Name = "HideText";
            this.Text = "Form1";
            this.gb_HideText.ResumeLayout(false);
            this.gb_HideText.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog dia_OpenImage;
        private System.Windows.Forms.OpenFileDialog dia_OpenText;
        private System.Windows.Forms.SaveFileDialog dia_BlenedImageLocation;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox gb_HideText;
        private System.Windows.Forms.Button bt_HideTextInImage;
        private System.Windows.Forms.Button bt_OpenText;
        private System.Windows.Forms.Label lb_EnterTextLocation;
        private System.Windows.Forms.TextBox tb_textPath;
        public System.Windows.Forms.TextBox tb_imagePath;
        private System.Windows.Forms.Label lb_enterImage;
        private System.Windows.Forms.Button bt_OpenImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_ExtractText;
        private System.Windows.Forms.Button bt_OpenOriginalImage;
        private System.Windows.Forms.TextBox tb_originalImagePath;
        public System.Windows.Forms.TextBox tb_BlendedImagePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_OpenBlendedImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog dia_SaveTextLocation;
    }
}

