using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosMenu : MonoBehaviour
{
    public GameObject _panelCreditos;

    public void ExibirMenu(bool _show)
    {
        _panelCreditos.SetActive(_show);
    }
   
}
