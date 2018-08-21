using UnityEngine;
using System.Collections;

public class JudgeState : MonoBehaviour {
	public static int[,] table = new int[,]{ { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
	public static int score = 0;
	public static bool State = true;
	public static SpriteRenderer img;
	public static JudgeState instance;
	// Use this for initialization
	public void Start () {
		instance = this;
		img = this.GetComponent<SpriteRenderer> ();
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				table [i, j] = 0;
			}
		}
		while (true) {
			int x = Random.Range (0, 4);
			int y = Random.Range (0, 4);
			int ti = Random.Range (1, 3);
			if (table [x, y] == 0) {
				table [x, y] = ti * 2 ;
				break;
			}
		}
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
					this.transform.GetComponent<SpriteRenderer> ().sortingLayerName = "Mtop";
					break;
				}
			}
		}
		if (State) {
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
					if (flagw != 0) {
						for (int i = 0; i < 4; i++) {
							for (int j = 0; j < 3; j++) {
								if (table [j, i] != 0) {
									for (int k = j + 1; k < 4; k++) {
										if (table [k, i] == table [j, i]) {
											table [j, i] += table [k, i];
											table [k, i] = 0;
											score += 2*table [j, i];
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
						while (true) {
							int x = Random.Range (0, 4);
							int y = Random.Range (0, 4);
							int ti = Random.Range (1, 3);
							if (table [x, y] == 0) {
								table [x, y] = ti * 2;
								break;
							}
						}
					}
				}
				else if (Input.GetKeyDown (KeyCode.S)) {
					if (flags != 0) {
						for (int i = 0; i < 4; i++) {
							for (int j = 3; j > 0; j--) {
								if (table [j, i] != 0) {
									for (int k = j - 1; k >= 0; k--) {
										if (table [k, i] == table [j, i]) {
											table [j, i] += table [k, i];
											table [k, i] = 0;
											score += 2*table [j, i];
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
						while (true) {
							int x = Random.Range (0, 4);
							int y = Random.Range (0, 4);
							int ti = Random.Range (1, 3);
							if (table [x, y] == 0) {
								table [x, y] = ti * 2;
								break;
							}
						}
					}
				}
				else if (Input.GetKeyDown (KeyCode.A)) {
					if (flaga != 0) {
						for (int i = 0; i < 4; i++) {
							for (int j = 0; j < 3; j++) {
								if (table [i, j] != 0) {
									for (int k = j + 1; k < 4; k++) {
										if (table [i, k] == table [i, j]) {
											table [i, j] += table [i, k];
											table [i, k] = 0;
											score += 2*table [i, j];
											break;
										} else if (table [i, k] != 0) {
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
						while (true) {
							int x = Random.Range (0, 4);
							int y = Random.Range (0, 4);
							int ti = Random.Range (1, 3);
							if (table [x, y] == 0) {
								table [x, y] = ti * 2;
								break;
							}
						}
					}
				}
				else if (Input.GetKeyDown (KeyCode.D)) {
					if (flagd != 0) {
						for (int i = 0; i < 4; i++) {
							for (int j = 3; j > 0; j--) {
								if (table [i, j] != 0) {
									for (int k = j - 1; k >= 0; k--) {
										if (table [i, k] == table [i, j]) {
											table [i, j] += table [i, k];
											table [i, k] = 0;
											score += 2*table [i, j];
											break;
										} else if (table [i, k] != 0) {
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
						while (true) {
							int x = Random.Range (0, 4);
							int y = Random.Range (0, 4);
							int ti = Random.Range (1, 3);
							if (table [x, y] == 0) {
								table [x, y] = ti * 2;
								break;
							}
						}
					}
				}
			} else {
				img.sprite = Resources.Load ("end", typeof(Sprite))as Sprite;
				this.transform.GetComponent<SpriteRenderer> ().sortingLayerName = "Mtop";
			}
		}
	}
}
