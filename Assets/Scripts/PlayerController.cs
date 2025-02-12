using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    AudioSource audioSource;

    public bool canPickUpItem = false;
    public int keysCollected = 0;

    public AudioClip pickUpSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact(InputAction.CallbackContext context)
    {

        if(context.started)
        {
            canPickUpItem =true;
        }

        if(context.canceled) 
        {
            canPickUpItem = false;
        }
    }

    public void PlayPickUpAudio()
    {
        audioSource.PlayOneShot(pickUpSound);
    }


}
