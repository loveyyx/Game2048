using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class changeImg1 : MonoBehaviour {
	private string tag0 = "" ;
	private string tag = "";
	private int numX = 0;
	private int numY = 0;
	private int value = 0;
	private SpriteRenderer img;
	void Initialize (){
		tag0 = transform.tag;
	}
	// Use this for initialization
	void Start () {
		Initialize ();
	    tag=System.Text.RegularExpressions.Regex.Replace(tag0,@"[^0-9]+","");
		numX = int.Parse (tag) % 4;
		numY = (int.Parse (tag) / 4) % 4;
		img = this.GetComponent<SpriteRenderer> ();
		img.sprite = Resources.Load ("empty", typeof(Sprite))as Sprite;
	}
	
	// Update is called once per frame
	void Update () {
		value=JudgeState.table[numX,numY];
		if (value != 0) {
			string na = value.ToString ();
			img.sprite = Resources.Load (na, typeof(Sprite))as Sprite;
		} else {
			img.sprite = Resources.Load ("empty", typeof(Sprite))as Sprite;
		}
	}
}
