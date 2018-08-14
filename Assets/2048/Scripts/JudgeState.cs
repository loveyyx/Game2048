using UnityEngine;
using System.Collections;

public class JudgeState : MonoBehaviour {
	public static int[,] table = new int[,]{ { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
	private string name = "cube";
	public int score = 0;
	public bool State = true;
	private SpriteRenderer img;
	// Use this for initialization
	void Start () {
		img = this.GetComponent<SpriteRenderer> ();
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				table [i, j] = 0;
			}
		}
		int x = Random.Range(0,4);
		int y = Random.Range(0,4);
		int ti = Random.Range(1,3);
		table [x, y] = ti * 2 + 2;
	}
	int w(int[,]table){
		int flagw = 0;
		for (int i = 0; i < 4; i++) {
			for (int j = 3; j > 0; j--) {
				if (table [j, i] != 0) {
					if (table [j - 1, i] == 0 || table [j, i] == table [j - 1, i]) {
						flagw = 1;
						return flagw;
					}
				}
			}
		}
		return flagw;
	}
	int s(int[,]table){
		int flags = 0;
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 3; j++) {
				if (table [j, i] != 0) {
					if (table [j + 1, i] == 0 || table [j, i] == table [j + 1, i]) {
						flags = 1;
						return flags;
					}
				}
			}
		}
		return flags;
	}
	int d(int[,]table){
		int flagd = 0;
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 3; j++) {
				if (table [i, j] != 0) {
					if (table [i, j+1] == 0 || table [i, j] == table [i, j+1]) {
						flagd = 1;
						return flagd;
					}
				}
			}
		}
		return flagd;
	}
	int a(int[,]table){
		int flaga = 0;
		for (int i = 0; i < 4; i++) {
			for (int j = 3; j > 0; j--) {
				if (table [i, j] != 0) {
					if (table [i, j-1] == 0 || table [i, j-1] == table [i, j]) {
						flaga = 1;
						return flaga;
					}
				}
			}
		}
		return flaga;
	}
	private int flag =0;
	// Update is called once per frame
	void Update () {
		img = this.GetComponent<SpriteRenderer> ();
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				if (table [i, j] == 2048) {
					State = false;
					img = this.GetComponent<SpriteRenderer> ();
					img.sprite = Resources.Load ("success", typeof(Sprite))as Sprite;
					break;
				}
			}
		}
		if (State == true) {
			int flaga = a (table);
			int flagd = d (table);
			int flags = s (table);
			int flagw = w (table);
			flag = flaga + flags + flagd + flagw;
			if (flag == 0) {
				State = false;
			} else {
				State = true;
			}
			if (State) {
				if (Input.GetKeyDown (KeyCode.W)) {
					for (int i = 0; i < 4; i++) {
						for (int j = 0; j < 3; j++) {
							if (table [j, i] != 0) {
								for (int k = j + 1; k < 4; k++) {
									if (table [k, i] == table [j, i]) {
										table [j, i] += table [k, i];
										table [k, i] = 0;
										score += table [j, i];
										break;
									} else if (table [k, i] != 0) {
										break;
									}
								}
							}
						}
						for (int p = 0; p < 3; p++) {
							if (table [p, i] == 0) {
								for (int l = p + 1; l < 4; l++) {
									if (table [l, i] != 0) {
										table [p, i] = table [l, i];
										table [l, i] = 0;
										break;
									}
								}
							}
						}
					}
					int x = Random.Range(0,4);
					int y = Random.Range(0,4);
					int ti = Random.Range(1,3);
					if (table [x, y] == 0) {
						table [x, y] = ti * 2 + 2;
					}
				}
				if (Input.GetKeyDown (KeyCode.S)) {
					for (int i = 0; i < 4; i++) {
						for (int j = 3; j > 0; j--) {
							if (table [j, i] != 0) {
								for (int k = j - 1; k >= 0; k--) {
									if (table [k, i] == table [j, i]) {
										table [j, i] += table [k, i];
										table [k, i] = 0;
										score += table [j, i];
										break;
									} else if (table [k, i] != 0) {
										break;
									}
								}
							}
						}
						for (int p = 3; p > 0; p--) {
							if (table [p, i] == 0) {
								for (int l = p - 1; l >= 0; l--) {
									if (table [l, i] != 0) {
										table [p, i] = table [l, i];
										table [l, i] = 0;
										break;
									}
								}
							}
						}
					}
					int x = Random.Range(0,4);
					int y = Random.Range(0,4);
					int ti = Random.Range(1,3);
					if (table [x, y] == 0) {
						table [x, y] = ti * 2 + 2;
					}
				}
				if (Input.GetKeyDown (KeyCode.A)) {
					for (int i = 0; i < 4; i++) {
						for (int j = 0; j < 3; j++) {
							if (table [i, j] != 0) {
								for (int k = i + 1; k < 4; k++) {
									if (table [i, k] == table [i, j]) {
										table [i, j] += table [i, k];
										table [i, k] = 0;
										score += table [i, j];
										break;
									}
								}
							}
						}
						for (int p = 0; p < 3; p++) {
							if (table [i, p] == 0) {
								for (int l = p + 1; l < 4; l++) {
									if (table [i, l] != 0) {
										table [i, p] = table [i, l];
										table [i, l] = 0;
										break;
									}
								}
							}
						}
					}
					int x = Random.Range(0,4);
					int y = Random.Range(0,4);
					int ti = Random.Range(1,3);
					if (table [x, y] == 0) {
						table [x, y] = ti * 2 + 2;
					}
				}
				if (Input.GetKeyDown (KeyCode.D)) {
					for (int i = 0; i < 4; i++) {
						for (int j = 3; j > 0; j--) {
							if (table [i, j] != 0) {
								for (int k = i - 1; k >= 0; k--) {
									if (table [i, k] == table [i, j]) {
										table [i, j] += table [i, k];
										table [i, k] = 0;
										score += table [i, j];
										break;
									}
								}
							}
						}
						for (int p = 3; p > 0; p--) {
							if (table [i, p] == 0) {
								for (int l = p - 1; l >= 0; l--) {
									if (table [i, l] != 0) {
										table [i, p] = table [i, l];
										table [i, l] = 0;
										break;
									}
								}
							}
						}
					}
					int x = Random.Range(0,4);
					int y = Random.Range(0,4);
					int ti = Random.Range(1,3);
					if (table [x, y] == 0) {
						table [x, y] = ti * 2 + 2;
					}
				}
			} else {
				img.sprite = Resources.Load ("end", typeof(Sprite))as Sprite;
			}
		}
	}
}
