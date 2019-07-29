using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{
    enum FALAS { FALA1, FALA2, FALA3, FALA4}
    FALAS falaAtual;
    public GameObject popupChef;
    public Image artePopupChef;
    UnityEvent evento;

    public void Start()
    {
        popupChef.SetActive(true);
        evento = new UnityEvent();
        switch(GameManager.instance.faseAtual)
        {
            case GameManager.FASE.FASE1:
                evento.AddListener(fala1);
                break;

            case GameManager.FASE.FASE2:
                evento.AddListener(fala3);
                break;

            case GameManager.FASE.FASE3:
                evento.AddListener(fala4);
                break;
        }
        evento.Invoke();
    }

    public void fala1()
    {
        falaAtual = FALAS.FALA1;
        artePopupChef.sprite = Resources.Load<Sprite>(Idioma.instance.fala1);
    }

    public void ok()
    {
        if (falaAtual == FALAS.FALA1)
            fala2();

        else
        {
            popupChef.SetActive(false);
            GameManager.instance.isJogoOn = true;
        }
    }

    public void fala2()
    {
        falaAtual = FALAS.FALA2;
        artePopupChef.sprite = Resources.Load<Sprite>(Idioma.instance.fala2);
    }

    public void fala3()
    {
        falaAtual = FALAS.FALA3;
        artePopupChef.sprite = Resources.Load<Sprite>(Idioma.instance.fala3);
    }

    public void fala4()
    {
        falaAtual = FALAS.FALA4;
        artePopupChef.sprite = Resources.Load<Sprite>(Idioma.instance.fala4);
    }
}
