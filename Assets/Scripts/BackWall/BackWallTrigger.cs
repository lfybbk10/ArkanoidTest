using UnityEngine;


public class BackWallTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _triggerMask;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.IsInLayerMask(_triggerMask))
        {
            AddNegativePoints();
        }
    }

    private void AddNegativePoints()
    {
        Statistic.AddNegativePoints(1);
    }
}
