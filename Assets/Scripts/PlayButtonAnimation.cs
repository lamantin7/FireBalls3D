using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleFrom;
    [SerializeField] private Vector3 _scaleTo;
    [SerializeField] [Min(0f)] private float _duration;

    private void Start() => 
        StartCoroutine(PlayLoopPulse(transform, _scaleFrom,_scaleTo, _duration));

    private IEnumerator PlayLoopPulse(Transform transformPulse, Vector3 from, Vector3 to, float duration)
    {
        while (true) 
        {
            yield return StartCoroutine(PulseButton(transformPulse, to, duration));
            yield return StartCoroutine(PulseButton(transformPulse, from, duration));
        }
    }
    private IEnumerator PulseButton (Transform transformButton, Vector3 maxPulse, float duration)
    {
        float enteredTime = Time.time;
        Vector3 enteredScale = transformButton.localScale;
        while (Time.time<enteredTime+duration) 
        {
            float elapsedTimePercent = (Time.time - enteredTime) / duration;
            transform.localScale = Vector3.Lerp(enteredScale, maxPulse,elapsedTimePercent);
            yield return null;
        }
    }
}
