using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMove : MonoBehaviour
{

    [SerializeField] GameObject initObject;
    InitScript initScript;

    float speed;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        initObject = GameObject.Find("initObject");

        initScript = initObject.GetComponent<InitScript>();

        speed = initScript.naveSpeed;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        speed = initScript.naveSpeed;
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        float posZ = transform.position.z;
        //print(posZ);

        if (posZ < -20)
        {
            Destroy(gameObject);
        }

    }

}