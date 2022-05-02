using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodnessMetre : MonoBehaviour
{
    public Slider slider;

    public void SetMaxGoodness(int goodness)
    {
        slider.maxValue = goodness;

        slider.value = goodness; 
    }

    public void SetGoodness(int goodness) 
    {
        slider.value = goodness; 
    }
}
