namespace Quizer
{
    partial class FormTheme
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
            this.cBoxThemes = new System.Windows.Forms.ComboBox();
            this.listQuestions = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxNameTheme = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cBoxThemes
            // 
            this.cBoxThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxThemes.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cBoxThemes.FormattingEnabled = true;
            this.cBoxThemes.Location = new System.Drawing.Point(109, 58);
            this.cBoxThemes.Name = "cBoxThemes";
            this.cBoxThemes.Size = new System.Drawing.Size(511, 39);
            this.cBoxThemes.TabIndex = 5;
            this.cBoxThemes.SelectedIndexChanged += new System.EventHandler(this.cBoxThemes_SelectedIndexChanged);
            // 
            // listQuestions
            // 
            this.listQuestions.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listQuestions.FormattingEnabled = true;
            this.listQuestions.Location = new System.Drawing.Point(109, 122);
            this.listQuestions.Name = "listQuestions";
            this.listQuestions.Size = new System.Drawing.Size(512, 410);
            this.listQuestions.Sorted = true;
            this.listQuestions.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(109, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "Редактирование категорий вопросов";
            // 
            // tBoxNameTheme
            // 
            this.tBoxNameTheme.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tBoxNameTheme.Location = new System.Drawing.Point(109, 564);
            this.tBoxNameTheme.Name = "tBoxNameTheme";
            this.tBoxNameTheme.PlaceholderText = "Название категории";
            this.tBoxNameTheme.Size = new System.Drawing.Size(400, 39);
            this.tBoxNameTheme.TabIndex = 4;
            this.tBoxNameTheme.TextChanged += new System.EventHandler(this.tBoxNameTheme_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAdd.Location = new System.Drawing.Point(515, 560);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(50, 50);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = " ";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDelete.Location = new System.Drawing.Point(571, 560);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(50, 50);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = " ";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(12, 9);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(85, 35);
            this.buttonHelp.TabIndex = 8;
            this.buttonHelp.Text = "Справка";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // FormTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(735, 623);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.tBoxNameTheme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listQuestions);
            this.Controls.Add(this.cBoxThemes);
            this.Name = "FormTheme";
            this.Text = "FormTheme";
            this.Load += new System.EventHandler(this.FormTheme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxThemes;
        private System.Windows.Forms.CheckedListBox listQuestions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxNameTheme;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonHelp;
    }
}