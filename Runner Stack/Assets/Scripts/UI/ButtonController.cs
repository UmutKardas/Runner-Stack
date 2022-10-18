using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private CubeSpawnController cubeSpawnController;
    [SerializeField] private CubeCutController cubeCutController;
    [SerializeField] private RotateCamera rotateCamera;



    public void SetRestartButton()
    {
        SceneManager.LoadScene(0);
    }



    public void SetNextButton()
    {
        int listIndex;
        listIndex = playerMovementController.targetPositions.Count;
        rotateCamera.SetVirtualCameraPriorityValueIncrease();
        cubeCutController.cubeIndex = 0;
        cubeSpawnController.lastCubeObject.transform.position = playerMovementController.targetPositions[listIndex - 1].position;
        cubeSpawnController.CreateNewCube();
    }
}
