using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem Explosion;
    public float Health;
    public float DeathScore;
    public float Cost;
    public float DropChancePercentage;
    public GameObject[] Drops;

    private Transform PlayerShip;
    private Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
        Explosion.gameObject.SetActive(false);
        PlayerShip = GameObject.Find("Ship").transform;
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Score.score += DeathScore;
        Destroy(transform.gameObject);
        Explosion.gameObject.SetActive(true);
        if (Random.Range(0, 100) < DropChancePercentage)
        {
            GameObject DroppedPowerUp = Instantiate(Drops[Random.Range(0, Drops.Length)], transform.position, Quaternion.identity);
            var direction = PlayerShip.position - transform.position;
            DroppedPowerUp.GetComponent<Rigidbody>().AddForce(direction * 30);
            Destroy(DroppedPowerUp, 30);
        }
        Explosion.Play();
        Destroy(transform.gameObject);
    }
}
