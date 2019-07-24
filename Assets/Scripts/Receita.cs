using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Receita : MonoBehaviour
{
    public TextMeshProUGUI[] ingredientes = new TextMeshProUGUI[4];

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
}
