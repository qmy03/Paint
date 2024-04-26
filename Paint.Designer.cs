using System.Windows.Forms;

namespace Paint
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnRectFr = new System.Windows.Forms.Button();
            this.btnEllipseFr = new System.Windows.Forms.Button();
            this.btnCirFr = new System.Windows.Forms.Button();
            this.btnCir = new System.Windows.Forms.Button();
            this.btnRect = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPen = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.ptBox = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ptBox);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 671);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(647, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(289, 150);
            this.panel4.TabIndex = 17;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Beige;
            this.panel6.Controls.Add(this.btnColor);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(183, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(91, 130);
            this.panel6.TabIndex = 21;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Snow;
            this.btnColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnColor.BackgroundImage")));
            this.btnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(15, 10);
            this.btnColor.Margin = new System.Windows.Forms.Padding(0);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(60, 60);
            this.btnColor.TabIndex = 11;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            this.btnColor.MouseLeave += new System.EventHandler(this.btnColor_MouseLeave);
            this.btnColor.MouseHover += new System.EventHandler(this.btnColor_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 32);
            this.label3.TabIndex = 18;
            this.label3.Text = "Color";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Beige;
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.numericUpDown1);
            this.panel5.Location = new System.Drawing.Point(17, 103);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(160, 37);
            this.panel5.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Beige;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 32);
            this.label4.TabIndex = 20;
            this.label4.Text = "Size";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.UseWaitCursor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.Beige;
            this.numericUpDown1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(71, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(76, 33);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.UseWaitCursor = true;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Oswald", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Beige;
            this.label2.Location = new System.Drawing.Point(28, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 44);
            this.label2.TabIndex = 15;
            this.label2.Text = "CHANGE";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnLine);
            this.panel3.Controls.Add(this.btnRectFr);
            this.panel3.Controls.Add(this.btnEllipseFr);
            this.panel3.Controls.Add(this.btnCirFr);
            this.panel3.Controls.Add(this.btnCir);
            this.panel3.Controls.Add(this.btnRect);
            this.panel3.Controls.Add(this.btnEllipse);
            this.panel3.Location = new System.Drawing.Point(180, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 150);
            this.panel3.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Oswald", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(134, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "DRAW SHAPE";
            // 
            // btnLine
            // 
            this.btnLine.BackColor = System.Drawing.Color.Snow;
            this.btnLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLine.BackgroundImage")));
            this.btnLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLine.FlatAppearance.BorderSize = 0;
            this.btnLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLine.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLine.Location = new System.Drawing.Point(14, 80);
            this.btnLine.Margin = new System.Windows.Forms.Padding(0);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(60, 60);
            this.btnLine.TabIndex = 6;
            this.btnLine.UseVisualStyleBackColor = false;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            this.btnLine.MouseHover += new System.EventHandler(this.btnLine_MouseHover);
            // 
            // btnRectFr
            // 
            this.btnRectFr.BackColor = System.Drawing.Color.Snow;
            this.btnRectFr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRectFr.BackgroundImage")));
            this.btnRectFr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRectFr.FlatAppearance.BorderSize = 0;
            this.btnRectFr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRectFr.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRectFr.Location = new System.Drawing.Point(74, 80);
            this.btnRectFr.Margin = new System.Windows.Forms.Padding(0);
            this.btnRectFr.Name = "btnRectFr";
            this.btnRectFr.Size = new System.Drawing.Size(60, 60);
            this.btnRectFr.TabIndex = 0;
            this.btnRectFr.UseVisualStyleBackColor = false;
            this.btnRectFr.Click += new System.EventHandler(this.btnRectFr_Click);
            this.btnRectFr.MouseLeave += new System.EventHandler(this.btnRectFr_MouseLeave);
            this.btnRectFr.MouseHover += new System.EventHandler(this.btnRectFr_MouseHover);
            // 
            // btnEllipseFr
            // 
            this.btnEllipseFr.BackColor = System.Drawing.Color.Snow;
            this.btnEllipseFr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEllipseFr.BackgroundImage")));
            this.btnEllipseFr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEllipseFr.FlatAppearance.BorderSize = 0;
            this.btnEllipseFr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEllipseFr.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEllipseFr.Location = new System.Drawing.Point(134, 80);
            this.btnEllipseFr.Margin = new System.Windows.Forms.Padding(0);
            this.btnEllipseFr.Name = "btnEllipseFr";
            this.btnEllipseFr.Size = new System.Drawing.Size(60, 60);
            this.btnEllipseFr.TabIndex = 9;
            this.btnEllipseFr.UseVisualStyleBackColor = false;
            this.btnEllipseFr.Click += new System.EventHandler(this.btnEllipseFr_Click);
            this.btnEllipseFr.MouseLeave += new System.EventHandler(this.btnEllipseFr_MouseLeave);
            this.btnEllipseFr.MouseHover += new System.EventHandler(this.btnEllipseFr_MouseHover);
            // 
            // btnCirFr
            // 
            this.btnCirFr.BackColor = System.Drawing.Color.Snow;
            this.btnCirFr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCirFr.BackgroundImage")));
            this.btnCirFr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCirFr.FlatAppearance.BorderSize = 0;
            this.btnCirFr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCirFr.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCirFr.Location = new System.Drawing.Point(194, 80);
            this.btnCirFr.Margin = new System.Windows.Forms.Padding(0);
            this.btnCirFr.Name = "btnCirFr";
            this.btnCirFr.Size = new System.Drawing.Size(60, 60);
            this.btnCirFr.TabIndex = 13;
            this.btnCirFr.UseVisualStyleBackColor = false;
            this.btnCirFr.Click += new System.EventHandler(this.btnCirFr_Click);
            this.btnCirFr.MouseLeave += new System.EventHandler(this.btnCirFr_MouseLeave);
            this.btnCirFr.MouseHover += new System.EventHandler(this.btnCirFr_MouseHover);
            // 
            // btnCir
            // 
            this.btnCir.BackColor = System.Drawing.Color.Snow;
            this.btnCir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCir.BackgroundImage")));
            this.btnCir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCir.FlatAppearance.BorderSize = 0;
            this.btnCir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCir.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCir.Location = new System.Drawing.Point(374, 80);
            this.btnCir.Margin = new System.Windows.Forms.Padding(0);
            this.btnCir.Name = "btnCir";
            this.btnCir.Size = new System.Drawing.Size(60, 60);
            this.btnCir.TabIndex = 14;
            this.btnCir.UseVisualStyleBackColor = false;
            this.btnCir.Click += new System.EventHandler(this.btnCir_Click);
            this.btnCir.MouseLeave += new System.EventHandler(this.btnCir_MouseLeave);
            this.btnCir.MouseHover += new System.EventHandler(this.btnCir_MouseHover);
            // 
            // btnRect
            // 
            this.btnRect.BackColor = System.Drawing.Color.Snow;
            this.btnRect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRect.BackgroundImage")));
            this.btnRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRect.FlatAppearance.BorderSize = 0;
            this.btnRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRect.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRect.Location = new System.Drawing.Point(254, 80);
            this.btnRect.Margin = new System.Windows.Forms.Padding(0);
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(60, 60);
            this.btnRect.TabIndex = 8;
            this.btnRect.UseVisualStyleBackColor = false;
            this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
            this.btnRect.MouseLeave += new System.EventHandler(this.btnRect_MouseLeave);
            this.btnRect.MouseHover += new System.EventHandler(this.btnRect_MouseHover);
            // 
            // btnEllipse
            // 
            this.btnEllipse.BackColor = System.Drawing.Color.Snow;
            this.btnEllipse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEllipse.BackgroundImage")));
            this.btnEllipse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEllipse.FlatAppearance.BorderSize = 0;
            this.btnEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEllipse.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEllipse.Location = new System.Drawing.Point(314, 80);
            this.btnEllipse.Margin = new System.Windows.Forms.Padding(0);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(60, 60);
            this.btnEllipse.TabIndex = 10;
            this.btnEllipse.UseVisualStyleBackColor = false;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            this.btnEllipse.MouseLeave += new System.EventHandler(this.btnEllipse_MouseLeave);
            this.btnEllipse.MouseHover += new System.EventHandler(this.btnEllipse_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Controls.Add(this.btnPen);
            this.panel2.Controls.Add(this.btnSaveImage);
            this.panel2.Controls.Add(this.btn_Delete);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 150);
            this.panel2.TabIndex = 16;
            // 
            // btnPen
            // 
            this.btnPen.AutoEllipsis = true;
            this.btnPen.BackColor = System.Drawing.Color.Snow;
            this.btnPen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPen.BackgroundImage")));
            this.btnPen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPen.FlatAppearance.BorderSize = 0;
            this.btnPen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPen.Location = new System.Drawing.Point(85, 80);
            this.btnPen.Margin = new System.Windows.Forms.Padding(0);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(60, 60);
            this.btnPen.TabIndex = 13;
            this.btnPen.UseVisualStyleBackColor = false;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            this.btnPen.MouseLeave += new System.EventHandler(this.btnPen_MouseLeave);
            this.btnPen.MouseHover += new System.EventHandler(this.btnPen_MouseHover);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.BackColor = System.Drawing.Color.Snow;
            this.btnSaveImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.BackgroundImage")));
            this.btnSaveImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveImage.FlatAppearance.BorderSize = 0;
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveImage.Location = new System.Drawing.Point(14, 10);
            this.btnSaveImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(60, 60);
            this.btnSaveImage.TabIndex = 13;
            this.btnSaveImage.UseVisualStyleBackColor = false;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            this.btnSaveImage.MouseLeave += new System.EventHandler(this.btnSaveImage_MouseLeave);
            this.btnSaveImage.MouseHover += new System.EventHandler(this.btnSaveImage_MouseHover);
            // 
            // btn_Delete
            // 
            this.btn_Delete.AutoEllipsis = true;
            this.btn_Delete.BackColor = System.Drawing.Color.Snow;
            this.btn_Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Delete.BackgroundImage")));
            this.btn_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Delete.FlatAppearance.BorderSize = 0;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Location = new System.Drawing.Point(85, 10);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(60, 60);
            this.btn_Delete.TabIndex = 15;
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            this.btn_Delete.MouseLeave += new System.EventHandler(this.btn_Delete_MouseLeave);
            this.btn_Delete.MouseHover += new System.EventHandler(this.btn_Delete_MouseHover);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Snow;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(14, 80);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 60);
            this.btnClear.TabIndex = 12;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseLeave += new System.EventHandler(this.btnClear_MouseLeave);
            this.btnClear.MouseHover += new System.EventHandler(this.btnClear_MouseHover);
            // 
            // ptBox
            // 
            this.ptBox.BackColor = System.Drawing.Color.White;
            this.ptBox.Location = new System.Drawing.Point(10, 170);
            this.ptBox.Margin = new System.Windows.Forms.Padding(0);
            this.ptBox.Name = "ptBox";
            this.ptBox.Size = new System.Drawing.Size(926, 490);
            this.ptBox.TabIndex = 1;
            this.ptBox.TabStop = false;
            this.ptBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ptBox_Paint);
            this.ptBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptBox_MouseDown);
            this.ptBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptBox_MouseMove);
            this.ptBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptBox_MouseUp);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(951, 669);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Paint";
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ptBox;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnRectFr;
        private System.Windows.Forms.Button btnEllipseFr;
        private System.Windows.Forms.Button btnCirFr;
        private System.Windows.Forms.Button btnRect;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnCir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private Panel panel4;
        private Panel panel6;
        private Label label3;
        private Panel panel5;
        private Label label4;
        private Label label2;
    }
}

