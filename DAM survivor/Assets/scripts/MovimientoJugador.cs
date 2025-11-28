using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    ///////////////////////////////////// VARIABLES /////////////////////////////////
    private bool puedeMoverse = true;
    private float velocidadMovimiento = 5f;
    private Vector2 direccionPlana;

    public Controles control;

    public PauseMenu pauseMenu;   // ← arrastrar en el inspector

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

        // ----- MOVIMIENTO -----
        if (puedeMoverse)
        {
            direccionPlana = control.Player.Move.ReadValue<Vector2>();
            Vector3 direccionMovimiento = new Vector3(direccionPlana.x, 0f, direccionPlana.y);
            direccionMovimiento.Normalize();

            transform.position += direccionMovimiento * velocidadMovimiento * Time.deltaTime;

            if (direccionMovimiento != Vector3.zero)
            {
                Quaternion rotacionDeseada = Quaternion.LookRotation(direccionMovimiento);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, 10f * Time.deltaTime);
            }
        }
    }
}
