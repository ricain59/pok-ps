namespace PS
{
    partial class FormInicial
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.checkBoxLogin = new System.Windows.Forms.CheckBox();
            this.checkBoxDown = new System.Windows.Forms.CheckBox();
            this.checkBoxZoom = new System.Windows.Forms.CheckBox();
            this.textBoxVm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(57, 22);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(57, 66);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(13, 205);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(159, 20);
            this.textBoxLogin.TabIndex = 2;
            this.textBoxLogin.Visible = false;
            // 
            // checkBoxLogin
            // 
            this.checkBoxLogin.AutoSize = true;
            this.checkBoxLogin.Location = new System.Drawing.Point(53, 182);
            this.checkBoxLogin.Name = "checkBoxLogin";
            this.checkBoxLogin.Size = new System.Drawing.Size(77, 17);
            this.checkBoxLogin.TabIndex = 3;
            this.checkBoxLogin.Text = "With Login";
            this.checkBoxLogin.UseVisualStyleBackColor = true;
            this.checkBoxLogin.CheckedChanged += new System.EventHandler(this.checkBoxLogin_CheckedChanged);
            // 
            // checkBoxDown
            // 
            this.checkBoxDown.AutoSize = true;
            this.checkBoxDown.Location = new System.Drawing.Point(53, 133);
            this.checkBoxDown.Name = "checkBoxDown";
            this.checkBoxDown.Size = new System.Drawing.Size(79, 17);
            this.checkBoxDown.TabIndex = 4;
            this.checkBoxDown.Text = "down to up";
            this.checkBoxDown.UseVisualStyleBackColor = true;
            // 
            // checkBoxZoom
            // 
            this.checkBoxZoom.AutoSize = true;
            this.checkBoxZoom.Location = new System.Drawing.Point(53, 110);
            this.checkBoxZoom.Name = "checkBoxZoom";
            this.checkBoxZoom.Size = new System.Drawing.Size(53, 17);
            this.checkBoxZoom.TabIndex = 5;
            this.checkBoxZoom.Text = "Zoom";
            this.checkBoxZoom.UseVisualStyleBackColor = true;
            // 
            // textBoxVm
            // 
            this.textBoxVm.Location = new System.Drawing.Point(53, 157);
            this.textBoxVm.Name = "textBoxVm";
            this.textBoxVm.Size = new System.Drawing.Size(29, 20);
            this.textBoxVm.TabIndex = 6;
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 235);
            this.Controls.Add(this.textBoxVm);
            this.Controls.Add(this.checkBoxZoom);
            this.Controls.Add(this.checkBoxDown);
            this.Controls.Add(this.checkBoxLogin);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Name = "FormInicial";
            this.Text = "StartDT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormInicial_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.CheckBox checkBoxLogin;
        private System.Windows.Forms.CheckBox checkBoxDown;
        private System.Windows.Forms.CheckBox checkBoxZoom;
        private System.Windows.Forms.TextBox textBoxVm;
    }
}

