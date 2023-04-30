using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    [RequireComponent(typeof(Button))]
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private string _levelSceneName = "TropicT 1";
        void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(LoadLevel);
        }
        private void LoadLevel() 
        {
            SceneManager.LoadScene(_levelSceneName);
        }


    }
}