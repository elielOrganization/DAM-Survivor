using UnityEngine;

public class DamageOrbitalShield : MonoBehaviour
{
    private int damage;
    private float radius;
    private float rotationSpeed;

    private float angle;   // ángulo actual
    private Transform player;

    public void Configure(int dmg, float rad, float rotSpeed)
    {
        damage = dmg;
        radius = rad;           // distancia respecto al player
        rotationSpeed = rotSpeed;
    }

    public void SetInitialAngle(float degrees)
    {
        angle = degrees;
        player = transform.parent;   // el player es el padre
    }

    private void Update()
    {
        if (player == null) return;

        // Incrementar el ángulo
        angle += rotationSpeed * Time.deltaTime;

        // Convertir ángulo a radianes
        float rad = angle * Mathf.Deg2Rad;

        // Nuevo offset
        Vector3 offset = new Vector3(Mathf.Cos(rad), 0f, Mathf.Sin(rad)) * radius;

        transform.position = player.position + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
                enemy.Recibirdano(damage);
        }
    }
}
