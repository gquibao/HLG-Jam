using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Relogio : MonoBehaviour
{
    public static Relogio instance;
    private const float secondsToDegrees = 360f / 60;
    public float time = 0, tempoFill;
    public float tempoTotal = 10;
    public Image areaVermelha;

    private void Start()
    {
        tempoFill = tempoTotal;
        instance = this;
    }

    private void Update()
    {
        if (GameManager.instance.isJogoOn)
        {
            if (areaVermelha.fillAmount < 1)
            {
                time += Time.deltaTime;
                tempoFill += (1 / tempoTotal) * Time.deltaTime;
                areaVermelha.fillAmount = time / tempoFill;
            }

            else
            {
                GameManager.instance.fimDeJogo();
            }
        }
    }
}
