using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    ///////////////////////////////////// VARIABLES /////////////////////////////////
    private bool puedeMoverse = true;
    private float velocidadMovimiento;
    private Vector2 direccionPlana;

    public Controles control;
    public PauseMenu pauseMenu;  
    public Transform camara;

    // Referencia al Rigidbody
    private Rigidbody rb;
    // Guardamos la dirección de movimiento para usarla en FixedUpdate
    private Vector3 direccionMovimiento;

    ///////////////////////////////////// FUNCIONES UNITY /////////////////////////////////
    private void Awake()
    {
        control = new Controles();
        rb = GetComponent<Rigidbody>();   
    }

    private void Start()
    {
        velocidadMovimiento = Player.Instance.stats.Speed;
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

                // ROTACIÓN
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

    // Movimiento físico en FixedUpdate
    private void FixedUpdate()
    {
        if (!puedeMoverse || direccionMovimiento.sqrMagnitude <= 0.001f)
            return;

        rb.MovePosition(rb.position + direccionMovimiento * velocidadMovimiento * Time.fixedDeltaTime);

    }
}
