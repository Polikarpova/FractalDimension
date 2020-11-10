namespace FractalDimension
{
    partial class SubsetsForm
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
            this.FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel
            // 
            this.FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanel.Name = "FlowLayoutPanel";
            this.FlowLayoutPanel.Size = new System.Drawing.Size(1182, 593);
            this.FlowLayoutPanel.TabIndex = 0;
            // 
            // SubsetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 593);
            this.Controls.Add(this.FlowLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(1200, 640);
            this.Name = "SubsetsForm";
            this.Text = "Разделение на подмножества";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SubsetsForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel;
    }
}