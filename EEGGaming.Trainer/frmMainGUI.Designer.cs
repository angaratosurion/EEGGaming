namespace EEGGaming.Trainer
{
    partial class frmMainGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new System.Windows.Forms.Button();
            btnStop = new System.Windows.Forms.Button();
            btnBlinked = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new System.Windows.Forms.Label();
            lblElapsed = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            lblBatteryLvl = new System.Windows.Forms.Label();
            cbxEnableFiltering = new System.Windows.Forms.CheckBox();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            btnLoadCsv = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            lblSampleCount = new System.Windows.Forms.Label();
            btnMakeGraphs = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new System.Drawing.Point(27, 11);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(94, 28);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new System.Drawing.Point(149, 16);
            btnStop.Name = "btnStop";
            btnStop.Size = new System.Drawing.Size(94, 28);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnBlinked
            // 
            btnBlinked.Location = new System.Drawing.Point(891, 12);
            btnBlinked.Name = "btnBlinked";
            btnBlinked.Size = new System.Drawing.Size(94, 28);
            btnBlinked.TabIndex = 2;
            btnBlinked.Text = "i Blinked";
            btnBlinked.UseVisualStyleBackColor = true;
            btnBlinked.Click += btnBlinked_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(400, 16);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(94, 28);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 399);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 19);
            label1.TabIndex = 4;
            label1.Text = "Elapsed";
            label1.Click += label1_Click;
            // 
            // lblElapsed
            // 
            lblElapsed.AutoSize = true;
            lblElapsed.Location = new System.Drawing.Point(95, 403);
            lblElapsed.Name = "lblElapsed";
            lblElapsed.Size = new System.Drawing.Size(17, 19);
            lblElapsed.TabIndex = 5;
            lblElapsed.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(363, 399);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(131, 19);
            label2.TabIndex = 6;
            label2.Text = "Battery Percentage: ";
            // 
            // lblBatteryLvl
            // 
            lblBatteryLvl.AutoSize = true;
            lblBatteryLvl.Location = new System.Drawing.Point(531, 403);
            lblBatteryLvl.Name = "lblBatteryLvl";
            lblBatteryLvl.Size = new System.Drawing.Size(28, 19);
            lblBatteryLvl.TabIndex = 7;
            lblBatteryLvl.Text = "0%";
            // 
            // cbxEnableFiltering
            // 
            cbxEnableFiltering.AutoSize = true;
            cbxEnableFiltering.Location = new System.Drawing.Point(738, 16);
            cbxEnableFiltering.Name = "cbxEnableFiltering";
            cbxEnableFiltering.Size = new System.Drawing.Size(121, 23);
            cbxEnableFiltering.TabIndex = 8;
            cbxEnableFiltering.Text = "Enable Filtering";
            cbxEnableFiltering.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLoadCsv
            // 
            btnLoadCsv.Location = new System.Drawing.Point(274, 16);
            btnLoadCsv.Name = "btnLoadCsv";
            btnLoadCsv.Size = new System.Drawing.Size(94, 28);
            btnLoadCsv.TabIndex = 10;
            btnLoadCsv.Text = "Load CSV";
            btnLoadCsv.UseVisualStyleBackColor = true;
            btnLoadCsv.Click += btnLoadCsv_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(601, 402);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(164, 19);
            label3.TabIndex = 11;
            label3.Text = "Number Of Sample Taken";
            // 
            // lblSampleCount
            // 
            lblSampleCount.AutoSize = true;
            lblSampleCount.Location = new System.Drawing.Point(776, 402);
            lblSampleCount.Name = "lblSampleCount";
            lblSampleCount.Size = new System.Drawing.Size(17, 19);
            lblSampleCount.TabIndex = 12;
            lblSampleCount.Text = "0";
            // 
            // btnMakeGraphs
            // 
            btnMakeGraphs.Location = new System.Drawing.Point(518, 10);
            btnMakeGraphs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnMakeGraphs.Name = "btnMakeGraphs";
            btnMakeGraphs.Size = new System.Drawing.Size(198, 29);
            btnMakeGraphs.TabIndex = 13;
            btnMakeGraphs.Text = "Make Graphs";
            btnMakeGraphs.UseVisualStyleBackColor = true;
            btnMakeGraphs.Click += btnMakeGraphs_Click;
            // 
            // frmMainGUI
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1021, 103);
            Controls.Add(btnMakeGraphs);
            Controls.Add(lblSampleCount);
            Controls.Add(label3);
            Controls.Add(btnLoadCsv);
            Controls.Add(cbxEnableFiltering);
            Controls.Add(lblBatteryLvl);
            Controls.Add(label2);
            Controls.Add(lblElapsed);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(btnBlinked);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "frmMainGUI";
            Text = "Form1";
            Load += frmMainGUI_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnBlinked;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBatteryLvl;
        private System.Windows.Forms.CheckBox cbxEnableFiltering;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnLoadCsv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSampleCount;
        private System.Windows.Forms.Button btnMakeGraphs;
    }
}
