using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBehavior : MonoBehaviour {
	public ParticleSystem ShootingStar1, ShootingStar2, ShootingStar3, ShootingStar4, ShootingStar5, ShootingStar6, ShootingStar7, ShootingStar8;
	public ParticleSystem StarTrail1, StarTrail2, StarTrail3, StarTrail4, StarTrail5, StarTrail6, StarTrail7, StarTrail8;
	public Material Skybox1, Skybox2;
	private ParticleSystem parti;
	// Use this for initialization
	void Start ()
	{
		var star1 = ShootingStar1.main;
		var star2 = ShootingStar2.main;
		var star3 = ShootingStar3.main;
		var star4 = ShootingStar4.main;
		var star5 = ShootingStar5.main;
		var star6 = ShootingStar6.main;
		var star7 = ShootingStar7.main;
		var star8 = ShootingStar8.main;
		var trail1 = StarTrail1.main;
		var trail2 = StarTrail2.main;
		var trail3 = StarTrail3.main;
		var trail4 = StarTrail4.main;
		var trail5 = StarTrail5.main;
		var trail6 = StarTrail6.main;
		var trail7 = StarTrail7.main;
		var trail8 = StarTrail8.main;
		star1.startColor = new Color(1, 1, 1, 1);
		star2.startColor = new Color(1, 1, 1, 1);
		star3.startColor = new Color(1, 1, 1, 1);
		star4.startColor = new Color(1, 1, 1, 1);
		star5.startColor = new Color(1, 1, 1, 1);
		star6.startColor = new Color(1, 1, 1, 1);
		star7.startColor = new Color(1, 1, 1, 1);
		star8.startColor = new Color(1, 1, 1, 1);
		trail1.startColor = new Color(1, 1, 1, 0);
		trail2.startColor = new Color(1, 1, 1, 0);
		trail3.startColor = new Color(1, 1, 1, 0);
		trail4.startColor = new Color(1, 1, 1, 0);
		trail5.startColor = new Color(1, 1, 1, 0);
		trail6.startColor = new Color(1, 1, 1, 0);
		trail7.startColor = new Color(1, 1, 1, 0);
		trail8.startColor = new Color(1, 1, 1, 0);
	}

	// Update is called once per frame
	void Update ()
	{


	}
}
