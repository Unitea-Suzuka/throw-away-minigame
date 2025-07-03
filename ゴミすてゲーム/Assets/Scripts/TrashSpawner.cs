using UnityEngine;
using UnityEngine.UI;

public class TrashSpawnerUI : MonoBehaviour
{
    public GameObject trashPrefab;           // UI用のImageプレハブ
    public RectTransform spawnArea;          // ゴミを生成するUI領域
    public float spawnInterval = 2f;         // 生成間隔（秒）

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
        GameObject trash = Instantiate(trashPrefab, spawnArea);
        RectTransform rt = trash.GetComponent<RectTransform>();
        rt.anchoredPosition = localPos;
    }
}