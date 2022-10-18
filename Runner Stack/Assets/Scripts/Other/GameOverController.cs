using UnityEngine;

public class GameOverController : MonoBehaviour
{

    [SerializeField] private CubeSpawnController cubeSpawnController;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private Transform playerTransform;



    public void CheckCubeLocalScale(float x)
    {
        if (Mathf.Abs(x) <= 0.05)
        {
            restartButton.SetActive(true);
            Time.timeScale = 0;
        }
    }



    public void CheckDistance()
    {
        if (cubeSpawnController.lastCubeObject.transform.localScale.x < Mathf.Abs(cubeSpawnController.newCubeObject.transform.position.x))
        {
            restartButton.SetActive(true);
            Time.timeScale = 0;
        }
    }



    public void CheckPlayerYTransform()
    {
        if (playerTransform.position.y < 0f)
        {
            restartButton.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
