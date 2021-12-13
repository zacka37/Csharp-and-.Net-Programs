using System;

namespace Pets{
class Dog : Pet{

    public Dog(string name, string owner, double weight) : base ("dog", name, owner, weight) {

    }
    public string bark(int count){
        string barkString = "";
        for(int i = 0; count > i; i++){ 
            barkString =barkString+ "Bark!" ;
            
        }
        return barkString;
    }
}
        
   

    
}