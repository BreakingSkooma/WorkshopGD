using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public static CameraSwitcher instance { get; private set; }

    [SerializeField]
    private CameraController generalCamera;
    private CinemachineVirtualCamera generalVirtualCamera;
    [SerializeField]
    private CameraController zoomCamera;
    private CinemachineVirtualCamera zoomVirtualCamera;

    private void Awake()
    {
        instance = this;
        generalVirtualCamera = generalCamera.GetComponent<CinemachineVirtualCamera>();
        zoomVirtualCamera = zoomCamera.GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        ZoomOut();
    }

    public void ZoomIn(Transform target)
    {
        zoomCamera.FollowTarget(target);
        zoomVirtualCamera.Priority = 20;
        
    }

    public void ZoomOut()
    {
        zoomVirtualCamera.Priority = 5;
        zoomCamera.UnFollow();
    }
}
