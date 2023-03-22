using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            double percentage = 0;
            int studentsCounter = Students.Count;
            if (studentsCounter < 5)
                throw new InvalidOperationException();

            double[] averageGrades = new double[studentsCounter];

            for (int i = 0; i < studentsCounter; i++)
            {
                for (int j = 0; j < Students[i].Grades.Count; j++)
                {
                    averageGrades[i] += Students[i].Grades[j];
                }
                averageGrades[i] /= Students[i].Grades.Count;
            }

            Array.Sort(averageGrades);

            for (int i = 0; i < averageGrades.Length; i++)
            {
                if (averageGrade > averageGrades[i])
                {
                    percentage = (i + 1) / (double)averageGrades.Length;
                }

            }

            if (percentage >= 0.8) 
            {
                return 'A';
            }
            else if (percentage >= 0.6)
            {
                return 'B';
            }
            else if (percentage >= 0.4)
            {
                return 'C';
            }
            else if (percentage >= 0.2)
            {
                return 'D';
            }
            else return 'F';

        }


    }


}
