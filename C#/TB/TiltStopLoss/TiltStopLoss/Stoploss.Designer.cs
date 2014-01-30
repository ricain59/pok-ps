﻿namespace TiltStopLoss
{
    partial class Stoploss
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stoploss));
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelBb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHands = new System.Windows.Forms.Label();
            this.buttonSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(138, 36);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(38, 23);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.Location = new System.Drawing.Point(120, 9);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(56, 16);
            this.labelTimer.TabIndex = 1;
            this.labelTimer.Text = "00:00:00";
            // 
            // labelBb
            // 
            this.labelBb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBb.AutoSize = true;
            this.labelBb.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBb.ForeColor = System.Drawing.SystemColors.Window;
            this.labelBb.Location = new System.Drawing.Point(9, 8);
            this.labelBb.Name = "labelBb";
            this.labelBb.Size = new System.Drawing.Size(71, 24);
            this.labelBb.TabIndex = 2;
            this.labelBb.Text = "label1";
            this.labelBb.MouseLeave += new System.EventHandler(this.labelBb_MouseLeave);
            this.labelBb.MouseHover += new System.EventHandler(this.labelBb_MouseHover);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hands:";
            // 
            // labelHands
            // 
            this.labelHands.AutoSize = true;
            this.labelHands.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHands.Location = new System.Drawing.Point(57, 39);
            this.labelHands.Name = "labelHands";
            this.labelHands.Size = new System.Drawing.Size(15, 16);
            this.labelHands.TabIndex = 4;
            this.labelHands.Text = "0";
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(101, 36);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(31, 23);
            this.buttonSet.TabIndex = 5;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // Stoploss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(188, 64);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.labelHands);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelBb);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonStop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Stoploss";
            this.Text = "Stoploss";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Stoploss_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelBb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHands;
        private System.Windows.Forms.Button buttonSet;
    }
}