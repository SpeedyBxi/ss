using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target.transform.position, Vector3.up);
        transform.Rotate(new Vector3(0, -180, 0));
    }
}
