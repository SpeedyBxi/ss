using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    FinalEnemy fe;
    // Start is called before the first frame update
    void Start()
    {
        fe = GameObject.Find("Enemy").GetComponent<FinalEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.transform.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0)) {
            other.gameObject.transform.position = new Vector3(-109.69f, 284.51f, -557.89f);
            fe.activate = true;
        }
    }
}
