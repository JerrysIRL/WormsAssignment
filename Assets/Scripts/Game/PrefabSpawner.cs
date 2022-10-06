using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;
    public IEnumerator SpawnPickups() // coroutine for ammo pickup, spawns a new pickup in a random place every 10 seconds.
    {
        Vector3 randomPlace = new Vector3(Random.Range(8, 175), 2, Random.Range(8, 175));
        GameObject pickup = Instantiate(pickupPrefab, randomPlace, transform.rotation);
        yield return new WaitForSeconds(10f);
        StartCoroutine(SpawnPickups());
    }
}
