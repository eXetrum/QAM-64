namespace QAM64
{
    partial class UserInterface
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
            this.txtBoxInputBits = new System.Windows.Forms.TextBox();
            this.lblBinSeq = new System.Windows.Forms.Label();
            this.pbConstellation = new System.Windows.Forms.PictureBox();
            this.logBox = new System.Windows.Forms.TextBox();
            this.pbSignal = new System.Windows.Forms.PictureBox();
            this.btnGenerateSignal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbConstellation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignal)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxInputBits
            // 
            this.txtBoxInputBits.Location = new System.Drawing.Point(224, 10);
            this.txtBoxInputBits.Name = "txtBoxInputBits";
            this.txtBoxInputBits.Size = new System.Drawing.Size(304, 20);
            this.txtBoxInputBits.TabIndex = 0;
            this.txtBoxInputBits.Text = "000000";
            this.txtBoxInputBits.TextChanged += new System.EventHandler(this.txtBoxInputBits_TextChanged);
            this.txtBoxInputBits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputBits_KeyPress);
            // 
            // lblBinSeq
            // 
            this.lblBinSeq.AutoSize = true;
            this.lblBinSeq.Location = new System.Drawing.Point(13, 13);
            this.lblBinSeq.Name = "lblBinSeq";
            this.lblBinSeq.Size = new System.Drawing.Size(205, 13);
            this.lblBinSeq.TabIndex = 1;
            this.lblBinSeq.Text = "Входная битовая последовательность:";
            // 
            // pbConstellation
            // 
            this.pbConstellation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbConstellation.Location = new System.Drawing.Point(16, 40);
            this.pbConstellation.Name = "pbConstellation";
            this.pbConstellation.Size = new System.Drawing.Size(512, 512);
            this.pbConstellation.TabIndex = 2;
            this.pbConstellation.TabStop = false;
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(534, 476);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(771, 76);
            this.logBox.TabIndex = 3;
            // 
            // pbSignal
            // 
            this.pbSignal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbSignal.Location = new System.Drawing.Point(534, 40);
            this.pbSignal.Name = "pbSignal";
            this.pbSignal.Size = new System.Drawing.Size(770, 430);
            this.pbSignal.TabIndex = 4;
            this.pbSignal.TabStop = false;
            // 
            // btnGenerateSignal
            // 
            this.btnGenerateSignal.Location = new System.Drawing.Point(534, 8);
            this.btnGenerateSignal.Name = "btnGenerateSignal";
            this.btnGenerateSignal.Size = new System.Drawing.Size(137, 23);
            this.btnGenerateSignal.TabIndex = 5;
            this.btnGenerateSignal.Text = "Сгенерировать сигнал";
            this.btnGenerateSignal.UseVisualStyleBackColor = true;
            this.btnGenerateSignal.Click += new System.EventHandler(this.btnGenerateSignal_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 564);
            this.Controls.Add(this.btnGenerateSignal);
            this.Controls.Add(this.pbSignal);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.pbConstellation);
            this.Controls.Add(this.lblBinSeq);
            this.Controls.Add(this.txtBoxInputBits);
            this.Name = "UserInterface";
            this.Text = "QAM-64";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbConstellation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxInputBits;
        private System.Windows.Forms.Label lblBinSeq;
        private System.Windows.Forms.PictureBox pbConstellation;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.PictureBox pbSignal;
        private System.Windows.Forms.Button btnGenerateSignal;
    }
}

