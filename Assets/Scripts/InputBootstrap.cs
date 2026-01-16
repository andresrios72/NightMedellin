using UnityEngine;
using UnityEngine.InputSystem;

public class InputBootstrap : MonoBehaviour
{
    void Start()
    {
        // Cursor obligatorio para Starter Assets
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Forzar Action Map correcto
        var input = GetComponent<PlayerInput>();
        if (input != null)
        {
            input.SwitchCurrentActionMap("Player");
        }
    }
}
