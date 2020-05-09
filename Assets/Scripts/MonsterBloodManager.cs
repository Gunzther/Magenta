using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBloodManager : MonoBehaviour
{
    public Animator mapAnim;
    public int spawn;
    public GameObject bloodGO, basementGO, tofu;
    public CameraController cam;

    private int count;
    private bool showed;

    private void Awake()
    {
        spawn = -1;
        count = 0;
        showed = false;
    }

    public void Update()
    {
        if (!showed && spawn == count && transform.GetChild(count).childCount == 0)
        {
            print("blood plus: " + spawn + ", "+ count);
            if(count == 5)
            {
                tofu.GetComponent<TofuController>().repairing = true;
                Invoke("ShowBlood", 2f);
                Invoke("ShowBasement", 1f);
                Invoke("BackToTofu", 6f);
                showed = true;
            }
            mapAnim.SetTrigger("bloodIn");
            if(count < 5) count++;
        }
    }

    private void ShowBlood()
    {
        cam.target = bloodGO.transform;
    }

    private void ShowBasement()
    {
        cam.target = basementGO.transform;
    }

    private void BackToTofu()
    {
        tofu.GetComponent<TofuController>().repairing = false;
        cam.target = tofu.transform;
    }
}
