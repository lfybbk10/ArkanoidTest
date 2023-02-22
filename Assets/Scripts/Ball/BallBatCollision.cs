using System;
using UnityEngine;

[RequireComponent(typeof(BallMove))]
public class BallBatCollision : MonoBehaviour
{
    [SerializeField] private BatTrigger _batTrigger;
    
    private BallMove _ballMove;

    private float angleRangeMultiplier = 1.5f;

    private void Awake()
    {
        _ballMove = GetComponent<BallMove>();
    }

    private void OnEnable()
    {
        _batTrigger.OnCollisionEntered += ChangeBallDir;
    }

    private void OnDisable()
    {
        _batTrigger.OnCollisionEntered -= ChangeBallDir;
    }

    private void ChangeBallDir(float distFromCenter)
    {
        float bounceAngle = (float)Math.Sin(distFromCenter) / angleRangeMultiplier;
        Vector2 newBallDir = new Vector2(Mathf.Sin(bounceAngle), Mathf.Cos(bounceAngle)).normalized;
        
        _ballMove.ChangeDir(new Vector3(newBallDir.x,0,newBallDir.y));
    }
}
