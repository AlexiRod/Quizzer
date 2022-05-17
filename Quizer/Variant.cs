using System;
using System.Collections.Generic;
using System.Text;

namespace Quizer
{
    public class Variant
    {
        public string Text { get; set; }
        public bool isCorrect { get; set; }
        public int Score { get; set; }

        public Variant(string text, bool correct, int score)
        {
            Text = text;
            isCorrect = correct;
            Score = score;
        }
    }
}
