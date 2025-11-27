using UnityEngine;

public class Rayo : MonoBehaviour
{
    public int damage = 50;
    public float lifeTime = 1f;
    public float damageInterval = 0.25f;
    private float nextDamageTime = 0f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.SetParent(player);
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!gameObject.activeSelf) return;

        if (other.CompareTag("Enemy"))
        {
            if (Time.time >= nextDamageTime)
            {
                EnemyController enemy = other.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.Recibirdano(damage);
                }

                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
}
