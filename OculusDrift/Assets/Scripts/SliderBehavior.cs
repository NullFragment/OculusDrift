using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
public class SliderBehavior : MonoBehaviour {
	public string verticalInputString;
	public ParticleSystem ShootingStar1, ShootingStar2, ShootingStar3, ShootingStar4, ShootingStar5, ShootingStar6, ShootingStar7, ShootingStar8;
	public ParticleSystem StarTrail1, StarTrail2, StarTrail3, StarTrail4, StarTrail5, StarTrail6, StarTrail7, StarTrail8;
	public Material Skybox1, Skybox2, Skybox3;
	public Slider colorSlider;
	
	private float SliderValue;
	private Color ShootingStarColor = new Color(1,1,1,1);
	private Color ShootingStarTrail = new Color(1,1,1,1);

	public Material boxMaterial;

	AudioSource audioMusic;
	AudioSource audioNoise;
	AudioSource audioPinkNoise;

	public AudioClip lowMain, midMain, highMain, low1, low2, low3, mid1, mid2, mid3, high1, high2, high3, pinkNoise;

	private float musicVolume = 1f;
	private float noiseVolume = .03f;
	private float pinknoiseVolue = .03f;

	private int musicState;

	public GameObject upBtn;
	public GameObject downBtn;

	Button b1;
	Button b2;
	// Use this for initialization




	void Start ()
	{
		Color SkyboxTint = new Color(1, 1, 1, 1);
		Skybox1.SetColor("_TintColor", SkyboxTint);
		Skybox2.SetColor("_TintColor", SkyboxTint);
		Skybox3.SetColor("_TintColor", SkyboxTint);

		//colorSlider.onValueChanged.AddListener(delegate { UpdateColors(); });

		audioMusic = gameObject.AddComponent<AudioSource>();
			 audioNoise = gameObject.AddComponent<AudioSource>();
			 audioPinkNoise = gameObject.AddComponent<AudioSource>();

		audioMusic.clip = lowMain;
		audioMusic.volume = musicVolume;
		audioMusic.Play();

		audioNoise.clip = low1;
		audioNoise.volume = noiseVolume;
		audioNoise.Play();

		audioPinkNoise.clip = pinkNoise;
		audioPinkNoise.volume = pinknoiseVolue;
		audioPinkNoise.Play();

		 b1 = upBtn.GetComponent<Button>();
		 b2 = downBtn.GetComponent<Button>();

		b1.onClick.AddListener(delegate { upBtnClickHandler(); });
		b2.onClick.AddListener(delegate { downBtnClickHandler(); });

		musicState = 1;
	}

	// Update is called once per frame
	void Update ()
	{
		UpdateColors();

		if (Input.GetButton("Fire1"))
		{
			upBtnClickHandler();
		}

		if (Input.GetAxis(verticalInputString) > 0.5f)
		{
			upBtnClickHandler();
		}

		if (Input.GetAxis(verticalInputString) < -0.5f)
		{
			downBtnClickHandler();
		}

		if (Input.GetButton("Fire2"))
		{
			downBtnClickHandler();
		}

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
		
	
		if (SliderValue < 0.334f)
		{
			if(SliderValue > 0.154f && SliderValue < 0.334f)
			{
				float opacity = SliderValue * 2f;
				Color temp = boxMaterial.color;
				temp.a = opacity;
				boxMaterial.color = temp;
			}

			
			RenderSettings.skybox = Skybox1;
		}

		if (SliderValue > 0.334f && SliderValue < 0.666f)
		{



			if (SliderValue > 0.334f && SliderValue < 0.454f)
			{
				float opacity = 1f - SliderValue * 1.5f;
				Color temp = boxMaterial.color;
				temp.a = opacity;
				boxMaterial.color = temp;
			}

			RenderSettings.skybox = Skybox2;

			if (SliderValue > 0.554f && SliderValue < 0.666f)
			{
				float opacity = SliderValue * 1.2f;
				Color temp = boxMaterial.color;
				temp.a = opacity;
				boxMaterial.color = temp;
			}

		}

		if (SliderValue > 0.666f && SliderValue < 1f)
		{



			if (SliderValue > 0.666f)
			{
				float opacity =1 - SliderValue * 1.2f;
				Color temp = boxMaterial.color;
				temp.a = opacity;
				boxMaterial.color = temp;
			}
			RenderSettings.skybox = Skybox3;
		}

	}

