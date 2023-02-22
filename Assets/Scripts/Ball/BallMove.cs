using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class BallMove : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationValue;
    
    private Rigidbody _rigidbody;
    private float currSpeed;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        currSpeed = startSpeed;
    }

    private void FixedUpdate()
    {
        if (currSpeed < maxSpeed)
        {
            currSpeed += accelerationValue;
        }
        _rigidbody.velocity = _rigidbody.velocity.normalized*currSpeed;
    }

    public void StartMove()
    {
        _rigidbody.velocity = GetRandomDirection()*currSpeed;
    }

    public void ChangeDir(Vector3 dir)
    {
        _rigidbody.velocity = dir * currSpeed;
    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(0, 1f));
    }
}
