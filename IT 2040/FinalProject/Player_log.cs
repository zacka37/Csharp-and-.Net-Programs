using System;
namespace FinalProject{
    public class Player_Log{
        public string Name;
        public float Wins;
        public float Losses;
        public int Ties;
        

        public Player_Log(string Name, int Wins, int Losses, int Ties){
            this.Name = Name;
            this.Wins = Wins;
            this.Losses = Losses;
            this.Ties = Ties;
        }
        public string getName(){
            return this.Name;
        }
        public float getWins(){
            return this.Wins;
        }
        public float roundNumber(){
            return Wins + Losses + Ties + 1;
        }
        public float numberOfGamesPlayed(){
            return this.Wins + this.Losses + this.Ties;
        }
        public float allPlayerWinLosseRatio(){
            return Wins / Losses;
        }
        public float getLosses(){
            return this.Losses;
        }
        public int getTies(){
            return this.Ties;
        }
    }
}