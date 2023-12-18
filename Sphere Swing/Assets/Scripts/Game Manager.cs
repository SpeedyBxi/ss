using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene("Level Selector");
    }
    public void lOne() {
        SceneManager.LoadScene("Level 1");
    }
    public void lTwo() {
        SceneManager.LoadScene("Level 2");
    }
    public void lThree() {
        SceneManager.LoadScene("Level 3");
    }
    public void lFour() {
        SceneManager.LoadScene("Level 4");
    }
    public void lFive() {
        SceneManager.LoadScene("Level 5");
    }
    public void lSix() {
        SceneManager.LoadScene("Level 6");
    }
    public void lSeven() {
        SceneManager.LoadScene("Level 7");
    }
    public void lEight() {
        SceneManager.LoadScene("Level 8");
    }
    public void lNine() {
        SceneManager.LoadScene("Level 9");
    }
    public void Settings() {
        SceneManager.LoadScene("Settings");
    }
}
