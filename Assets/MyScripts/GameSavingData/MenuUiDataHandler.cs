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

        ChangeScene();
    }

    public void KeepTank()
    {
        SavingData.Instance._vehicle = TANK;

        ChangeScene();
    }

    private void ChangeScene()
    {
        if (inputField.text != "")
        {
            SceneManager.LoadScene(1);
        }
    }
}
