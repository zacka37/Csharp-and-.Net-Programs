using System;

namespace Pets{
class Cat : Pet{
    public Cat(string name, string owner, double weight) : base ("cat", name, owner, weight){

    }
    public string meow(int count){
        string meowString = "";
        for(int i = 0;count>i;i++){
            
            meowString = meowString+ "meow.";
        }
        return meowString;
}
}
}