using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool active = false;
    public Image background;
    public TextMeshProUGUI title;
    public Button main;
    public Button restart;
    PlayerController pc;


    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (active) {
                active = false;
            }
            else {
                active = true;
            }
        }
        if (active) {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
        background.gameObject.SetActive(active);
        title.gameObject.SetActive(active);
        main.gameObject.SetActive(active);
        restart.gameObject.SetActive(active);
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
    public void Restart() {
        pc.space = 6;
        pc.player.transform.position = new Vector3(0, 0, 0);
        pc.strokes += 2;
        pc.rb.velocity = new Vector3(0, 0, 0);
        active = false;
    }
}
