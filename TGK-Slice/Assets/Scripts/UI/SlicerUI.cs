using UnityEngine;
using System.Collections;

public class SlicerUI : MonoBehaviour {
	
	public GUIStyle slicerStyle = new GUIStyle();
	private Rect rectScore;
	private Rect rectLife;

	private Player p;

	// Use this for initialization
	void Start () {
		p = Camera.main.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		positionText();
		GUI.Label(rectScore, "Score : "+p.score, slicerStyle);
		GUI.Label(rectLife, "Life : "+p.life, slicerStyle);

		if(GameState.state==0)
			GUI.Label(new Rect(Screen.width/2-2f, Screen.height/2,50,50), "Game Over", slicerStyle);
	}

	void positionText(){
		rectScore.width = Screen.width*0.3f;
		rectScore.height = Screen.height*0.1f;
		rectLife.width = Screen.width*0.3f;
		rectLife.height = Screen.height*0.1f;

		rectScore.x = (Screen.width*(1-0.3f))/2;
		rectLife.x = (Screen.width*0.7f);
		rectScore.y = (Screen.height*0.01f);
		rectLife.y = (Screen.height*0.01f);
	}
}
