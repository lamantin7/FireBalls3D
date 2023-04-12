using Coroutines;
using Obstacles;
using Sequence;
using Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstalceMovement : MonoBehaviour
{
    //[SerializeField] private float _speed;
    //void FixedUpdate()
    //{        
    //    float angle=_speed;
    //    transform.Rotate(Vector3.up, angle);
    //}
    [SerializeField] private FloatRange _moveDuration;
    [SerializeField] private FloatRange _changeSpeedDuration;
    [SerializeField] private FloatRange _speed;

    [SerializeField] private AnimationCurve _changeSpeedCurve;

    private void Start()
    {
        IMovement movement = new RotationMovement(transform, Vector3.up);
        var terms = new IMovementSequenceTerm[]
        {
            new ChangeSpeedSequenceTerm(movement,_speed, _changeSpeedDuration,_changeSpeedCurve),
            new MoveSequenceTerm (movement, _moveDuration)
        };
        CoroutineExecutor coroutineExecutor = new CoroutineExecutor(this);
        MovementSequence sequence= new MovementSequence(terms, coroutineExecutor);
        sequence.StartProcessing();
    }
}
