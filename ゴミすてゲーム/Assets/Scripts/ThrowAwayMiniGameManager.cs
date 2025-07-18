using UnityEngine;
using TMPro;

public class ThrowAwayMiniGameManager : MonoBehaviour
{
    public GameObject resultModal;
    public GameObject InteractionBlocker;
    public TMP_Text resultScoreText;
    public TrashSpawner trashSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resultModal.SetActive(false);
        InteractionBlocker.SetActive(false);
        BGMManager.instance.PlayBGM("ê¬ãÛãÛç`");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowScore()
    {
        int resultScore = ScoreManager.Instance.GetScore();
        resultScoreText.text = resultScore.ToString();
    }

    public void GameOver()
    {
        trashSpawner.CancelSpawn();
        ShowResultModal();
        Draggable.isDragEnable = false;
        BGMManager.instance.StopBGM();
    }

    private void ShowResultModal()
    {
        ShowScore();
        resultModal.SetActive(true);
        InteractionBlocker.SetActive(true);
    }
}
