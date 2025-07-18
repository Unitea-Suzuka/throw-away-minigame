using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager instance;
    public AudioSource audioSource;
    public AudioClip[] SEClips;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySE(string SEname)
    {
        AudioClip audioClip = System.Array.Find(SEClips, clip => { return clip.name == SEname; });
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.loop = false;
            audioSource.Play();
        }
    }

    public void StopSE()
    {
        audioSource.Stop();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
