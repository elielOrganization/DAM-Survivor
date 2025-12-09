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

    void Awake()
    {
        controles = new Controles();
    }

    private void OnEnable()  => controles.Enable();
    private void OnDisable() => controles.Disable();

    void Start()
    {
        // Coloca la cámara en escena con el ángulo isométrico
        // y aquí solo guardamos la diferencia de posición
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        float scrollValue = controles.Camara.Zoom.ReadValue<float>();
        zoom -= scrollValue / suavizadoZoom;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);

        Vector3 zoomFinal = offset * zoom;

        // Solo seguir la posición, sin rotar con el jugador
        transform.position = player.transform.position + zoomFinal;

        // Opcional: mirar ligeramente al centro del jugador
        transform.LookAt(player.transform.position + Vector3.up * 1.5f);
    }
}
