using UnityEngine;

namespace KrupalKuchhadiya.Portfolio._1V1_Racing_3D
{
    public class Checkpoint : MonoBehaviour
    {
        // References
        [SerializeField] RaceManager raceManager;

        public int checkpointIndex;

        [SerializeField] GameObject checkpointMesh;


        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            PlayerLapTrackerReference tracker = other.GetComponent<PlayerLapTrackerReference>();
            if (tracker != null)
            {
                tracker.PlayerLapTracker().OnCheckpointPassed(checkpointIndex);
                raceManager.GetNextCheckpoint(this).ActiveCheckpoint();
                CheckpointCollected();
            }
        }

        public void ActiveCheckpoint()
        {
            checkpointMesh.SetActive(true);
        }

        void CheckpointCollected()
        {
            checkpointMesh.SetActive(false);
        }
    }
}