using UnityEngine;
using System.Collections;

public class HitFlash : MonoBehaviour
{
    public Renderer rend;            // arrastra aquí el MeshRenderer o SpriteRenderer
    public Color flashColor = Color.white;
    public float flashDuration = 0.1f;

    Color originalColor;

    void Start()
    {
        originalColor = rend.material.color;
    }

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        rend.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        rend.material.color = originalColor;
    }
}
