using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject options;
   
    public int opcion;
    public bool pausa;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        opcion = 0;  
        Time.timeScale = 1.0f;
        pausa = false;
        options.SetActive(false);
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (opcion == 2)
        {
            opcion = 0;
            options.SetActive(false);


            

        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void nextlevel()
    {
        SceneManager.LoadScene(2);
    }
    public void opciones()
    {
        opcion++;
        options.SetActive(true);
        
      
     
    

    
    }
    public void PausaJuego()
    {
        pausa = !pausa; 

        if (pausa)
        {
            Time.timeScale = 0;
            audio.Pause();
        }
        else
        {
            Time.timeScale = 1;
            audio.Play();
        }

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
