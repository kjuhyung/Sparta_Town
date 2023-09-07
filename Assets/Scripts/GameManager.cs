using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeTxt;

    float playTime;

    void Start()
    {
        
    }

    void Update()
    {
        playTime += Time.deltaTime;
        timeTxt.text = playTime.ToString("N1");
    }
}
