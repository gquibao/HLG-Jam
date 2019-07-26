using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Config()
    {
        SceneManager.LoadScene("Config");
    }

    public void Quit()
    {
        Debug.Log("SAIU");
        Application.Quit();
    }
}

