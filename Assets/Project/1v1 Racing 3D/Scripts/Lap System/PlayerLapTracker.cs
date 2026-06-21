using UnityEngine;

namespace KrupalKuchhadiya.Portfolio._1V1_Racing_3D
{
    public class PlayerLapTracker : MonoBehaviour
    {
        /*[Networked]*/ public int CurrentLap { get; private set; }
        /*[Networked]*/ public int CurrentCheckpoint { get; private set; }

        public int totalLaps = 3;
        public int totalCheckpoints = 5;

        private int expectedCheckpoint = 0;

        public /*override*/ void Spawned()
        {
            //if (Object.HasStateAuthority)
            //{
                CurrentLap = 0;
                CurrentCheckpoint = 0;
                expectedCheckpoint = 0;
            //}
        }

        public void OnCheckpointPassed(int checkpointIndex)
        {
            //if (!Object.HasStateAuthority) return;

            // ? Anti-cheat: wrong checkpoint
            if (checkpointIndex != expectedCheckpoint)
            {
                Debug.Log($"Wrong checkpoint: Expected {expectedCheckpoint}, Got {checkpointIndex}");
                return;
            }

            // ? Valid checkpoint
            CurrentCheckpoint = checkpointIndex;

            expectedCheckpoint++;

            // ?? Completed lap
            if (expectedCheckpoint >= totalCheckpoints)
            {
                expectedCheckpoint = 0;
                CurrentLap++;

                Debug.Log($"Lap Completed: {CurrentLap}");

                if (CurrentLap >= totalLaps)
                {
                    FinishRace();
                }
            }
        }

        private void FinishRace()
        {
            //Debug.Log($"Player {Object.InputAuthority} finished race!");
            RaceManager.Instance.PlayerFinished(this);
        }

        public int GetProgress()
        {
            return (CurrentLap * totalCheckpoints) + CurrentCheckpoint;
        }
    }
}
