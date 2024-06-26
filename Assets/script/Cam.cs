﻿using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {
	private float dampTime = 0.001f;
	private Vector3 velocity = Vector3.zero;
	private Transform target;
	private static bool camExist;
	
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>() as Transform;

		if(!camExist){
			DontDestroyOnLoad(transform.gameObject);
			camExist = true;
		}else{
			Destroy(gameObject);
		}
	}
	
	void Update () 
	{
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		
	}
}
