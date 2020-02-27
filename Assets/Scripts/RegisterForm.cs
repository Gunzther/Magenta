using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterForm : MonoBehaviour
{
    public InputField userField, passwordField, ConfirmPasswordField;
    public Slider sliderAge;
    public Dropdown dropdownGender;
    public Toggle toggleAgree;
    public Text textAge;

    RegisterModel registerModel;

    public void SubmitForm()
    {
        registerModel = new RegisterModel();

        if(passwordField.text == ConfirmPasswordField.text && toggleAgree.isOn)
        {
            registerModel.UserName = userField.text;
            registerModel.Password = passwordField.text;
            registerModel.gender = dropdownGender.options[dropdownGender.value].text;
            registerModel.age = (int)sliderAge.value;
            registerModel.accepted = toggleAgree.isOn;
        }

        print(JsonUtility.ToJson(registerModel));
    }

    public void ShowAgeValue()
    {
        textAge.text = sliderAge.value.ToString();
    }
}
