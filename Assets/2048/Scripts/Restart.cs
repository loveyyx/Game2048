using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
	void OnMouseUp(){
		JudgeState.table=new int[4,4]{{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0}};
		JudgeState.score = 0;
		JudgeState.State = true;
		JudgeState.img.sprite = Resources.Load ("board", typeof(Sprite))as Sprite;
		JudgeState.instance.transform.GetComponent<SpriteRenderer> ().sortingLayerName = "fg";
		while (true) {
			int x = Random.Range (0, 4);
			int y = Random.Range (0, 4);
			int ti = Random.Range (1, 3);
			if (JudgeState.table [x, y] == 0) {
				JudgeState.table [x, y] = ti * 2 ;
				break;
			}
		}
	}
}
