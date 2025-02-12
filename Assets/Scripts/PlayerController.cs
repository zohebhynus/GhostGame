using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool canPickUpItem = false;

    public int keysCollected = 0;

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


}
