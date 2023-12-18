using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.transform.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0)) {
            Finish();
            
        }
    }

    void Finish() {
        SceneManager.LoadScene("Main Menu");
    }
}
