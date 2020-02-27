using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginForm : MonoBehaviour
{
    public InputField userField;
    public InputField passwordField;
    
    public void CheckUserAndPassword()
    {
        if(userField.text == passwordField.text)
        {
            print("pass");
            SceneManager.LoadScene(1);
        }
        else
        {
            print("please try again");
        }
    }
}
