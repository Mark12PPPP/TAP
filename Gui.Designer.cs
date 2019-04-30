namespace TAP
{
    partial class Gui
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
            this.ClearLed = new System.Windows.Forms.Button();
            this.SetLed = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Panel_S2 = new System.Windows.Forms.Panel();
            this.Panel_S1 = new System.Windows.Forms.Panel();
            this.lbl_S1 = new System.Windows.Forms.Label();
            this.lbl_S2 = new System.Windows.Forms.Label();
            this.Panel_S3 = new System.Windows.Forms.Panel();
            this.lbl_S3 = new System.Windows.Forms.Label();
            this.Panel_S4 = new System.Windows.Forms.Panel();
            this.lbl_S4 = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ClearLed
            // 
            this.ClearLed.Location = new System.Drawing.Point(34, 79);
            this.ClearLed.Name = "ClearLed";
            this.ClearLed.Size = new System.Drawing.Size(75, 23);
            this.ClearLed.TabIndex = 2;
            this.ClearLed.Text = "ClearLed";
            this.ClearLed.UseVisualStyleBackColor = true;
            // 
            // SetLed
            // 
            this.SetLed.Location = new System.Drawing.Point(34, 108);
            this.SetLed.Name = "SetLed";
            this.SetLed.Size = new System.Drawing.Size(75, 23);
            this.SetLed.TabIndex = 3;
            this.SetLed.Text = "SetLed";
            this.SetLed.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "ReadButtons";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Panel_S2
            // 
            this.Panel_S2.BackColor = System.Drawing.SystemColors.Window;
            this.Panel_S2.Location = new System.Drawing.Point(194, 340);
            this.Panel_S2.Name = "Panel_S2";
            this.Panel_S2.Size = new System.Drawing.Size(76, 66);
            this.Panel_S2.TabIndex = 7;
            // 
            // Panel_S1
            // 
            this.Panel_S1.BackColor = System.Drawing.SystemColors.Window;
            this.Panel_S1.Location = new System.Drawing.Point(81, 340);
            this.Panel_S1.Name = "Panel_S1";
            this.Panel_S1.Size = new System.Drawing.Size(72, 66);
            this.Panel_S1.TabIndex = 8;
            // 
            // lbl_S1
            // 
            this.lbl_S1.AutoSize = true;
            this.lbl_S1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_S1.Location = new System.Drawing.Point(97, 324);
            this.lbl_S1.Name = "lbl_S1";
            this.lbl_S1.Size = new System.Drawing.Size(20, 13);
            this.lbl_S1.TabIndex = 0;
            this.lbl_S1.Text = "S1";
            // 
            // lbl_S2
            // 
            this.lbl_S2.AutoSize = true;
            this.lbl_S2.Location = new System.Drawing.Point(215, 324);
            this.lbl_S2.Name = "lbl_S2";
            this.lbl_S2.Size = new System.Drawing.Size(20, 13);
            this.lbl_S2.TabIndex = 9;
            this.lbl_S2.Text = "S2";
            // 
            // Panel_S3
            // 
            this.Panel_S3.BackColor = System.Drawing.SystemColors.Window;
            this.Panel_S3.Location = new System.Drawing.Point(322, 340);
            this.Panel_S3.Name = "Panel_S3";
            this.Panel_S3.Size = new System.Drawing.Size(76, 66);
            this.Panel_S3.TabIndex = 10;
            // 
            // lbl_S3
            // 
            this.lbl_S3.AutoSize = true;
            this.lbl_S3.Location = new System.Drawing.Point(343, 324);
            this.lbl_S3.Name = "lbl_S3";
            this.lbl_S3.Size = new System.Drawing.Size(20, 13);
            this.lbl_S3.TabIndex = 11;
            this.lbl_S3.Text = "S3";
            // 
            // Panel_S4
            // 
            this.Panel_S4.BackColor = System.Drawing.SystemColors.Window;
            this.Panel_S4.Location = new System.Drawing.Point(451, 340);
            this.Panel_S4.Name = "Panel_S4";
            this.Panel_S4.Size = new System.Drawing.Size(76, 66);
            this.Panel_S4.TabIndex = 11;
            // 
            // lbl_S4
            // 
            this.lbl_S4.AutoSize = true;
            this.lbl_S4.Location = new System.Drawing.Point(470, 324);
            this.lbl_S4.Name = "lbl_S4";
            this.lbl_S4.Size = new System.Drawing.Size(20, 13);
            this.lbl_S4.TabIndex = 12;
            this.lbl_S4.Text = "S4";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_S4);
            this.Controls.Add(this.Panel_S4);
            this.Controls.Add(this.lbl_S3);
            this.Controls.Add(this.Panel_S3);
            this.Controls.Add(this.lbl_S2);
            this.Controls.Add(this.lbl_S1);
            this.Controls.Add(this.Panel_S1);
            this.Controls.Add(this.Panel_S2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SetLed);
            this.Controls.Add(this.ClearLed);
            this.Name = "Gui";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ClearLed;
        private System.Windows.Forms.Button SetLed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel Panel_S2;
        private System.Windows.Forms.Panel Panel_S1;
        private System.Windows.Forms.Label lbl_S1;
        private System.Windows.Forms.Label lbl_S2;
        private System.Windows.Forms.Panel Panel_S3;
        private System.Windows.Forms.Label lbl_S3;
        private System.Windows.Forms.Panel Panel_S4;
        private System.Windows.Forms.Label lbl_S4;
        private System.Windows.Forms.Timer Timer;
    }
}

