
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI; 


public class GageObject:MonoBehaviour{


	void Start() {

	}
		
	public static void SwitchPoints(string param) {

		Slider _slider;

		_slider = GameObject.Find("Slider").GetComponent<Slider>();
		_slider.gameObject.SetActive(true);


		switch (param) {
		case "right":
			_slider.value += 0.2f;
			break;
		case "wrong":
			_slider.value -= 0.2f;
			break;
		default:
			break;
		
		}
	}

	public static void HideGage(){
		Slider _slider;

		_slider = GameObject.Find("Slider").GetComponent<Slider>();
		_slider.gameObject.SetActive(false);
	}
}

