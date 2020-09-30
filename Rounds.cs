using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{
    public Target[] Enemies;
    public int AmountOfRounds;
    public int budgetMultiplier;
    public float ExtraBudget;

    public Transform SpawnAreaCenter;
    public float StartSpawnAreaRadius;

    public LayerMask EnemyLayer;

    private float SpawnAreaRadius;
    private int roundNum;
    private int budget;
    private float Spent;
    GameObject scores = GameObject.Find("Score");

    void Start()
    {
        Vector3 center = transform.position;
    }
    void Update()
    {
        if (Physics.CheckSphere(SpawnAreaCenter.position, 50, EnemyLayer))
        {
            
            scores.GetComponent<Score>().clearScore();
        }
        else
        {
            SpawnRound();
        }
    }

    void SpawnRound()
    {
        Spent = 0;

        SpawnAreaRadius += Random.Range(-0.5f, 0.5f);
        if (roundNum <= AmountOfRounds)
        {
            budget = roundNum * budgetMultiplier;
            roundNum += 1;
            while (Spent < budget)
            {                  
                SpawnEnemy();             
            }
        }
    }

    void SpawnEnemy()
    {
        int EnemySelected = Random.Range(0, Enemies.Length);
        if ((Enemies[EnemySelected].Cost + Spent) <= budget)
        {
            Spent += Enemies[EnemySelected].Cost;
            GameObject newEnemy = Instantiate(Enemies[EnemySelected].gameObject,
                RandomCircle(SpawnAreaCenter.position, SpawnAreaRadius),
                Quaternion.identity);
        }
        else if (budget - (Enemies[EnemySelected].Cost + Spent) <= ExtraBudget || (Enemies[EnemySelected].Cost + Spent) - budget <= ExtraBudget)
        {
            Spent += Enemies[EnemySelected].Cost;
            GameObject newEnemy = Instantiate(Enemies[EnemySelected].gameObject,
                RandomCircle(SpawnAreaCenter.position, SpawnAreaRadius),
                Quaternion.identity);
        }

    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
