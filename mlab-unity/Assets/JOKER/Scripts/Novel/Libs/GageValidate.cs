
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI; 


public class GageValidate:MonoBehaviour{


	void Start() {

	}


	public static void SaveVP() {
		
		float _validationPoints;
		Slider _slider;

		_slider = GameObject.Find("Slider").GetComponent<Slider>();
		_slider.gameObject.SetActive(true);

		_validationPoints = _slider.value;

		PlayerPrefs.SetFloat("vp", _validationPoints);

	}

	public static bool GetVPAndResult(){

		float _vp;
		bool result;


		_vp = PlayerPrefs.GetFloat ("vp");

		if (_vp >= 0.8) {
			result = true;
		} else {
			result = false;
		}

		return result;
	}
}

