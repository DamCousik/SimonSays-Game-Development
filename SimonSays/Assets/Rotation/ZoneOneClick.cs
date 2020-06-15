using UnityEngine;
 using System.Collections;
 using UnityEngine.EventSystems;
 using UnityEngine.SceneManagement;
 
 public class ZoneOneClick : MonoBehaviour {


     //public float rayLength;
     //public LayerMask layermask;


     private void Update(){

         if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
             Debug.Log("Doing Ray test");
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out hit, Mathf.Infinity))
             {
                 //Debug.Log("Selected" +hit.name);
                 Debug.Log("Hit Somthing" +hit.transform.tag);
                 //Replace this with whatever logic you want to use to validate the objects you want to click on
                 if(hit.collider.gameObject.name == "zone1")
                 {
                     SceneManager.LoadScene("Zone-A-Screen");
                 }
             }
         }


     }
 }

     
     
     //void Start() {       
         //OnMouseDown();
      //   Update();
    // }
          
      //void OnMouseDown ()
      //{
          //if(Input.GetMouseButton(1)) {
       //   SceneManager.LoadScene("Zone1Scene");
        //}
      //}


      /*void Update() {

           if (Input.GetMouseButtonDown(0))
         {
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out hit, 100.0f))
             {
                 //Replace this with whatever logic you want to use to validate the objects you want to click on
                 if(hit.collider.gameObject.name == "zone1")
                 {
                     SceneManager.LoadScene("Zone1Scene");
                 }
             }
         }



      }*/
   

 

