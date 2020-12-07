using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Utils : MonoBehaviour
{
    private static Utils instance;
    
    void Awake(){

        if (instance == null){

            instance = this;
            DontDestroyOnLoad(this.gameObject);
    
            //Rest of your Awake code
    
        } else {
            Destroy(this);
        }
    }
 
     public static void StaticStart()
     {
         Debug.Log ("call received");
         instance.StartCoroutine (instance.FadeOut());
     }

     public static Coroutine StartCoroutineStatic() {
        return instance.StartCoroutine("FadeOut");
     }
 
     IEnumerator FadeOut()
     {
         yield return new WaitForSeconds (1f);
         Debug.Log ("call completed");
     }
}
