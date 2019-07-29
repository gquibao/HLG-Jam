using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Receita : MonoBehaviour
{
    public TextMeshProUGUI[] ingredientes = new TextMeshProUGUI[4];
    public List<int> ingredientesID = new List<int>();
    public Image resultado;

    private void Start()
    {
        resultado.enabled = false;
    }

    public void criarPedido()
    {
        foreach (TextMeshProUGUI txtIngrediente in ingredientes)
        {
            txtIngrediente.text = random();
        }
    }

    public string random()
    {
        string retorno = "";
        int random = Random.Range(0, 5);
        ingredientesID.Add(random);
        switch(random)
        {
            case 0:
                retorno = Idioma.instance.ingrediente1;
                break;

            case 1:
                retorno = Idioma.instance.ingrediente2;
                break;

            case 2:
                retorno = Idioma.instance.ingrediente3;
                break;

            case 3:
                retorno = Idioma.instance.ingrediente4;
                break;

            case 4:
                retorno = Idioma.instance.ingrediente5;
                break;
        }

        return retorno;
    }
}
