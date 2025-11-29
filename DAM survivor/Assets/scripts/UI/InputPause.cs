using UnityEngine;
using UnityEngine.InputSystem;

public class InputPause : MonoBehaviour
{
   public PauseMenu pauseMenu;   // referencia al script PauseMenu

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (pauseMenu != null)
        {
            if (pauseMenu.juegoPausado) pauseMenu.Reanudar();
            else pauseMenu.Pausar();
        }
    }
}
