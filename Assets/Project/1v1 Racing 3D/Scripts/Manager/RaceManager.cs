using System.Collections.Generic;
using UnityEngine;

namespace KrupalKuchhadiya.Portfolio._1V1_Racing_3D
{
    public class RaceManager : MonoBehaviour
    {
        public static RaceManager Instance;

        private List<PlayerLapTracker> players = new List<PlayerLapTracker>();
        private List<PlayerLapTracker> finishedPlayers = new List<PlayerLapTracker>();

        public List<Checkpoint> allCheckpoints;

        private void Awake()
        {
            Instance = this;
        }

        public void RegisterPlayer(PlayerLapTracker player)
        {
            if (!players.Contains(player))
                players.Add(player);
        }

        public void PlayerFinished(PlayerLapTracker player)
        {
            if (!finishedPlayers.Contains(player))
            {
                finishedPlayers.Add(player);
                Debug.Log($"Position: {finishedPlayers.Count}");
            }
        }

        public List<PlayerLapTracker> GetRankings()
        {
            players.Sort((a, b) => b.GetProgress().CompareTo(a.GetProgress()));
            return players;
        }
    
        /// <summary>
        /// Helper methods
        /// </summary>

        public Checkpoint GetNextCheckpoint(Checkpoint currentCheckpoint)
        {
            if (currentCheckpoint == allCheckpoints[allCheckpoints.Count - 1]) return allCheckpoints[0];
            else
            {
                int index = allCheckpoints.IndexOf(currentCheckpoint);
                return allCheckpoints[index+1];
            }
        }
    }
}
