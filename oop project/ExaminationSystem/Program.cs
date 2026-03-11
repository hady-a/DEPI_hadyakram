using System;
using System.Collections.Generic;
using System.Linq;

namespace ExaminationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            
            try
            {
                ShowWelcome();
                RunExaminationSystem();
            }
            catch (Exception ex)
            {
                ShowError($"Application Error: {ex.Message}");
            }
            
            Console.ReadKey();
        }

        static void RunExaminationSystem()
        {
            Subject subject = new Subject(101, "C# Programming");
            
            // Create Exam
            subject.CreateExam();

            ShowSection("EXAM CREATED");
            Console.WriteLine($"✓ Exam for {subject.SubjectName} created successfully\n");
            
            if (subject.SubjectExam.Questions.Length > 0)
            {
                Console.WriteLine("Questions Preview:");
                for (int i = 0; i < subject.SubjectExam.Questions.Length; i++)
                {
                    Console.WriteLine($"  {i + 1}. {subject.SubjectExam.Questions[i].Body}");
                    Console.WriteLine($"     Marks: {subject.SubjectExam.Questions[i].Mark}\n");
                }
            }

            PressKeyToContinue("Press any key to start the exam...");

            // Run exam and display results
            subject.SubjectExam.ShowExam();

            ShowSection("EXAM COMPLETED");
            PressKeyToContinue("Press any key to return to home...");
        }

        static void ShowWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('═', 70));
            Console.WriteLine("             EXAMINATION SYSTEM - INTERACTIVE GUI");
            Console.WriteLine(new string('═', 70));
            Console.ResetColor();

            Console.WriteLine("\n  Welcome to the Examination System!\n");
            Console.Write("  This application allows you to:\n");
            Console.WriteLine("    • Create custom exams with questions");
            Console.WriteLine("    • Take exams with instant feedback");
            Console.WriteLine("    • View detailed results and scores");
            Console.WriteLine("    • Practice multiple question types\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  Supported Question Types:");
            Console.ResetColor();
            Console.WriteLine("    ✓ Multiple Choice (MCQ)");
            Console.WriteLine("    ✓ True/False\n");

            PressKeyToContinue("Press any key to continue...");
        }

        static void ShowSection(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('═', 70));
            Console.WriteLine($"  {title}");
            Console.WriteLine(new string('═', 70));
            Console.ResetColor();
            Console.WriteLine();
        }

        static void ShowError(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('═', 70));
            Console.WriteLine("  ERROR");
            Console.WriteLine(new string('═', 70));
            Console.ResetColor();
            Console.WriteLine($"\n  {message}\n");
        }

        static void PressKeyToContinue(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}


