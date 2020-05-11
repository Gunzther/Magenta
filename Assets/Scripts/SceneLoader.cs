using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator anim;

    public void StartGame()
    {
        anim.SetTrigger("playGame");
        Invoke("ShowCutScene", 3f);
    }

    public void Play()
    {

    }

    private void ShowCutScene()
    {
        SceneManager.LoadScene(1);
    }
}
