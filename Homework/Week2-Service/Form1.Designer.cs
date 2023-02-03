namespace Week2_Service
{
    partial class Form1
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
            this.tb_number1 = new System.Windows.Forms.TextBox();
            this.tb_number2 = new System.Windows.Forms.TextBox();
            this.btn_calculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_number1
            // 
            this.tb_number1.Location = new System.Drawing.Point(266, 107);
            this.tb_number1.Name = "tb_number1";
            this.tb_number1.Size = new System.Drawing.Size(238, 20);
            this.tb_number1.TabIndex = 0;
            // 
            // tb_number2
            // 
            this.tb_number2.Location = new System.Drawing.Point(266, 145);
            this.tb_number2.Name = "tb_number2";
            this.tb_number2.Size = new System.Drawing.Size(238, 20);
            this.tb_number2.TabIndex = 1;
            // 
            // btn_calculate
            // 
            this.btn_calculate.Location = new System.Drawing.Point(331, 189);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.Size = new System.Drawing.Size(105, 20);
            this.btn_calculate.TabIndex = 2;
            this.btn_calculate.Text = "Calculate";
            this.btn_calculate.UseVisualStyleBackColor = true;
            this.btn_calculate.Click += new System.EventHandler(this.btn_calculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please enter a number in each box...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_calculate);
            this.Controls.Add(this.tb_number2);
            this.Controls.Add(this.tb_number1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_number1;
        private System.Windows.Forms.TextBox tb_number2;
        private System.Windows.Forms.Button btn_calculate;
        private System.Windows.Forms.Label label1;
    }
}

