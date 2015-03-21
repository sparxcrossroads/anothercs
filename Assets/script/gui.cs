using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {

    public static gui Instance = null;

    public int m_score = 0;
    public static int m_maxscore = 0;
    public int m_bullet = 100;
    private FPSPlayer m_play;

	// Use this for initialization
	void Start () {
        Instance = this;
        m_play = GameObject.FindGameObjectWithTag("player").GetComponent<FPSPlayer>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        if(m_play.m_life<=0)
        {
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 40;
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "you died");

            //restart
            GUI.skin.label.fontSize = 30;
            if (GUI.Button(new Rect(Screen.width * 0.5f - 150, Screen.height * 0.75f, 300, 40), "continue"))
                Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
