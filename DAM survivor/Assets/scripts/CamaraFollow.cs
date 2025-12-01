using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private float zoom = 1f;
    private float zoomMin = 0.5f;
    private float zoomMax = 2f;
    private Controles controles;
    private float suavizadoZoom = 10f;
    public float suavizadoRotacion = 10f;   // NUEVO

    void Awake()
    {
        controles = new Controles();
    }

    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Disable();
    }

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
{
    float scrollValue = controles.Camara.Zoom.ReadValue<float>();
    zoom -= scrollValue / suavizadoZoom;
    zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);

    // Offset base siempre relativo al jugador (tercera persona)
    Vector3 zoomFinal = offset * zoom;
    Vector3 offsetRotado = player.transform.rotation * zoomFinal;

    // Posición: detrás del jugador
    transform.position = player.transform.position + offsetRotado;

    // Rotación: mira al jugador, pero NO toca nada del jugador
    transform.LookAt(player.transform.position + Vector3.up * 1.5f);
}

}
