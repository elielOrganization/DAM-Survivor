using UnityEngine;
using System.Collections.Generic;

public class DamageFrost : MonoBehaviour
{
    private int damage;
    private float slowPercent;
    private float cooldown;
    private float timer = 0f;
    private List<EnemyController> enemigosDentro = new List<EnemyController>();

    public void Configure(int dmg, float slow, float cd)
    {
        damage = dmg;
        slowPercent = slow;
        cooldown = cd;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = cooldown;
            AplicarDañoGlobal();
        }
    }

    private void AplicarDañoGlobal()
    {
        foreach (EnemyController enemy in enemigosDentro)
        {
            if (enemy != null)
                enemy.Recibirdano(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                // Añadir a la lista
                enemigosDentro.Add(enemy);

                // Aplicar ralentización
                enemy.ModificarVelocidad(1f - slowPercent);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                // Quitar slow
                enemy.RestaurarVelocidad();

                // Eliminar de la lista
                enemigosDentro.Remove(enemy);
            }
        }
    }
}
