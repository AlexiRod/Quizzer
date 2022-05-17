using Quizer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizer
{
    public partial class Form1 : Form
    {
        public static string pathQuestions = "-";
        public static string pathThemes = "-";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit();
            formEdit.ShowDialog();
        }

        private void buttonTheme_Click(object sender, EventArgs e)
        {
            FormTheme formTheme = new FormTheme();
            formTheme.ShowDialog();
        }

        private void buttonGame_Click(object sender, EventArgs e)
        {
            FormGame formGame = new FormGame();
            formGame.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackgroundImage = Resources.back2;
            try
            {
                if (pathQuestions == "-" || pathThemes == "-" || !File.Exists(pathQuestions) || !File.Exists(pathThemes))
                {
                    MessageBox.Show("Проверьте, все ли переменные в файле Form1.cs с путями к файлам заполнены корректно. Переменная pathQuestions должна хранить в себе путь к существующему xml файлу с вопросами, а переменная pathThemes к существующему xml файлу с категориями вопросов. Путь должен быть в формате путь_к_файлу/questions.xml, например, С:/Quizzer/Xml/questions.xml");
                    buttonGame.Enabled = false;
                    buttonQuestion.Enabled = false;
                    buttonTheme.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте, все ли переменные в файле Form1.cs с путями к файлам заполнены корректно. Переменная pathQuestions должна хранить в себе путь к существующему xml файлу с вопросами, а переменная pathThemes к существующему xml файлу с категориями вопросов. Путь должен быть в формате путь_к_файлу/questions.xml, например, С:/Quizzer/Xml/questions.xml. Возникла ошибка: " + ex.Message);
                buttonGame.Enabled = false;
                buttonQuestion.Enabled = false;
                buttonTheme.Enabled = false;
            }
            
        }
    }
}
