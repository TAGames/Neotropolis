/*
* Ein Script, was kleine Raumschiffe spawnt und diese mit den nötigen Components ausstattet                             
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour {

	private GameObject ship; 
	public Sprite[] sprite; 
	public float SpawnHöheMax; 
	public float SpawnHöheMin; 
	private float timer = 0.0f; 
	public float maxSpawnTime; 
	public float minSpawnTime; 
	public float toKillPosition; 
	public float minSpeed; 
	public float maxSpeed; 
	public string sortLayer;








	/**********************************************************************************************************************************
	 * Es wird ein GO "randomShip" erzeugt. Die Komponenten dieses GO werden mithilfe der Parameter festgelegt
	 * Für das GO wird ein Zufälliges Sprite gewählt, eine Zufalls Spawnhöhe und eine Zufallsgeschwindigkeit.
	 * Außerdem wird dem GO eine Layer zugewiesen und ein Tag, welches bei der Zerstörung helfen soll
	 * 
	 * @sortLayer ist die SortingLayer, indem die GO erstellt werden
	 * @spawnRangeMax ist die Obergrenze der y länge des Spawners
	 * @spawnRangeMin ist die Untergrenze der y länge des Spanwers
	 * @sprite ist ein Array mit Sprites, welche zufällig gewählt werden
	 * @minSpeed / maxSpeed ist der Bereich an Geschwindigkeit, die das Shiff haben soll
	 ************************************************************************************************************************************/
	private void shipSpawner( Sprite[] sprite, float spawnRangeMax, float spawnRangeMin, float minSpeed, float maxSpeed, string sortLayer){

		int rnd = Random.Range (0, sprite.Length);

		GameObject ship = new GameObject ("smallRndShip");

		ship.transform.SetParent (this.transform);

		SpriteRenderer mySprite = ship.AddComponent<SpriteRenderer>();
		mySprite.sprite = sprite[rnd]; 

		ship.layer = 8; 
		mySprite.sortingLayerName = sortLayer;
		ship.tag = "shipKill";




		ship.AddComponent<shipSpeed> ();
		ship.transform.localPosition = new Vector3 (0.0f, Random.Range(spawnRangeMin, spawnRangeMax),0.0f); 

		ship.GetComponent<shipSpeed> ().myShipSpeed = Random.Range(minSpeed, maxSpeed);

	}










	// Es wird ein Timer gestartet, der random in meinem Zeitlimit ein Shiff mit der Methide oben erstellt.
	// Außerdem wird die Position von allen GO mit diesen Namen dauerhauft geprüft und ggf werden diese Zerstört (wenn sie eine gewisse Position überschrreiten)
	void Update () {

		timer += Time.deltaTime;
		if (timer >= Random.Range (minSpawnTime, maxSpawnTime)) {

			shipSpawner (sprite, SpawnHöheMax, SpawnHöheMin, minSpeed, maxSpeed, sortLayer);
				
			timer = 0; 
		}

		// Wenn das GO den Tag "shipKill" hat und der Absolutbetrag größer als tiKillPosition ist, dann zerstöre das GO
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("shipKill"))
		{
			if (go.name == "smallRndShip" && (Mathf.Abs (go.transform.localPosition.x) > toKillPosition)) {
				Destroy (go);
			}
				
		}




	}
}
