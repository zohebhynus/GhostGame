using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    EventSystem eventSystem;
    public GameObject lastSelectedMenuOption;

    private bool isUsingMouse = false;
    private bool isUsingKeyboard = false;

    void Start()
    {
        eventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        if (Mouse.current.delta.ReadValue() != Vector2.zero)
        {
            if (!isUsingMouse)
            {
                isUsingMouse = true;
                isUsingKeyboard = false;
                eventSystem.SetSelectedGameObject(null);
            }
        }

        // Check for Keyboard or Controller Input
        if (Keyboard.current.anyKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.dpad.ReadValue() != Vector2.zero)
        {
            if (!isUsingKeyboard)
            {
                isUsingKeyboard = true;
                isUsingMouse = false;
                // Re-select the last navigated button
                eventSystem.SetSelectedGameObject(lastSelectedMenuOption);
            }
        }

        // Store the last selected GameObject
        if (eventSystem.currentSelectedGameObject != null)
        {
            lastSelectedMenuOption = eventSystem.currentSelectedGameObject;
        }
    }

}
