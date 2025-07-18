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
        Destroy(other.gameObject);
        if (other.CompareTag("bottle"))
        {
            ScoreManager.Instance.AddScore(10);
            SEManager.instance.PlaySE("決定ボタンを押す44");
        }
        else if (other.CompareTag("can"))
        {
            ScoreManager.Instance.AddScore(10);
            SEManager.instance.PlaySE("決定ボタンを押す44");
        }
        else if (other.CompareTag("paper"))
        {
            ScoreManager.Instance.AddScore(10);
            SEManager.instance.PlaySE("決定ボタンを押す44");
        }
        else if (other.CompareTag("smoke"))
        {
            ScoreManager.Instance.AddScore(25);
            SEManager.instance.PlaySE("決定ボタンを押す46");
        }
    }
}
