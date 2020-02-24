using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float jumpPow = 10f;
    Vector3[] v3 = { Vector3.left, Vector3.right, Vector3.forward, Vector3.back };
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(v3[Random.Range(0, 4)] * jumpPow, ForceMode.Impulse);
            rb.AddForce(Vector3.up * jumpPow, ForceMode.Impulse);
        }
        if (transform.position.y < -50)
        {
            transform.position = new Vector3(0, 0.5f, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Horizontal")*15f, 0, Input.GetAxis("Vertical")*15f);
    }
}
