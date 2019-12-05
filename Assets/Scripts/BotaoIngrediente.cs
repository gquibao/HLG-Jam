using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class BotaoIngrediente : MonoBehaviour
{
    public int id;
    public string ingredientName;
    public GameObject prefab;

    SerialPort sp = new SerialPort("COM3", 9600);

    private void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    private void Update()
    {
        try
        {
            print(sp.ReadLine());
            Debug.Log(ingredientName == sp.ReadLine());
            if (ingredientName  == sp.ReadLine())
            {
                CreateIngredients();
            }
        }
        catch (System.Exception)
        {

        }
    }

    private void OnMouseDown()
    {
        CreateIngredients();
    }

    private void CreateIngredients()
    {
        if (GameManager.instance.ordemIngredientes.Count < 4 && GameManager.instance.isJogoOn)
        {
            GameManager.instance.click.Play();
            Transform spawnerPosition = transform;
            Transform[] transforms = FindObjectsOfType<Transform>();
            foreach (Transform transform in transforms)
            {
                if (transform.gameObject.tag == "Spawner")
                {
                    spawnerPosition = transform;
                }
            }
            GameObject go = Instantiate(prefab, spawnerPosition.position, spawnerPosition.rotation);
            go.GetComponent<Ingrediente>().id = id;
            GameManager.instance.adicionarIngredienteALuz(go.GetComponent<Ingrediente>());
        }
    }
}
