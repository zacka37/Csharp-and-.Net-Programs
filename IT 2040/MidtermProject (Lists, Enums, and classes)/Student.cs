using System;

namespace MidtermProject{
    class Student : Person{
        string major;
        int creditHours;
        StudentClass studentClass;
        public Student(string firstName, string lastName, string id, string major, int creditHours) : base (firstName, lastName, id, Category.student){
            this.major = major;
            this.creditHours = creditHours;
        }
        public int updateCreditHours(int hours){
            creditHours = creditHours + hours;
            return  creditHours;
        }
        public StudentClass getStudentClass(){
            if (creditHours <= 29){
                studentClass = StudentClass.freshman;
                return studentClass;
            }
            if (creditHours >=30 && creditHours <= 59){
                studentClass = StudentClass.sophomore;
                return studentClass;
            }
            if (creditHours >=60 && creditHours <= 89){
                studentClass = StudentClass.junior;
                return studentClass;
            }
            if (creditHours >=90){
                studentClass = StudentClass.senior;
                return studentClass;
            }
            return studentClass;
        }
        public int getCreditHours(){
            return creditHours;
        }
    }
}