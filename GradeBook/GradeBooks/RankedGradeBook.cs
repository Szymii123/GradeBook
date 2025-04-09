using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            int threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var sortedGrades = Students
                .OrderByDescending(s => s.AverageGrade)
                .Select(s => s.AverageGrade)
                .ToList();

            if (averageGrade >= sortedGrades[threshold - 1])
                return 'A';
            else if (averageGrade >= sortedGrades[(threshold * 2) - 1])
                return 'B';
            else if (averageGrade >= sortedGrades[(threshold * 3) - 1])
                return 'C';
            else if (averageGrade >= sortedGrades[(threshold * 4) - 1])
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
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
