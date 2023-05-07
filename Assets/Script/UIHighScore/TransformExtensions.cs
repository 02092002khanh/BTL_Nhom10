using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static void DestroyAllChilren(this Transform target)
    {
        List<Transform> child = target.GetComponentsInChildren<Transform>().ToList();
        if(child.Contains(target))
        {
            child.Remove(target);
        }
        foreach (var item in child)
        {
            GameObject.Destroy(item.gameObject);
        }
    }
}
