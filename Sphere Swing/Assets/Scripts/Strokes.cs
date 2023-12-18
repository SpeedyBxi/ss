using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class Strokes : MonoBehaviour
{
    PlayerController pc;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Strokes: " + pc.strokes;
    }
}
