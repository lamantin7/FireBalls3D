using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseButtonAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleFrom;
    [SerializeField] private Vector3 _scaleTo;
    [SerializeField] [Min(0f)] private float _duration;
    [SerializeField] private AnimationCurve _scaleCurve;

    private void Start() => 
        StartCoroutine(PlayLoopPulse(transform, _scaleFrom,_scaleTo, _duration, _scaleCurve));

    private IEnumerator PlayLoopPulse(Transform transformPulse, Vector3 from, Vector3 to, float duration, AnimationCurve scaleCurve)
    {
        while (true) 
        {
            yield return StartCoroutine(PulseButton(transformPulse, to, duration, scaleCurve));
            yield return StartCoroutine(PulseButton(transformPulse, from, duration, scaleCurve));
        }
    }
    private IEnumerator PulseButton (Transform transformButton, Vector3 to, float duration, AnimationCurve scaleCurve)
    {
        float enteredTime = Time.time;
        Vector3 enteredScale = transformButton.localScale;
        while (Time.time<enteredTime+duration) 
        {
            float elapsedTimePercent = (Time.time - enteredTime) / duration;
            Vector3 difference = to - enteredScale;
            Vector3 scaledDifference= scaleCurve.Evaluate(elapsedTimePercent)*difference;
            transformButton.localScale = enteredScale+scaledDifference;
            yield return null;
        }
    }
}
