using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Dynamic;
using System.Numerics;
using System.Diagnostics;
using System.Net.Mime;
using System.Globalization;
using System.Security.Cryptography;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;


public class ControlPlayer : MonoBehaviour
{
   private Rigidbody rb;
    public float speed;
    private int dado;
    private int totalContador;
    private bool botonActivo;
    private int casillaExtra = 0;

    public GameObject panelcito = null;
    public GameObject mostrarDado;
    public GameObject Playercito;
    private GameObject posicionFinal;
    public Button boton;
   private int contadorTabla;

    



void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

void Update()
    {

            
    }
 
public void LanzarDado(){
    dado = Random.Range(1,4);
    totalContador = totalContador +  dado;
    mostrarDado.GetComponent<Text>().text = "" + dado;
    
   
    print(totalContador +" "+ dado+" "+botonActivo);
        if(totalContador < 16){
            boton.enabled=false;
            botonActivo = false;
            StartCoroutine("EsperarYMover");
        }else {
            transform.position = new Vector3(GameObject.FindGameObjectWithTag("16").transform.position.x,GameObject.FindGameObjectWithTag("16").transform.position.y,GameObject.FindGameObjectWithTag("16").transform.position.z);
            mostrarDado.GetComponent<Text>().text = "termino el juego" ;
            print("termino el juego");
            boton.enabled=false;
        }
}

public IEnumerator EsperarYMover(){
    
        yield return new WaitForSecondsRealtime (1);
       moverFicha();
     }

public void moverFicha(){

            contarFichas();
          
            posicionFinal = GameObject.FindGameObjectWithTag(totalContador.ToString());
            transform.position = new Vector3(posicionFinal.transform.position.x,posicionFinal.transform.position.y,posicionFinal.transform.position.z);
            
            contadorTabla = totalContador - casillaExtra;   
       

            if (posicionFinal.gameObject.CompareTag("5")||posicionFinal.gameObject.CompareTag("12"))
            {  
                print("rojo");
                 StartCoroutine("echarAtras");   
            }
            if (posicionFinal.gameObject.CompareTag("8")||posicionFinal.gameObject.CompareTag("10")||posicionFinal.gameObject.CompareTag("14"))
            {
                print("verde");  
            }
            if(totalContador > 17)
                {
                 transform.position = new Vector3(GameObject.FindGameObjectWithTag("16").transform.position.x,GameObject.FindGameObjectWithTag("16").transform.position.y,GameObject.FindGameObjectWithTag("16").transform.position.z);
                }
             botonActivo = true;
             boton.enabled = true;
           
    }

    public IEnumerator echarAtras(){
    
        yield return new WaitForSecondsRealtime (1);
       retrocederPlayer();
     }
    private void retrocederPlayer(){
          posicionFinal = GameObject.FindGameObjectWithTag((totalContador -2).ToString());
          transform.position = new Vector3(posicionFinal.transform.position.x,posicionFinal.transform.position.y,posicionFinal.transform.position.z);
          botonActivo = true;
          boton.enabled = true;
          
    }

    private void contarFichas(){
        

                if (totalContador>4  )
                     {
                         casillaExtra= 1; 
                    }      
                 if (totalContador>7 )
                    {
                        casillaExtra= 2; 
                        }
                if (totalContador>9 )
                    {
                        casillaExtra= 3; 
                        }        
                if (totalContador> 11)
                    {
                        casillaExtra= 4; 
                        }        
                if (totalContador> 13)
                    {
                        casillaExtra= 2; 
                        }        
    }
    
}


