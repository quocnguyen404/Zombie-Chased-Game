using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyReference;

    private GameObject spawnedEnemy;

    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;

    private int randomIndex;
    private int randomSide;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());        
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 10));
            randomIndex = Random.Range(0, enemyReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedEnemy = Instantiate(enemyReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnedEnemy.transform.position = leftPos.position;
                spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
            }

            if (randomSide == 1)
            {
                spawnedEnemy.transform.position = rightPos.position;
                spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 10);
                spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        } //while
    }
}
