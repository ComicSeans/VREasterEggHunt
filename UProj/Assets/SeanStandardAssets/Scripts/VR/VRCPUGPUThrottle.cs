using UnityEngine;
using System.Collections;

public class VRCPUGPUThrottle : MonoBehaviour
{
#pragma warning disable 0414
    [Header("CPU Throttle Settings")]
    [SerializeField]
    private bool UseDefaultCPUThrottle = true;
    [Range(0, 3)]
    [SerializeField]
    private int CPUThrottle = 2;
    [Header("GPU Throttle Settings")]
    [SerializeField]
    private bool UseDefaultGPUThrottle = true;
    [Range(0, 3)]
    [SerializeField]
    private int GPUThrottle = 2;
#pragma warning restore 0414
#if !UNITY_EDITOR && UNITY_ANDROID
    private void Awake()
    {
        if (!UseDefaultCPUThrottle) OVRPlugin.cpuLevel = CPUThrottle;
        if (!UseDefaultGPUThrottle) OVRPlugin.gpuLevel = GPUThrottle;
    }
#endif
}
