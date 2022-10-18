using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    [SerializeField] private Animator playerAnimator;



    public void SetDanceAnimationActive()
    {
        playerAnimator.SetBool("Dancing", true);
    }



    public void SetDanceAnimationDeActive()
    {
        playerAnimator.SetBool("Dancing", false);
    }
}
