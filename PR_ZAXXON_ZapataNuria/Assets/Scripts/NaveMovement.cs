using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaveMovement : MonoBehaviour
{
    //Movimiento de desplazamiento
    [SerializeField] float desplSpeed;
    [SerializeField] InitScript initScript;
    //Variables para la restricción de movimiento
    float limiteR = 10;
    float limiteL = -10;
    float limiteU = 10;
    float limiteS = 1;

    //Variable booleana que determina si puedo moverme o no
    bool inLimitH = true;
    bool inLimitV = true;

    [SerializeField]GameObject nave; 

    // Start is called before the first frame update
    void Start()
    {
        initScript = GameObject.Find("initObject").GetComponent<InitScript>();
        desplSpeed = 10f;
        
    }


    // Update is called once per frame
    
    void Update()
    {
        //Obtengo los valores de los ejes y los asigno a variables
    
        float desplH = Input.GetAxis("Horizontal");
        float desplV = Input.GetAxis("Vertical");


        //Variables de posición en X y en Y para la restricción
        float posX = transform.position.x;
        float posy = transform.position.y;

        // H and V Movement Restricted
       // (si está en el límite de H true, se moverá)
        if (inLimitH)
        {
            transform.Translate(Vector3.right * Time.deltaTime * desplH * desplSpeed, Space.World);
        }

        // (si está en el límite de V true, se moverá)
        if (inLimitV)
        {
            transform.Translate(Vector3.up * Time.deltaTime * desplV * desplSpeed, Space.World);
        }
        // Si la posicion de x supera el límite de la derecha y está en la zona +0 (derecha) ooooo la posicion de x supera el límite de la izquierda y está en la zona de la izq, no se moverá)
        if (posX > limiteR && desplH > 0 || posX < limiteL && desplH < 0)
        {
            inLimitH = false;
        }
        // si no cumple eso, sí se moverá
        else
        {
            inLimitH = true;
        }
        // igual que antes pero en vertical.
        if (posy > limiteU && desplV > 0 || posy < limiteS && desplV < 0)
        {
            inLimitV = false;
        }
        else
        {
            inLimitV = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

           if(other.gameObject.layer == 6)
        {
            nave.SetActive(false);
            SceneManager.LoadScene(2);
            initScript.SendMessage("Morir");
        }
    }


}
