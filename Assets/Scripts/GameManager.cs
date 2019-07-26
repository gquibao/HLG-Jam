using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject prefabPedido;
    public GameObject efeitoFumaca;

    public Transform varalPedidos;

    public List<Ingrediente> ordemIngredientes = new List<Ingrediente>();
    public List<Receita> ordemReceitas = new List<Receita>();

    public SpriteRenderer boloFinal;

    public Sprite[] bolos;
    public Sprite spr_Acerto;
    public Sprite spr_Erro;

    public int pratosEntregues = 0;
    public TextMeshProUGUI txt_PratosEntregues;
    public int pratosErrados = 0;

    float tempoNovaReceita = 10;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        txt_PratosEntregues.text = "x 0";
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
            if (ordemIngredientes[i].id == ordemReceitas[0].ingredientesID[i])
            {
                contadorAcertos++;
            }
        }

        if (contadorAcertos >= 4)
        {
            Debug.Log("Acertou");
            pratosEntregues++;
            txt_PratosEntregues.text = "x " + pratosEntregues;
            ordemReceitas[0].resultado.enabled = true;
            ordemReceitas[0].resultado.sprite = spr_Acerto;
            StartCoroutine(aparecerBolo());
            StartCoroutine(limparListas(true));
        }

        else
        {
            pratosErrados++;
            ordemReceitas[0].resultado.enabled = true;
            ordemReceitas[0].resultado.sprite = spr_Erro;
            StartCoroutine(limparListas(false));
        }
    }

    IEnumerator limparListas(bool isPonto)
    {
        yield return new WaitForSeconds(3);
        if (!isPonto)
        {
            foreach (Ingrediente ingrediente in ordemIngredientes)
            {
                Destroy(ingrediente.gameObject);
            }
        }
        boloFinal.sprite = null;
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
        yield return new WaitForSeconds(tempoNovaReceita);
        if (ordemReceitas.Count < 3)
        {
            criarNovoPedido();
        }
        StartCoroutine(spawnarNovosPedidos());
    }

    IEnumerator aparecerBolo()
    {
        yield return new WaitForSeconds(1);
        foreach (Ingrediente ingrediente in ordemIngredientes)
        {
            Destroy(ingrediente.gameObject);
        }
        efeitoFumaca.SetActive(true);
        boloFinal.sprite = bolos[Random.Range(0, bolos.Length)];
        yield return new WaitForSeconds(1);
        efeitoFumaca.SetActive(false);
    }
}
