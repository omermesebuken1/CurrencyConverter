using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Globalization;
using System;
using UnityEngine.UI;

public class BottomHud : MonoBehaviour
{

    [SerializeField] private NavBarController controller;
    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TextMeshProUGUI curr1Name;
    [SerializeField] private TextMeshProUGUI curr2Name;
    [SerializeField] private TextMeshProUGUI curr1Value;
    [SerializeField] private TextMeshProUGUI curr2Value;

    [SerializeField] private Color32 selectedColor;
    [SerializeField] private Color32 unselectedColor;

    private API api;

    private bool isCurr1Input = true;

    public string currencyName;
    public string exchangeRate;

    private float value1;
    private float value2;

    private void Awake()
    {
        api = FindObjectOfType<API>();
    }


    private void Update()
{
    if (curr1Value.text.Length > 10)
    {
        float tmpNum = float.Parse(curr1Value.text, new CultureInfo("tr-TR"));
        curr1Value.text = tmpNum.ToString("0.###E+0");
    }

    if (curr2Value.text.Length > 10)
    {
        float tmpNum = float.Parse(curr2Value.text, new CultureInfo("tr-TR"));
        curr2Value.text = tmpNum.ToString("0.###E+0"); 
    }
}


    public void ChangeNames()
    {
        isCurr1Input = false;
        ToggleCurrencyInput();
        header.text = currencyName + " / TRY: " + exchangeRate;
        curr1Name.text = currencyName;
        curr1Value.text = "0";
        curr2Value.text = "0";


    }

    public void AC()
    {
        curr1Value.text = "0";
        curr2Value.text = "0";
        value1 = 0;
        value2 = 0;
    }

    public void AddComma()
    {
        if (isCurr1Input)
        {
            if (!curr1Value.text.Contains(","))
            {
                curr1Value.text += ",";
            }
        }
        else
        {
            if (!curr2Value.text.Contains(","))
            {
                curr2Value.text += ",";
            }
        }
    }

    public void AddDigit(int digit)
    {
        if (isCurr1Input)
        {
            if (!curr1Value.text.Contains(","))
            {
                value1 = value1 * 10 + digit;
                curr1Value.text = FormatNumber(value1);
            }
            else
            {
                string[] parts = curr1Value.text.Split(',');
                string decimalPart = parts.Length > 1 ? parts[1] : "";
                int decimalPlaces = decimalPart.Length;
                float newValue = value1 + digit * Mathf.Pow(10, -decimalPlaces - 1);
                value1 = newValue;
                if (digit == 0)
                {
                    curr1Value.text = FormatNumberForAddingZero(curr1Value.text);
                }
                else
                {
                    curr1Value.text = FormatNumber(value1);
                }
            }
        }
        else
        {
            if (!curr2Value.text.Contains(","))
            {
                value2 = value2 * 10 + digit;
                curr2Value.text = FormatNumber(value2);
            }
            else
            {
                string[] parts = curr2Value.text.Split(',');
                string decimalPart = parts.Length > 1 ? parts[1] : "";
                int decimalPlaces = decimalPart.Length;
                float newValue = value2 + digit * Mathf.Pow(10, -decimalPlaces - 1);
                value2 = newValue;

                if (digit == 0)
                {
                    curr2Value.text = FormatNumberForAddingZero(curr2Value.text);
                }
                else
                {
                    curr2Value.text = FormatNumber(value2);
                }
            }
        }

        ConvertCurrency();
    }



    private string FormatNumberForAddingZero(string numberString)
    {
        return numberString + "0";
    }




    private string FormatNumber(float number)
{
    // Determine if the number has decimal places
    int decimalPlaces = 0;
    if (number % 1 != 0)
    {
        string[] parts = number.ToString(CultureInfo.GetCultureInfo("tr-TR")).Split(',');
        decimalPlaces = parts.Length > 1 ? parts[1].Length : 0;
    }
    return number.ToString("#,##0." + new string('0', decimalPlaces), CultureInfo.GetCultureInfo("tr-TR"));
    
}



