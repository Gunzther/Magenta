using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TofuTracking : MonoBehaviour
{
    public Transform Tofu;
    private float hight;

    // Start is called before the first frame update
    void Start()
    {
        hight = this.transform.position.y - Tofu.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Tofu.position.x, Tofu.position.y + hight, Tofu.position.z);
    }
}
