namespace ImageRouteRuler
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.bReset = new System.Windows.Forms.Button();
            this.bDelLast = new System.Windows.Forms.Button();
            this.bLoadImage = new System.Windows.Forms.Button();
            this.lScale = new System.Windows.Forms.Label();
            this.textScale = new System.Windows.Forms.TextBox();
            this.imageBox1 = new ImageRouteRuler.ImageBoxWithRoute();
            this.SuspendLayout();
            // 
            // bReset
            // 
            this.bReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bReset.Location = new System.Drawing.Point(1036, 12);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 1;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.BReset_Click);
            // 
            // bDelLast
            // 
            this.bDelLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bDelLast.Location = new System.Drawing.Point(1036, 41);
            this.bDelLast.Name = "bDelLast";
            this.bDelLast.Size = new System.Drawing.Size(75, 23);
            this.bDelLast.TabIndex = 2;
            this.bDelLast.Text = "Delete last";
            this.bDelLast.UseVisualStyleBackColor = true;
            this.bDelLast.Click += new System.EventHandler(this.BDelLast_Click);
            // 
            // bLoadImage
            // 
            this.bLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bLoadImage.Location = new System.Drawing.Point(1036, 181);
            this.bLoadImage.Name = "bLoadImage";
            this.bLoadImage.Size = new System.Drawing.Size(75, 23);
            this.bLoadImage.TabIndex = 3;
            this.bLoadImage.Text = "Load image";
            this.bLoadImage.UseVisualStyleBackColor = true;
            this.bLoadImage.Click += new System.EventHandler(this.BLoadImage_Click);
            // 
            // lScale
            // 
            this.lScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lScale.AutoSize = true;
            this.lScale.Location = new System.Drawing.Point(1039, 158);
            this.lScale.Name = "lScale";
            this.lScale.Size = new System.Drawing.Size(22, 13);
            this.lScale.TabIndex = 4;
            this.lScale.Text = "1 : ";
            // 
            // textScale
            // 
            this.textScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textScale.Location = new System.Drawing.Point(1059, 155);
            this.textScale.Name = "textScale";
            this.textScale.Size = new System.Drawing.Size(52, 20);
            this.textScale.TabIndex = 5;
            this.textScale.Text = "50000";
            this.textScale.TextChanged += new System.EventHandler(this.TextScale_TextChanged);
            // 
            // imageBox1
            // 
            this.imageBox1.AllowDoubleClick = true;
            this.imageBox1.AlwaysShowHScroll = true;
            this.imageBox1.AlwaysShowVScroll = true;
            this.imageBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox1.Image = ((System.Drawing.Image)(resources.GetObject("imageBox1.Image")));
            this.imageBox1.Location = new System.Drawing.Point(0, 3);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(1030, 201);
            this.imageBox1.TabIndex = 0;
            this.imageBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageBox1_Paint);
            this.imageBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageBox1_MouseDown);
            this.imageBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageBox1_MouseUp);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 216);
            this.Controls.Add(this.textScale);
            this.Controls.Add(this.lScale);
            this.Controls.Add(this.bLoadImage);
            this.Controls.Add(this.bDelLast);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.imageBox1);
            this.Name = "Main";
            this.Text = "Image Route Ruler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageBoxWithRoute imageBox1;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Button bDelLast;
        private System.Windows.Forms.Button bLoadImage;
        private System.Windows.Forms.Label lScale;
        private System.Windows.Forms.TextBox textScale;
    }
}

