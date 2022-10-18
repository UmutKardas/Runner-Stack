using UnityEngine;
using Cinemachine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private PlayerAnimationController playerAnimationController;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject nextButton;

    [SerializeField] private float rotatespeed;

    private bool isWin;



    public void SetCameraPosition()
    {
        transform.position = player.transform.position;
    }



    public void SetVirtualCameraPriorityValueDecrease()
    {
        playerAnimationController.SetDanceAnimationActive();
        playerMovementController.movementSpeed = 0;
        virtualCamera.Priority = 8;
        isWin = true;
        nextButton.SetActive(true);
    }



    public void SetVirtualCameraPriorityValueIncrease()
    {
        playerAnimationController.SetDanceAnimationDeActive();
        playerMovementController.movementSpeed = 2;
        virtualCamera.Priority = 13;
        isWin = false;
        nextButton.SetActive(false);
    }



    private void Update()
    {
        if (isWin)
        {
            RotateVirtualCamera();
        }
    }



    public void RotateVirtualCamera()
    {
        transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime);
    }
}
