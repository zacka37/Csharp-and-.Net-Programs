using System;

namespace MidtermProject{
class Person{
    private string firstName;
    private string lastName;
    private string id;
    private Category category;

    public Person(string firstName, string lastName, string id, Category category){
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = id;
        this.category = category;
    }
    public void getPersonInfo(){
        Console.WriteLine($"Name: {this.firstName}");
        Console.WriteLine($"ID: {this.id} ; Type: {this.category}"); 
    }
    public string getFirstName(){
        return this.firstName;
    }
    public string setFirstName(string newFirstName){
        return this.firstName = newFirstName;
    }
    public string getLastName(){
        return this.lastName;
    }
    public string setLastName(string newLastName){
        return this.lastName = newLastName;
    }
    public Category getCategory(){
        return this.category;
    }
    public Category setCategory(Category newCategory){
        return this.category = newCategory;
    }
    public string getID(){
        return this.id;
    }
}
}