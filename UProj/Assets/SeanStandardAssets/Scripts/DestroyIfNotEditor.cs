using UnityEngine;
using System.Collections;

public class DestroyIfNotEditor : MonoBehaviour
{
#if !UNITY_EDITOR
    private void Awake()
    {
        Destroy(gameObject);
    }
#endif
}
