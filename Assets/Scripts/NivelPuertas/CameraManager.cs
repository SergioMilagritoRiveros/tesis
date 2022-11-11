//using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
     
     

    public Transform orientacion;
    public float sensibilidadx;
    public  float sensibilidady;
    float rotacionx;
    float rotaciony;
    
 
    private void Start(){

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    private void Update()
     {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensibilidadx;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensibilidady;

        rotaciony += mouseX;

        rotacionx -= mouseY;
        rotacionx = Mathf.Clamp(rotacionx,-90f, 90f);

        transform.rotation = Quaternion.Euler(rotacionx, rotaciony,0);
        orientacion.rotation = Quaternion.Euler(0,rotaciony,0);
     }
 

 void LateUpdate() {
      
    }
}