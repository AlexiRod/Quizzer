using Quizer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Quizer
{
    public partial class FormGame : Form
    {
        private string pathQuestions;
        private string pathThemes;

        private List<Question> allQuestions = new List<Question>();
        private List<Theme> allThemes = new List<Theme>();
        private Random random = new Random();
        private Button[] buttons;
        public FormGame()
        {
            InitializeComponent();
            pathQuestions = Form1.pathQuestions;
            pathThemes = Form1.pathThemes;
            buttons = new Button[] { buttonVariant1, buttonVariant2, buttonVariant3, buttonVariant4};
        }

        // Методы файлов:

        public void ReadAllQuestions()
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(pathQuestions);
                XmlElement element = document.DocumentElement;
                XmlNodeList nodes = element.SelectNodes("question");
                if (nodes == null)
                    return;

                allQuestions.Clear();
                foreach (XmlNode node in nodes)
                {
                    try
                    {
                        string name = node.SelectSingleNode("@name").Value;
                        string text = node.SelectSingleNode("text").InnerText;
                        int time, difficulty;
                        if (!int.TryParse(node.SelectSingleNode("time").InnerText, out time)) { MessageBox.Show("Ошибка конвертации времени"); return; }
                        if (!int.TryParse(node.SelectSingleNode("difficulty").InnerText, out difficulty)) { MessageBox.Show("Ошибка конвертации сложности"); return; }

                        string[] stringVariants = node.SelectSingleNode("variants").InnerText.Split('\n');
                        List<Variant> allVariants = new List<Variant>();
                        foreach (var str in stringVariants)
                        {
                            if (str == string.Empty) continue;
                            string[] parts = str.Split(',');
                            string vText = parts[0];
                            bool vCorrect = parts[1] == "True" ? true : false;
                            int vScore = Convert.ToInt32(parts[2]);

                            Variant variant = new Variant(vText, vCorrect, vScore);
                            allVariants.Add(variant);
                        }
                        Question qq = new Question(name, text, allVariants, time, difficulty);
                        allQuestions.Add(qq);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при работе с файлом! " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с файлом! " + ex.Message);
                return;
            }
        }

        public void ReadAllThemes()
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(pathThemes);
                XmlElement element = document.DocumentElement;
                XmlNodeList nodes = element.SelectNodes("theme");
                if (nodes == null)
                    return;

                allThemes.Clear();
                foreach (XmlNode node in nodes)
                {
                    try
                    {
                        string name = node.SelectSingleNode("@name").Value;

                        string[] stringQuestions = node.SelectSingleNode("questions").InnerText.Split('\n');
                        List<Question> aQuestions = new List<Question>();
                        foreach (var str in stringQuestions)
                        {
                            Question question = new Question();
                            if (str == string.Empty) continue;
                            foreach (var quest in allQuestions)
                            {
                                if (quest.Name == str)
                                {
                                    question = quest;
                                    break;
                                }
                            }
                            aQuestions.Add(question);
                        }
                        Theme theme = new Theme(name, aQuestions);
                        allThemes.Add(theme);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при работе с файлом! " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с файлом! " + ex.Message);
                return;
            }
        }



        private int time = 0;
        private int score = 0;
        private Question question = new Question();

        private void FormGame_Load(object sender, EventArgs e)
        {
            ReadAllQuestions();
            ReadAllThemes();
            foreach (var theme in allThemes)
                cBoxThemes.Items.Add(theme.Name);
            this.BackgroundImage = Resources.back;

            if (cBoxThemes.SelectedItem == null)
                chBoxTheme.Enabled = false;
            else chBoxTheme.Enabled = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = false;
            List<Question> questions = allQuestions;
            string addTheme = "";
            if (chBoxTheme.Checked)
            {
                Theme theme = new Theme();
                foreach (var item in allThemes)
                    if (item.Name == cBoxThemes.SelectedItem.ToString())
                    {
                        theme = item;
                        addTheme = "\n(" + theme.Name + ")";
                        break;
                    }
                questions = theme.Questions;
            }
            int ind = random.Next(0, questions.Count);
            question = questions[ind];

            labelQuestionName.Text = question.Name + addTheme;
            labelQuestionText.Text = question.Text + $" (сложность {question.Difficulty})";
            time = question.Time;

            for (int i = 0; i < 4; i++)
            {
                buttons[i].Enabled = true;
                buttons[i].Text = question.Variants[i].Text;
                buttons[i].BackColor = Color.White;
            }
            timer.Enabled = true;
            labelTime.Text = "Время на ответ: " + time + " c";
            labelScore.Text = "Очки: " + score;
        }

        private void buttonVariant_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                if (button == buttons[i])
                    index = i;
            }

            if (question.Variants[index].isCorrect)
                button.BackColor = Color.Lime;
            else
                button.BackColor = Color.Red;
            
            score += question.Variants[index].Score;
            string sgn = Math.Sign(question.Variants[index].Score) == 1 ? "+" : "";
            labelScore.Text = $"Очки: {score} ({sgn}{question.Variants[index].Score})";
            timer.Enabled = false;
            buttonNext.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                labelTime.Text = "Время на ответ: " + time + " c";
            }
            else
            {
                foreach (var b in buttons)
                {
                    b.Enabled = false;
                    b.BackColor = Color.Red;
                }
                score += Math.Min(question.Variants[0].Score, question.Variants[1].Score);
                labelScore.Text = $"Очки: {score} ({Math.Min(question.Variants[0].Score, question.Variants[1].Score)})";
                timer.Enabled = false;
                buttonNext.Enabled = true;
            }
        }

        private void cBoxThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxThemes.SelectedItem == null)
                chBoxTheme.Enabled = false;
            else chBoxTheme.Enabled = true;
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("При нажатии на кнопку 'Далее' в верхнем правом углу отобразится вопрос с вариантами ответа. У вас будет ограниченное количество времени, чтобы отвтить на него, иначе ответ будет считаться неверным. При правильном ответе вы получаете очки, при неправильном теряете. Если вы хотите отвечать на вопросы из какой-то конкретной категории, установите галочку в соответствующем окне и выберите категорию из выпадающего списка");
        }

        

    }
}
