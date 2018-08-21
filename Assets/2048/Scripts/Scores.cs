using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Scores : MonoBehaviour {
	private static Scores instance;
	public int total = 0;
	public Text text_score;
	// Use this for initialization
	void Start () {
		instance = this;
		text_score =instance.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		total = JudgeState.score;
		text_score.text = total.ToString();
	}
}
