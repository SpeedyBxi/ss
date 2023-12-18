using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 100;
    public int space = 0;
    public GameObject arrow;
    public new GameObject camera;
    public GameObject dirt;
    public GameObject camera2;
    public GameObject player;
    int direction = 1;
    public Rigidbody rb;
    public int force = 15;
    public int strokes = 0;
    Menu men;
    public AudioSource thwack;
    public AudioSource thud;
    
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
            // only progresses if the player is still
            if (transform.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0)) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    space++;
                }
                if (Input.GetKeyDown(KeyCode.Tab) && space == 0) {
                    space = 5;
                }
            }
            
            // move camera around horizontally
            if (space == 0) {
                transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed);
            }
            if (space == 1) {
                camera.transform.SetParent(null);
                dirt.transform.SetParent(null);
                transform.Rotate(Vector3.right * -45);
                arrow.SetActive(true);
                space++;
            }
            // move arrow up and down
            if (space == 2) {
                transform.Rotate(Vector3.right, Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed);
                if (transform.eulerAngles.x > 0 && transform.eulerAngles.x < 270) {
                    transform.Rotate(Vector3.left, Time.deltaTime * rotationSpeed);
                }
                if (transform.eulerAngles.x > 270 && (transform.eulerAngles.z > 179 && transform.eulerAngles.z < 181)) {
                    transform.Rotate(Vector3.right, Time.deltaTime * rotationSpeed);
                }
            }
            // arrow grows and shrinks and moves accordingly
            if (space == 3) {
                arrow.transform.localScale = new Vector3(arrow.transform.localScale.x, arrow.transform.localScale.y + .015f * direction, arrow.transform.localScale.z);
                arrow.transform.localPosition = new Vector3(arrow.transform.localPosition.x, arrow.transform.localPosition.y, arrow.transform.localPosition.z + .015f * direction);
                if (arrow.transform.localScale.y > 1.5f) {
                    direction = -1;
                }
                if (arrow.transform.localScale.y < .5f) {
                    direction = 1;
                }
            }
            // force depending on scale is applied then rotation is set to 0 and space is added cause this only happens once
            if (space == 4) {
                arrow.SetActive(false);
                dirt.GetComponent<ParticleSystem>().Play();
                rb.AddForce(transform.forward * arrow.transform.localScale.y * force, ForceMode.Impulse);
                transform.eulerAngles = new Vector3(0, 0, 0);
                thwack.Play();
                strokes++;
                space++;
            }
            // move second camera up and down and horizontal rotation for camera
            if (space == 5) {
                camera.SetActive(false);
                camera2.SetActive(true);
                transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed);
                camera2.transform.Rotate(Vector3.right, Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed * -1);
                if (Input.GetKey(KeyCode.LeftControl)) {
                    camera2.transform.localPosition = new Vector3(camera2.transform.localPosition.x, camera2.transform.localPosition.y, camera2.transform.localPosition.z - .05f);
                }
                if (Input.GetKey(KeyCode.LeftShift)) {
                    camera2.transform.localPosition = new Vector3(camera2.transform.localPosition.x, camera2.transform.localPosition.y, camera2.transform.localPosition.z + .05f);
                }
            }
            if (space == 6) {
                camera.transform.SetParent(gameObject.transform);
                dirt.transform.SetParent(gameObject.transform);
                camera.transform.localPosition = new Vector3(0, 2.93f, -5.09f);
                dirt.transform.localPosition = new Vector3(0, 0, 0);
                camera2.transform.localPosition = new Vector3(-0.09653568f, 6.25f, -5.22f);
                camera.transform.eulerAngles = transform.eulerAngles + new Vector3(15, 0, 0);
                camera.SetActive(true);
                camera2.SetActive(false);
                arrow.SetActive(false);
                arrow.transform.localScale = new Vector3(.3f, .9f, .3f);
                arrow.transform.localPosition = new Vector3(0, 0, 2);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                direction = 1;
                space = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Out") {
            space = 6;
            player.transform.position = new Vector3(0, 0, 0);
            strokes += 2;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision other) {
        thud.Play();
    }

}


