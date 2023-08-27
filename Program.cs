using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Team_project
{
    interface ITeam
    {
        void Add(Player player);

        void Remove(int playerId);

        Player GetPlayerById(int playerid);
        Player GetPlayerByName(int playername);

        List<Player> GetAllPlayers();
    }

    class OneDayTeam:ITeam
    {
        public static List<Player> oneDayTeam = new List<Player>();

        public OneDayTeam() {
            oneDayTeam = new List<Player>();
        }

        public void Add(Player player)
        {
            if (oneDayTeam.Count < 11)
            {
                oneDayTeam.Add(player);
                Console.WriteLine("Player is added successfully");
            }
            else
            {
                Console.WriteLine("Team is already full.");
            }
        }

        public void Remove(int playerId)
        {
            Player playerToRemove = oneDayTeam.Find(p => p.PlayerId == playerId);
            if (playerToRemove != null)
            {
                oneDayTeam.Remove(playerToRemove);
                Console.WriteLine("Player is removed successfully.");
            }
            else
            {
                Console.WriteLine("Player not found in the team.");
            }
        }

        public Player GetPlayerById(int playerId)
        {
            return oneDayTeam.Find(p => p.PlayerId == playerId);
        }

        public Player GetPlayerByName(string playerName)
        {
            return oneDayTeam.Find(p => p.PlayerName == playerName);
        }

        public List<Player> GetAllPlayers()
        {
            return oneDayTeam;
        }

        public Player GetPlayerByName(int playername)
        {
            throw new NotImplementedException();
        }
    }
    class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            OneDayTeam obj=new OneDayTeam();
            bool flag = true;
            while (flag)
            {
                Console.Write("Enter 1:To Add Player 2:To Remove Player by Id 3.Get Player By Id 4.Get Player by Name 5.Get All Players:");
                int ch = Int32.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Player newPlayer = new Player();
                        Console.Write("Enter Player Id:");
                        newPlayer.PlayerId = Int32.Parse(Console.ReadLine());
                        Console.Write("Enter Player Name:");
                        newPlayer.PlayerName = Console.ReadLine();
                        Console.Write("Enter Player Age:");
                        newPlayer.PlayerAge = Int32.Parse(Console.ReadLine());
                        obj.Add(newPlayer);
                        break;
                    case 2:
                        Console.Write("Enter Player Id to Remove:");
                        int playerIdToRemove = int.Parse(Console.ReadLine());
                        obj.Remove(playerIdToRemove);
                        break;
                    case 3:
                        Console.Write("Enter Player Id to Get:");
                        int playerIdToGet = int.Parse(Console.ReadLine());
                        Player playerById = obj.GetPlayerById(playerIdToGet);
                        if (playerById != null)
                        {
                            Console.WriteLine($"Player Id: {playerById.PlayerId}, Name: {playerById.PlayerName}, Age: {playerById.PlayerAge}");
                        }
                        else
                        {
                            Console.WriteLine("Player not found.");
                        }
                        break;

                    case 4:
                        Console.Write("Enter Player Name to Get:");
                        string playerNameToGet = Console.ReadLine();
                        Player playerByName = obj.GetPlayerByName(playerNameToGet);
                        if (playerByName != null)
                        {
                            Console.WriteLine($"Player Id: {playerByName.PlayerId}, Name: {playerByName.PlayerName}, Age: {playerByName.PlayerAge}");
                        }
                        else
                        {
                            Console.WriteLine("Player not found.");
                        }
                        break;

                    case 5:
                        List<Player> allPlayers = obj.GetAllPlayers();
                        if (allPlayers.Count > 0)
                        {
                            foreach (var player in allPlayers)
                            {
                                Console.WriteLine($"Player Id: {player.PlayerId}, Name: {player.PlayerName}, Age: {player.PlayerAge}");
                            }
                        }
                        else
                        {
                            Console.Write("No players in the team.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
                Console.Write("Do you want to continue (yes/no)?:");
                string input= Console.ReadLine();
                if (input == "yes")
                {
                    flag = true;
                }
                else { 
                    flag = false;
                }
            }
        }
    }
}
