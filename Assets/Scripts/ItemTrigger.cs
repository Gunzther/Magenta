using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTrigger : MonoBehaviour
{
    public GameObject ePanel;

    //float[] keyPosInBag = { 0.7f, 0, -0.7f, -1.4f, -2.1f, -2.8f };
    int itemPos, choosingItemIndex, keyIndex;
    bool foundKey, openBag;
    string keyName;
    GameObject foundedKeyGO;
    Transform bag;

    private void Awake()
    {
        bag = transform.parent.GetChild(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        itemPos = 0;
        openBag = false;
        foundKey = false;
        keyName = "";
        keyIndex = 0;
        choosingItemIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (foundKey && Input.GetKeyDown(KeyCode.E))
        {
            print("picked up key");
            AddToBag(foundedKeyGO.gameObject);
        }

        if (openBag)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if(choosingItemIndex > 0) choosingItemIndex -= 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (choosingItemIndex < bag.childCount - 1) choosingItemIndex += 1; 
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                keyName = bag.GetChild(choosingItemIndex).transform.name;
                keyIndex = choosingItemIndex;
                CloseBag();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && bag.childCount > 0)
        {
            bag.GetChild(0).position = new Vector3(transform.position.x - 1, 0.1f, transform.position.z);
            bag.GetChild(0).parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "key")
        {
            print("found key");
            ePanel.SetActive(true);

            if(bag.childCount > 0)
            {
                ePanel.GetComponentInChildren<Text>().text = "bag is full, press Q to drop item";
            }
            else
            {
                ePanel.GetComponentInChildren<Text>().text = "press E to pick up";
                foundedKeyGO = other.gameObject;
                foundKey = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "key")
        {
            ePanel.SetActive(false);
        }
    }

    void AddToBag(GameObject item)
    {
        item.transform.parent = bag;
        item.transform.localPosition = new Vector3(0, 0, 0);
        ePanel.SetActive(false);
        itemPos += 1;
    }

    public void ResetKeyPicked()
    {
        keyName = "";
        keyIndex = 0;
    }

    public void RemoveFromBag(int index)
    {
        itemPos -= 1;
        Destroy(bag.GetChild(index).gameObject);
        ResetKeyPicked();
    }

    public void OpenBag()
    {
        if(bag.childCount > 0)
        {
            foundKey = false;
            ePanel.SetActive(true);
            ePanel.GetComponentInChildren<Text>().text = "press SPACE to use item";

            bag.gameObject.SetActive(true);
            transform.parent.GetComponent<TofuController>().openBag = true;
            openBag = true;
        }
    }

    public void CloseBag()
    {
        ePanel.SetActive(false);
        bag.gameObject.SetActive(false);
        transform.parent.GetComponent<TofuController>().openBag = false;
        openBag = false;
        choosingItemIndex = 0;
    }

    public string GetKeyChose()
    {
        return keyName;
    }

    public int GetKeyChoseIndex()
    {
        return keyIndex;
    }
}
