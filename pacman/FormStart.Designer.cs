namespace pacman
{
    partial class FormStart
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPacman = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxNick = new System.Windows.Forms.TextBox();
            this.labelNick = new System.Windows.Forms.Label();
            this.labelDifficultyLevel = new System.Windows.Forms.Label();
            this.buttonEasy = new System.Windows.Forms.Button();
            this.buttonMedium = new System.Windows.Forms.Button();
            this.buttonHard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPacman
            // 
            this.labelPacman.AutoSize = true;
            this.labelPacman.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPacman.ForeColor = System.Drawing.Color.Yellow;
            this.labelPacman.Location = new System.Drawing.Point(209, 9);
            this.labelPacman.Name = "labelPacman";
            this.labelPacman.Size = new System.Drawing.Size(323, 111);
            this.labelPacman.TabIndex = 0;
            this.labelPacman.Text = "Pacman";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Yellow;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.Location = new System.Drawing.Point(284, 320);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(156, 59);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxNick
            // 
            this.textBoxNick.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNick.Location = new System.Drawing.Point(19, 230);
            this.textBoxNick.Name = "textBoxNick";
            this.textBoxNick.Size = new System.Drawing.Size(177, 45);
            this.textBoxNick.TabIndex = 2;
            // 
            // labelNick
            // 
            this.labelNick.AutoSize = true;
            this.labelNick.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNick.ForeColor = System.Drawing.Color.Yellow;
            this.labelNick.Location = new System.Drawing.Point(61, 179);
            this.labelNick.Name = "labelNick";
            this.labelNick.Size = new System.Drawing.Size(83, 39);
            this.labelNick.TabIndex = 3;
            this.labelNick.Text = "Nick:";
            // 
            // labelDifficultyLevel
            // 
            this.labelDifficultyLevel.AutoSize = true;
            this.labelDifficultyLevel.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDifficultyLevel.ForeColor = System.Drawing.Color.Yellow;
            this.labelDifficultyLevel.Location = new System.Drawing.Point(405, 179);
            this.labelDifficultyLevel.Name = "labelDifficultyLevel";
            this.labelDifficultyLevel.Size = new System.Drawing.Size(246, 39);
            this.labelDifficultyLevel.TabIndex = 4;
            this.labelDifficultyLevel.Text = "Poziom trudności:";
            // 
            // buttonEasy
            // 
            this.buttonEasy.BackColor = System.Drawing.Color.Red;
            this.buttonEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEasy.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEasy.Location = new System.Drawing.Point(343, 230);
            this.buttonEasy.Name = "buttonEasy";
            this.buttonEasy.Size = new System.Drawing.Size(113, 43);
            this.buttonEasy.TabIndex = 5;
            this.buttonEasy.Text = "Easy";
            this.buttonEasy.UseVisualStyleBackColor = false;
            this.buttonEasy.Click += new System.EventHandler(this.buttonEasy_Click);
            // 
            // buttonMedium
            // 
            this.buttonMedium.BackColor = System.Drawing.Color.Red;
            this.buttonMedium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMedium.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonMedium.Location = new System.Drawing.Point(462, 230);
            this.buttonMedium.Name = "buttonMedium";
            this.buttonMedium.Size = new System.Drawing.Size(113, 43);
            this.buttonMedium.TabIndex = 6;
            this.buttonMedium.Text = "Medium";
            this.buttonMedium.UseVisualStyleBackColor = false;
            this.buttonMedium.Click += new System.EventHandler(this.buttonMedium_Click);
            // 
            // buttonHard
            // 
            this.buttonHard.BackColor = System.Drawing.Color.Red;
            this.buttonHard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHard.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonHard.Location = new System.Drawing.Point(581, 230);
            this.buttonHard.Name = "buttonHard";
            this.buttonHard.Size = new System.Drawing.Size(113, 43);
            this.buttonHard.TabIndex = 7;
            this.buttonHard.Text = "Hard";
            this.buttonHard.UseVisualStyleBackColor = false;
            this.buttonHard.Click += new System.EventHandler(this.buttonHard_Click);
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(711, 413);
            this.Controls.Add(this.buttonHard);
            this.Controls.Add(this.buttonMedium);
            this.Controls.Add(this.buttonEasy);
            this.Controls.Add(this.labelDifficultyLevel);
            this.Controls.Add(this.labelNick);
            this.Controls.Add(this.textBoxNick);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelPacman);
            this.MaximizeBox = false;
            this.Name = "FormStart";
            this.ShowIcon = false;
            this.Text = "Pacman";
            this.Load += new System.EventHandler(this.FormStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPacman;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxNick;
        private System.Windows.Forms.Label labelNick;
        private System.Windows.Forms.Label labelDifficultyLevel;
        private System.Windows.Forms.Button buttonEasy;
        private System.Windows.Forms.Button buttonMedium;
        private System.Windows.Forms.Button buttonHard;
    }
}

