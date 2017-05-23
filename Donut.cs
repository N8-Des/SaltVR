using UnityEngine;
using System.Collections;

public class Donut : MonoBehaviour
{
	public float health;
	public Vector3 startingVelocity = new Vector3(1,1,1);
	public bool dead = false;

	// Use this for initialization
	void Start ()
	{
	
	}


	//Returns true if damage killed this object -- Hal
	public virtual bool TakeDamage(float damage){
		health = health - damage;
		if (health <= 0) {
			if (dead == false) {
				dead = true;
				Destroy (this.gameObject);
				return true;
			} else {
						
					return false;
				}
			} else {
				return false;
		}
	}
}