namespace FractalDimension
{
    partial class GraphForm
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
            this.Graph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // Graph
            // 
            this.Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Graph.Location = new System.Drawing.Point(0, 0);
            this.Graph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Graph.Name = "Graph";
            this.Graph.ScrollGrace = 0D;
            this.Graph.ScrollMaxX = 0D;
            this.Graph.ScrollMaxY = 0D;
            this.Graph.ScrollMaxY2 = 0D;
            this.Graph.ScrollMinX = 0D;
            this.Graph.ScrollMinY = 0D;
            this.Graph.ScrollMinY2 = 0D;
            this.Graph.Size = new System.Drawing.Size(682, 353);
            this.Graph.TabIndex = 0;
            this.Graph.UseExtendedPrintDialog = true;
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 353);
            this.Controls.Add(this.Graph);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "GraphForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "График";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl Graph;
    }
}