using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CalculateBMI : MonoBehaviour
{
    public InputField height;
    public InputField weight;
    public Text stsTxt;

    // CALCULATE BMI

    public void calculate(){
       
        var heightInCheck = checkHeightInputField();
        var weightInCheck = checkWeightInputFields();

        if(heightInCheck == true && weightInCheck == true){
            var hValCheck = negativeValueCheckTS(height.text);
            var wValCheck = negativeValueCheckTS(weight.text);
            if(hValCheck == true && wValCheck == true){
                var _height = float.Parse(height.text);
                var _weight = float.Parse(weight.text);
                var checkheightDigits = checkValueDigits(_height);
                var checkweightDigits = checkValueDigits(_weight);
                if(checkheightDigits == true && checkweightDigits == true){
                    var result = calculateBMI(_height,_weight);
                    Debug.Log("BMI: " + result);
                    getBMIResults(result);
                }else {
                    stsTxt.GetComponent<UnityEngine.UI.Text>().text = "Height, weight exceeds digits allowed";
                }
            }
            else{
                stsTxt.GetComponent<UnityEngine.UI.Text>().text = "Negative values are not allowed";
            }
            
        }       
    }

    public void getBMIResults(double bmi){

        var bmiRes = getBMIResultsTS(bmi);

        switch(bmiRes)
        {
        case "underweight":
            Debug.Log("You're underweight.");
            stsTxt.GetComponent<UnityEngine.UI.Text>().text = "You're underweight.";
            stsTxt.GetComponent<UnityEngine.UI.Text>().color=Color.red;
            break;
        case "overweight":
            Debug.Log("You're Overweight.");
            stsTxt.GetComponent<UnityEngine.UI.Text>().text = "You're Overweight.";
            stsTxt.GetComponent<UnityEngine.UI.Text>().color=Color.red;
            break;
        case "normal":
            Debug.Log("You're normal weight.");
            stsTxt.GetComponent<UnityEngine.UI.Text>().text = "You're normal weight.";
            stsTxt.GetComponent<UnityEngine.UI.Text>().color=Color.green;
            break;
        default:
            break;
        }
    }

    bool checkHeightInputField(){
        if(height.text.Length>1){
            return true;
        }
        else{
            stsTxt.GetComponent<UnityEngine.UI.Text>().text = "Please enter a valid height in cm";
            return false;
        }
    }

    bool checkWeightInputFields(){
        if(weight.text.Length>1){
            return true;
        }
        else{
            stsTxt.GetComponent<UnityEngine.UI.Text>().text = "Please enter a valid weight in kg";
            return false;
        }
    }

    public static void SendToGoogle(){
       //gScriptObj.GetComponent<SendToGSpreadsheet>().Send();
    }

    

    // static functions

    public static bool negativeValueCheckTS(string txt)
    {
        if (txt.Length > 0 && txt[0] == '-') {
            
            return false;
        }
        else{
            return true;
        }
        
    }

    public static string checkWeightInputFieldsTS(string txt){
        if(txt.Length>1){
            return "weight field is valid";
        }
        else{
            return "weight input field is empty";
        }
    }

    public static string checkHeightInputFieldsTS(string txt){
        if(txt.Length>1){
            return "height field is valid";
        }
        else{
            
            return "height input field is empty";
        }
    }

    public static bool checkValueDigits(double val){
        if(val < 999){
            return true;
        }else{
            return false;
        }
    }

    public static double calculateBMI(float height, float weight){
        double bmi = (float)weight / Mathf.Pow((float)height, 2);
        var bmiValue = System.Math.Round(bmi,4);
        return bmiValue;
        
    }

    public static string getBMIResultsTS(double bmi){
        string status = "";
        if (bmi <= 0.0018){
            status = "underweight";
        }
		else if (bmi > 0.0018 && bmi < 0.0023) {
            status = "normal";
        }
		else if (bmi >= 0.0023){
            status = "overweight";
        }

        return status;
    }

    

}
