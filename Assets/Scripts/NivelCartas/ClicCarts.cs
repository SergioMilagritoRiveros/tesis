using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClicCarts : MonoBehaviour
{       
        private Rigidbody rb;
        private AudioSource voltearCarta;        
        private GameObject cartaSeleccionada;
        private GameObject carta1 = null;
        private GameObject carta2; 
        private GameObject [] cartasAdestruir;
        public GameObject mostrarPuntuacion;
        private int puntuacion = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        voltearCarta = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         laser();
    }

    public void laser(){
        if (Input.GetMouseButtonDown(0))
         {
             RaycastHit raycastHit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out raycastHit, 100f))
             {
                 if (raycastHit.transform != null)
                 {
                     CurrentClickedGameObject(raycastHit.transform.gameObject);
                     
                 }
             }
         }

    }
    

  public void CurrentClickedGameObject(GameObject gameObject)
 {
    cartaSeleccionada = gameObject;  
    print(cartaSeleccionada.tag);
    if (carta1==null)
    {
        carta1 = cartaSeleccionada;
        print("la carta 1 seleccionada es: "+carta1.tag);
        voltearCarta.Play();
        carta1.SetActive(false);
      
    }
    else if(carta1!=null)
    {
      carta2 = cartaSeleccionada;
        print("la carta 2 seleccionada es: "+carta2.tag);
        voltearCarta.Play();
        carta2.SetActive(false);
    }   
    if (carta1!=null && carta2!=null)
    {
        StartCoroutine("mostrarCartas");
         
    }
    if (puntuacion == 8)
    {
       StartCoroutine("adiosJuego");
    }
    
 }


    public IEnumerator mostrarCartas(){
        yield return new WaitForSecondsRealtime (1);
        print ("2");
        desaparecerCarta();
     }

    public IEnumerator adiosJuego()
    {
        yield return new WaitForSecondsRealtime (1);
        escenaMenuInicio();
    }

    public void regresarCarta1(GameObject cartaVoletada){
         cartaVoletada.SetActive(true);
         print ("la carta fallida es: "+cartaVoletada.tag);
         carta1= null;   
    }

    public void regresarCarta2(GameObject cartaVoletada){
         cartaVoletada.SetActive(true);
         print ("la carta fallida es: "+cartaVoletada.tag);
         carta2 = null;
    }

  public void desaparecerCarta()
  {
    if (carta1.tag == carta2.tag)
    {
        print("son pares");
       cartasAdestruir = GameObject.FindGameObjectsWithTag(carta1.tag); 
       foreach (GameObject cartita in cartasAdestruir)
       {
            GameObject.Destroy(cartita);
            carta1= null;
            carta2 = null;
       }
        puntuacion++;
        mostrarPuntuacion.GetComponent<Text>().text = "" + puntuacion;
    }else
    {
        regresarCarta1(carta1);
        regresarCarta2(carta2);
      
    }
  }
   public void escenaMenuInicio()
    {
        SceneManager.LoadScene("Menu");
    }
    
  }


