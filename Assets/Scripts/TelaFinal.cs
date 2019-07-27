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
            resultado.sprite = Resources.Load<Sprite>("aprovado");
        }

        else
        {
            resultado.sprite = Resources.Load<Sprite>("demitido");
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

        yield return new WaitForSeconds(2);
        resultado.gameObject.SetActive(true);
    }
}
