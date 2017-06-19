
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
		float _points = 0.0f;

		_slider = GameObject.Find("Slider").GetComponent<Slider>();
		_slider.gameObject.SetActive(true);


		switch (param) {

		case "0":
			_points = 0.1f;
			_slider.value = _points;
			break;

		case "2":
			_points = 0.3f;
			_slider.value = _points;
			break;


		case "4":
			_points = 0.4f;
			_slider.value = _points;
			break;


		case "6":
			_points = 1.0f;
			_slider.value = _points;
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

