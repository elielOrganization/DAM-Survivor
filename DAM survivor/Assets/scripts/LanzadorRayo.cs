using UnityEngine;
using System.Collections;

public class LanzadorRayo : MonoBehaviour
{
    public GameObject rayoPrefab;
    public float cooldown = 20f;
    private bool puedeDisparar = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeDisparar)
            StartCoroutine(DispararRayo());
    }
   IEnumerator DispararRayo()
    {
        puedeDisparar = false;
        Vector3 spawnPos = transform.position + transform.forward * 1f;
        Instantiate(rayoPrefab, spawnPos, transform.rotation);

        yield return new WaitForSeconds(cooldown);
        puedeDisparar = true;
    }
}
