using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TrashSpawnerUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> trashPrefabs;           // UI用のImageプレハブ
    [SerializeField] private RectTransform spawnArea;          // ゴミを生成するUI領域
    [SerializeField] private float spawnInterval = 2f;         // 生成間隔（秒）
    [SerializeField] private Transform trashParent;

    void Start()
    {
        InvokeRepeating(nameof(SpawnTrash), 0f, spawnInterval);
    }

    void SpawnTrash()
    {
        // スポーンエリアのサイズを取得
        Vector2 size = spawnArea.rect.size;

        // ランダムな位置（アンカー中心からの相対）を計算
        float x = Random.Range(-size.x / 2f, size.x / 2f);
        float y = Random.Range(-size.y / 2f, size.y / 2f);
        Vector2 localPos = new Vector2(x, y);

        // ゴミを生成して親にセット
        int index = Random.Range(0, trashPrefabs.Count);
        GameObject trash = Instantiate(trashPrefabs[index], spawnArea);
        RectTransform rt = trash.GetComponent<RectTransform>();
        rt.anchoredPosition = localPos;
        //trash.transform.SetParent(trashParent,false);
    }
}