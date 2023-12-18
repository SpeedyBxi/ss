using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    // Start is called before the first frame update
    public int rate = 20;
    public GameObject player;
    public AudioSource boing;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Translate(Vector3.right * rate * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bounce") {
            rate *= -1;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player") {
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50, 0), ForceMode.Impulse);
            player.GetComponent<Rigidbody>().AddForce(player.transform.forward, ForceMode.Impulse);
            boing.Play();
        }
    }
}
