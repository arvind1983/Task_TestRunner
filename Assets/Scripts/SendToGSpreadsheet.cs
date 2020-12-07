using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SendToGSpreadsheet : MonoBehaviour
{
    static public SendToGSpreadsheet instance;
    string testName;
    string testResult;

    string[] testNames = new string[] {"ValidateNegativeValuesInInputField", "ValidateWeightInputFieldIsEmpty", "ValidateHeightInputFieldIsEmpty",
    "ValidateHeightInputFieldIsNotEmpty","ValidateWeightInputFieldIsNotEmpty","ValidateBMICalculation","ValidateBMIOverWeight","ValidateBMIUnderWeight",
    "ValidateBMINormalWeight","ValidateWeightNotExceed3digits","ValidateWeightNotExceedsMore3digits"};

    void Awake() {
        instance = this;
    }

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSecf0S0G4jS6nUKTd_q0suN0qI64cAOy-ywJAwtNx7zJ3sJbA/formResponse";

    IEnumerator PostData(string testName, string testResult) {
        WWWForm form = new WWWForm();
        form.AddField("entry.1084823695", testName);
        form.AddField("entry.445978170", testResult);
 
        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Data sent to Google Spreadsheets!");
        }
    }
    public void Send() {
        foreach (string tName in testNames)
        {
            SendData(tName,"Pass");
        }
        //SendData("ValidateWeightInputFieldIsEmpty","Pass");

    }

    public void SendData(string testName, string testResult){

        instance.StartCoroutine(PostData(testName, testResult));
    }
}
