using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KrupalKuchhadiya.Portfolio._1V1_Racing_3D
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private string practiceSceneName;

        [SerializeField] private TMP_InputField nicknameInputField;
        [SerializeField] private string username;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            LoadData();
        }


        void LoadData()
        {
            if (PlayerPrefs.HasKey("Username"))
            {
                username = PlayerPrefs.GetString("Username");
                nicknameInputField.text = username;
            }
            else
            {
                username = "Guest_" + Random.Range(00000,99999).ToString("00000");
                nicknameInputField.text = username;
                PlayerPrefs.SetString("Username", username);
            }
        }

        public void SaveNickname()
        {
            if (nicknameInputField.text != string.Empty 
                && nicknameInputField.text != null 
                && nicknameInputField.text != username)
            {
                username = nicknameInputField.text;
                PlayerPrefs.SetString("Username", username);
            }
        }

        public void PracticeGame()
        {
            SceneManager.LoadScene(practiceSceneName);
        }
    }
}
