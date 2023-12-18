using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Menu men;
    Rigidbody rb;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        men = GameObject.Find("Menu").GetComponent<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!men.active) {
            transform.LookAt(player);
            transform.position += transform.forward * .025f;            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Out") {
            transform.position = new Vector3(0, 0.67f, 36.71f);
        }
    }
}
