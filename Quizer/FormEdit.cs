using Quizer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Quizer
{
    public partial class FormEdit : Form
    {

        private string pathQuestions;
        private string pathThemes;

        private Question question;
        private List<Question> allQuestions = new List<Question>();

        private TextBox[] textBoxes;
        private RadioButton[] radioButtons;
        public FormEdit()
        {
            InitializeComponent();
            textBoxes = new TextBox[] { variant1, variant2, variant3, variant4 };
            radioButtons = new RadioButton[] { radioButton1, radioButton2, radioButton3, radioButton4 };
            pathQuestions = Form1.pathQuestions;
            pathThemes = Form1.pathThemes;
        }

        // Методы файлов:

        public void AddQuestion(Question question)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(pathQuestions);
                XmlElement mainElement = document.DocumentElement;
                XmlElement newElement = document.CreateElement("question");
                XmlAttribute name = document.CreateAttribute("name");
                name.AppendChild(document.CreateTextNode(question.Name));

                XmlElement text = document.CreateElement("text");
                text.AppendChild(document.CreateTextNode(question.Text));
                XmlElement time = document.CreateElement("time");
                time.AppendChild(document.CreateTextNode(question.Time.ToString()));
                XmlElement difficulty = document.CreateElement("difficulty");
                difficulty.AppendChild(document.CreateTextNode(question.Difficulty.ToString()));

                XmlElement vars = document.CreateElement("variants");
                string v = "";
                foreach (var q in question.Variants)
                    v += $"{q.Text},{q.isCorrect},{q.Score}\n";
                vars.AppendChild(document.CreateTextNode(v));

                newElement.Attributes.Append(name);
                newElement.AppendChild(text);
                newElement.AppendChild(time);
                newElement.AppendChild(difficulty);
                newElement.AppendChild(vars);

                mainElement.AppendChild(newElement);
                document.Save(pathQuestions);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с файлом! " + ex.Message);
                return;
            }
        }

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
                if (cBoxName.Items != null)
                    cBoxName.Items.Clear();
                if (allQuestions != null)
                    foreach (var item in allQuestions)
                        cBoxName.Items.Add(item.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с файлом! " + ex.Message);
                return;
            }
        }


        public bool RemoveQuestion(string name)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(pathQuestions);
                XmlElement element = document.DocumentElement;

                XmlNode node = element.SelectSingleNode($"question[@name='{name}']");
                if (node != null)
                {
                    element.RemoveChild(node);
                    document.Save(pathQuestions);
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с файлом! " + ex.Message);
                return false;
            }
            
        }




        // Методы формы:

        private void FormEdit_Load(object sender, EventArgs e)
        {
            cBoxDifficulty.SelectedItem = "1";
            buttonAdd.BackgroundImage = Resources.plus;
            buttonSave.BackgroundImage = Resources.save;
            buttonDelete.BackgroundImage = Resources.delete;
            ReadAllQuestions();
            UpdateQuestion(0);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (tBoxAddName.Text == string.Empty)
            {
                MessageBox.Show("Введите название вопроса.");
                return;
            }
            if (tBoxAddName.Enabled && allQuestions != null)
            {
                bool isInList = false;
                foreach (var item in allQuestions)
                {
                    if(item.Name == tBoxAddName.Text)
                    { 
                        isInList = true;
                        break;
                    }
                }
                if (isInList)
                {
                    MessageBox.Show("Вопрос с таким названием уже существует.");
                    return;
                }
                else cBoxName.Text = tBoxAddName.Text;
            }
            if (tBoxText.Text == string.Empty)
            {
                MessageBox.Show("Введите текст вопроса.");
                return;
            }
            if (variant1.Text == string.Empty || variant2.Text == string.Empty || variant3.Text == string.Empty || variant4.Text == string.Empty)
            {
                MessageBox.Show("Введите 4 варианта ответа.");
                return;
            }
            if (!int.TryParse(tBoxScore.Text, out int points) || points <= 0)
            {
                MessageBox.Show("Количество очков должно быть целым положительным числом.");
                return;
            }
            if (!int.TryParse(tBoxPenalty.Text, out int penPoint) || penPoint <= 0)
            {
                MessageBox.Show("Штраф должен быть целым положительным числом.");
                return;
            }
            if (!int.TryParse(tBoxTime.Text, out int times) || times <= 0)
            {
                MessageBox.Show("Количество секунд должно быть целым положительным числом.");
                return;
            }

            List<Variant> vars = new List<Variant>();
            for (int i = 0; i < 4; i++)
            {
                int add;
                if (radioButtons[i].Checked)
                    add = points;
                else add = -penPoint;
                Variant variant = new Variant(textBoxes[i].Text, radioButtons[i].Checked, add);
                vars.Add(variant);
            }
            string varName = cBoxName.Text;
            if (tBoxAddName.Enabled)
            { 
                varName = tBoxAddName.Text;
                cBoxName.SelectedItem = varName;
            }
            question = new Question(varName, tBoxText.Text, vars, times, Convert.ToInt32(cBoxDifficulty.SelectedItem));
            if (RemoveQuestion(question.Name))
                MessageBox.Show($"Вопрос '{question.Name}' обновлен.");
            else MessageBox.Show($"Вопрос '{question.Name}' добавлен.");
            AddQuestion(question);
            cBoxName.Enabled = true;
            cBoxName.Visible = true;
            tBoxAddName.Visible = false;
            tBoxAddName.Enabled = false;
            tBoxAddName.Text = "-";
            ReadAllQuestions();
            cBoxName.SelectedItem = question.Name;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (RemoveQuestion(question.Name))
            { 
                MessageBox.Show($"Вопрос '{question.Name}' удален.");
                tBoxText.Text = "";
                variant1.Text = "";
                variant2.Text = "";
                variant3.Text = "";
                variant4.Text = "";
                radioButton1.Checked = true;
                tBoxScore.Text = "0";
                tBoxPenalty.Text = "0";
                tBoxTime.Text = "0";
                cBoxDifficulty.SelectedItem = "1";
                ReadAllQuestions();
                UpdateQuestion(0);
                if (allQuestions.Count == 0)
                    buttonSave.Enabled = false;
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            cBoxName.Enabled = false;
            cBoxName.Visible = false;
            tBoxAddName.Visible = true;
            tBoxAddName.Enabled = true;
            buttonSave.Enabled = true;

            tBoxText.Text = "";
            variant1.Text = "";
            variant2.Text = "";
            variant3.Text = "";
            variant4.Text = "";
            radioButton1.Checked = true;
            tBoxScore.Text = "0";
            tBoxPenalty.Text = "0";
            tBoxTime.Text = "0";
            cBoxDifficulty.SelectedItem = "1";
        }
        public void UpdateQuestion(int j)
        {
            if (allQuestions.Count == 0)
            {
                buttonSave.Enabled = false;
                return;
            }
            question = allQuestions[j];
            cBoxName.SelectedItem = question.Name;
            tBoxText.Text = question.Text;
            tBoxTime.Text = question.Time.ToString();
            cBoxDifficulty.SelectedItem = question.Difficulty.ToString();


            for (int i = 0; i < question.Variants.Count; i++)
            {
                bool isCorrect = question.Variants[i].isCorrect;
                textBoxes[i].Text = question.Variants[i].Text;
                radioButtons[i].Checked = isCorrect;
                if (isCorrect)
                    tBoxScore.Text = question.Variants[i].Score.ToString();
                else tBoxPenalty.Text = Math.Abs(question.Variants[i].Score).ToString();
            }
        }

        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuestion(cBoxName.SelectedIndex);
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для того, чтобы изменить существующий вопрос, выберите его из выпадающего списка. В соответствующие поля нужно будет ввести текст вопроса, варианты, выбрать среди них верный, указать количество очков за правильный и неправильный ответ, время на вопрос и его сложность. Если все данные корректны, то при нажатии на кнопку 'Сохранить' существующий вопрос обновится. Для того, чтобы добавить новый вопрос, нажмите на кнопку с изображением плюса. Введите необходимые данные, а также название вопроса и нажмите на кнопку сохранения. Если все верно, в общий список добавится новый вопрос. Чтобы удалить вопрос, выберите его название в выпадающем списке и нажмите на кнопку с изображением корзины.");
        }
    }
}
