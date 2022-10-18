using UnityEngine;

public class CubeMaterialController : MonoBehaviour
{

    [SerializeField] private CubeSpawnController cubeSpawnController;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material cubeMaterial;



    void Start()
    {
        cubeSpawnController = GameObject.FindObjectOfType<CubeSpawnController>();
        meshRenderer.material = Instantiate(cubeMaterial);
        SetMaterialColor();
    }



    public void SetMaterialColor()
    {
        meshRenderer.material.color = cubeSpawnController.cubeColor[cubeSpawnController.colorIndex];
    }
}
