using System;

namespace ExaminationSystem
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answerList, Answer rightAnswer) 
            : base(header, body, mark)
        {
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }

        public override string ToString()
        {
            string answers = "";
            for (int i = 0; i < AnswerList.Length; i++)
            {
                answers += $"{AnswerList[i]}\n";
            }
            return $"{base.ToString()}\n{answers}";
        }
    }
}
