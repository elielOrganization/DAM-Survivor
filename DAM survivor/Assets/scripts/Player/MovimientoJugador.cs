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

    // NUEVO: referencia al Rigidbody
    private Rigidbody rb;
    // NUEVO: guardamos la dirección de movimiento para usarla en FixedUpdate
    private Vector3 direccionMovimiento;

    ///////////////////////////////////// FUNCIONES UNITY /////////////////////////////////
    private void Awake()
    {
        control = new Controles();
        rb = GetComponent<Rigidbody>();   // ← asegúrate de que el jugador tiene Rigidbody
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
        if (LevelUpManager.IsLevelUpOpen)
            return;

        // ----- PAUSA -----
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
            direccionMovimiento = forwardCam * direccionPlana.y + rightCam * direccionPlana.x;

            if (direccionMovimiento.sqrMagnitude > 0.001f)
            {
                direccionMovimiento.Normalize();

                // ROTACIÓN SIGUE IGUAL
                if (direccionPlana.y > 0.1f || direccionPlana.x != 0)
                {
                    Quaternion rotacionDeseada = Quaternion.LookRotation(direccionMovimiento);
                    transform.rotation = Quaternion.Slerp(
                        transform.rotation,
                        rotacionDeseada,
                        10f * Time.deltaTime
                    );
                }
            }
            else
            {
                // si no hay input, no movemos al rigidbody
                direccionMovimiento = Vector3.zero;
            }
        }
        else
        {
            direccionMovimiento = Vector3.zero;
        }
    }

    // NUEVO: movimiento físico en FixedUpdate
    private void FixedUpdate()
    {
        if (!puedeMoverse || direccionMovimiento.sqrMagnitude <= 0.001f)
            return;

        rb.MovePosition(rb.position + direccionMovimiento * velocidadMovimiento * Time.fixedDeltaTime);

    }
}
