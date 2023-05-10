using GameStates.Base;
using GameStates.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class RestartButton:MonoBehaviour
    {
        [SerializeField] private SOGameStateMachine _stateMachine;
        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(_stateMachine.Enter<SOLevelLostState>);
        }
    }
}
