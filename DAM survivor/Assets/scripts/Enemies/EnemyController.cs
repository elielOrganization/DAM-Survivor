using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// ////////////////////////////////// Variables ///////////////////////
    /// </summary>
    public HitFlash hitFlash;   // referencia al efecto visual de daño

    //Referencia al jugador//
    private GameObject player;

    //Info del SO//
    public EnemyStats Stats;

    //Stats propios//
    private int maxHP;
    private int currentHP;
    private int damage;
    private int defense;
    private float speed;
    private float currentSpeed;
    public GameObject exp;
    public GameObject OrbeVerde;
    public GameObject OrbeAzul;
    public GameObject OrbeDorado;

    
    /// <summary>
    /// /////////////////////////////////// Funciones Unity ///////////////////////////////
    /// </summary>
    void Awake()
    {
        maxHP = Stats.MaxHP;
        currentHP = maxHP;
        damage = Stats.Damage;
        defense = Stats.Defense;
        speed = Stats.Speed;
        currentSpeed = speed;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelUpManager.IsLevelUpOpen)
            return;
        if (player != null)
        {
            //Cojo la direccion
            Vector3 direccion = player.transform.position - transform.position;
            direccion.Normalize();

            //Moverme hacia el jugador
            transform.position += direccion * currentSpeed * Time.deltaTime;

        }
    }
    public void ModificarVelocidad(float multiplicador)
    {
        currentSpeed = speed * multiplicador;
    }

    public void RestaurarVelocidad()
    {
        currentSpeed = speed;
    }

    public void Recibirdano(int danio)
{
    int danioFinal = danio - defense;
    if (danioFinal < 0)
    {
        danioFinal = 0;
    }

    currentHP -= danioFinal;

    // Feedback visual de daño
    if (hitFlash != null)
    {
        hitFlash.Flash();
    }

    if (currentHP <= 0)
    {
        Morir();
    }
}


    private void Morir()
{
    SoltarOrbeConProbabilidad();
    Destroy(gameObject);
}

    private void SoltarOrbeConProbabilidad()
{
    float random = Random.value;

    if (random < 0.6f)
    {
        Instantiate(OrbeVerde, transform.position, Quaternion.identity);
    }
    else if (random < 0.9f)
    {
        Instantiate(OrbeAzul, transform.position, Quaternion.identity);
    }
    else
    {
        Instantiate(OrbeDorado, transform.position, Quaternion.identity);
    }
}
}
