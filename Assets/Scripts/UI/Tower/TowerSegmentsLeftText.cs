using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI.Tower
{
    public class TowerSegmentsLeftText : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _text;
        public void UpdateTextValue(int segmentCount)=>
            _text.text = $"{segmentCount}";
    }
}