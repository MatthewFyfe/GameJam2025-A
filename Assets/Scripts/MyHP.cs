using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyHP : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        // string myHP = ControlPoint.playerHP;
        // text.text = $"This computer's IP : {localIP}";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"HP : {ControlPointSP.playerHP}";
    }
}
