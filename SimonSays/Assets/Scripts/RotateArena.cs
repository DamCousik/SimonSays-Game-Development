using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArena : MonoBehaviour
{
    //float rotation = 0.0f;
    // Start is called before the first frame update
    //float rotationAngle = 80;
    //float smoothTime = 1.0f;
    //private Vector3 currentRotation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,Time.deltaTime*40,0));

        //currentRotation = gameObject.transform.eulerAngles;
        //transform.rotation = Quaternion.Euler(0, 360, 0 );

        //Quaternion desiredRotation = Quaternion.Euler (0,rotationAngle,0);
        //transform.rotation = Quaternion.Lerp (transform.rotation, desiredRotation, smoothTime);


       /* if (rotation <= 180.0f ) {
                 rotation = rotation + Time.deltaTime;
      }
        transform.Rotate (new Vector3 (0.0f, rotation, 0.0f));
        
      */
    
    }

    
}
