using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonsMethods : MonoBehaviour
{

	public Slider colorSlider;

	public void UpButtonPressed()
	{
		colorSlider.value += .01f;
	}
}
