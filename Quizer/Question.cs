using System;
using System.Collections.Generic;
using System.Text;

namespace Quizer
{
    public class Question
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Time { get; set; }
        public int Difficulty { get; set; }
        public List<Variant> Variants { get; set; }

        public Question(string name, string text, List<Variant> variants, int time, int difficulty)
        {
            Name = name;
            Text = text;
            Variants = variants;
            Time = time;
            Difficulty = difficulty;
        }

        public Question()
        {

        }
    }
}
