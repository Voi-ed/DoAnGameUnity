using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image fillBar;
    [SerializeField] TextMeshProUGUI ValueText;

    public void UpdateHealth(int currentValue,int MaxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)MaxValue;
        ValueText.text = currentValue.ToString()+"/"+MaxValue.ToString();

    }
}
