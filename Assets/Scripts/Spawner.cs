using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    // Update is called once per frame
    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(7f);
        }


    }
    public void StopSpawning()
    {
        StopCoroutine(SpawnObstacle());
    }
}
