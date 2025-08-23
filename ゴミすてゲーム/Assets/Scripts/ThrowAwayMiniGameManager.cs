using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.UI;

public class ThrowAwayMiniGameManager : MonoBehaviour
{
    public GameObject resultModal;
    public GameObject InteractionBlocker;
    public TMP_Text resultScoreText;
    public TrashSpawner trashSpawner;
    public static List<Sprite> thrownTrash = new List<Sprite>();
    public Transform dummyContent;
    public GameObject dummyTrash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resultModal.SetActive(false);
        InteractionBlocker.SetActive(false);
        BGMManager.instance.PlayBGM("青空空港");
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
        SEManager.instance.PlaySE("警官のホイッスル2");
        trashSpawner.CancelSpawn();
        ShowResultModal(thrownTrash);
        Draggable.isDragEnable = false;
        BGMManager.instance.StopBGM();
    }

    private void ShowResultModal(List<Sprite>thrownTrash)
    {
        ShowScore();
        resultModal.SetActive(true);
        Debug.Log("showScore");
        foreach (Transform child in dummyContent)
        {
            Destroy(child.gameObject);
        }

        foreach (var sprite in thrownTrash)
        {
            GameObject icon = Instantiate(dummyTrash, dummyContent);
            Image img = icon.GetComponent<Image>();
            img.sprite = sprite;
            img.enabled = true;
        }
        InteractionBlocker.SetActive(true);
    }

    public static void AddTrash(Sprite sprite)
    {
        thrownTrash.Add(sprite);
        Debug.Log(sprite);
    }
}
