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
	 	public class FeedComponent:AbstractComponent
	 	{

		  	public override void start ()
		  	{

			   	//変数に結果を格納
				//GageObject.SwitchPoints(chosenNumber);

				GageValidate.SaveVP ();


			   	//次のシナリオに進む処理
			   	this.gameManager.nextOrder ();

			  	}

		 }
	/*	
--------------


[doc]
tag=result
group=シナリオ制御
title=別のシナリオ位置へジャンプ

[desc]
このタグの場所に到達するとfileとtargetで指定された場所へジャンプします

ジャンプ命令はcallスタックに残りません。つまり、return で指定位置に戻ることができません。
result先では標準でcaller_index と caller_file という変数が格納されています。
これは、resultした地点のファイルとindexを保持しています。
mp.caller_index と mp.caller_file を使うことで元の位置に戻ることが可能です

resultには好きなパラメータを渡すことが可能です。
result先ではmp.arg1 のような形で変数にアクセスすることが可能です。

scene=new とすることで、全く新しいシーンを新たに生成した上でジャンプすることができます。
まっさらな状態になるので、もう一度背景やキャラクター情報などを定義する必要があります。

場面の切り替わりなどではscene=newでresultすることにより、不要なデータを一掃することで
健全な状態を保ってゲームを進めることができるできます。
ですので、定期的にscene=new でジャンプを行うことをオススメします。


[sample]

[result taget=*test]
ここは無視される[p]

*test

ここにジャンプする。

[param]
file=移動するシナリオファイル名を指定します。省略された場合は現在のシナリオファイルと見なされます
＊スライダーで８割に達していなければゲームクリアかゲームオーバーかのどちらかで分岐されるようあらかじめ指定
target=ジャンプ先のラベル名を指定します。省略すると先頭から実行されます
index=内部的に保持しているゲーム進行状況の数値を指定することができます。
scene=new を指定すると、新しくシーンを作成した上でジャンプします。


[_doc]


--------------------
 */
	 	public class ResultComponent:AbstractComponent
	 	{
			public ResultComponent ()
			{
	
				//必須項目
				this.arrayVitalParam = new List<string> {
					//"target"
				};
	
				this.originalParam = new Dictionary<string,string> () {
					{ "target","" },
					{ "file","" },
					{ "index",""},
					{ "scene",""}, //ここにnew が入っている場合はジャンプ後にシーンをイチから作り直す。
					{ "next","true"}, //next にfalse が入っている場合、ジャンプ先でnextOrderを行いません。
	
				};
	
			}


		  	public override void start ()
		  	{

			if (GageValidate.GetVPAndResult ()) {

					this.param ["target"] = "goal";

					string target = this.param ["target"].Replace ("*", "").Trim();
					string file = this.param ["file"];
		
					if (file == "") {
						file = StatusManager.currentScenario;
					}
		
					//ファイルが異なるものになる場合、シナリオをロードする
		
					if (StatusManager.currentScenario != file) {
						this.gameManager.loadScenario (file);
					}
		
		
					int index = -1;
		
					//index直指定の場合はそれに従う
					if (this.param ["index"] != "") {
					
						index = int.Parse(this.param ["index"]);
					
					} else {
		
						index = this.gameManager.scenarioManager.getIndex (file, target);
							
					}
		
					//mp変数の中身を書き換える resultのpmの内容で
					//NovelSingleton.GameManager.statusManager.variable.replaceAll("mp",this.param);;
		
					//ゲームマネージャーの現在の位置をそこに書き換えてnextOrderでどうだ。
					this.gameManager.CurrentComponentIndex = index;
					StatusManager.currentScenario = file;
		
					//シーンをクリアして作りなおす
					if (this.param ["scene"] == "new") {
		
						//new の場合はスタックをすべて削除する
						this.gameManager.scenarioManager.removeAllStacks ();
		
						StatusManager.nextFileName = file;
						StatusManager.nextTargetName = target;
						StatusManager.currentScenario = "";
						//resultから来たことを通知するためのパラメータが必要
						Application.LoadLevel("Player");
		
					}
		
					if (this.param ["next"] == "false") {
					
					} else {
						this.gameManager.nextOrder ();
					}				
				} else {

					this.param ["target"] = "gameover";

					string target = this.param ["target"].Replace ("*", "").Trim();
					string file = this.param ["file"];
		
					if (file == "") {
						file = StatusManager.currentScenario;
					}
		
					//ファイルが異なるものになる場合、シナリオをロードする
		
					if (StatusManager.currentScenario != file) {
						this.gameManager.loadScenario (file);
					}
		
		
					int index = -1;
		
					//index直指定の場合はそれに従う
					if (this.param ["index"] != "") {
					
						index = int.Parse(this.param ["index"]);
					
					} else {
		
						index = this.gameManager.scenarioManager.getIndex (file, target);
							
					}
		
					//mp変数の中身を書き換える resultのpmの内容で
					//NovelSingleton.GameManager.statusManager.variable.replaceAll("mp",this.param);;
		
					//ゲームマネージャーの現在の位置をそこに書き換えてnextOrderでどうだ。
					this.gameManager.CurrentComponentIndex = index;
					StatusManager.currentScenario = file;
		
					//シーンをクリアして作りなおす
					if (this.param ["scene"] == "new") {
		
						//new の場合はスタックをすべて削除する
						this.gameManager.scenarioManager.removeAllStacks ();
		
						StatusManager.nextFileName = file;
						StatusManager.nextTargetName = target;
						StatusManager.currentScenario = "";
						//resultから来たことを通知するためのパラメータが必要
						Application.LoadLevel("Player");
		
					}
		
					if (this.param ["next"] == "false") {
					
					} else {
						this.gameManager.nextOrder ();
					}
				}	

			}

		}


}


