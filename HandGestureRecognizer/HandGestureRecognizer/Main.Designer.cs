namespace IAProject
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.lblCam1 = new System.Windows.Forms.Label();
            this.imageBox7 = new Emgu.CV.UI.ImageBox();
            this.lblCam2 = new System.Windows.Forms.Label();
            this.imageBox6 = new Emgu.CV.UI.ImageBox();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.imageBox4 = new Emgu.CV.UI.ImageBox();
            this.imageBox5 = new Emgu.CV.UI.ImageBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblCam3 = new System.Windows.Forms.Label();
            this.lblCam4 = new System.Windows.Forms.Label();
            this.lblCam6 = new System.Windows.Forms.Label();
            this.lblCam7 = new System.Windows.Forms.Label();
            this.lblCam5 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = " ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1301, 38);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::IAProject.Properties.Resources.media_playback_start;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(35, 35);
            this.toolStripButton1.Text = "Start";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::IAProject.Properties.Resources.Crystal_Project_Player_stop;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(35, 35);
            this.toolStripButton2.Text = "Stop";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::IAProject.Properties.Resources.Crystal_Project_Exit;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 35);
            this.toolStripButton3.Text = "Exit";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // lblCam1
            // 
            this.lblCam1.AutoSize = true;
            this.lblCam1.Location = new System.Drawing.Point(18, 55);
            this.lblCam1.Name = "lblCam1";
            this.lblCam1.Size = new System.Drawing.Size(42, 13);
            this.lblCam1.TabIndex = 4;
            this.lblCam1.Text = "Original";
            // 
            // imageBox7
            // 
            this.imageBox7.Location = new System.Drawing.Point(21, 81);
            this.imageBox7.Name = "imageBox7";
            this.imageBox7.Size = new System.Drawing.Size(398, 284);
            this.imageBox7.TabIndex = 2;
            this.imageBox7.TabStop = false;
            // 
            // lblCam2
            // 
            this.lblCam2.AutoSize = true;
            this.lblCam2.Location = new System.Drawing.Point(425, 65);
            this.lblCam2.Name = "lblCam2";
            this.lblCam2.Size = new System.Drawing.Size(36, 13);
            this.lblCam2.TabIndex = 3;
            this.lblCam2.Text = "Binary";
            // 
            // imageBox6
            // 
            this.imageBox6.Location = new System.Drawing.Point(425, 81);
            this.imageBox6.Name = "imageBox6";
            this.imageBox6.Size = new System.Drawing.Size(413, 284);
            this.imageBox6.TabIndex = 2;
            this.imageBox6.TabStop = false;
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(21, 399);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(132, 110);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(169, 399);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(132, 110);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // imageBox3
            // 
            this.imageBox3.Location = new System.Drawing.Point(319, 399);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(132, 110);
            this.imageBox3.TabIndex = 2;
            this.imageBox3.TabStop = false;
            // 
            // imageBox4
            // 
            this.imageBox4.Location = new System.Drawing.Point(471, 399);
            this.imageBox4.Name = "imageBox4";
            this.imageBox4.Size = new System.Drawing.Size(132, 110);
            this.imageBox4.TabIndex = 2;
            this.imageBox4.TabStop = false;
            // 
            // imageBox5
            // 
            this.imageBox5.Location = new System.Drawing.Point(624, 399);
            this.imageBox5.Name = "imageBox5";
            this.imageBox5.Size = new System.Drawing.Size(132, 110);
            this.imageBox5.TabIndex = 2;
            this.imageBox5.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(971, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 212);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Gesture : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Finger Number : ";
            // 
            // txtPort
            // 
            this.txtPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPort.FormattingEnabled = true;
            this.txtPort.Location = new System.Drawing.Point(1045, 293);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(112, 21);
            this.txtPort.TabIndex = 12;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblCam3
            // 
            this.lblCam3.AutoSize = true;
            this.lblCam3.Location = new System.Drawing.Point(21, 377);
            this.lblCam3.Name = "lblCam3";
            this.lblCam3.Size = new System.Drawing.Size(87, 13);
            this.lblCam3.TabIndex = 9;
            this.lblCam3.Text = "1 - Draw Contour";
            // 
            // lblCam4
            // 
            this.lblCam4.AutoSize = true;
            this.lblCam4.Location = new System.Drawing.Point(166, 377);
            this.lblCam4.Name = "lblCam4";
            this.lblCam4.Size = new System.Drawing.Size(89, 13);
            this.lblCam4.TabIndex = 10;
            this.lblCam4.Text = "2 - Remove Face";
            // 
            // lblCam6
            // 
            this.lblCam6.AutoSize = true;
            this.lblCam6.Location = new System.Drawing.Point(468, 377);
            this.lblCam6.Name = "lblCam6";
            this.lblCam6.Size = new System.Drawing.Size(92, 13);
            this.lblCam6.TabIndex = 11;
            this.lblCam6.Text = "4 - Skin Detection";
            // 
            // lblCam7
            // 
            this.lblCam7.AutoSize = true;
            this.lblCam7.Location = new System.Drawing.Point(621, 377);
            this.lblCam7.Name = "lblCam7";
            this.lblCam7.Size = new System.Drawing.Size(116, 13);
            this.lblCam7.TabIndex = 12;
            this.lblCam7.Text = "5 - Extract Canny Edge";
            // 
            // lblCam5
            // 
            this.lblCam5.AutoSize = true;
            this.lblCam5.Location = new System.Drawing.Point(316, 377);
            this.lblCam5.Name = "lblCam5";
            this.lblCam5.Size = new System.Drawing.Size(92, 13);
            this.lblCam5.TabIndex = 13;
            this.lblCam5.Text = "3 - Skin Detection";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(972, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Circuit Port : ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 560);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblCam5);
            this.Controls.Add(this.lblCam7);
            this.Controls.Add(this.lblCam6);
            this.Controls.Add(this.lblCam4);
            this.Controls.Add(this.lblCam3);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.lblCam1);
            this.Controls.Add(this.imageBox7);
            this.Controls.Add(this.lblCam2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.imageBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.imageBox5);
            this.Controls.Add(this.imageBox4);
            this.Name = "Main";
            this.Text = "Main";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private Emgu.CV.UI.ImageBox imageBox3;
        private Emgu.CV.UI.ImageBox imageBox4;
        private System.Windows.Forms.Label label1;
        private Emgu.CV.UI.ImageBox imageBox5;
        private Emgu.CV.UI.ImageBox imageBox6;
        private System.Windows.Forms.Label label2;
        private Emgu.CV.UI.ImageBox imageBox7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Label lblCam2;
        private System.Windows.Forms.Label lblCam1;
        private System.Windows.Forms.ComboBox txtPort;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblCam3;
        private System.Windows.Forms.Label lblCam4;
        private System.Windows.Forms.Label lblCam6;
        private System.Windows.Forms.Label lblCam7;
        private System.Windows.Forms.Label lblCam5;
        private System.Windows.Forms.Label label5;
    }
}

