namespace pacman
{
    partial class FormNewGame
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
            this.labelNewGame = new System.Windows.Forms.Label();
            this.buttonNewGameYes = new System.Windows.Forms.Button();
            this.buttonNewGameNo = new System.Windows.Forms.Button();
            this.labelNewGameMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNewGame
            // 
            this.labelNewGame.AutoSize = true;
            this.labelNewGame.Font = new System.Drawing.Font("Comic Sans MS", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNewGame.ForeColor = System.Drawing.Color.Yellow;
            this.labelNewGame.Location = new System.Drawing.Point(289, 225);
            this.labelNewGame.Name = "labelNewGame";
            this.labelNewGame.Size = new System.Drawing.Size(238, 67);
            this.labelNewGame.TabIndex = 0;
            this.labelNewGame.Text = "Nowa gra";
            // 
            // buttonNewGameYes
            // 
            this.buttonNewGameYes.BackColor = System.Drawing.Color.Yellow;
            this.buttonNewGameYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNewGameYes.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNewGameYes.Location = new System.Drawing.Point(194, 345);
            this.buttonNewGameYes.Name = "buttonNewGameYes";
            this.buttonNewGameYes.Size = new System.Drawing.Size(157, 50);
            this.buttonNewGameYes.TabIndex = 1;
            this.buttonNewGameYes.Text = "TAK";
            this.buttonNewGameYes.UseVisualStyleBackColor = false;
            this.buttonNewGameYes.Click += new System.EventHandler(this.buttonNewGameYes_Click);
            // 
            // buttonNewGameNo
            // 
            this.buttonNewGameNo.BackColor = System.Drawing.Color.Yellow;
            this.buttonNewGameNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNewGameNo.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNewGameNo.Location = new System.Drawing.Point(456, 345);
            this.buttonNewGameNo.Name = "buttonNewGameNo";
            this.buttonNewGameNo.Size = new System.Drawing.Size(157, 50);
            this.buttonNewGameNo.TabIndex = 2;
            this.buttonNewGameNo.Text = "NIE";
            this.buttonNewGameNo.UseVisualStyleBackColor = false;
            this.buttonNewGameNo.Click += new System.EventHandler(this.buttonNewGameNo_Click);
            // 
            // labelNewGameMessage
            // 
            this.labelNewGameMessage.AutoSize = true;
            this.labelNewGameMessage.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNewGameMessage.ForeColor = System.Drawing.Color.Yellow;
            this.labelNewGameMessage.Location = new System.Drawing.Point(252, 37);
            this.labelNewGameMessage.Name = "labelNewGameMessage";
            this.labelNewGameMessage.Size = new System.Drawing.Size(0, 84);
            this.labelNewGameMessage.TabIndex = 3;
            // 
            // FormNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelNewGameMessage);
            this.Controls.Add(this.buttonNewGameNo);
            this.Controls.Add(this.buttonNewGameYes);
            this.Controls.Add(this.labelNewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormNewGame";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FormNewGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNewGame;
        private System.Windows.Forms.Button buttonNewGameYes;
        private System.Windows.Forms.Button buttonNewGameNo;
        private System.Windows.Forms.Label labelNewGameMessage;
    }
}