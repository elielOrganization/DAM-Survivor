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
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
    // Update is called once per frame
    private void LateUpdate()
    {
        float scrollValue = controles.Camara.Zoom.ReadValue<float>();
        zoom -= scrollValue / suavizadoZoom;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
        Vector3 zoomFinal = offset * zoom;
        transform.position = player.transform.position + zoomFinal;
    }
}
