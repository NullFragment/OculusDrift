﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	public Transform target;
	public Vector3 distance = new Vector3(0f, 1f, -5f);
	public float positionDamping = 2f;
	public float rotationDamping = 2f;
	private Transform thisTransform;

	// Use this for initialization
	void Start ()
	{
		thisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if(target == null)
		{
			return;
		}
		
		Vector3 wantedPosition = target.position + (target.rotation * distance);
		Vector3 currentPositon = Vector3.Lerp(thisTransform.position, wantedPosition, positionDamping * Time.deltaTime);
		Quaternion wantedRotation = Quaternion.LookRotation(target.position - thisTransform.position, target.up);

		thisTransform.position = currentPositon;
		thisTransform.rotation = wantedRotation;
	}
}