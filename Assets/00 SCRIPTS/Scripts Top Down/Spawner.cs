using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;
    float time = 1;

    public GameObject[] enemies;
    private void Start()
    {
        StartCoroutine(CalculatorTime());
    }

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int randEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randEnemy], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn/time;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    IEnumerator CalculatorTime()
    {
       
        yield return new WaitForSeconds(30f);
        time++;

    }
}
