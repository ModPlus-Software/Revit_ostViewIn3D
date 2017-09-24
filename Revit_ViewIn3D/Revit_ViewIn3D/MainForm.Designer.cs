namespace Revit_3DSectionBox
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbSection = new System.Windows.Forms.TrackBar();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.linkLabelFedor = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tbSection)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSection
            // 
            this.tbSection.Location = new System.Drawing.Point(1, 1);
            this.tbSection.Maximum = 50;
            this.tbSection.Minimum = 1;
            this.tbSection.Name = "tbSection";
            this.tbSection.Size = new System.Drawing.Size(250, 45);
            this.tbSection.TabIndex = 39;
            this.tbSection.Value = 1;
            this.tbSection.Scroll += new System.EventHandler(this.tbSection_Scroll);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(176, 33);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(68, 13);
            this.linkLabel.TabIndex = 40;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "About author";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // linkLabelFedor
            // 
            this.linkLabelFedor.AutoSize = true;
            this.linkLabelFedor.Location = new System.Drawing.Point(12, 33);
            this.linkLabelFedor.Name = "linkLabelFedor";
            this.linkLabelFedor.Size = new System.Drawing.Size(69, 13);
            this.linkLabelFedor.TabIndex = 41;
            this.linkLabelFedor.TabStop = true;
            this.linkLabelFedor.Text = "Friendly apps";
            this.linkLabelFedor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFedor_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(248, 55);
            this.Controls.Add(this.linkLabelFedor);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.tbSection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3D Section box";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tbSection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbSection;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.LinkLabel linkLabelFedor;
    }
}