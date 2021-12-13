using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject
{
    class Program
    {
        public static string Menu(){
            string userChoice;
                
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.WriteLine("\t1. Start New Game");
            Console.WriteLine("\t2. Load Game");
            Console.WriteLine("\t3. Quit");
            while(true){
                
                Console.WriteLine("\nEnter Choice: ");

                userChoice = Console.ReadLine();
                if (userChoice != "1" && userChoice != "2" && userChoice != "3")
                {
                    Console.WriteLine("Invalid choice, select option 1,2 or 3.");
                    continue;
                }
                else
                {
                    break;
                }
            }

            return userChoice;
            }
        public static void Game(Player_Log player)
        {        
            string Game_Choice;
            Console.WriteLine($"Round {player.roundNumber()}");
            Console.WriteLine("\t1. Rock");
            Console.WriteLine("\t2. Paper");
            Console.WriteLine("\t3. Scissors");
                
            while(true)
            {
                Console.WriteLine("\nWhat will it be?");
                Game_Choice = Console.ReadLine();
                if (Game_Choice != "1" && Game_Choice != "2" & Game_Choice != "3")
                {
                    Console.WriteLine("Pick an option that is listed above (1, 2 or 3)");
                    continue;
                }
                else
                {
                    break;
                }
            }
                
            Random random = new Random();
            int Random_Number = random.Next(1, 4);        
            if(Game_Choice == "1" && Random_Number == 1){
                Console.WriteLine("You chose rock. The computer chose rock. You tied!");
                player.Ties++;
            }else if (Game_Choice == "2" && Random_Number == 2){
                Console.WriteLine("You chose paper. The computer chose paper. You tied!");
                player.Ties++;
            }else if (Game_Choice == "3" && Random_Number == 3){
                Console.WriteLine("You chose scissors. The computer chose scissors. You tied!");
                player.Ties++;
            }else if (Game_Choice == "1" && Random_Number == 2){
                Console.WriteLine("You chose rock. The computer chose paper. You lose!");
                player.Losses++;
            }else if (Game_Choice == "1" && Random_Number == 3){
                Console.WriteLine("You chose rock. The computer chose scissors. You win!");
                player.Wins++;
            }else if (Game_Choice == "2" && Random_Number == 1){
                Console.WriteLine("You chose paper. The computer chose rock. You win!");
                player.Wins++;
            }else if (Game_Choice == "2" && Random_Number == 3){
                Console.WriteLine("You chose paper. The computer chose scissors. You lose!");
                player.Losses++;
            }else if (Game_Choice == "3" && Random_Number == 1){
                Console.WriteLine("You chose scissors. The computer chose rock. You lose!");
                player.Losses++;
            }else if (Game_Choice == "3" && Random_Number == 2){
                Console.WriteLine("You chose scissors. The computer chose paper. You win!");
                player.Wins++;
            }
        }
        public static string Menu_After_Play(){
            string afterGameChoice;
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("\t1. Play Again");
            Console.WriteLine("\t2. View Player Statistics");
            Console.WriteLine("\t3. View Leaderboard");
            Console.WriteLine("\t4. Quit");
            Console.WriteLine("Enter choice:");
                
            while(true)
            {
                afterGameChoice = Console.ReadLine();
                if (afterGameChoice != "1" && afterGameChoice != "2" && afterGameChoice != "3" && afterGameChoice != "4")
                {
                    Console.WriteLine("Enter a number corresponding to the options above (1, 2, 3 or 4).");
                    continue;
                }
                else
                {
                    break;
                }
            }
            return afterGameChoice;
        }
        public static void ViewLeaderBoard(List<Player_Log> playerList)
        {
            Console.WriteLine("\nTop 10 Winning Players");
            var top10Wins = (from Player_Log in playerList orderby Player_Log.Wins descending select Player_Log);
            int counter = 0;            
            foreach(var player in top10Wins)
            {
                counter++;
                Console.WriteLine($"{player.Name}: {player.Wins}");
                if(counter == 10)
                {
                    break;
                }
            }
            Console.WriteLine("\nMost Games Played:");
            var top5GamesPlayed = (from Player_Log in playerList orderby Player_Log.numberOfGamesPlayed() descending select Player_Log).Take(5);
            foreach(var player in top5GamesPlayed)
            {
                Console.WriteLine($"{player.Name}:{player.numberOfGamesPlayed()}");
            }
            float totalWins = 0;
            float totalLosses = 0;
            foreach(var player in playerList)
            {
                totalWins += player.Wins;
                totalLosses += player.Losses;
            }
            float totalWinLosseRatio = totalWins/totalLosses;
            float decimalTotalWinLossRatio = (float)Math.Round(totalWinLosseRatio * 100f) / 100f;
            Console.WriteLine($"\nWin/Loss Ratio: {decimalTotalWinLossRatio}");  
            float totalNumberOfGamesPlayed = 0;
            foreach (var player in playerList)
            {
                
                totalNumberOfGamesPlayed += player.numberOfGamesPlayed();
                
            }
            Console.WriteLine($"\nTotal Games Played {totalNumberOfGamesPlayed}");
        }
        public static void Saving(List<Player_Log> playerList, string userName)
        {
            using(var writer = new StreamWriter("player_log.csv")){
            foreach(var player in playerList)
            {
                
                try
                {       
                     writer.WriteLine($"{player.Name},{player.Wins},{player.Losses},{player.Ties}");
                }
                catch(Exception)
                {
                    Console.WriteLine($"{userName}, the game could not be saved.");
                }
            }
        }
        }
        public static void playerStat(Player_Log player, string userName)
        {
            Console.WriteLine($"\n{userName}, here are your game play statistics…");
            Console.WriteLine($"Wins: {player.getWins()}");
            Console.WriteLine($"Losses: {player.getLosses()}");
            Console.WriteLine($"Ties: {player.getTies()}");
            try
            {
                float winLossRatioPlayerStat = player.Wins/player.Losses;
                float decimalWinLossRatioPlayerStat = (float)Math.Round(winLossRatioPlayerStat * 100f) / 100f;
                Console.WriteLine($"Win/Loss Ratio: {decimalWinLossRatioPlayerStat}");
            }
            catch (Exception)
            {
                Console.WriteLine("Play more games to see your Win/Loss Ratio.");
            }
            
        }
        public static Player_Log Load(List<Player_Log> player_Log_List)
        {
            
                Console.WriteLine("What is your name?");
                string userName = Console.ReadLine();
                try{
                    foreach(var player in player_Log_List)
                    {
                        if (player.getName() == userName)
                        {
                            Console.WriteLine($" Welcome back {userName}. Let’s play!");
                            return player;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"{userName}, Not Found");
                }
                
            
                
                return null;
            
        }
        public static Player_Log WhatIsYourName(string userName, List<Player_Log> player_Log_List)
        {
            while(true)
            {
                bool doesMatchName = false;
                Console.WriteLine("What is your name!");
                userName = Console.ReadLine();
                foreach(var player in player_Log_List)
                {
                    if(player.Name == userName)
                    {
                        Console.WriteLine("Sorry that name is already in use, Enter another name");
                        doesMatchName = true;
                    }
                }
                if(doesMatchName == false)
                {
                    break;
                }
            }
                Player_Log newPlayer = new Player_Log(userName, 0, 0, 0);
                player_Log_List.Add(newPlayer);
                Console.WriteLine($"Hello {userName}, Let's play!");
                newPlayer.roundNumber();
                
               
                return newPlayer;
        }
    
               
        static void Main(string[] args)
        {
            string csvDataFilePath = "player_log.csv";
            List<Player_Log> player_Log_List = Player_log_loader.Load(csvDataFilePath);
            
            string userName = "";
            string afterGameChoice = "";
            string userChoice = Menu();
            while (true)
            {
                if(userChoice == "1")
                {    
                    while(true)
                    {
                        bool doesMatchName = false;
                        Console.WriteLine("What is your name!");
                        userName = Console.ReadLine();
                        foreach(var player in player_Log_List)
                        {
                            if(player.Name == userName)
                            {
                                Console.WriteLine("Sorry that name is already in use, Enter another name");
                                doesMatchName = true;
                            }
                        }
                        if(doesMatchName == false)
                        {
                            break;
                        }
                    }
                    Player_Log newPlayer = new Player_Log(userName, 0, 0, 0);
                    player_Log_List.Add(newPlayer);
                    Console.WriteLine($"Hello {userName}, Let's play!");
                    newPlayer.roundNumber();
                    Game(newPlayer);
                    //afterGameChoice = Menu_After_Play();
                    while (true)
                    {
                        afterGameChoice = Menu_After_Play();
                        if (afterGameChoice == "1")
                        {
                            Game(newPlayer);
                            continue;
                        }
                        else if (afterGameChoice == "2")
                        {
                            playerStat(newPlayer, userName);
                            continue;
                        }
                        else if (afterGameChoice == "3")
                        {
                            ViewLeaderBoard(player_Log_List);
                        }
                        else if (afterGameChoice == "4")
                        {
                            Saving(player_Log_List,userName);
                            Console.WriteLine($"{userName}, your game has been saved.");
                            Environment.Exit(1);
                            
                        }
                    }
                }
                else if (userChoice == "2")
                {
                    try{
                        var loadedPlayer = Load(player_Log_List);
                        userName = loadedPlayer.Name;
                        
                        Game(loadedPlayer);
                        while (true)
                        {
                            afterGameChoice = Menu_After_Play();
                            if (afterGameChoice == "1")
                            {
                                Game(loadedPlayer);
                                continue;
                            }
                            else if (afterGameChoice == "2")
                            {
                                
                                playerStat(loadedPlayer, userName);
                                continue;
                            }
                            else if (afterGameChoice == "3")
                            {
                                ViewLeaderBoard(player_Log_List);
                            }
                            else if (afterGameChoice == "4")
                            {
                                Saving(player_Log_List,userName);
                                Console.WriteLine($"{userName}, your game has been saved.");
                                Environment.Exit(1);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Sorry that game could not be found.");
                        userChoice = Menu();
                        continue;
                    } 
                }
                else if (userChoice == "3")
                Environment.Exit(1);
            }
        }
    }
}
