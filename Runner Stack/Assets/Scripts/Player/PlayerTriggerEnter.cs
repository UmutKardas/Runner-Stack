using UnityEngine;
using Kardas;

public class PlayerTriggerEnter : MonoBehaviour
{

    [SerializeField] private RotateCamera rotateCamera;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag.FINISH))
        {
            Destroy(other.gameObject);
            rotateCamera.SetCameraPosition();
            rotateCamera.SetVirtualCameraPriorityValueDecrease();
        }
    }
}
