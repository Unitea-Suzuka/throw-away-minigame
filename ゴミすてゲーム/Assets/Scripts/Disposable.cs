using UnityEngine;

public class Disposable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Garbage"))
        {
            Destroy(other.gameObject);
            ScoreManager.Instance.AddScore(10);
        }
    }
}
