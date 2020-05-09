using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoorOpenTrigger : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "playerBase")
        {
            anim.SetBool("open", true);
        }
    }
}
