using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private TextMeshProUGUI fpsTMP;

    private void Awake()
    {
        fpsTMP = gameObject.GetComponent<TextMeshProUGUI>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        fpsTMP.text = Mathf.RoundToInt(1 / Time.deltaTime).ToString();
    }
}
