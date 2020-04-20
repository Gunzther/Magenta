using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    private void Awake()
    {
        if (target == null)
        {
            print("Target of cam is null.");
            target = GameObject.FindGameObjectWithTag("player");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x - 7.5f, transform.position.y, target.transform.position.z + 4f);
    }
}
