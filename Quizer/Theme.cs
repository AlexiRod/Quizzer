using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quizer
{
    public class Theme
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public decimal AverageDifficulty { get; set; }

        public Theme(string name, List<Question> questions)
        {
            Name = name;
            Questions = questions;
            List<int> a = new List<int>();
            foreach (var item in questions)
                a.Add(item.Difficulty);
            if(questions.Count != 0)
            AverageDifficulty = (decimal)a.Average();
        }
        
        public Theme()
        {

        }
    }
}
