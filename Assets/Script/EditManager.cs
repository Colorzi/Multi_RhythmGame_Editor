using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    private static EditManager instance;

    public static EditManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<EditManager>();

            return instance;
        }
    }

    public GameObject railPrefab;
    GameObject rail;
    public GameObject judgeLine;
    public float beatLineDistance = 1.5f;
    public AudioSource audioSource;
    float railLength;
    float currentMusicTime;

    public GameObject noteLinePrefab;
    public List<GameObject> lines = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RailMove();
    }

    public void CreateRail()
    {
        rail = Instantiate(railPrefab, judgeLine.transform.position, Quaternion.identity);
        railLength = (audioSource.clip.length / 0.3f) * beatLineDistance;
        rail.transform.localScale = new Vector2(judgeLine.transform.localScale.x, railLength);
        CreateLines();
    }

    void CreateLines()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject lineObject = Instantiate(noteLinePrefab);
            lineObject.GetComponent<Line>().number = i;
            lineObject.SetActive(false);
            lines.Add(lineObject);
        }
    }

    private void RailMove()
    {
        if (audioSource.clip != null)
        {
            currentMusicTime = audioSource.time / audioSource.clip.length;
            rail.transform.position = new Vector2(judgeLine.transform.position.x, judgeLine.transform.position.y - Mathf.Lerp(0, rail.transform.localScale.y, currentMusicTime));
        }
    }

    public void SetOffset()
    {
        
    }
}
