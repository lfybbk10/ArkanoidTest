using UnityEngine;

public static class Extensions
{
    public static bool IsInLayerMask(this GameObject obj, LayerMask layerMask)
    {
        return ((layerMask.value & (1 << obj.layer)) > 0);
    }
}
