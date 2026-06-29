using UnityEngine;

namespace KrupalKuchhadiya.Portfolio._1V1_Racing_3D
{
    public class MinimapCameraFollow : MonoBehaviour
    {
        public Transform target;
        public float height = 100f;

        void LateUpdate()
        {
            if (target == null)
                return;

            transform.position = new Vector3(
                target.position.x,
                target.position.y + height,
                target.position.z
            );
        }
    }
}
