using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWord : MonoBehaviour
{


    // void start() {


    // }

    // void update() {
        
    // }
    
    public float time = 1; //Seconds to read the text
    
     IEnumerator Start ()
     {
         yield return new WaitForSeconds(time);
         Destroy(gameObject);
    }


}



 
 
