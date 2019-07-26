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
                retorno = "Brocólis";
                break;

            case 1:
                retorno = "Peixe";
                break;

            case 2:
                retorno = "Frango";
                break;

            case 3:
                retorno = "Carne";
                break;

            case 4:
                retorno = "Uva";
                break;
        }

        return retorno;
    }
}
