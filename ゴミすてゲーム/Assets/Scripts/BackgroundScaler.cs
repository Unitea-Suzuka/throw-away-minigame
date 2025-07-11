using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        FitBackgroundToCamera(sr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FitBackgroundToCamera(SpriteRenderer sr)
    {
        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWidth = screenHeight * Camera.main.aspect;

        Vector2 spriteSize = sr.sprite.bounds.size;
        Vector3 newScale = sr.transform.localScale;

        newScale.x = screenWidth / spriteSize.x;
        newScale.y = screenHeight / spriteSize.y;

        sr.transform.localScale = newScale;
    }
}
