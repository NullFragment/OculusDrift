using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehavior : MonoBehaviour {
	public ParticleSystem ShootingStar1, ShootingStar2, ShootingStar3, ShootingStar4, ShootingStar5, ShootingStar6, ShootingStar7, ShootingStar8;
	public ParticleSystem StarTrail1, StarTrail2, StarTrail3, StarTrail4, StarTrail5, StarTrail6, StarTrail7, StarTrail8;
	public Material Skybox1, Skybox2, Skybox3;
	public Slider colorSlider;
	
	private float SliderValue;
	private Color ShootingStarColor = new Color(1,1,1,1);
	private Color ShootingStarTrail = new Color(1,1,1,1);

	public Material boxMaterial;

	public AudioListener audio;

	// Use this for initialization
	void Start ()
	{
		Color SkyboxTint = new Color(1, 1, 1, 1);
		Skybox1.SetColor("_TintColor", SkyboxTint);
		Skybox2.SetColor("_TintColor", SkyboxTint);
		Skybox3.SetColor("_TintColor", SkyboxTint);


		//colorSlider.onValueChanged.AddListener(delegate { UpdateColors(); });
	}

	// Update is called once per frame
	void Update ()
	{
		UpdateColors();
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
		star1.startColor = ShootingStarColor;
		star2.startColor = ShootingStarColor;
		star3.startColor = ShootingStarColor;
		star4.startColor = ShootingStarColor;
		star5.startColor = ShootingStarColor;
		star6.startColor = ShootingStarColor;
		star7.startColor = ShootingStarColor;
		star8.startColor = ShootingStarColor;
		trail1.startColor = ShootingStarTrail;
		trail2.startColor = ShootingStarTrail;
		trail3.startColor = ShootingStarTrail;
		trail4.startColor = ShootingStarTrail;
		trail5.startColor = ShootingStarTrail;
		trail6.startColor = ShootingStarTrail;
		trail7.startColor = ShootingStarTrail;
		trail8.startColor = ShootingStarTrail;
	}
	
	void UpdateColors ()
	{
		Color SkyboxFadein = new Color(1, 1, 1, 1);
		Color SkyboxFadeout = new Color(0, 0, 0, 1);
		
		SliderValue = colorSlider.GetComponent<Slider>().value;

		ShootingStarColor = new Color(0, 0, 1f*(1f-SliderValue), 1);
		ShootingStarTrail = new Color(0, 0, .75f*(1f-SliderValue), 1);

		ShootingStarColor = new Color(1f * SliderValue, 0, 0, 1);
		ShootingStarTrail = new Color(.75f * SliderValue, 0, 0, 1);
		
	
		if (SliderValue < .3333333333333f)
		{
			if(SliderValue > 0.15f && SliderValue < .3333333333333f)
			{
				float opacity = SliderValue * 2f;
				Color temp = boxMaterial.color;
				temp.a = opacity;
				boxMaterial.color = temp;
			}


			RenderSettings.skybox = Skybox1;
		}

		if (SliderValue > .3333333333333f && SliderValue < .666666666666666f)
		{

			if (SliderValue > .3333333333333f && SliderValue < 0.45f)
			{
				float opacity = 1f - SliderValue * 1.5f;
				Color temp = boxMaterial.color;
				temp.a = opacity;
				boxMaterial.color = temp;
			}

			RenderSettings.skybox = Skybox2;

			if (SliderValue > .555555555555f && SliderValue < .666666666666666f)
			{
				float opacity = SliderValue * 1.2f;
				Color temp = boxMaterial.color;
				temp.a = opacity;
				boxMaterial.color = temp;
			}

		}

		if (SliderValue > .666666666666666f && SliderValue < 1f)
		{
			if (SliderValue > .666666666666666f)
			{
				float opacity =1 - SliderValue * 1.2f;
				Color temp = boxMaterial.color;
				temp.a = opacity;
				boxMaterial.color = temp;
			}
			RenderSettings.skybox = Skybox3;
		}

		Debug.Log(SliderValue);
	}
}
