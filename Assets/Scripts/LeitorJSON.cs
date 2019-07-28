using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LeitorJSON : MonoBehaviour
{
    private void Start()
    {
        lerJSON("Ingles");
        Menu.instance.alterarIdioma();
    }


    void lerJSON(string nomeJSON)
    {
        TextAsset json = Resources.Load(nomeJSON) as TextAsset;
        Idioma idiomaAtual = JsonUtility.FromJson<Idioma>(json.ToString());
        Idioma.instance = idiomaAtual;
    }

    public void trocarIdioma(string idioma)
    {
        lerJSON(idioma);
        Menu.instance.alterarIdioma();
    }
}
