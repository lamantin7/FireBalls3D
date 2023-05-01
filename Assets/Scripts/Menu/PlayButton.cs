using GameStates.Base;
using GameStates.States;
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
        [SerializeField] private SOGameStateMachine _stateMachine;  
        void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(_stateMachine.Enter<SOLevelEntryState>);
        }
       


    }
}