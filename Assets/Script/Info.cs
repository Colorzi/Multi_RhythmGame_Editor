using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    
    GameObject rail;
   
    int changeLineCount;
    List<GameObject> lines;

    // Start is called before the first frame update
    void Start()
    {
        changeLineCount = 0;
        lines = EditManager.Instance.lines;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LineInput(Text text)
    {
        rail = GameObject.FindWithTag("Rail");

        int.TryParse(text.text, out changeLineCount);

        for(int i = 0; i < lines.Count; i++)
        {
            lines[i].SetActive(false);
        }

        for(int i = 0; i < changeLineCount; i++)
        {
            lines[i].SetActive(true);
        }
    }
}
