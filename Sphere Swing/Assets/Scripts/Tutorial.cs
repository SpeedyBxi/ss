using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    PlayerController pc;
    public TextMeshProUGUI[] tutorialTexts;
    int targetIndex = 0;
    int space = 0;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        pc.space = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0)) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                space++;
            }
        }

        if (space == 1) {
            targetIndex = 1;
        }
        if (space == 2) {
            targetIndex = 2;           
        }
        if (space == 3) {
            targetIndex = 3;          
        }
        if (space == 4) {
            targetIndex = 4;            
        }
        if (space == 5) {
            targetIndex = -1;
        }
        for (int i = 0; i < tutorialTexts.Length; i ++) {
            if (i == targetIndex) {
                tutorialTexts[i].gameObject.SetActive(true);
            }
            else {
                tutorialTexts[i].gameObject.SetActive(false);
            }
        }
    }
}
