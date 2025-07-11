using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> trashPrefabs;
    [SerializeField] private float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnTrash), 0f, spawnInterval);
    }

    void SpawnTrash()
    {
        // Selct where to spawn
        Vector3 randomViewportPos = new Vector3(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            10f
        );

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(randomViewportPos);
        worldPos.z = 0f;

        Vector3 spawnPos = worldPos;
        
        // Instantiate random trash
        int randomIndex = Random.Range(0, trashPrefabs.Count);
        GameObject randomTrash = trashPrefabs[randomIndex];
        Instantiate(randomTrash, spawnPos, Quaternion.identity);
    }
}