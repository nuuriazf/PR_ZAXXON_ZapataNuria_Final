using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorObstaculo : MonoBehaviour
{


    [SerializeField] GameObject[] arrayObst;
    [SerializeField] GameObject initObject;
    float intervalo= 0.5f;

    InitScript initScript;


    private void Start()
    {
        initScript = initObject.GetComponent<InitScript>();
        StartCoroutine("CrearObstaculos");
        
    }

    IEnumerator CrearObstaculos()
    {
        while (true)
        {
            int randomNum;
            int level = initScript.levelGame;
            print(level);
            if(level == 1)
            {
                randomNum = 0;
                intervalo = 1f;
            }
            else if(level == 2)
            {
               
                randomNum = Random.Range(0, arrayObst.Length);
                intervalo = 0.5f;
            }
            else
            {
                randomNum = Random.Range(0, arrayObst.Length);
                intervalo = 0.2f;
            }

            

            Vector3 instPos;

            if (arrayObst[randomNum].tag == "columna")
            {

                instPos = new Vector3(Random.Range(-10f, 10f),2f, transform.position.z);
            }

            else 
            {
                instPos = new Vector3(Random.Range(-9f, 9f), Random.Range(2f, 10f), transform.position.z);
            }

            Instantiate(arrayObst[randomNum], instPos, Quaternion.identity);

            yield return new WaitForSeconds(intervalo);


        }

    }
    public void Parar()
    {
        print("Se han parado la corrutina");
        StopCoroutine("CrearObstaculos");
    }


    /*

    //[SerializeField] GameObject obst1; 
   // [SerializeField] GameObject obst2; 

    [SerializeField] Transform initPos;

    [SerializeField] GameObject[] arrayObst;

    int level;
    float intervalo;
    //Variable con la distancia entre obstáculos
    [SerializeField] float distanciaEntreObstaculos;
    //Variable para las columnas iniciales
    [SerializeField] float distPrimerObst = 60f;
    float speed;
    InitScript initScript;




    void Start()
    {

        initScript = GameObject.Find("initObject").GetComponent<InitScript>();
        distanciaEntreObstaculos = 30f;
        intervalo = distanciaEntreObstaculos / initScript.naveSpeed;
        CrearColumnasIniciales();
        StartCoroutine("CrearObstaculos");

    }

    public void Parar()
    {
        print("Se han parado la corrutina");
        StopCoroutine("CrearObstaculos");
    }

    //Corrutina 
    IEnumerator CrearObstaculos()
    {
        //GameObject obstRandom;
        bool haSalidoPared = false;
        int contadorParedes = 0;

        while (true)
        {
            int randomNum;


            //Voctor en el que se instanciar´´a
            Vector3 instPos = new Vector3(0f, 0f, initPos.position.z);
            //Obtengo el nivel en el que estamos (en cada vuelta de la corrutina)
            level = initScript.levelGame;
            //print(level);
            //Según el nivel, instancio unos u otros obstáculos

            if (initScript.score >0f && initScript.score  < 250f)
            {
                randomNum = 0;
            }
            else if (initScript.score > 250f)
            {
                randomNum = Random.Range(0, arrayObst.Length);
            }
            else
            {
                //En este caso, el nº aleatorio es entre 0 y la longitud del Array
                randomNum = Random.Range(0, arrayObst.Length);
            }

            intervalo = distanciaEntreObstaculos / initScript.naveSpeed;
            //print(intervalo);

            //Creo un Vector3 que indicará la posición de instanciación
            //El valor X es random, el Z el del objeto de referencia


            if (arrayObst[randomNum].tag == "columna")
            {

                instPos = new Vector3(Random.Range(-10f, 10f), 1f, initPos.position.z);
            }



           if (arrayObst[randomNum].tag == "estrella")
            {
                instPos = new Vector3(Random.Range(-9f, 9f), Random.Range(5f, 10f), initPos.position.z);
            }

            Instantiate(arrayObst[randomNum], instPos, Quaternion.identity);


            yield return new WaitForSeconds(intervalo);
        }
    }
    void CrearColumnasIniciales()
    {


        float numColumnasIniciales = (transform.position.z - distPrimerObst) / distanciaEntreObstaculos;

        numColumnasIniciales = Mathf.Round(numColumnasIniciales); 



        for (float n = distPrimerObst; n < transform.position.z; n += distanciaEntreObstaculos)
        {

            Vector3 initColPos = new Vector3(Random.Range(-10f, 10f), 0f, n);

            Instantiate(arrayObst[0], initColPos, Quaternion.identity);

        }
    }

    */

}
