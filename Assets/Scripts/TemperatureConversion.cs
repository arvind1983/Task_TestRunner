using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureConversion : MonoBehaviour
{
    // FAH TO KEL

    public static float FahrenheitToKelvin(float fahrenheit)
    {
        return ((fahrenheit - 32f) * 5f) / 9f + 273.15f;
    }

    public static float FahrenheitToCel(float fahrenheit)
    {
        //(°F - 32) / 1.8 = °C
        return (fahrenheit - 32f) / 1.8f;
    }

    public static float CelToFahrenheit(float cel)
    {
        //(°C * 1.8) + 32 = °F
        return (cel * 1.8f) +32;
    }

    public void tempFtoK()
    {
        var tempRes = FahrenheitToKelvin(212F);
        Debug.Log("Temperature results " + tempRes);
    }

    public void tempCtoF()
    {
        var tempRes = CelToFahrenheit(18F);
        Debug.Log("Temperature results " + tempRes);
    }

    public void tempFtoC()
    {
        var tempRes = FahrenheitToCel(101.3F);
        Debug.Log("Temperature results " + tempRes);
    }
}
