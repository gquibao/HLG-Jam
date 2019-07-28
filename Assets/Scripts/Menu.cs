using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    public GameObject menuConfig;
    public GameObject menuCreditos;
    public GameObject selecaoFase;

    public Image btIniciar;
    public Image btCreditos;
    public Image btConfig;
    public Image btSair;
    public TextMeshProUGUI txtConfiguracoes;
    public TextMeshProUGUI txtAudio;
    public TextMeshProUGUI txtSelecaoIdioma;
    public TextMeshProUGUI txtCreditos;
    public TextMeshProUGUI txtProgramador;
    public TextMeshProUGUI txtArtista;
    public TextMeshProUGUI txtMusicas;

    public TextMeshProUGUI recordeFase1;
    public TextMeshProUGUI recordeFase2;
    public TextMeshProUGUI recordeFase3;

    public Button fase1;
    public Button fase2;
    public Button fase3;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Fase1"))
            PlayerPrefs.SetInt("Fase1", 0);

        else
        {
            if (PlayerPrefs.GetInt("Fase1") == 0)
            {
                fase2.interactable = false;
            }

            else
            {
                fase2.interactable = true;
            }
        }

        if (!PlayerPrefs.HasKey("Fase2"))
            PlayerPrefs.SetInt("Fase2", 0);

        else
        {
            if(PlayerPrefs.GetInt("Fase2") == 0)
            {
                fase3.interactable = false;
            }

            else
            {
                fase3.interactable = true;
            }
        }

        if (!PlayerPrefs.HasKey("Recorde1"))
            PlayerPrefs.SetInt("Recorde1", 0);

        if (!PlayerPrefs.HasKey("Recorde2"))
            PlayerPrefs.SetInt("Recorde2", 0);

        if (!PlayerPrefs.HasKey("Recorde3"))
            PlayerPrefs.SetInt("Recorde3", 0);

        recordeFase1.text = PlayerPrefs.GetInt("Recorde1").ToString();
        recordeFase2.text = PlayerPrefs.GetInt("Recorde2").ToString();
        recordeFase3.text = PlayerPrefs.GetInt("Recorde3").ToString();
}

    public void Jogar()
    {
        selecaoFase.SetActive(!selecaoFase.activeSelf);
    }

    public void iniciarLevel(string fase)
    {
        SceneManager.LoadScene(fase);
    }

    public void Creditos()
    {
        menuCreditos.SetActive(!menuCreditos.activeSelf);
    }

    public void Config()
    {
        menuConfig.SetActive(!menuConfig.activeSelf);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void alterarIdioma()
    {
        btIniciar.sprite = Resources.Load<Sprite>(Idioma.instance.btIniciar);
        btCreditos.sprite = Resources.Load<Sprite>(Idioma.instance.btCreditos);
        btConfig.sprite = Resources.Load<Sprite>(Idioma.instance.btConfig);
        btSair.sprite = Resources.Load<Sprite>(Idioma.instance.btSair);
        txtConfiguracoes.text = Idioma.instance.txtConfiguracoes;
        txtAudio.text = Idioma.instance.txtAudio;
        txtSelecaoIdioma.text = Idioma.instance.txtSelecaoIdioma;
        txtCreditos.text = Idioma.instance.txtCreditos;
        txtProgramador.text = Idioma.instance.txtProgramador;
        txtArtista.text = Idioma.instance.txtArtista;
        txtMusicas.text = Idioma.instance.txtMusicas;
    }
}

