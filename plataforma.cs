using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{
    private int X;
    private float miposicionX;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        X = 1;
        miposicionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(X, 0, 0) * Time.deltaTime * speed, Space.World);
        if (transform.position.x > miposicionX + 2)
        {
            X = -1;
        }
        if (transform.position.x < miposicionX - 2)
        {
            X = 1;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.parent = transform;
    }
    void OnCollisionExit2D(Collision2D other)
    {

        other.transform.parent = null;
    }
}
