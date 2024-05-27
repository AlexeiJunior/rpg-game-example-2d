using UnityEngine;
using System.Collections;

public class LoadArea : MonoBehaviour {
	public string str;

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Player") Application.LoadLevel(str);
	}
}
