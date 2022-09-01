using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMPro.TMP_InputField inputField;
    public bool Press;
    void Update()
    {
        if (Press || Input.GetKey(KeyCode.Insert))
        {
            Menu.Player = inputField.text;
            SceneManager.LoadScene(1);
            SceneManager.UnloadScene(0);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
