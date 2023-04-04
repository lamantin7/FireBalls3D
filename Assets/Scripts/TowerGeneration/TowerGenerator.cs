using System.Collections;
using System.Collections.Generic;
using TowerGeneration;
using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;

public class TowerGenerator : MonoBehaviour
{
    [SerializeField] private UnityObject _towerFactory;

    private IAsyncTowerFactory TowerFactory=>(IAsyncTowerFactory) _towerFactory;

    private void OnValidate()
    {
        if ( _towerFactory != null && _towerFactory is IAsyncTowerFactory == false)
        {
            _towerFactory = null;
            throw new InvalidOperationException($"Tower factory should be derived from {nameof(IAsyncTowerFactory)}");
        }
    }
}
