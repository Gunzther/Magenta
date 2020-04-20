using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float speed;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
        if (Input.GetKey(KeyCode.RightArrow)) transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        if (Input.GetKey(KeyCode.UpArrow)) transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.DownArrow)) transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        if (transform.position.y <= -5) transform.position = new Vector3(0, 2f, 0.1f);
    }
}
