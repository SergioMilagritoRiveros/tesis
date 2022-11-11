using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    private AudioSource sonidoMenu;
    // Start is called before the first frame update
    void Start()
    {
     sonidoMenu = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
public void escenaNivel1(){

    SceneManager.LoadScene("Concentrece");
    sonidoMenu.Play();
}
public void escenaNivel2(){

    SceneManager.LoadScene("Jumanji");
     sonidoMenu.Play();
}
public void escenaNivel3(){

    SceneManager.LoadScene("Puertas");
     sonidoMenu.Play();
}

}
