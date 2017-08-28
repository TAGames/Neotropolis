using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* In diesem Script werden verschiedene Layers in einer 2D umgebung (eigentlich 3D) 
	 * jeh nach Distanz zum Spieler gescrollt um einem Parallax effekt zu erhalten
     * Wichtig: Entferne Objekte müssen schneller sein, damit sie mit dem Spieler mithalten, 
     * schnell sieht dann langsam aus, wärend langsam beim bewegen schnell aussieht */
public class Parallax : MonoBehaviour {



	/* Hier werden die Trannsform Komponenten jedes Hintergrunds / Layer die sich bewegen sollen gespeichert, 
	 * mit Transform kann ein GameObject bewegt etc. werden. Jedes GO hat eine Transformkomponente,
	 * 
	 * !die Layers einfach per Drag and Drop auf diesen Array ziehen! */
	public Transform[] backgrounds; 

	/*Hier wird für jeden Hintergrund basierend auf deren Abstand zum Spieler eine Zahl gespeichert um das Scrollen, abhänmgig von ihrer Entfernung zu Scrollen,
	 * Berge die weiter weg sind, sollen zB langsamer Scrollen */
	private float[] parallaxScales;


	//Hier wird das Scrollen einfach bei bedarf skaliert 
	public float smoothing = 1; 

	//Hier wird die Cameraposition vom letzen Frame gespeichert 
	private Vector3 previousCameraPosition; 


	// Use this for initialization
	void Start () {

		//Die Kameraposition ist am Anfang natürlich die Ausgansposition
		previousCameraPosition = transform.position;


	    //Hier sagen wir der parallaxScale Array soll genauso groß sein, wie es backgrounds gibt
		parallaxScales = new float [backgrounds.Length];

		//Hier wird die z Komponente (also der Abstand zu uns) für jeden Background drinnne gespeichert und * -1 genommen (weil es positiv sien soll) 
		for (int i = 0; i<parallaxScales.Length; i++)
		{
			parallaxScales [i] = backgrounds [i].position.z * -1;
		}

	}
	
	// Update is called once per frame
	void LateUpdate () {

		//Hier gehen wir jeden Background durch 
		for (int i = 0; i<backgrounds.Length; i++)
		{

			// Der Vektor Parralax (für das Aktuelle background) ist so groß wie die Entfernung von unserer Position zur der des letzen Frames * (der Skalierungsfaktor / smoothing) 
			Vector3 parallax = (previousCameraPosition - transform.position) * (parallaxScales[i] / smoothing);


			//Hier sagen wir einfach, der Background hat seine neue Position an der alten + parallax (für x und y), z soll die ganze Zeit gleich bleiben!
			backgrounds[i].position = new Vector3(backgrounds[i].position.x + parallax.x, backgrounds[i].position.y + parallax.y, backgrounds[i].position.z);
		}

		previousCameraPosition = transform.position; 


	}
}
