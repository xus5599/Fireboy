using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public int agua;
    public float speed;
    public Transform target;
    private Vector3 start, end;
    public Transform personaje;
    // Start is called before the first frame update
    void Start()
    {
        agua = 0;
        StartCoroutine("inicio");
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agua == 1)
        {
            if (transform.position.y < personaje.position.y + 6)
            {
                speed = 3;
            }

            if (transform.position.y > personaje.position.y -6)
            {
                speed = Random.Range(1f, 1.75f);
            }
            
            if (target != null)
            {
                float fixedSpeed = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);

            }
        }
       
    }
    
    IEnumerator inicio()
    {
        

        yield return new WaitForSeconds(3f);
        agua = 1;
       
    }
   
   
}
