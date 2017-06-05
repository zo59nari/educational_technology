using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

namespace Novel{

	 	public class ParamComponent:AbstractComponent
	 	{
		  	public ParamComponent ()
		  	{
			  
			   	//必須項目
			   	this.arrayVitalParam = new List<string> {
				   	"arg1",
				   	};

			   	this.originalParam = new Dictionary<string, string>() {
				   	{"arg1",""},
				  	};

			 	}

		  	public override void start ()
		  	{

			   	string chosenNumber = this.param ["arg1"];


			   	//変数に結果を格納
				Gage.SwitchPoints(chosenNumber);


			   	//次のシナリオに進む処理
			   	this.gameManager.nextOrder ();

			  	}

		 	}

}


