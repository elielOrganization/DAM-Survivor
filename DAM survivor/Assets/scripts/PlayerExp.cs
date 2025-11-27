using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public int experiencia = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exp"))
        {
            experiencia +=1;
            Destroy(other.gameObject);
        }
    }
}
