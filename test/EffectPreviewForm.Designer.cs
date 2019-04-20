namespace test
{
    partial class EffectPreviewForm
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
            this.beforeAfter1 = new test.BeforeAfter();
            this.SuspendLayout();
            // 
            // beforeAfter1
            // 
            this.beforeAfter1.After = null;
            this.beforeAfter1.Before = null;
            this.beforeAfter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.beforeAfter1.Location = new System.Drawing.Point(0, 0);
            this.beforeAfter1.Name = "beforeAfter1";
            this.beforeAfter1.Size = new System.Drawing.Size(944, 678);
            this.beforeAfter1.TabIndex = 0;
            this.beforeAfter1.Text = "beforeAfter1";
            // 
            // EffectPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 678);
            this.Controls.Add(this.beforeAfter1);
            this.MaximumSize = new System.Drawing.Size(960, 717);
            this.MinimumSize = new System.Drawing.Size(960, 717);
            this.Name = "EffectPreviewForm";
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BeforeAfter beforeAfter1;


    }
}

