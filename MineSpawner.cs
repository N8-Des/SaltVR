using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour {
	private IEnumerator spawnMine;
	public bool ableToSpawn = true; //originally was false for balancing reasons, but you cannot yield with a normal function. 
	public float atkSpeed;
	public Vector3 offset = new Vector3( 0, 2, 0 );

	public IEnumerator Spawn(){
		if (ableToSpawn) {
			GameObject Mine = GameObject.Instantiate ((GameObject)Resources.Load ("Mine"));
			Mine.AddComponent<Rigidbody> ();
			Mine.transform.position = this.transform.position + offset;
			ableToSpawn = false;
			Debug.Log ("Spawned Mine!");
			yield return new WaitForSeconds (atkSpeed);
			ableToSpawn = true;
		}
	}
	public void Update(){
		if (ableToSpawn) {
			spawnMine = Spawn ();
			Debug.Log ("Help");
			StartCoroutine (spawnMine);
		}
	}
}

