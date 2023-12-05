using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private Transform defaultTransform;

    [SerializeField]
    private float zoom = 4;

    private float defaultZoom;


    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void FollowTarget(Transform target)
    {
        virtualCamera.Follow = target;
        virtualCamera.LookAt = target;
    }

    public void UnFollow()
    {
        virtualCamera.Follow = defaultTransform;
        virtualCamera.LookAt = defaultTransform;
    }
}
