using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public string name;

        public RankedGradeBook(string name, bool isWeighted) : base(name , isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var studentTotal = Students.Count;

            if (studentTotal < 5)
            {
                throw new InvalidOperationException();
            }

            var goodStudents = 0;
            foreach (var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                {
                    goodStudents++;
                }
            }

            var goodsStudentsPercentage = (float)goodStudents / studentTotal;
            if (goodsStudentsPercentage <= 0.2)
            {
                return 'A';
            }
            if (goodsStudentsPercentage > 0.2 && goodsStudentsPercentage <= 0.4)
            {
                return 'B'; 
            }
            if (goodsStudentsPercentage > 0.6 && goodsStudentsPercentage <= 0.8)
            {
                return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics() // override CalculateStatistics i CalculateStudentStatistics
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {   
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
