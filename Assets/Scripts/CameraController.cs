using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _size = 5;
    CinemachineVirtualCamera _camera;
    void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {
        MouseWheel();
    }

    void MouseWheel()
    {
        _size = UnityEngine.Input.GetAxisRaw("Mouse ScrollWheel");
        _camera.m_Lens.OrthographicSize -= _size;
    }
}
