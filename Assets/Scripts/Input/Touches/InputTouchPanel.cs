using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputTouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action<Touching> Begun;
    public event Action<Touching> Holding;
    public event Action<Touching> Ended;
    private Coroutine _holdingRoutine;

    public void OnPointerDown(PointerEventData eventData)
    {
        Begun?.Invoke(new Touching());
        _holdingRoutine=StartCoroutine(ProcessHoldingInput());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Ended?.Invoke(new Touching());
        StopCoroutine(_holdingRoutine);
    }
    private IEnumerator ProcessHoldingInput()
    {
        while (true) 
        {
            Holding?.Invoke(new Touching());
            yield return null;
        }
    }
}
