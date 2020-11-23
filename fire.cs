using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject llama;

    public bool fuego = false;

    private Animator animate;
    
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        animate.SetBool("llama", fuego);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            soundmusic.boolsoundignite = true;
            fuego = true;
        }
    }
}
