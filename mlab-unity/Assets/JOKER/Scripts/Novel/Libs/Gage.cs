
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI; 


public class Gage:MonoBehaviour{


	void Start() {

	}
		
	public static void SwitchPoints(string param) {

		Slider _slider;
		float _points = 0.0f;

		_slider = GameObject.Find("Slider").GetComponent<Slider>();


		switch (param) {

		case "0":
			_points = 0.1f;
			_slider.value = _points;
			break;

		case "1":
			_points = 0.2f;
			_slider.value = _points;
			break;


		case "2":
			_points = 0.3f;
			_slider.value = _points;
			break;


		case "3":
			_points = 0.4f;
			_slider.value = _points;
			break;


		default:
			break;
		}
	}
}

