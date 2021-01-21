using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public int number;
    GameObject rail;
    [SerializeField] float scaleX, scaleY;

    // Start is called before the first frame update
    void Start()
    {
        scaleX = 0.003781101f;
        scaleY = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector2(scaleX, scaleY);
    }

    private void OnEnable()
    {
        rail = GameObject.FindWithTag("Rail");
        gameObject.transform.SetParent(rail.transform);
    }
}
