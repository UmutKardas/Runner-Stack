using UnityEngine;

public class CubeCutController : MonoBehaviour
{
    [SerializeField] private CubeSpawnController cubeSpawnController;
    [SerializeField] private PlayerVoiceController playerVoiceController;
    [SerializeField] private GameOverController gameOverController;

    public float distance;
    private float newScaleX;
    private float newCutPositionX;

    public int cubeIndex = 0;



    public void CutNewCubeObject()
    {
        cubeIndex++;
        if (cubeIndex < 9)
        {
            newScaleX = cubeSpawnController.newCubeObject.transform.localScale.x;

            if (distance >= 0)
            {
                newScaleX = cubeSpawnController.lastCubeObject.transform.localScale.x - distance;
                cubeSpawnController.newCubeObject.transform.localScale = new Vector3(Mathf.Abs(newScaleX), 1f, 5f);
                cubeSpawnController.newCubeObject.transform.position = new Vector3(cubeSpawnController.newCubeObject.transform.position.x - (distance / 2f), 0f, cubeSpawnController.newCubeObject.transform.position.z);
            }

            else
            {
                newScaleX = cubeSpawnController.lastCubeObject.transform.localScale.x + distance;
                cubeSpawnController.newCubeObject.transform.localScale = new Vector3(Mathf.Abs(newScaleX), 1f, 5f);
                cubeSpawnController.newCubeObject.transform.position = new Vector3(-(Mathf.Abs(cubeSpawnController.newCubeObject.transform.position.x - (distance / 2))), 0f, cubeSpawnController.newCubeObject.transform.position.z);
            }


            CutObject();
            gameOverController.CheckDistance();
            gameOverController.CheckCubeLocalScale(newScaleX);
            cubeSpawnController.lastCubeObject = cubeSpawnController.newCubeObject;
            cubeSpawnController.CreateNewCube();
        }
    }



    public void CutObject()
    {
        if (Mathf.Abs(distance) < 0.08f)
        {
            playerVoiceController.IncreaseCurrentPitchValue();
        }

        else
        {
            playerVoiceController.ResetcurrentPitchValue();

            if (distance >= 0)
            {
                newCutPositionX = (newScaleX / 2) + (distance / 2) + cubeSpawnController.newCubeObject.transform.position.x;
                GameObject cutObject = Instantiate(cubeSpawnController.newCubeObject, new Vector3(newCutPositionX, 0, cubeSpawnController.newCubeObject.transform.position.z), Quaternion.identity);
                cutObject.transform.localScale = new Vector3(Mathf.Abs(distance), 1, 5);
                cutObject.AddComponent<Rigidbody>();
            }

            else
            {
                newCutPositionX = (newScaleX / 2) - (distance / 2) - cubeSpawnController.newCubeObject.transform.position.x;
                GameObject cutObject = Instantiate(cubeSpawnController.newCubeObject, new Vector3(-newCutPositionX, 0, cubeSpawnController.newCubeObject.transform.position.z), Quaternion.identity);
                cutObject.transform.localScale = new Vector3(Mathf.Abs(distance), 1, 5);
                cutObject.AddComponent<Rigidbody>();
            }
        }
    }



    public void CheckCubesBetweenDistance(GameObject lastCube, GameObject newCube)
    {
        distance = newCube.transform.position.x - lastCube.transform.position.x;
    }
}
