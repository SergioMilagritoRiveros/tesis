
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

 [Header("movement")]

 public float speed;
private int puntuacion=0;
 public Transform orientacion;
  private float hor;
  private float ver;
  public GameObject openText = null;
  private GameObject puertaSeleccionada;
  private GameObject marcoPuerta;
  private Vector3 direccion;
  private Rigidbody rb;
  public GameObject mostrarPuntuacion;
  private AudioSource sonidoNivel;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.freezeRotation =true;
    sonidoNivel= GetComponent<AudioSource>();
    openText.SetActive(false);
  }
  private void FixedUpdate(){
    movimientoPlayer();
  }
  
  private void Update()
  {
    MyInput();
    if (isOpendoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                 openText.SetActive(false); 
                destruirPuerta();
            }
        }
    
  }

    private void MyInput(){
        hor= Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
       
    }

    private void movimientoPlayer(){
        direccion = orientacion.forward * ver + orientacion.right * hor;
        rb.AddForce(direccion.normalized * speed * 1f , ForceMode.Force);

    }

 private void OnTriggerEnter(Collider other) {
        if (other.tag =="door")         
        {
            print("toco");
            puertaSeleccionada= other.gameObject;
            openText.SetActive(true);
            adiospuerta();

        }else{
             openText.SetActive(false); 
        }
 }
private bool isOpendoor{

        get{
            return openText.activeInHierarchy ;
          }

          }


          public IEnumerator adiospuerta()
    {
        yield return new WaitForSecondsRealtime (1);
        destruirPuerta();
    }

          private void destruirPuerta(){
            puertaSeleccionada.SetActive(false); 
            puntuacion++;
            mostrarPuntuacion.GetComponent<Text>().text = "" + puntuacion;
          }
}
