using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarField : MonoBehaviour
{

	private Transform thisTransform;
	private ParticleSystem.Particle[] points;
	private float starDistanceSqr;
	private float starClipDistanceSqr;
	private float speed;
	private Vector3 lastPosition;

	public Transform player;
	public Color starColor;
	public int starsMax = 5000;
	public float starSize = .35f;
	public float starDistance = 10000f;
	public float starClipDistance = 0f;

	// Use this for initialization
	void Start()
	{
		thisTransform = GetComponent<Transform>();
		starDistanceSqr = starDistance * starDistance;
		starClipDistanceSqr = starClipDistance * starClipDistance;
		lastPosition = player.position;

	}

	private void CreateStars()
	{
		points = new ParticleSystem.Particle[starsMax];

		for (int i = 0; i < starsMax; i++)
		{
			points[i].position = Random.insideUnitSphere * starDistance + thisTransform.position;
			points[i].startColor = new Color(starColor.r, starColor.g, starColor.b, starColor.a);
			points[i].startSize = starSize;
		}
	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (points == null)
		{
			CreateStars();
		}

		speed = (player.position - lastPosition).magnitude;
		lastPosition = player.position;
		starSize = (float)(1 / (1 + speed));
		for (int i = 0; i < starsMax; i++)
		{
			if ((points[i].position - thisTransform.position).sqrMagnitude > starDistanceSqr)
			{
				points[i].position = Random.insideUnitSphere.normalized * starDistance + thisTransform.position;
			}

			else if ((points[i].position - thisTransform.position).sqrMagnitude <= starClipDistanceSqr)
			{
				float percentage = (points[i].position - thisTransform.position).sqrMagnitude / starClipDistanceSqr;
				points[i].color = new Color(starColor.r*(1-percentage), starColor.g*(1 - percentage), starColor.b*(1 - percentage), percentage);
				points[i].size = starSize * percentage;
			}
		}

		Debug.Log(starSize);

		GetComponent<ParticleSystem>().SetParticles(points, points.Length);
	}
}