using UnityEngine;

public class CubeMovementController : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float[] horizontalLimits;

    private Vector3 movementDirection;



    public void SetMovementSpeed(float value)
    {
        movementSpeed = value;
    }



    public void SetMovementDirection(Vector3 value)
    {
        movementDirection = value;
    }



    void FixedUpdate()
    {
        SetCuveMovement();
        CheckCubeHorizontalPosition();
    }



    private void SetCuveMovement()
    {
        transform.Translate(movementDirection * movementSpeed * Time.fixedDeltaTime);
    }



    private void CheckCubeHorizontalPosition()
    {
        if (transform.position.x >= horizontalLimits[1])
        {
            movementDirection = Vector3.left;
        }

        else if (transform.position.x < horizontalLimits[0])
        {
            movementDirection = Vector3.right;
        }
    }
}