	void UpdateSounds()
	{

		Debug.Log(SliderValue);
		
		if (SliderValue == 0.334f && musicState == 1) // from low to mid
		{
			colorSlider.GetComponent<Slider>().value = (float)(Math.Round((colorSlider.GetComponent<Slider>().value + 0.002f), 3));

			audioMusic.Stop();
			audioNoise.Stop();

			audioMusic.clip = midMain;
			audioMusic.volume = musicVolume;
			audioMusic.Play();

			audioNoise.clip = mid1;
			audioNoise.volume = noiseVolume;
			audioNoise.Play();

			audioNoise.clip = mid2;
			audioNoise.volume = noiseVolume;
			audioNoise.Play();

			audioNoise.clip = mid3;
			audioNoise.volume = noiseVolume;
			audioNoise.Play();

			musicState = 2;
			Debug.Log("Changing state from low to mid");


		}else	if (SliderValue == 0.334f && musicState == 2) // from mid to low
		{
			colorSlider.GetComponent<Slider>().value = (float)(Math.Round((colorSlider.GetComponent<Slider>().value - 0.002f), 3));

			audioMusic.Stop();
			audioNoise.Stop();

			audioMusic.clip = lowMain;
			audioMusic.volume = musicVolume;
			audioMusic.Play();

			audioNoise.clip = low1;
			audioNoise.volume = noiseVolume;
			audioNoise.Play();

			audioNoise.clip = low2;
			audioNoise.volume = noiseVolume;
			audioNoise.Play();

			audioNoise.clip = low3;
			audioNoise.volume = noiseVolume;
			audioNoise.Play();

			musicState = 1;
			Debug.Log("Changing state from mid to low");


		}

		if (SliderValue == 0.666f && musicState == 2) // from mid to high
			{
			colorSlider.GetComponent<Slider>().value = (float)(Math.Round((colorSlider.GetComponent<Slider>().value + 0.002f), 3));

			audioMusic.Stop();
				audioNoise.Stop();

				audioMusic.clip = highMain;
				audioMusic.volume = musicVolume;
				audioMusic.Play();

				audioNoise.clip = high1;
				audioNoise.volume = noiseVolume;
				audioNoise.Play();

				audioNoise.clip = high2;
				audioNoise.volume = noiseVolume;
				audioNoise.Play();

				audioNoise.clip = high3;
				audioNoise.volume = noiseVolume;
				audioNoise.Play();

				musicState = 3;
			Debug.Log("Changing state from mid to high");


		}else if (SliderValue == 0.666f && musicState == 3) // from high to mid
			{
			colorSlider.GetComponent<Slider>().value = (float)(Math.Round((colorSlider.GetComponent<Slider>().value - 0.002f), 3));

			audioMusic.Stop();
				audioNoise.Stop();

				audioMusic.clip = midMain;
				audioMusic.volume = musicVolume;
				audioMusic.Play();

				audioNoise.clip = mid1;
				audioNoise.volume = noiseVolume;
				audioNoise.Play();

				audioNoise.clip = mid2;
				audioNoise.volume = noiseVolume;
				audioNoise.Play();

				audioNoise.clip = mid3;
				audioNoise.volume = noiseVolume;
				audioNoise.Play();

				musicState = 2;
			Debug.Log("Changing state from high to mid");


		}



	}

	void upBtnClickHandler()
	{
		colorSlider.GetComponent<Slider>().value = (float)(Math.Round((colorSlider.GetComponent<Slider>().value + 0.002f),3));
		UpdateSounds();
	}

	void downBtnClickHandler()
	{
		colorSlider.GetComponent<Slider>().value = (float)(Math.Round((colorSlider.GetComponent<Slider>().value - 0.002f), 3));
		UpdateSounds();
	}

}
