using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricityManager : MonoBehaviour
{
    public List<GameObject> lightRooms;
    public List<GameObject> doors;
    public GameObject ePanel;
    public GameObject repairPanel;
    public bool waitForE;

    private bool repaired;
    private Animator turretAnim;
    private TofuController tofuController;

    private void Awake()
    {
        turretAnim = transform.GetComponent<Animator>();
        tofuController = GameObject.FindObjectOfType<TofuController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        repaired = false;
        waitForE = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitForE && Input.GetKeyDown(KeyCode.E))
        {
            tofuController.repairing = true;
            ePanel.SetActive(false);
            repairPanel.SetActive(true);
            waitForE = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!repaired && other.transform.tag == "playerBase")
        {
            ePanel.SetActive(true);
            ePanel.GetComponentInChildren<Text>().text = "press E to repair";
            waitForE = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ePanel.SetActive(false);
        waitForE = false;
    }

    public void SuccessRepair()
    {
        tofuController.repairing = false;
        repaired = true;
        repairPanel.SetActive(false);
        turretAnim.SetBool("repair", true);

        Invoke("ActiveLight", 2);
    }

    void ActiveLight()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Animator>().SetBool("active", true);
        }

        foreach (GameObject light in lightRooms)
        {
            light.SetActive(true);
        }
    }

    public void ActiveTofu()
    {
        tofuController.repairing = false;
    }
}
