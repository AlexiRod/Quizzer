namespace Quizer
{
    partial class FormGame
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
            this.cBoxThemes = new System.Windows.Forms.ComboBox();
            this.chBoxTheme = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelQuestionText = new System.Windows.Forms.Label();
            this.labelQuestionName = new System.Windows.Forms.Label();
            this.buttonVariant1 = new System.Windows.Forms.Button();
            this.buttonVariant3 = new System.Windows.Forms.Button();
            this.buttonVariant2 = new System.Windows.Forms.Button();
            this.buttonVariant4 = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonHelp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBoxThemes
            // 
            this.cBoxThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxThemes.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cBoxThemes.FormattingEnabled = true;
            this.cBoxThemes.Location = new System.Drawing.Point(392, 546);
            this.cBoxThemes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cBoxThemes.Name = "cBoxThemes";
            this.cBoxThemes.Size = new System.Drawing.Size(498, 39);
            this.cBoxThemes.TabIndex = 5;
            this.cBoxThemes.SelectedIndexChanged += new System.EventHandler(this.cBoxThemes_SelectedIndexChanged);
            // 
            // chBoxTheme
            // 
            this.chBoxTheme.AutoSize = true;
            this.chBoxTheme.BackColor = System.Drawing.Color.Transparent;
            this.chBoxTheme.Location = new System.Drawing.Point(133, 552);
            this.chBoxTheme.Name = "chBoxTheme";
            this.chBoxTheme.Size = new System.Drawing.Size(251, 30);
            this.chBoxTheme.TabIndex = 6;
            this.chBoxTheme.Text = "Вопросы из категории";
            this.chBoxTheme.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelScore);
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Location = new System.Drawing.Point(12, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 96);
            this.panel1.TabIndex = 7;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(14, 52);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(87, 26);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "Очки: 0";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(14, 14);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(167, 26);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "Время на ответ:";
            // 
            // labelQuestionText
            // 
            this.labelQuestionText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelQuestionText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelQuestionText.Location = new System.Drawing.Point(133, 221);
            this.labelQuestionText.Name = "labelQuestionText";
            this.labelQuestionText.Size = new System.Drawing.Size(757, 110);
            this.labelQuestionText.TabIndex = 8;
            this.labelQuestionText.Text = "Текст вопроса";
            this.labelQuestionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelQuestionName
            // 
            this.labelQuestionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelQuestionName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelQuestionName.Location = new System.Drawing.Point(133, 142);
            this.labelQuestionName.Name = "labelQuestionName";
            this.labelQuestionName.Size = new System.Drawing.Size(757, 72);
            this.labelQuestionName.TabIndex = 8;
            this.labelQuestionName.Text = "Название вопроса";
            this.labelQuestionName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonVariant1
            // 
            this.buttonVariant1.BackColor = System.Drawing.Color.White;
            this.buttonVariant1.Enabled = false;
            this.buttonVariant1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVariant1.Location = new System.Drawing.Point(133, 348);
            this.buttonVariant1.Name = "buttonVariant1";
            this.buttonVariant1.Size = new System.Drawing.Size(375, 85);
            this.buttonVariant1.TabIndex = 9;
            this.buttonVariant1.Text = "1";
            this.buttonVariant1.UseVisualStyleBackColor = false;
            this.buttonVariant1.Click += new System.EventHandler(this.buttonVariant_Click);
            // 
            // buttonVariant3
            // 
            this.buttonVariant3.BackColor = System.Drawing.Color.White;
            this.buttonVariant3.Enabled = false;
            this.buttonVariant3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVariant3.Location = new System.Drawing.Point(515, 348);
            this.buttonVariant3.Name = "buttonVariant3";
            this.buttonVariant3.Size = new System.Drawing.Size(375, 85);
            this.buttonVariant3.TabIndex = 9;
            this.buttonVariant3.Text = "3";
            this.buttonVariant3.UseVisualStyleBackColor = false;
            this.buttonVariant3.Click += new System.EventHandler(this.buttonVariant_Click);
            // 
            // buttonVariant2
            // 
            this.buttonVariant2.BackColor = System.Drawing.Color.White;
            this.buttonVariant2.Enabled = false;
            this.buttonVariant2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVariant2.Location = new System.Drawing.Point(133, 439);
            this.buttonVariant2.Name = "buttonVariant2";
            this.buttonVariant2.Size = new System.Drawing.Size(375, 85);
            this.buttonVariant2.TabIndex = 9;
            this.buttonVariant2.Text = "2";
            this.buttonVariant2.UseVisualStyleBackColor = false;
            this.buttonVariant2.Click += new System.EventHandler(this.buttonVariant_Click);
            // 
            // buttonVariant4
            // 
            this.buttonVariant4.BackColor = System.Drawing.Color.White;
            this.buttonVariant4.Enabled = false;
            this.buttonVariant4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVariant4.Location = new System.Drawing.Point(515, 439);
            this.buttonVariant4.Name = "buttonVariant4";
            this.buttonVariant4.Size = new System.Drawing.Size(375, 85);
            this.buttonVariant4.TabIndex = 9;
            this.buttonVariant4.Text = "4";
            this.buttonVariant4.UseVisualStyleBackColor = false;
            this.buttonVariant4.Click += new System.EventHandler(this.buttonVariant_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label.Location = new System.Drawing.Point(345, 45);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(337, 37);
            this.label.TabIndex = 10;
            this.label.Text = "Викторина \"Quizzer\"";
            // 
            // buttonNext
            // 
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Location = new System.Drawing.Point(894, 38);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(60, 60);
            this.buttonNext.TabIndex = 11;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonHelp.Location = new System.Drawing.Point(12, 587);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(111, 35);
            this.buttonHelp.TabIndex = 8;
            this.buttonHelp.Text = "Справка";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(989, 634);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonVariant4);
            this.Controls.Add(this.buttonVariant2);
            this.Controls.Add(this.buttonVariant3);
            this.Controls.Add(this.buttonVariant1);
            this.Controls.Add(this.labelQuestionName);
            this.Controls.Add(this.labelQuestionText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chBoxTheme);
            this.Controls.Add(this.cBoxThemes);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormGame";
            this.Text = "FormGame";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxThemes;
        private System.Windows.Forms.CheckBox chBoxTheme;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelQuestionText;
        private System.Windows.Forms.Label labelQuestionName;
        private System.Windows.Forms.Button buttonVariant1;
        private System.Windows.Forms.Button buttonVariant3;
        private System.Windows.Forms.Button buttonVariant2;
        private System.Windows.Forms.Button buttonVariant4;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonHelp;
    }
}