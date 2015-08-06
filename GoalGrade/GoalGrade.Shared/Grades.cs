using System;
using System.Collections.Generic;
using System.Text;

namespace GoalGrade
{
    public class Grades
    {
        public double currentGrade { get; set; }
        public double examWeight { get; set; }
        public double desiredGrade { get; set; }
        public double goalGrade { get; set; }

        public Grades()
        {
            currentGrade = 0;
            examWeight = 0;
            desiredGrade = 0;
            goalGrade = 0;
        }

        public void calculateGoalGrade()
        {
            var gradeWithoutExam = (1 - examWeight) * currentGrade;
            var neededForGoal = desiredGrade - gradeWithoutExam;
            goalGrade = neededForGoal / examWeight;
        }
    }
}
