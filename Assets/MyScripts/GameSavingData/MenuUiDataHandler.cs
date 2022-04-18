using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class MenuUiDataHandler : MonoBehaviour
{
    public TMP_InputField inputField;

    public GameObject CAR;
    public GameObject TANK;

    public void KeepCurrentName()
    {
        string s;
        s = inputField.text;
        SavingData.Instance._name = s;
    }

    public void KeepCar()
    {
        SavingData.Instance._vehicle = CAR;

        if (inputField.text != "")
        {
            SceneManager.LoadScene(1);
        }
    }

    public void KeepTank()
    {
        SavingData.Instance._vehicle = TANK;

        if (inputField.text != "")
        {
            SceneManager.LoadScene(1);
        }
    }
}
