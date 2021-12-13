using System;

namespace Pets{
    class Pet {
    private string type;
    private string name;
    private string owner;
    private double weight;

    public Pet(string type, string name, string owner, double weight){
        this.type = type;
        this.name = name;
        this.owner = owner;
        this.weight = weight;
    }
    public string getTag(){
    return "If lost, call " + this.owner;
    }
    public string getName(){
        return name;
    }
    public string getType(){
        return type;
    }
    public string getOwner(){
        return owner;
    }
    public double getWeight(){
        return weight;
    }
    public void setOwner(string newOwner){
        this.owner = newOwner;
    }
    public void setWeight(double newWeight){
        this.weight = newWeight;
    }

    }
}