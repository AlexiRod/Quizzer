namespace Quizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonQuestion = new System.Windows.Forms.Button();
            this.buttonTheme = new System.Windows.Forms.Button();
            this.buttonGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonQuestion
            // 
            this.buttonQuestion.BackColor = System.Drawing.Color.White;
            this.buttonQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonQuestion.Location = new System.Drawing.Point(250, 254);
            this.buttonQuestion.Name = "buttonQuestion";
            this.buttonQuestion.Size = new System.Drawing.Size(353, 75);
            this.buttonQuestion.TabIndex = 0;
            this.buttonQuestion.Text = "Редактор вопросов";
            this.buttonQuestion.UseVisualStyleBackColor = false;
            this.buttonQuestion.Click += new System.EventHandler(this.buttonQuestion_Click);
            // 
            // buttonTheme
            // 
            this.buttonTheme.BackColor = System.Drawing.Color.White;
            this.buttonTheme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTheme.Location = new System.Drawing.Point(250, 335);
            this.buttonTheme.Name = "buttonTheme";
            this.buttonTheme.Size = new System.Drawing.Size(353, 75);
            this.buttonTheme.TabIndex = 1;
            this.buttonTheme.Text = "Редактор категорий вопросов";
            this.buttonTheme.UseVisualStyleBackColor = false;
            this.buttonTheme.Click += new System.EventHandler(this.buttonTheme_Click);
            // 
            // buttonGame
            // 
            this.buttonGame.BackColor = System.Drawing.Color.White;
            this.buttonGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGame.Location = new System.Drawing.Point(251, 173);
            this.buttonGame.Name = "buttonGame";
            this.buttonGame.Size = new System.Drawing.Size(352, 75);
            this.buttonGame.TabIndex = 2;
            this.buttonGame.Text = "Игра";
            this.buttonGame.UseVisualStyleBackColor = false;
            this.buttonGame.Click += new System.EventHandler(this.buttonGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 557);
            this.Controls.Add(this.buttonGame);
            this.Controls.Add(this.buttonTheme);
            this.Controls.Add(this.buttonQuestion);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonQuestion;
        private System.Windows.Forms.Button buttonTheme;
        private System.Windows.Forms.Button buttonGame;
    }
}

