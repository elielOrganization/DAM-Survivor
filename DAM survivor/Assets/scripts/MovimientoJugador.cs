using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    ///////////////////////////////////// VARIABLES /////////////////////////////////
    private bool puedeMoverse = true;
    private float velocidadMovimiento = 5f;
    private Vector2 direccionPlana;

    public Controles control;

    public PauseMenu pauseMenu;   // ← arrastrar en el inspector

    public Transform camara;

    ///////////////////////////////////// FUNCIONES UNITY /////////////////////////////////
    private void Awake()
    {
        control = new Controles();
    }

    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }

    void Update()
    {
        // ----- PAUSA -----
        // si la acción Pause se ha pulsado este frame
        if (control.Player.pause.triggered)
        {
            if (pauseMenu.juegoPausado)
                pauseMenu.Reanudar();
            else
                pauseMenu.Pausar();
        }

        if (puedeMoverse)
        {
            direccionPlana = control.Player.Move.ReadValue<Vector2>();

            // Direcciones basadas en la cámara (X,Z)
            Vector3 forwardCam = camara.forward;
            forwardCam.y = 0;
            forwardCam.Normalize();

            Vector3 rightCam = camara.right;
            rightCam.y = 0;
            rightCam.Normalize();

            // Movimiento relativo a la cámara
            Vector3 direccionMovimiento = forwardCam * direccionPlana.y + rightCam * direccionPlana.x;

            if (direccionMovimiento.sqrMagnitude > 0.001f)
            {
                direccionMovimiento.Normalize();
                transform.position += direccionMovimiento * velocidadMovimiento * Time.deltaTime;

                // Solo rotar si el input es hacia adelante
                if (direccionPlana.y > 0.1f || direccionPlana.x != 0)
                {
                    Quaternion rotacionDeseada = Quaternion.LookRotation(direccionMovimiento);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, 10f * Time.deltaTime);
                }
                // Si el input es solo hacia atrás, no rota
            }

        }

    }
}
