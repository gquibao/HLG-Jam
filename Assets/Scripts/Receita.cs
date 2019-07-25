using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Receita : MonoBehaviour
{
    public TextMeshProUGUI[] ingredientes = new TextMeshProUGUI[4];

    public void criarPedido()
    {
        foreach (TextMeshProUGUI txtIngrediente in ingredientes)
        {
            txtIngrediente.text = random().ToString();
        }
    }

    public int random()
    {
        int random = Random.Range(0, 4);
        return random;
    }
}
