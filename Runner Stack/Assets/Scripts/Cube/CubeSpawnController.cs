using UnityEngine;

public class CubeSpawnController : MonoBehaviour
{

    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private float[] spawnPoints;


    public GameObject lastCubeObject;
    public GameObject newCubeObject;
    public GameObject cubePrefab;
    public Color[] cubeColor;


    public int colorIndex;
    private int spawnPointIndex = 0;



    private void Start()
    {
        CreateNewCube();
    }



    public void CreateNewCube()
    {
        IncreaseSpawnPointIndex();
        newCubeObject = Instantiate(cubePrefab, new Vector3(spawnPoints[spawnPointIndex], 0, lastCubeObject.transform.position.z + 5f), Quaternion.identity);
        colorIndex++;

        if (colorIndex >= cubeColor.Length)
        {
            colorIndex = 0;
        }

        newCubeObject.transform.localScale = new Vector3(lastCubeObject.transform.localScale.x, 1, 5f);
        playerMovementController.targetPositions.Add(newCubeObject.transform);
        SetCubeMovementDirection(newCubeObject);
    }



    private void SetCubeMovementDirection(GameObject cubeObject)
    {
        cubeObject.GetComponent<CubeMovementController>().SetMovementDirection(Vector3.right);
    }



    private void IncreaseSpawnPointIndex()
    {
        spawnPointIndex++;

        if (spawnPointIndex >= 1)
        {
            spawnPointIndex = 0;
        }
    }
}
