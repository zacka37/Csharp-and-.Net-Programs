using System;
using System.Collections.Generic;
using System.IO;
namespace FinalProject{
    public static class Player_log_loader{
        private static int NumItemsInRow = 4;

        public static List<Player_Log> Load (string csvDataFilePath){
            List<Player_Log> player_Logs_List = new List<Player_Log>();

            try
            {
                using (var reader = new StreamReader(csvDataFilePath))
                {
                    int LineNumber = 0;
                    while(!reader.EndOfStream)
                    {
                        
                        LineNumber++;
                        var Values = reader.ReadLine().Split(',');
                        if (Values.Length != NumItemsInRow){
                            throw new Exception($"Row {LineNumber} contains {Values.Length} values. It should contain {NumItemsInRow}.");
                        }
                        try
                        {
                            string Name = Convert.ToString(Values[0]);
                            int Wins = Int32.Parse(Values[1]);
                            int Losses = Int32.Parse(Values[2]);
                            int Ties = Int32.Parse(Values[3]);
                            Player_Log player_log = new Player_Log(Name,Wins,Losses,Ties);
                            player_Logs_List.Add(player_log);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {LineNumber} contains invalid data. ({e.Message})");
                        }
                    }
                }
            }catch (Exception e){
                throw new Exception($"Unable to open {csvDataFilePath}. ({e.Message})");
            }
            return player_Logs_List;
        }
    }
}