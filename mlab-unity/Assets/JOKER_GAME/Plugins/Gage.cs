using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

namespace Novel{


	/*	
--------------

ゲージの増減処理
[gage]
points="n"

n = 1, 2, 3


ゲージを隠す（デフォルトでゲージは表示されてる）
[hgage]


[_doc]
--------------------
 */
	 	public class GageComponent:AbstractComponent
	 	{
		  	public GageComponent ()
		  	{
			  
			   	this.arrayVitalParam = new List<string> {
				   	"points",
				   	};

			   	this.originalParam = new Dictionary<string, string>() {
				   	{"points",""},
				  	};

			 	}

		  	public override void start ()
		  	{

			   	string chosenNumber = this.param ["points"];


			   	//変数に結果を格納
				GageObject.SwitchPoints(chosenNumber);


			   	//次のシナリオに進む処理
			   	this.gameManager.nextOrder ();

			  	}

		 	}


	 	public class HgageComponent:AbstractComponent
	 	{
		  	public HgageComponent ()
		  	{

			}

		  	public override void start ()
		  	{
				GageObject.HideGage();
			   	this.gameManager.nextOrder ();

			}

		 }


}


