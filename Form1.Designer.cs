namespace Visual_studio
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.white = new System.Windows.Forms.Label();
            this.whitex = new System.Windows.Forms.Label();
            this.VS = new System.Windows.Forms.Label();
            this.turn = new System.Windows.Forms.Label();
            this.blackx = new System.Windows.Forms.Label();
            this.black = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // white
            // 
            this.white.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.white.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.white.Location = new System.Drawing.Point(323, 19);
            this.white.Name = "white";
            this.white.Size = new System.Drawing.Size(150, 50);
            this.white.TabIndex = 2;
            this.white.Text = "white";
            this.white.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // whitex
            // 
            this.whitex.AutoSize = true;
            this.whitex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.whitex.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whitex.Location = new System.Drawing.Point(386, 50);
            this.whitex.Name = "whitex";
            this.whitex.Size = new System.Drawing.Size(24, 19);
            this.whitex.TabIndex = 3;
            this.whitex.Text = "x2";
            // 
            // VS
            // 
            this.VS.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.VS.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VS.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.VS.Location = new System.Drawing.Point(168, 19);
            this.VS.Name = "VS";
            this.VS.Size = new System.Drawing.Size(150, 50);
            this.VS.TabIndex = 4;
            this.VS.Text = "VS";
            this.VS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // turn
            // 
            this.turn.BackColor = System.Drawing.Color.Black;
            this.turn.Location = new System.Drawing.Point(163, 14);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(160, 60);
            this.turn.TabIndex = 5;
            // 
            // blackx
            // 
            this.blackx.AutoSize = true;
            this.blackx.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.blackx.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blackx.Location = new System.Drawing.Point(75, 50);
            this.blackx.Name = "blackx";
            this.blackx.Size = new System.Drawing.Size(24, 19);
            this.blackx.TabIndex = 7;
            this.blackx.Text = "x2";
            // 
            // black
            // 
            this.black.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.black.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.black.Location = new System.Drawing.Point(12, 19);
            this.black.Name = "black";
            this.black.Size = new System.Drawing.Size(150, 50);
            this.black.TabIndex = 6;
            this.black.Text = "black";
            this.black.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 536);
            this.Controls.Add(this.blackx);
            this.Controls.Add(this.black);
            this.Controls.Add(this.turn);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.whitex);
            this.Controls.Add(this.white);
            this.Name = "Form1";
            this.Text = "Reversi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label white;
        private System.Windows.Forms.Label whitex;
        private System.Windows.Forms.Label VS;
        private System.Windows.Forms.Label turn;
        private System.Windows.Forms.Label blackx;
        private System.Windows.Forms.Label black;
    }
}

