using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var iJump = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[iJump - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[(iJump * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(iJump * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(iJump * 4) - 1] <= averageGrade)
            {
                return 'D';
            }

            return 'F';
        }
    }
}