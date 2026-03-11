using System;

namespace ExaminationSystem
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam()
        {
            Console.Clear();
            Console.WriteLine($"--- Creating Exam for {SubjectName} ---");
            Console.WriteLine("1. Final Exam");
            Console.WriteLine("2. Practical Exam");
            Console.Write("Choose Exam Type (1 or 2): ");
            
            int examType;
            while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2))
            {
                Console.Write("Invalid input. Please choose 1 or 2: ");
            }

            Console.Write("Enter the exam time in minutes: ");
            int minutes;
            while (!int.TryParse(Console.ReadLine(), out minutes) || minutes <= 0)
            {
                Console.Write("Invalid input. Please enter valid minutes: ");
            }

            Console.Write("Enter the number of questions: ");
            int numQuestions;
            while (!int.TryParse(Console.ReadLine(), out numQuestions) || numQuestions <= 0)
            {
                Console.Write("Invalid input. Please enter a valid number of questions: ");
            }

            if (examType == 1)
            {
                SubjectExam = new FinalExam(TimeSpan.FromMinutes(minutes), numQuestions);
                CreateQuestionsForFinalExam();
            }
            else
            {
                SubjectExam = new PracticalExam(TimeSpan.FromMinutes(minutes), numQuestions);
                CreateQuestionsForPracticalExam();
            }
        }

        private void CreateQuestionsForFinalExam()
        {
            for (int i = 0; i < SubjectExam.NumberOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine($"--- Q{i + 1} Configuration ---");
                Console.WriteLine("1. True/False Question");
                Console.WriteLine("2. MCQ Question");
                Console.Write("Choose Question Type (1 or 2): ");
                
                int qType;
                while (!int.TryParse(Console.ReadLine(), out qType) || (qType != 1 && qType != 2))
                {
                    Console.Write("Invalid input. Please choose 1 or 2: ");
                }

                if (qType == 1)
                {
                    SubjectExam.Questions[i] = CreateAndReturnTFQuestion();
                }
                else
                {
                    SubjectExam.Questions[i] = CreateAndReturnMCQQuestion();
                }
            }
        }

        private void CreateQuestionsForPracticalExam()
        {
            Console.Clear();
            Console.WriteLine("Please note that Practical Exams can only contain MCQ questions.");
            for (int i = 0; i < SubjectExam.NumberOfQuestions; i++)
            {
                Console.WriteLine($"--- Q{i + 1} Configuration ---");
                SubjectExam.Questions[i] = CreateAndReturnMCQQuestion();
            }
        }

        private TrueFalseQuestion CreateAndReturnTFQuestion()
        {
            Console.WriteLine("\n[True/False Question Setup]");
            Console.Write("Enter Question Body: ");
            string body = Console.ReadLine();

            Console.Write("Enter Mark: ");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.Write("Invalid input. Please enter a valid mark: ");
            }

            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
            Console.Write("Choose Correct Answer (1 for True, 2 for False): ");
            int rightId;
            while (!int.TryParse(Console.ReadLine(), out rightId) || (rightId != 1 && rightId != 2))
            {
                Console.Write("Invalid input. Please enter 1 or 2: ");
            }

            Answer rightAnswer = new Answer(rightId, rightId == 1 ? "True" : "False");

            return new TrueFalseQuestion("True/False Question", body, mark, rightAnswer);
        }

        private MCQQuestion CreateAndReturnMCQQuestion()
        {
            Console.WriteLine("\n[MCQ Question Setup]");
            Console.Write("Enter Question Body: ");
            string body = Console.ReadLine();

            Console.Write("Enter Mark: ");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0)
            {
                Console.Write("Invalid input. Please enter a valid mark: ");
            }

            Console.Write("Enter number of choices (e.g. 3 or 4): ");
            int choicesCount;
            while (!int.TryParse(Console.ReadLine(), out choicesCount) || choicesCount < 2)
            {
                Console.Write("Invalid input. Please enter a number greater than 1: ");
            }

            Answer[] choices = new Answer[choicesCount];
            for (int j = 0; j < choicesCount; j++)
            {
                Console.Write($"Enter choice {j + 1} text: ");
                choices[j] = new Answer(j + 1, Console.ReadLine());
            }

            Console.Write($"Enter the correct choice ID (1 to {choicesCount}): ");
            int rightId;
            while (!int.TryParse(Console.ReadLine(), out rightId) || rightId < 1 || rightId > choicesCount)
            {
                Console.Write($"Invalid input. Please enter an ID between 1 and {choicesCount}: ");
            }

            Answer rightAnswer = choices[rightId - 1];

            return new MCQQuestion("Multiple Choice Question", body, mark, choices, rightAnswer);
        }
    }
}
