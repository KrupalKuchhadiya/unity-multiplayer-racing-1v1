using UnityEngine;

namespace KrupalKuchhadiya.Portfolio._1V1_Racing_3D
{
    public class PracticeManager : MonoBehaviour
    {
        [SerializeField] private RCC_CarControllerV4 carController;

        private void Start()
        {
            carController.gameObject.name = PlayerPrefs.GetString("Username");
        }
    }
}