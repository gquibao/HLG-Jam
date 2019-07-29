using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TelaFinal : MonoBehaviour
{
    public TextMeshProUGUI txt_Acertos, txt_Erros, txt_Total;
    public Image resultado;

    private void OnEnable()
    {
        resultado.gameObject.SetActive(false);
        txt_Acertos.text = "x0";
        txt_Erros.text = "-0";
        txt_Total.text = "x0";
        StartCoroutine(contarPontos());
    }

    IEnumerator contarPontos()
    {
        if (GameManager.instance.passouFase)
        {
            resultado.sprite = Resources.Load<Sprite>(Idioma.instance.iconeAprovado);
            int pontos = GameManager.instance.pontosFinais;
            switch (GameManager.instance.faseAtual)
            {
                case GameManager.FASE.FASE1:
                    if (pontos > PlayerPrefs.GetInt("Recorde1"))
                    {
                        PlayerPrefs.SetInt("Recorde1", pontos);
                    }
                    break;

                case GameManager.FASE.FASE2:
                    if (pontos > PlayerPrefs.GetInt("Recorde2"))
                    {
                        PlayerPrefs.SetInt("Recorde2", pontos);
                    }
                    break;

                case GameManager.FASE.FASE3:
                    if (pontos > PlayerPrefs.GetInt("Recorde3"))
                    {
                        PlayerPrefs.SetInt("Recorde3", pontos);
                    }
                    break;
            }
        }

        else
        {
            resultado.sprite = Resources.Load<Sprite>(Idioma.instance.iconeDemitido);
        }

        for (int i = 0; i <= GameManager.instance.pratosEntregues; i++)
        {
            yield return new WaitForSeconds(0.05f);
            txt_Acertos.text = "x" + i.ToString();
        }

        for (int i = 0; i <= GameManager.instance.pratosErrados; i++)
        {
            yield return new WaitForSeconds(0.05f);
            txt_Erros.text = "-" + i.ToString();
        }

        for (int i = 0; i <= GameManager.instance.pontosFinais; i++)
        {
            yield return new WaitForSeconds(0.05f);
            txt_Total.text = "x" + i.ToString();
        }

        yield return new WaitForSeconds(1);
        resultado.gameObject.SetActive(true);
    }
}
