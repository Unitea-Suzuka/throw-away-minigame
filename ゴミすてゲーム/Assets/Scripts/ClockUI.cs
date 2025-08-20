using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private Image clockInner;
    [SerializeField] private float startTime;
    private float currentTime;

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            float ratio = Mathf.Clamp01(currentTime / startTime);
            clockInner.fillAmount = ratio;
        }
    }
}