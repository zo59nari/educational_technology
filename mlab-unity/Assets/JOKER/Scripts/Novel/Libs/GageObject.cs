
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI; 


public class GageObject:MonoBehaviour{


	void Start() {

	}

//	public static void SwitchPoint(){
//		Slider _slide;
//		float _points = 0.0f;
//
//		_slide = GameObject.Find ("Slider").GetComponent<Slider> ();
//		_slide.gameObject.SetActive (true);
//
//
//	}
		

	public static void SwitchPoints(string param) {

		Slider _slider;
		//float _points = 0.0f;

		_slider = GameObject.Find("Slider").GetComponent<Slider>();
		_slider.gameObject.SetActive(true);
		//_slider.value = 1.0f;


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




//		switch (param) {
//
//		case "0":
//			_points = 0.1f;
//			_slider.value = _points;
//			break;
//
//		case "2":
//			_points = 0.2f;
//			_slider.value = _points;
//			break;
//
//
//		case "4":
//			_points = 0.3f;
//			_slider.value = _points;
//			break;
//
//
//		case "5":
//			_points = 0.4f;
//			_slider.value = _points;
//			break;
//
//		case "6":
//			_points = 0.5f;
//			_slider.value = _points;
//			break;
//
//		case "7":
//			_points = 0.6f;
//			_slider.value = _points;
//			break;
//
//		case "8":
//			_points = 0.7f;
//			_slider.value = _points;
//			break;
//
//		case "9":
//			_points = 0.8f;
//			_slider.value = _points;
//			break;
//
//		case "10":
//			_points = 0.9f;
//			_slider.value = _points;
//			break;
//
//		case "11":
//			_points = 1.0f;
//			_slider.value = _points;
//			break;
//
//		default:
//			break;
//		}
	}

	public static void HideGage(){
		Slider _slider;

		_slider = GameObject.Find("Slider").GetComponent<Slider>();
		_slider.gameObject.SetActive(false);
	}
}

