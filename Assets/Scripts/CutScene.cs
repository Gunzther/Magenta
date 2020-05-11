using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Play", 17.5f);
    }

    private void Play()
    {
        SceneManager.LoadScene(2);
    }
}
