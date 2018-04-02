using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Engine;

public class UserGUI : MonoBehaviour {
	private UserAction action;

	GUIStyle MyStyle;
	GUIStyle MyButtonStyle;
	public int if_win_or_not;
	public int isPause = 0;//1->pause, 0->continue

	void Start(){
		action = Director.get_Instance ().curren as UserAction;

		MyStyle = new GUIStyle ();
		MyStyle.fontSize = 40;
		MyStyle.normal.textColor = new Color (255f, 0, 0);
		MyStyle.alignment = TextAnchor.MiddleCenter;

		MyButtonStyle = new GUIStyle ("button");
		MyButtonStyle.fontSize = 30;
	}
	void reStart(){
		if (GUI.Button (new Rect (Screen.width/2-Screen.width/8, Screen.height/2+100, 150, 50), "Restart", MyButtonStyle)) {
			if_win_or_not = 0;
			action.restart ();
			moveable.cn_move = 0;
		}
	}
	void IsPause(){
		if (GUI.Button (new Rect (Screen.width / 2 - 350, Screen.height / 2 + 100, 150, 50), "Pause", MyButtonStyle)) {
			if (moveable.cn_move == 0) {
				action.pause ();
				moveable.cn_move = 1;
			} else {
				GUI.Label (new Rect (Screen.width / 2 - Screen.width / 4, Screen.height / 2 + 200, 150, 50), "Has Pause, Please press 'continue' to continue", MyStyle);
			}
		} else if (GUI.Button (new Rect (Screen.width-Screen.width/2, Screen.height / 2 + 100, 150, 50), "Continue", MyButtonStyle)) {
			if (moveable.cn_move == 1) {
				action.Coninu();
				moveable.cn_move = 0;
			} else {
				GUI.Label (new Rect (Screen.width / 2 - Screen.width / 4, Screen.height / 2 + 200, 150, 50), "Game is running", MyStyle);
			}
		}
	}
	void OnGUI(){
		IsPause ();
		reStart ();
		if (if_win_or_not == -1) {
			GUI.Label (new Rect (Screen.width/2-Screen.width/8, 50, 100, 50), "Game Over!!!", MyStyle);
			IsPause ();
			reStart ();
		} else if (if_win_or_not == 1) {
			GUI.Label (new Rect (Screen.width/2-Screen.width/8, 50, 100, 50), "You Win!!!", MyStyle);
			IsPause ();
			reStart ();
		}
	}
}
