using UnityEngine;

public class PlayerVoiceController : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    public float currentPitchValue = 0.3f;



    public void IncreaseCurrentPitchValue()
    {
        if (currentPitchValue <= 3)
        {
            currentPitchValue += 0.1f;
            audioSource.pitch = currentPitchValue;
            audioSource.Play();
        }
    }



    public void ResetcurrentPitchValue()
    {
        currentPitchValue = 0.3f;
    }
}
