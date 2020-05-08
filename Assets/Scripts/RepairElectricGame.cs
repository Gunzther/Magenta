using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairElectricGame : MonoBehaviour
{
    public ElectricityManager em;
    public GameObject repairPanel;

    int[] degrees = { 0, 90, 0, 0, 0, 180, 180, 90, 270 };
    bool[] result = new bool[9];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 9; i++)
        {
            result[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTrueAll())
        {
            em.SuccessRepair();
        }
    }

    public void Click(Transform img)
    {
        int i = int.Parse(img.name);

        float zRotation = img.eulerAngles.z + 90;
        if (zRotation == 360) zRotation = 0;
        img.eulerAngles = new Vector3(0, 0, zRotation);

        if(img.eulerAngles.z == degrees[i] || img.eulerAngles.z == degrees[i] + 180 || img.eulerAngles.z == degrees[i] - 180)
        {
            result[i] = true;
        }

        print(img.eulerAngles.z);
    }

    public void Close()
    {
        em.waitForE = true;
        em.ActiveTofu();
        repairPanel.SetActive(false);
    }

    private bool IsTrueAll()
    {
        for (int i = 0; i < 9; i++)
        {
            if (!result[i]) return false;
        }
        return true;
    }
}
