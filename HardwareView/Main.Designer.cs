namespace HardwareView
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
            this.CPUTemp = new System.Windows.Forms.Label();
            this.GPUTemp = new System.Windows.Forms.Label();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.GPU = new System.Windows.Forms.PictureBox();
            this.CPU = new System.Windows.Forms.PictureBox();
            this.Background = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CPUTemp
            // 
            this.CPUTemp.AutoSize = true;
            this.CPUTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.CPUTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CPUTemp.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPUTemp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CPUTemp.Location = new System.Drawing.Point(57, 20);
            this.CPUTemp.Name = "CPUTemp";
            this.CPUTemp.Size = new System.Drawing.Size(34, 23);
            this.CPUTemp.TabIndex = 1;
            this.CPUTemp.Text = "0 C";
            this.CPUTemp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CPUTemp_MouseMove);
            // 
            // GPUTemp
            // 
            this.GPUTemp.AutoSize = true;
            this.GPUTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.GPUTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GPUTemp.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GPUTemp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GPUTemp.Location = new System.Drawing.Point(57, 53);
            this.GPUTemp.Name = "GPUTemp";
            this.GPUTemp.Size = new System.Drawing.Size(34, 23);
            this.GPUTemp.TabIndex = 2;
            this.GPUTemp.Text = "0 C";
            this.GPUTemp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GPUTemp_MouseMove);
            // 
            // Updater
            // 
            this.Updater.Interval = 1000;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // GPU
            // 
            this.GPU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.GPU.Image = global::HardwareView.Properties.Resources.gpu;
            this.GPU.Location = new System.Drawing.Point(12, 53);
            this.GPU.Name = "GPU";
            this.GPU.Size = new System.Drawing.Size(39, 30);
            this.GPU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GPU.TabIndex = 4;
            this.GPU.TabStop = false;
            this.GPU.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GPU_MouseMove);
            // 
            // CPU
            // 
            this.CPU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.CPU.Image = global::HardwareView.Properties.Resources.cpu;
            this.CPU.Location = new System.Drawing.Point(12, 12);
            this.CPU.Name = "CPU";
            this.CPU.Size = new System.Drawing.Size(39, 31);
            this.CPU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CPU.TabIndex = 3;
            this.CPU.TabStop = false;
            this.CPU.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CPU_MouseMove);
            // 
            // Background
            // 
            this.Background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.Background.ContextMenuStrip = this.contextMenuStrip1;
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(120, 96);
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            this.Background.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Background_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 96);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.GPU);
            this.Controls.Add(this.CPU);
            this.Controls.Add(this.GPUTemp);
            this.Controls.Add(this.CPUTemp);
            this.Controls.Add(this.Background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.Load += new System.EventHandler(this.Main_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.GPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.Label CPUTemp;
        private System.Windows.Forms.Label GPUTemp;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.PictureBox CPU;
        private System.Windows.Forms.PictureBox GPU;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

