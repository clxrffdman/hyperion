using UnityEngine;

public class targetOld : MonoBehaviour
{
    public ParticleSystem Explosion;
    public float Health;
    public float DeathScore;
    public float Cost;
    public GameObject death_particle;
    public GameObject[] Drops;

    void Start()
    {
        death_particle = (GameObject)Resources.Load("death", typeof(GameObject));
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
        Instantiate(death_particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
        
        

        
        
    }
}
