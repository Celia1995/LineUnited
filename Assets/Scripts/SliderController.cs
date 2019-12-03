using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    Slider slider;
    public TextMeshProUGUI texto;

    public void Awake()
    {
        slider = GetComponent<Slider>();
        OnSliderChange();
    }

    public void OnSliderChange()
    {
        texto.text = (slider.value*10).ToString("f0");
    }
       
}
