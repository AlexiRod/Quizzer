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
    public partial class FormTheme : Form
    {

        private string pathQuestions;
        private string pathThemes;

        private List<Question> allQuestions = new List<Question>();
        private List<Theme> allThemes = new List<Theme>();

        public FormTheme()
        {
            InitializeComponent();
            pathQuestions = Form1.pathQuestions;
            pathThemes = Form1.pathThemes;
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
                if (listQuestions.Items != null)
                    listQuestions.Items.Clear();
                if (allQuestions != null)
                    foreach (var item in allQuestions)
                        listQuestions.Items.Add(item.Name);
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

                if (cBoxThemes.Items != null)
                    cBoxThemes.Items.Clear();
                if (allThemes != null)
                    foreach (var item in allThemes)
                        cBoxThemes.Items.Add(item.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с файлом! " + ex.Message);
                return;
            }
        }



        public void AddTheme(Theme theme)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(pathThemes);
                XmlElement mainElement = document.DocumentElement;
                XmlElement newElement = document.CreateElement("theme");
                XmlAttribute name = document.CreateAttribute("name");
                name.AppendChild(document.CreateTextNode(theme.Name));

               
                XmlElement questions = document.CreateElement("questions");
                string q = "";
                foreach (var quest in theme.Questions)
                    q += $"{quest.Name}\n";
                questions.AppendChild(document.CreateTextNode(q));

                newElement.Attributes.Append(name);
                newElement.AppendChild(questions);

                mainElement.AppendChild(newElement);
                document.Save(pathThemes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с файлом! " + ex.Message);
                return;
            }
        }

        public bool RemoveTheme(string name)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(pathThemes);
                XmlElement element = document.DocumentElement;

                XmlNode node = element.SelectSingleNode($"theme[@name='{name}']");
                if (node != null)
                {
                    element.RemoveChild(node);
                    document.Save(pathThemes);
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
        private void FormTheme_Load(object sender, EventArgs e)
        {
            ReadAllQuestions();
            ReadAllThemes();
            UpdateTheme(0);
            buttonAdd.BackgroundImage = Resources.save;
            buttonDelete.BackgroundImage = Resources.delete;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (tBoxNameTheme.Text == string.Empty)
            {
                MessageBox.Show("Введите название категории.");
                return;
            }
            
            if(listQuestions.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один вопрос для данной категории.");
                return;
            }

            List<Question> addQuestions = new List<Question>();
            foreach (var item in listQuestions.CheckedItems)
            {
                Question question = new Question();
                foreach (var quest in allQuestions)
                {
                    if (quest.Name == item.ToString())
                    {
                        question = quest;
                        break;
                    } 
                }
                addQuestions.Add(question);
            }
            Theme theme = new Theme(tBoxNameTheme.Text, addQuestions);
            if (RemoveTheme(theme.Name))
                MessageBox.Show($"Категория '{theme.Name}' обновлена.");
            else MessageBox.Show($"Категория '{theme.Name}' добавлена.");

            AddTheme(theme);
            ReadAllThemes();
            cBoxThemes.SelectedItem = theme.Name;
            tBoxNameTheme.Text = theme.Name;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (tBoxNameTheme.Text == string.Empty)
            {
                MessageBox.Show("Введите название категории для удаления в окно слева.");
                return;
            }
            if (RemoveTheme(tBoxNameTheme.Text))
            {
                MessageBox.Show($"Категория '{tBoxNameTheme.Text}' удалена.");
                tBoxNameTheme.Text = "";
                
                ReadAllThemes();
                UpdateTheme(0);
                //UpdateQuestion(0);
                //if (allQuestions.Count == 0)
                //    buttonSave.Enabled = false;
            }
            ReadAllThemes();
            UpdateTheme(0);
        }

        private void cBoxThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTheme(cBoxThemes.SelectedIndex);
        }
        private void tBoxNameTheme_TextChanged(object sender, EventArgs e)
        {

        }
        public void UpdateTheme(int j)
        {
            if (allThemes.Count == 0)
            {
                //cBoxThemes.SelectedItem = "New Theme";
                for (int i = 0; i < listQuestions.Items.Count; i++)
                    listQuestions.SetItemChecked(i, false);
                
                return;
            }
            Theme theme = allThemes[j];
            cBoxThemes.SelectedItem = theme.Name;
            tBoxNameTheme.Text = theme.Name;

            for (int i = 0; i < listQuestions.Items.Count; i++)
            {
                listQuestions.SetItemChecked(i, false);
                foreach (var question in theme.Questions)
                {
                    if (listQuestions.Items[i].ToString() == question.Name)
                    {
                        listQuestions.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для того, чтобы изменить существующую категорию вопросов, выберите ее в выпадающем списке посередине. В окне со списком вопросов отметьте галочкой те, которые должны входить в выбранную категорию. После этого нажмите кнопку сохранения. Если вы не изменяли имя категории в окне 'Название категории' снизу, то выбранная категория обновится. Если же вы изменили ее название, создастся новая категория с указанным названием и списком вопросов. Для того, чтобы удалить категорию, выберите ее название из выпадающего списка и нажмите на кнопку с изображением корзины.");
        }
    }
}
