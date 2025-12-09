using UnityEngine;

public class Experiencia : MonoBehaviour
{
    public int exp; // valor del prefab

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerExperiencia>().AñadirExperiencia(exp);
            Destroy(gameObject);
        }
    }
}
