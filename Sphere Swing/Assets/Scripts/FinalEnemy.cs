using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnemy : MonoBehaviour
{
    Menu men;
    Rigidbody rb;
    public Transform player;
    public bool activate = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        men = GameObject.Find("Menu").GetComponent<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!men.active && activate) {
            transform.LookAt(player);
            transform.position += transform.forward * .025f;            
        }
        if (player.position == new Vector3(0, 0, 0)) {
            activate = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Out") {
            transform.position = new Vector3(-109.69f, 285.24f, -542.85f);
        }
    }
}
