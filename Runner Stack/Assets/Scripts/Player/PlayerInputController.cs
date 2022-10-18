using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    [SerializeField] private CubeSpawnController cubeSpawnController;
    [SerializeField] private CubeCutController cubeCutController;



    void Update()
    {
        HandlePlayerInput();
    }



    public void HandlePlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cubeSpawnController.newCubeObject.GetComponent<CubeMovementController>().SetMovementSpeed(0);
            cubeCutController.CheckCubesBetweenDistance(cubeSpawnController.lastCubeObject, cubeSpawnController.newCubeObject);
            cubeCutController.CutNewCubeObject();
        }
    }
}
