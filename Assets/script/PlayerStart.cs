using UnityEngine;
using System.Collections;

public class PlayerStart : MonoBehaviour {
	private Transform target;
	private Player playerScript;
	public Vector2 faceSide;
	void Start () {
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() as Player;
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>() as Transform;
		target.position = transform.position;
		playerScript.setLastMove(faceSide);
	}
}
