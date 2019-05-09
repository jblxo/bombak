namespace Bombak
{
    partial class SetField
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
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.lblTitle = new System.Windows.Forms.Label();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.lblX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(88, 58);
            this.numericUpDownX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownX.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownX.TabIndex = 0;
            this.numericUpDownX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.Location = new System.Drawing.Point(60, 7);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(169, 49);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Bombák";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(88, 81);
            this.numericUpDownY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownY.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownY.TabIndex = 2;
            this.numericUpDownY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(182, 60);
            this.lblX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 13);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Y";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStart.Location = new System.Drawing.Point(68, 168);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(161, 63);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // SetField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 287);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.numericUpDownY);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.numericUpDownX);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SetField";
            this.Text = "SetField";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
    }
}