using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject prefabPedido;
    public Transform varalPedidos;

    public List<Ingrediente> ordemIngredientes = new List<Ingrediente>();
    public List<Receita> ordemReceitas = new List<Receita>();

    public int pontos = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        criarNovoPedido();
        StartCoroutine(spawnarNovosPedidos());
    }

    public void adicionarIngredienteALuz(Ingrediente ingrediente)
    {
        ordemIngredientes.Add(ingrediente);
        if (ordemIngredientes.Count == 4)
        {
            comparar();
        }
    }

    public void criarNovoPedido()
    {
        GameObject go = Instantiate(prefabPedido, varalPedidos);
        go.GetComponent<Receita>().criarPedido();
        ordemReceitas.Add(go.GetComponent<Receita>());
    }

    public void comparar()
    {
        int contadorAcertos = 0;

        for (int i = 0; i < ordemIngredientes.Count; i++)
        {
            if (ordemIngredientes[i].id == int.Parse(ordemReceitas[0].ingredientes[i].text))
            {
                contadorAcertos++;
            }
        }

        if (contadorAcertos >= 4)
        {
            Debug.Log("Acertou");
            pontos++;
            StartCoroutine(limparListas());
        }

        else
        {
            pontos--;
            StartCoroutine(limparListas());
        }
    }

    IEnumerator limparListas()
    {
        yield return new WaitForSeconds(2);
        foreach (Ingrediente ingrediente in ordemIngredientes)
        {
            Destroy(ingrediente.gameObject);
        }
        ordemIngredientes.Clear();
        Destroy(ordemReceitas[0].gameObject);
        ordemReceitas.RemoveAt(0);

        if (ordemReceitas.Count <= 0)
        {
            criarNovoPedido();
        }
    }

    IEnumerator spawnarNovosPedidos()
    {
        yield return new WaitForSeconds(5);
        if (ordemReceitas.Count < 3)
        {
            criarNovoPedido();
        }
        StartCoroutine(spawnarNovosPedidos());
    }
}
