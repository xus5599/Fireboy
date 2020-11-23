using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APUNTADO : MonoBehaviour
{
    float timeAux;
    public GameObject fireboy;
    public Rigidbody2D misil;
    public Transform lanzador;
    public Transform seguir;
    public float veldisparo;
    // Start is called before the first frame update
    void Start()
    {
        timeAux = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = lanzador.TransformDirection(Vector3.forward);
        float timeDif = Time.time - timeAux;
        
        
      Vector3 difference = fireboy.transform.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        if ((transform.position.y > seguir.position.y - 6 ) && ( transform.position.y < seguir.position.y + 6 ))
        {
            
            if (timeDif > 1.5f)
            {
                Rigidbody2D misilinstanc;
                misilinstanc = Instantiate(misil, lanzador.position, lanzador.rotation);
                misilinstanc.AddForce(lanzador.forward * 100 * veldisparo);
                timeAux = Time.time;
            }
        }

        
    }
}