    public void DeleteDigit()
    {
        if (isCurr1Input)
        {
            string valueString = curr1Value.text;

            // Check if the value contains a comma
            if (valueString.Contains(","))
            {
                // If there's a comma, remove the last character and update value1
                valueString = valueString.Remove(valueString.Length - 1);
                if (valueString.Length == 0)
                {
                    // If the string becomes empty, set value1 to 0
                    value1 = 0;
                }
                else
                {
                    // Otherwise, parse the updated string to float
                    value1 = float.Parse(valueString, new CultureInfo("tr-TR"));
                }
            }
            else
            {
                // If there's no comma, remove the last digit
                if (valueString.Length > 0)
                {
                    valueString = valueString.Remove(valueString.Length - 1);
                    value1 = valueString.Length > 0 ? float.Parse(valueString, new CultureInfo("tr-TR")) : 0;
                }
            }
            // Update the text of curr1Value
            curr1Value.text = FormatNumber(value1);
        }
        else
        {
            string valueString = curr2Value.text;
            if (valueString.Contains(","))
            {
                valueString = valueString.Remove(valueString.Length - 1);
                if (valueString.Length == 0)
                {
                    value2 = 0;
                }
                else
                {
                    value2 = float.Parse(valueString, new CultureInfo("tr-TR"));
                }
            }
            else
            {
                if (valueString.Length > 0)
                {
                    valueString = valueString.Remove(valueString.Length - 1);
                    value2 = valueString.Length > 0 ? float.Parse(valueString, new CultureInfo("tr-TR")) : 0;
                }
            }
            curr2Value.text = FormatNumber(value2);
        }

        ConvertCurrency();
    }

    public void ToggleCurrencyInput()
    {
        isCurr1Input = !isCurr1Input;
        curr1Value.text = "0";
        curr2Value.text = "0";
        value1 = 0;
        value2 = 0;

        if (isCurr1Input)
        {
            curr1Name.color = selectedColor;
            curr1Value.color = selectedColor;
            curr2Name.color = unselectedColor;
            curr2Value.color = unselectedColor;
        }
        else
        {
            curr2Name.color = selectedColor;
            curr2Value.color = selectedColor;
            curr1Name.color = unselectedColor;
            curr1Value.color = unselectedColor;
        }
    }

    public void ConvertCurrency()
    {
        float rate = float.Parse(api.GetYourSelling(currencyName),CultureInfo.GetCultureInfo("tr-TR"));

        if (isCurr1Input)
        {
            value2 = value1 * rate;
            curr2Value.text = FormatNumber(value2);
        }
        else
        {
            value1 = value2 / rate;
            curr1Value.text = FormatNumber(value1);
        }
    }

    public void changeToCurr1()
    {
        isCurr1Input = true;
        curr1Value.text = "0";
        curr2Value.text = "0";
        value1 = 0;
        value2 = 0;

        if (isCurr1Input)
        {
            curr1Name.color = selectedColor;
            curr1Value.color = selectedColor;
            curr2Name.color = unselectedColor;
            curr2Value.color = unselectedColor;
        }
        else
        {
            curr2Name.color = selectedColor;
            curr2Value.color = selectedColor;
            curr1Name.color = unselectedColor;
            curr1Value.color = unselectedColor;
        }
    }

    public void changeToCurr2()
    {
        isCurr1Input = false;
        curr1Value.text = "0";
        curr2Value.text = "0";
        value1 = 0;
        value2 = 0;

        if (isCurr1Input)
        {
            curr1Name.color = selectedColor;
            curr1Value.color = selectedColor;
            curr2Name.color = unselectedColor;
            curr2Value.color = unselectedColor;
        }
        else
        {
            curr2Name.color = selectedColor;
            curr2Value.color = selectedColor;
            curr1Name.color = unselectedColor;
            curr1Value.color = unselectedColor;
        }
    }

}
