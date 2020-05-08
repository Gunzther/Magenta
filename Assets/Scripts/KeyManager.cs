using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public GameObject ePanel;
    public string keyColor;
    public bool doorActive;

    private bool keyCheckActive, waitForKey;
    private ItemTrigger player;
    private Animator anim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ItemTrigger>();
        anim = transform.parent.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        keyCheckActive = false;
        waitForKey = false;
        doorActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        string keyChose = player.GetKeyChose();
        int index = player.GetKeyChoseIndex();

        if (keyCheckActive && Input.GetKeyDown(KeyCode.E))
        {
            waitForKey = true;
            player.OpenBag();
        }

        if(waitForKey && IsOwnKey(keyChose))
        {
            print("door's open");
            player.RemoveFromBag(index);
            anim.SetBool("open", true);
            waitForKey = false;
        }

        if (waitForKey && keyChose != "" && !IsOwnKey(keyChose))
        {
            print("wrong key");
            //sound play()
            player.ResetKeyPicked();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(doorActive && !player.IsEmptyBag() && other.transform.tag == "playerBase")
        {
            ePanel.SetActive(true);
            ePanel.GetComponentInChildren<Text>().text = "press E to open bag";
            keyCheckActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            keyCheckActive = false;
            ePanel.SetActive(false);
        }
    }

    private bool IsOwnKey(string keyColorTracked)
    {
        if (keyColorTracked == keyColor) return true;
        return false;
    }
}
