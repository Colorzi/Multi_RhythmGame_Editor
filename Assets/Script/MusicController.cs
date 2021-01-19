using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;

    public static MusicController Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<MusicController>();

            return instance;
        }
    }

    public AudioSource audioSource;
    public Slider progressBar;
    public Text timeText;

    int timeText_min;
    int timeText_sec;
    int timeText_microSec;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProgressBar();
        ChangeProgressTimeText();
    }

    public void MusicStart()
    {
        if (audioSource.clip != null)
        {
            audioSource.volume = 0.2f;
            audioSource.Play();
        }
    }

    public void MusicPause()
    {
        if (audioSource.clip != null)
        {
            audioSource.Pause();
        }
    }

    public void MusicStop()
    {
        if (audioSource.clip != null)
        {
            audioSource.Stop();
        }
    }

    public void ProgressBar()
    {
        if (audioSource.clip != null)
        {
            progressBar.maxValue = audioSource.clip.length - 0.01f;
            progressBar.value = audioSource.time;
        }
    }

    public void ControlProgressBar()
    {

        audioSource.time = progressBar.value;
    }

    public void ChangeProgressTimeText()
    {
        float currentTime = (float)audioSource.time;

        timeText_min = (int)(currentTime / 60);
        timeText_sec = (int)(currentTime - timeText_min * 60);
        timeText_microSec = (int)((currentTime % 1) * 1000);

        timeText.text = string.Format("{0:D2}:{1:D2}:{2:D3}", timeText_min, timeText_sec, timeText_microSec);
    }
}
