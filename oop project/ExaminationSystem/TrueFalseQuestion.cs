using System;

namespace ExaminationSystem
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark, Answer rightAnswer)
            : base(header, body, mark)
        {
            AnswerList = new Answer[]
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };
            RightAnswer = rightAnswer;
        }

        public override string ToString()
        {
            string answers = "";
            for (int i = 0; i < AnswerList.Length; i++)
            {
                answers += $"{AnswerList[i]}\t";
            }
            return $"{base.ToString()}\n{answers}";
        }
    }
}
