using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> trashPrefabs;
    [SerializeField] private List<float> spawnWeights;
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
        int randomIndex = GetWeightedRandomIndex(spawnWeights);
        GameObject randomTrash = trashPrefabs[randomIndex];
        Instantiate(randomTrash, spawnPos, Quaternion.identity);
    }

    private int GetWeightedRandomIndex(List<float> weights)
    {
        float totalWeight = 0f;
        foreach (float weight in weights)
            totalWeight += weight;

        float randomValue = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;

        for (int i = 0; i < weights.Count; i++)
        {
            cumulativeWeight += weights[i];
            if (randomValue < cumulativeWeight)
                return i;
        }

        return weights.Count - 1;
    }

    public void CancelSpawn()
    {
        CancelInvoke(nameof(SpawnTrash));
    }
}