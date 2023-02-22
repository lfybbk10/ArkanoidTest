using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BatController : MonoBehaviour
{
    [SerializeField] private BoxCollider _leftWall;
    [SerializeField] private BoxCollider _rightWall;
    [SerializeField] private Camera _camera;

    private float minX, maxX;

    private float sensitivityMultiplier = 14;

    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        CalculateControllerRange();
    }

    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(GetXByMousePosition(),minX,maxX);
        transform.position = newPosition;
    }

    private float GetXByMousePosition()
    {
        Vector3 mousePos = _camera.ScreenToViewportPoint(Input.mousePosition);
        mousePos.x -= 0.5f;
        mousePos.x *= sensitivityMultiplier;
        return mousePos.x;
    }

    private void CalculateControllerRange()
    {
        CalculateMinX();
        CalculateMaxX();
    }
    
    private void CalculateMinX()
    {
        float leftWallX = _leftWall.transform.TransformPoint(_leftWall.center).x +
                           _leftWall.transform.TransformVector(_leftWall.size).x;
        minX = leftWallX + _collider.size.x/2f;
    }
    private void CalculateMaxX()
    {
        float rightWallX = _rightWall.transform.TransformPoint(_rightWall.center).x -
                            _rightWall.transform.TransformVector(_rightWall.size).x;
        maxX = rightWallX - _collider.size.x/2f;
    }
}
