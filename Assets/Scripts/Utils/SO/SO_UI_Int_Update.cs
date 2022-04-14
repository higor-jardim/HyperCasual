using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SO_UI_Int_Update : MonoBehaviour
{
    public SO_Int soInt;
    public TextMeshProUGUI uiTextValue;

    void Start()
    {
        uiTextValue.text = soInt.value.ToString();
    }

    void Update()
    {
        uiTextValue.text = soInt.value.ToString();
    }
}
