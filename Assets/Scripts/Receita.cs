using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Receita : MonoBehaviour
{
    public TextMeshProUGUI[] ingredientes = new TextMeshProUGUI[4];
    public TextMeshProUGUI resultado;
    public int contador = 0;

    public void criarPedido()
    {
        ingredientes[0].text = random().ToString();
        ingredientes[1].text = random().ToString();
        ingredientes[2].text = random().ToString();
        ingredientes[3].text = random().ToString();
    }

    public int random()
    {
        int random = Random.Range(0, 2);
        return random;
    }

    public void pontos()
    {
        StartCoroutine(contarPontos());
    }

    IEnumerator contarPontos()
    {
        if (GameManager.instance.ordemIngredientes[contador].id == int.Parse(ingredientes[contador].text))
        {
            ingredientes[contador].color = Color.green;
            GameManager.instance.pontos++;
        }
        else
        {
            ingredientes[contador].color = Color.red;
        }

        contador++;

        if (contador == 4)
        {
            StartCoroutine(contarPontos());
        }

        if (GameManager.instance.pontos >= ingredientes.Length)
        {
            resultado.text = "ACERTOU";
            resultado.color = Color.green;
        }
        else
        {
            resultado.text = "ERROU";
            resultado.color = Color.red;
        }

        yield return new WaitForSeconds(2);

        foreach (GameObject objIngrediente in GameManager.instance.objIngredientes)
        {
            Destroy(objIngrediente);
        }
        GameManager.instance.ordemIngredientes.Clear();
        GameManager.instance.pontos = 0;
        contador = 0;

        foreach (TextMeshProUGUI textoIngrediente in ingredientes)
        {
            textoIngrediente.color = Color.white;
            textoIngrediente.text = "";
        }
        resultado.text = "";
    }
}
