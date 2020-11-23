using UnityEngine;
using System.Collections;

public class soundmusic : MonoBehaviour
{

	//Bool 
	public static bool boolsoundsalto;

	public static bool boolsoundignite;
	private bool OnnOff;


	AudioSource Music; 

	//AudiSources
	public AudioClip FXsalto, FXignite;

	void Awake()
	{
		Music = GetComponent<AudioSource>();

		boolsoundsalto = false;
		boolsoundignite = false;
	}


	// Use this for initialization
	void Start()
	{
		OnnOff = true;


	}//Start


	// Update is called once per frame
	void Update()
	{


		if (OnnOff)
		{



			// ######## SONIDOS DEL PLAYER ##########

			if (boolsoundsalto)
			{
				AudioSource.PlayClipAtPoint(FXsalto, transform.position, 0.5f);
				boolsoundsalto = false;
			}
			if (boolsoundignite)
			{
				AudioSource.PlayClipAtPoint(FXignite, transform.position, 0.2f);
				boolsoundignite = false;
			}

		}




	}//Update



}//Class
