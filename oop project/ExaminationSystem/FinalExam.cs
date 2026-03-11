using System;

namespace ExaminationSystem
{
    public class FinalExam : Exam
    {
        public FinalExam(TimeSpan timeOfExam, int numberOfQuestions)
            : base(timeOfExam, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            int totalGrade = 0;
            int earnedGrade = 0;
            Answer[] studentAnswers = new Answer[Questions.Length];

            Console.WriteLine($"--- Final Exam ---");
            Console.WriteLine($"Time: {TimeOfExam.TotalMinutes} Minutes, Questions: {NumberOfQuestions}\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"Q{i + 1}: {q.ToString()}");
                Console.Write("Enter the number of your answer: ");

                int answerId;
                while (!int.TryParse(Console.ReadLine(), out answerId) || !Array.Exists(q.AnswerList, a => a != null && a.AnswerId == answerId))
                {
                    Console.Write("Invalid input. Please enter a valid answer number: ");
                }

                studentAnswers[i] = Array.Find(q.AnswerList, a => a.AnswerId == answerId);
                Console.WriteLine("------------------------------------------");
            }

            Console.Clear();
            Console.WriteLine("=== EXAM RESULTS ===");

            for (int i = 0; i < Questions.Length; i++)
            {
                var q = Questions[i];
                Console.WriteLine($"Q{i + 1}: {q.Body}");
                Console.WriteLine($"Your Answer: {studentAnswers[i].AnswerText}");
                Console.WriteLine($"Correct Answer: {q.RightAnswer.AnswerText}");

                totalGrade += q.Mark;
                if (studentAnswers[i].AnswerId == q.RightAnswer.AnswerId)
                {
                    earnedGrade += q.Mark;
                }
                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine($"\nYour Final Grade: {earnedGrade} / {totalGrade}");
        }
    }
}
