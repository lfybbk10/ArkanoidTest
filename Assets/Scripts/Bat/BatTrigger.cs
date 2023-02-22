using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BatTrigger : MonoBehaviour
{
    public event Action<float> OnCollisionEntered;
    
    [SerializeField] private LayerMask _triggerMask;
    
    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.IsInLayerMask(_triggerMask))
        {
            Vector3 contactPoint = other.contacts[0].point;
            CalculateDistXFromCenter(contactPoint);
            AddPositivePoints();
        }
    }

    private void CalculateDistXFromCenter(Vector3 contactPoint)
    {
        Vector3 centerCollider = transform.TransformPoint(_collider.center);
        float distXFromCenter = contactPoint.x - centerCollider.x;
        OnCollisionEntered?.Invoke(distXFromCenter);
    }

    private void AddPositivePoints()
    {
        Statistic.AddPositivePoints(1);
    }
}
