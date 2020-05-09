using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoorCloseTrigger : MonoBehaviour
{
    public GameObject lightroom;
    private Animator anim;

    private void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "playerBase")
        {
            anim.SetBool("open", false);
            Invoke("OpenLight", 0.5f);
            transform.gameObject.SetActive(false);
        }
    }

    private void OpenLight()
    {
        lightroom.SetActive(true);
    }
}
