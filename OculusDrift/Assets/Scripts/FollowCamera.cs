using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FollowCamera : MonoBehaviour {

	public Transform target;
	public Transform player;
	public float movementSpeed = 3.5f;
	public Vector3 distance = new Vector3(0f, 0f, 0f);
	public float positionDamping = 1.5f;
	public float rotationDamping = 10f;
	private Transform thisTransform;


	public GameObject upBtn;
	public GameObject downBtn;

	Button b1;
	Button b2;


	// Use this for initialization
	void Start ()
	{
		thisTransform = GetComponent<Transform>();
		b1 = upBtn.GetComponent<Button>();
		b2 = downBtn.GetComponent<Button>();


		b1.onClick.AddListener(delegate { upBtnClickHandler(); });
		b2.onClick.AddListener(delegate { downBtnClickHandler(); });
	}
	
	// Update is called once per frame
	void Update ()
	{ 
		if(target == null)
		{
			return;
		}

		changeSpeed();


		player.position += player.forward * Time.deltaTime * movementSpeed;
		Vector3 wantedPosition = target.position + (target.rotation * distance) ;
		Vector3 currentPositon = Vector3.Lerp(thisTransform.position, wantedPosition, positionDamping * Time.deltaTime);
		Quaternion wantedRotation = Quaternion.LookRotation(target.position - thisTransform.position, target.up);

		thisTransform.position = currentPositon;
		thisTransform.rotation = wantedRotation;


	}

	void changeSpeed()
	{
		Debug.Log(movementSpeed);
		if (movementSpeed >= 3.5f && movementSpeed < 120f)
		{
			if (Input.GetAxis("Vertical") < -0.5 )
			{
				movementSpeed -= Input.GetAxis("Vertical")*15;
			}
			else if(Input.GetAxis("Vertical") > 0.5)
			{
				movementSpeed += Input.GetAxis("Vertical") * 15;
			}
		}

		if (movementSpeed > 120f)
		{
			movementSpeed = 120f;
		}

		if (movementSpeed < 3.5f)
		{
			movementSpeed = 3.5f;
		}
	}

	void upBtnClickHandler()
	{
		Debug.Log(movementSpeed);
		if (movementSpeed > 120f)
		{
			movementSpeed = 120f;

		}
		else if (movementSpeed <= 3.5f)
		{
			movementSpeed += 15;
		}
	}

	void downBtnClickHandler()
	{
		Debug.Log(movementSpeed);
		if (movementSpeed >= 3.5f)
		{
			movementSpeed -= 15;

		}
		else if(movementSpeed < 3.5f)
		{
			movementSpeed = 3.5f;
		}
	}
}
