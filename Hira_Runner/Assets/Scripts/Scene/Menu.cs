using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static string Player;
    public TMPro.TextMeshPro PlayerText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerText.SetText("Jogador: "+Player);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.Insert))
        {
            SceneManager.LoadScene(2);
            SceneManager.UnloadScene(1);
        }
    }
}
