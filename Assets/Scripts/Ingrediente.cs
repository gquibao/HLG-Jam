using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    public int id;
    public GameObject prefab;

    private void OnMouseDown()
    {
        Transform spawnerPosition = transform;
        Transform[] transforms = FindObjectsOfType<Transform>();
        foreach(Transform transform in transforms)
        {
            if(transform.gameObject.tag == "Spawner")
            {
                spawnerPosition = transform;
            }
        }
        GameObject go = Instantiate(prefab, spawnerPosition.position, spawnerPosition.rotation);
        GameManager.instance.addIngrediente(this, go);
    }
}
