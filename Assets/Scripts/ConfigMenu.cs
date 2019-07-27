using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigMenu : MonoBehaviour
{
    public GameObject _panelConfig;

    public void ExibirMenu(bool _show)
    {
        _panelConfig.SetActive(_show);
    }
   
}
