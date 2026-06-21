using UnityEngine;

namespace KrupalKuchhadiya.Portfolio._1V1_Racing_3D
{
    public class PlayerLapTrackerReference : MonoBehaviour
    {
        [SerializeField] PlayerLapTracker _playerLapTracker;

        public PlayerLapTracker PlayerLapTracker()
        {
            return _playerLapTracker;
        }
    }
}
