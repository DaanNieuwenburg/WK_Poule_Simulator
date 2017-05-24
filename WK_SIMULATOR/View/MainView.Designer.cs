namespace WK_SIMULATOR
{
    partial class Mainview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainview));
            this.bt_Start = new System.Windows.Forms.Button();
            this.bt_Close = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Start
            // 
            this.bt_Start.BackColor = System.Drawing.Color.Transparent;
            this.bt_Start.BackgroundImage = global::WK_SIMULATOR.Properties.Resources.start_button_leave;
            this.bt_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Start.FlatAppearance.BorderSize = 0;
            this.bt_Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Start.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Start.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_Start.Location = new System.Drawing.Point(146, 197);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(245, 77);
            this.bt_Start.TabIndex = 0;
            this.bt_Start.TabStop = false;
            this.bt_Start.UseVisualStyleBackColor = false;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            this.bt_Start.MouseEnter += new System.EventHandler(this.bt_Start_MouseEnter);
            this.bt_Start.MouseLeave += new System.EventHandler(this.bt_Start_MouseLeave);
            // 
            // bt_Close
            // 
            this.bt_Close.BackColor = System.Drawing.Color.Transparent;
            this.bt_Close.BackgroundImage = global::WK_SIMULATOR.Properties.Resources.close_button_leave;
            this.bt_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bt_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Close.FlatAppearance.BorderSize = 0;
            this.bt_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Close.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Close.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_Close.Location = new System.Drawing.Point(146, 299);
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.Size = new System.Drawing.Size(245, 77);
            this.bt_Close.TabIndex = 1;
            this.bt_Close.TabStop = false;
            this.bt_Close.UseVisualStyleBackColor = false;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            this.bt_Close.MouseEnter += new System.EventHandler(this.bt_Close_MouseEnter);
            this.bt_Close.MouseLeave += new System.EventHandler(this.bt_Close_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(46, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Mainview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(558, 417);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_Close);
            this.Controls.Add(this.bt_Start);
            this.MaximizeBox = false;
            this.Name = "Mainview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.Button bt_Close;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

