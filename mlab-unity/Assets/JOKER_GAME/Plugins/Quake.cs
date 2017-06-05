using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


//Novel空間に作成
namespace Novel{
	public class QuakeComponent:AbstractComponent{
		public QuakeComponent(){}
		GameObject target = GameObject.Find("MainCamera");
		public override void start(){
			iTween.ShakePosition(target, iTween.Hash("x",1.5, "y",1.5, "time",3.0f)); 
			this.gameManager.nextOrder();
		}
	}
}

