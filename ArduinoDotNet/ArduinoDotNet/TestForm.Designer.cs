namespace ArduinoSharp
{
    partial class TestForm
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
            this.digitalWrite = new System.Windows.Forms.Button();
            this.closeB = new System.Windows.Forms.Button();
            this.analogReadB = new System.Windows.Forms.Button();
            this.digtialReadB = new System.Windows.Forms.Button();
            this.pinTB = new System.Windows.Forms.TextBox();
            this.valueTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkDriverB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // digitalWrite
            // 
            this.digitalWrite.Location = new System.Drawing.Point(13, 42);
            this.digitalWrite.Name = "digitalWrite";
            this.digitalWrite.Size = new System.Drawing.Size(91, 23);
            this.digitalWrite.TabIndex = 0;
            this.digitalWrite.Text = "Digital Write";
            this.digitalWrite.UseVisualStyleBackColor = true;
            this.digitalWrite.Click += new System.EventHandler(this.digitalWrite_Click);
            // 
            // closeB
            // 
            this.closeB.Location = new System.Drawing.Point(13, 227);
            this.closeB.Name = "closeB";
            this.closeB.Size = new System.Drawing.Size(75, 23);
            this.closeB.TabIndex = 1;
            this.closeB.Text = "Close";
            this.closeB.UseVisualStyleBackColor = true;
            this.closeB.Click += new System.EventHandler(this.closeB_Click);
            // 
            // analogReadB
            // 
            this.analogReadB.Location = new System.Drawing.Point(13, 71);
            this.analogReadB.Name = "analogReadB";
            this.analogReadB.Size = new System.Drawing.Size(91, 23);
            this.analogReadB.TabIndex = 0;
            this.analogReadB.Text = "Analogue Read";
            this.analogReadB.UseVisualStyleBackColor = true;
            this.analogReadB.Click += new System.EventHandler(this.analogReadB_Click);
            // 
            // digtialReadB
            // 
            this.digtialReadB.Location = new System.Drawing.Point(13, 100);
            this.digtialReadB.Name = "digtialReadB";
            this.digtialReadB.Size = new System.Drawing.Size(91, 23);
            this.digtialReadB.TabIndex = 0;
            this.digtialReadB.Text = "Digital Read";
            this.digtialReadB.UseVisualStyleBackColor = true;
            this.digtialReadB.Click += new System.EventHandler(this.digtialReadB_Click);
            // 
            // pinTB
            // 
            this.pinTB.Location = new System.Drawing.Point(136, 44);
            this.pinTB.Name = "pinTB";
            this.pinTB.Size = new System.Drawing.Size(51, 20);
            this.pinTB.TabIndex = 2;
            this.pinTB.Text = "3";
            // 
            // valueTB
            // 
            this.valueTB.Location = new System.Drawing.Point(193, 44);
            this.valueTB.Name = "valueTB";
            this.valueTB.Size = new System.Drawing.Size(51, 20);
            this.valueTB.TabIndex = 2;
            this.valueTB.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Flash Driver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkDriverB
            // 
            this.checkDriverB.Location = new System.Drawing.Point(109, 12);
            this.checkDriverB.Name = "checkDriverB";
            this.checkDriverB.Size = new System.Drawing.Size(91, 23);
            this.checkDriverB.TabIndex = 3;
            this.checkDriverB.Text = "Check Driver";
            this.checkDriverB.UseVisualStyleBackColor = true;
            this.checkDriverB.Click += new System.EventHandler(this.checkDriverB_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.checkDriverB);
            this.Controls.Add(this.valueTB);
            this.Controls.Add(this.pinTB);
            this.Controls.Add(this.closeB);
            this.Controls.Add(this.digtialReadB);
            this.Controls.Add(this.analogReadB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.digitalWrite);
            this.Name = "TestForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button digitalWrite;
        private System.Windows.Forms.Button closeB;
        private System.Windows.Forms.Button analogReadB;
        private System.Windows.Forms.Button digtialReadB;
        private System.Windows.Forms.TextBox pinTB;
        private System.Windows.Forms.TextBox valueTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button checkDriverB;
    }
}

