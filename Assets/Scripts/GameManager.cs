using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject prefabPedido;

    public int pontos = 0;
    public Transform varalPedidos;

    public List<Ingrediente> ordemIngredientes = new List<Ingrediente>();
    public List<GameObject> objIngredientes = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(criarNovoPedido());
    }

    IEnumerator criarNovoPedido()
    {
        yield return new WaitForSeconds(10);
        GameObject go = Instantiate(prefabPedido, varalPedidos);
        go.GetComponent<Receita>().criarPedido();
        StartCoroutine(criarNovoPedido());
    }

    public void addIngrediente(Ingrediente ingrediente, GameObject objIngrediente)
    {
        ordemIngredientes.Add(ingrediente);
        objIngredientes.Add(objIngrediente);

        if (ordemIngredientes[contador].id == int.Parse(ingredientes[contador].text))
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
    }
}
