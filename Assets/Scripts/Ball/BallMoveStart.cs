using UnityEngine;

[RequireComponent(typeof(BallMove))]
public class BallMoveStart : MonoBehaviour
{
    private BallMove _ballMove;

    private void Awake()
    {
        _ballMove = GetComponent<BallMove>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ballMove.StartMove();
            enabled = false;
        }
    }
}
