using System;

namespace MidtermProject{
    class Professor : Person{
        string department;
        string researchArea;
        public Professor(string firstName, string lastName, string id, string department, string researchArea) : base (firstName, lastName, id, Category.faculty){
            this.department = department;
            this.researchArea = researchArea;
        }
        public string getDepartment(){
            return this.department;
        }
        public string setDepartment(string newdepartment){
            department = newdepartment;
            return this.department;
        }
        public string getResearchArea(){
            return this.researchArea;
        }
        public string setResearchArea(string newResearchArea){
            researchArea = newResearchArea;
            return this.researchArea;
        }
        
    }
}