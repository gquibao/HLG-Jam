using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoIngrediente : MonoBehaviour
{
    public int id;
    public GameObject prefab;

    private void OnMouseDown()
    {
        if (GameManager.instance.ordemIngredientes.Count < 4 && GameManager.instance.isJogoOn)
        {
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
