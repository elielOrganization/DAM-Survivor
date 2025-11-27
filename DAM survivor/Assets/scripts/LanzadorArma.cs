using System.Collections;
using UnityEngine;

public class LanzadorArma : MonoBehaviour
{
    public GameObject armaPrefab;
    public GameObject armaPrefab2;
    public float ratioDeDisparo = 1f; // Armas por segundo
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(dispararArma());
        StartCoroutine(dispararArma2());
    }

    public IEnumerator dispararArma()
    {
        while (true)
        {
            Instantiate(armaPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(ratioDeDisparo);
        }
    }
     public IEnumerator dispararArma2()
    {
        while (true)
        {
            Instantiate(armaPrefab2, transform.position + transform.forward, transform.rotation);
            yield return new WaitForSeconds(ratioDeDisparo);
        }
    }


}


