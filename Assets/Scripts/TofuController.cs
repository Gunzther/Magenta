using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TofuController : MonoBehaviour
{
    public float speed;
    public bool openBag;

    int floorMask;                      
    float camRayLength = 100f;
    Vector3 movement;
    Rigidbody rb;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Physics.IgnoreLayerCollision(10, 11);
        Physics.IgnoreLayerCollision(12, 13);
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!openBag)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Move(h, v);
            Turning();
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Turning() //turning to the mouse point
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }
}
