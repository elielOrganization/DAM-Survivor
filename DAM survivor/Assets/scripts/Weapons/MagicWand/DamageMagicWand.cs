using UnityEngine;

public class DamageMagicWand : MonoBehaviour
{
    private int damage;
    private float speed;
    private Transform target;

    public void Configure(int dmg, float spd, Transform tgt)
    {
        damage = dmg;
        speed = spd;
        target = tgt;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Dirección hacia el objetivo
        Vector3 dir = (target.position - transform.position).normalized;

        // Mover
        transform.position += dir * speed * Time.deltaTime;

        // Si está muy cerca impactar
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            EnemyController e = target.GetComponent<EnemyController>();
            if (e != null)
                e.Recibirdano(damage);

            Destroy(gameObject);
        }
    }
}
