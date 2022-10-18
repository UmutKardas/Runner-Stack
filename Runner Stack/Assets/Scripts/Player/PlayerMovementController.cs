using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private GameOverController gameOverController;
    [SerializeField] private float lerpValue;

    public List<Transform> targetPositions = new List<Transform>();
    public float movementSpeed;

    private int index = 0;



    private void Start()
    {
        Time.timeScale = 1;
    }



    private void FixedUpdate()
    {
        SetCharacterMovementForward();
        SetCharacterPosition();
        CheckTargetComplete();
        gameOverController.CheckPlayerYTransform();
    }



    private void SetCharacterMovementForward()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
    }



    public void SetCharacterPosition()
    {
        if (targetPositions.Count > 0)
        {
            float newPositionX = transform.position.x;
            newPositionX = Mathf.Lerp(newPositionX, targetPositions[index].position.x, lerpValue * Time.fixedDeltaTime);
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
    }



    private void CheckTargetComplete()
    {
        if (transform.position.z >= targetPositions[index].position.z + 2.5f)
        {
            index++;
        }
    }
}
