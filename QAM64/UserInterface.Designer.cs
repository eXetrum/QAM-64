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
            this.lblBinSeqInp = new System.Windows.Forms.Label();
            this.pbConstellation = new System.Windows.Forms.PictureBox();
            this.logBox = new System.Windows.Forms.TextBox();
            this.pbSignal = new System.Windows.Forms.PictureBox();
            this.btnSendData = new System.Windows.Forms.Button();
            this.lblMessageInp = new System.Windows.Forms.Label();
            this.txtBoxMessageInp = new System.Windows.Forms.TextBox();
            this.chBoxNoise = new System.Windows.Forms.CheckBox();
            this.groupBoxEncode = new System.Windows.Forms.GroupBox();
            this.groupBoxDecode = new System.Windows.Forms.GroupBox();
            this.lblMessageOut = new System.Windows.Forms.Label();
            this.txtBoxOutputBits = new System.Windows.Forms.TextBox();
            this.txtBoxMessageOut = new System.Windows.Forms.TextBox();
            this.lblBinSeqOut = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbConstellation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignal)).BeginInit();
            this.groupBoxEncode.SuspendLayout();
            this.groupBoxDecode.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxInputBits
            // 
            this.txtBoxInputBits.Location = new System.Drawing.Point(217, 50);
            this.txtBoxInputBits.Name = "txtBoxInputBits";
            this.txtBoxInputBits.ReadOnly = true;
            this.txtBoxInputBits.Size = new System.Drawing.Size(289, 20);
            this.txtBoxInputBits.TabIndex = 2;
            this.txtBoxInputBits.TextChanged += new System.EventHandler(this.txtBoxInputBits_TextChanged);
            this.txtBoxInputBits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputBits_KeyPress);
            // 
            // lblBinSeqInp
            // 
            this.lblBinSeqInp.AutoSize = true;
            this.lblBinSeqInp.Location = new System.Drawing.Point(6, 53);
            this.lblBinSeqInp.Name = "lblBinSeqInp";
            this.lblBinSeqInp.Size = new System.Drawing.Size(205, 13);
            this.lblBinSeqInp.TabIndex = 1;
            this.lblBinSeqInp.Text = "Входная битовая последовательность:";
            // 
            // pbConstellation
            // 
            this.pbConstellation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbConstellation.Location = new System.Drawing.Point(12, 100);
            this.pbConstellation.Name = "pbConstellation";
            this.pbConstellation.Size = new System.Drawing.Size(512, 512);
            this.pbConstellation.TabIndex = 2;
            this.pbConstellation.TabStop = false;
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(1202, 18);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(86, 76);
            this.logBox.TabIndex = 15;
            this.logBox.Visible = false;
            // 
            // pbSignal
            // 
            this.pbSignal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbSignal.Location = new System.Drawing.Point(530, 100);
            this.pbSignal.Name = "pbSignal";
            this.pbSignal.Size = new System.Drawing.Size(758, 510);
            this.pbSignal.TabIndex = 4;
            this.pbSignal.TabStop = false;
            // 
            // btnSendData
            // 
            this.btnSendData.Enabled = false;
            this.btnSendData.Location = new System.Drawing.Point(1048, 60);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(148, 34);
            this.btnSendData.TabIndex = 3;
            this.btnSendData.Text = "Передать данные";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // lblMessageInp
            // 
            this.lblMessageInp.AutoSize = true;
            this.lblMessageInp.Location = new System.Drawing.Point(6, 26);
            this.lblMessageInp.Name = "lblMessageInp";
            this.lblMessageInp.Size = new System.Drawing.Size(68, 13);
            this.lblMessageInp.TabIndex = 6;
            this.lblMessageInp.Text = "Сообщение:";
            // 
            // txtBoxMessageInp
            // 
            this.txtBoxMessageInp.Location = new System.Drawing.Point(217, 21);
            this.txtBoxMessageInp.Name = "txtBoxMessageInp";
            this.txtBoxMessageInp.Size = new System.Drawing.Size(289, 20);
            this.txtBoxMessageInp.TabIndex = 1;
            this.txtBoxMessageInp.TextChanged += new System.EventHandler(this.txtBoxMessage_TextChanged);
            this.txtBoxMessageInp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxMessage_KeyPress);
            // 
            // chBoxNoise
            // 
            this.chBoxNoise.AutoSize = true;
            this.chBoxNoise.Checked = true;
            this.chBoxNoise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxNoise.Location = new System.Drawing.Point(1048, 12);
            this.chBoxNoise.Name = "chBoxNoise";
            this.chBoxNoise.Size = new System.Drawing.Size(148, 17);
            this.chBoxNoise.TabIndex = 7;
            this.chBoxNoise.Text = "Канал с наличием шума";
            this.chBoxNoise.UseVisualStyleBackColor = true;
            // 
            // groupBoxEncode
            // 
            this.groupBoxEncode.Controls.Add(this.lblMessageInp);
            this.groupBoxEncode.Controls.Add(this.txtBoxInputBits);
            this.groupBoxEncode.Controls.Add(this.txtBoxMessageInp);
            this.groupBoxEncode.Controls.Add(this.lblBinSeqInp);
            this.groupBoxEncode.Location = new System.Drawing.Point(12, 12);
            this.groupBoxEncode.Name = "groupBoxEncode";
            this.groupBoxEncode.Size = new System.Drawing.Size(512, 82);
            this.groupBoxEncode.TabIndex = 0;
            this.groupBoxEncode.TabStop = false;
            this.groupBoxEncode.Text = "Передача";
            // 
            // groupBoxDecode
            // 
            this.groupBoxDecode.Controls.Add(this.lblMessageOut);
            this.groupBoxDecode.Controls.Add(this.txtBoxMessageOut);
            this.groupBoxDecode.Controls.Add(this.txtBoxOutputBits);
            this.groupBoxDecode.Controls.Add(this.lblBinSeqOut);
            this.groupBoxDecode.Location = new System.Drawing.Point(530, 12);
            this.groupBoxDecode.Name = "groupBoxDecode";
            this.groupBoxDecode.Size = new System.Drawing.Size(512, 82);
            this.groupBoxDecode.TabIndex = 9;
            this.groupBoxDecode.TabStop = false;
            this.groupBoxDecode.Text = "Прием";
            // 
            // lblMessageOut
            // 
            this.lblMessageOut.AutoSize = true;
            this.lblMessageOut.Location = new System.Drawing.Point(6, 24);
            this.lblMessageOut.Name = "lblMessageOut";
            this.lblMessageOut.Size = new System.Drawing.Size(68, 13);
            this.lblMessageOut.TabIndex = 10;
            this.lblMessageOut.Text = "Сообщение:";
            // 
            // txtBoxOutputBits
            // 
            this.txtBoxOutputBits.Location = new System.Drawing.Point(225, 48);
            this.txtBoxOutputBits.Name = "txtBoxOutputBits";
            this.txtBoxOutputBits.ReadOnly = true;
            this.txtBoxOutputBits.Size = new System.Drawing.Size(281, 20);
            this.txtBoxOutputBits.TabIndex = 9;
            // 
            // txtBoxMessageOut
            // 
            this.txtBoxMessageOut.Location = new System.Drawing.Point(225, 19);
            this.txtBoxMessageOut.Name = "txtBoxMessageOut";
            this.txtBoxMessageOut.ReadOnly = true;
            this.txtBoxMessageOut.Size = new System.Drawing.Size(281, 20);
            this.txtBoxMessageOut.TabIndex = 7;
            // 
            // lblBinSeqOut
            // 
            this.lblBinSeqOut.AutoSize = true;
            this.lblBinSeqOut.Location = new System.Drawing.Point(6, 50);
            this.lblBinSeqOut.Name = "lblBinSeqOut";
            this.lblBinSeqOut.Size = new System.Drawing.Size(213, 13);
            this.lblBinSeqOut.TabIndex = 8;
            this.lblBinSeqOut.Text = "Выходная битовая последовательность:";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 622);
            this.Controls.Add(this.groupBoxDecode);
            this.Controls.Add(this.groupBoxEncode);
            this.Controls.Add(this.chBoxNoise);
            this.Controls.Add(this.pbSignal);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.pbConstellation);
            this.Name = "UserInterface";
            this.Text = "QAM-64";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbConstellation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignal)).EndInit();
            this.groupBoxEncode.ResumeLayout(false);
            this.groupBoxEncode.PerformLayout();
            this.groupBoxDecode.ResumeLayout(false);
            this.groupBoxDecode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxInputBits;
        private System.Windows.Forms.Label lblBinSeqInp;
        private System.Windows.Forms.PictureBox pbConstellation;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.PictureBox pbSignal;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Label lblMessageInp;
        private System.Windows.Forms.TextBox txtBoxMessageInp;
        private System.Windows.Forms.CheckBox chBoxNoise;
        private System.Windows.Forms.GroupBox groupBoxEncode;
        private System.Windows.Forms.GroupBox groupBoxDecode;
        private System.Windows.Forms.Label lblMessageOut;
        private System.Windows.Forms.TextBox txtBoxMessageOut;
        private System.Windows.Forms.TextBox txtBoxOutputBits;
        private System.Windows.Forms.Label lblBinSeqOut;
    }
}

