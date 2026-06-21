using UnityEngine;

namespace KrupalKuchhadiya.Portfolio._1V1_Racing_3D
{
    public class Checkpoint : MonoBehaviour
    {
        public int checkpointIndex;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"This is {gameObject.name} and {other.gameObject.name} collide");
            if (!other.CompareTag("Player")) return;
            Debug.Log($"This is player collision");

            PlayerLapTrackerReference tracker = other.GetComponent<PlayerLapTrackerReference>();
            if (tracker != null)
            {
                tracker.PlayerLapTracker().OnCheckpointPassed(checkpointIndex);
            }
        }
    }
}