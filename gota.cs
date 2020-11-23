using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gota : MonoBehaviour
{
    public float speed;
    public Transform target;
    private Vector3 start, end;
    public int corutina;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
        StartCoroutine("inicio");
        corutina = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (corutina ==1)
        {
            
            StartCoroutine("movimiento");
            corutina = 0;
        }
        if (transform.position.x < target.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);

        }
        if (transform.position.x > target.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, -270);

        }
        if (transform.position == target.position)
        {
            target.position = (target.position == start) ? end : start;
        }
    }

    IEnumerator inicio()
    {
        float fixedSpeed = speed * Time.deltaTime;

        yield return new WaitForSeconds(0.333333f);
        transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        StartCoroutine("movimiento");
    }
    IEnumerator movimiento()
    {
        float fixedSpeed = speed * Time.deltaTime;

        yield return new WaitForSeconds(1f);
        transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        corutina = 1;
    }
    

}
