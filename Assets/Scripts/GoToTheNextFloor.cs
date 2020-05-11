using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTheNextFloor : MonoBehaviour
{
    public GameObject tofu, endPanel;
    public Animator miniTofuAnim;
    public CameraController cam;

    private Animator warpAnim, tofuAnim;
    private TofuController tofuController;

    private void Awake()
    {
        warpAnim = transform.parent.GetComponent<Animator>();
        tofuAnim = tofu.transform.GetComponent<Animator>();
        tofuController = tofu.transform.GetComponent<TofuController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            cam.end = true;
            tofuController.repairing = true;
            miniTofuAnim.SetBool("up", true);
            Invoke("TofuUp", 2f);
            Invoke("NextScene", 7f);
        }
    }

    private void TofuUp()
    {
        tofuAnim.enabled = true;
        warpAnim.SetBool("close", true);
        endPanel.SetActive(true);
    }

    private void NextScene()
    {
        SceneManager.LoadScene(0);
    }
}
