using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {
    public float camera_height = 1.8f;
    public float camera_distance = 1.0f;

    private Transform player;
    private Transform camera;

    private Vector3 m_camrot;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("player").transform;
        camera = Camera.main.transform;
        m_camrot = camera.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

        //look at palyer
        //camera.LookAt(player);

        float rv = Input.GetAxis("Mouse Y");
        float rh = Input.GetAxis("Mouse X");
        m_camrot.x -= rv;
        m_camrot.y += rh;
        camera.eulerAngles = m_camrot;

        //forward
        //camera.eulerAngles = new Vector3(camera.eulerAngles.x,
        //    player.eulerAngles.y,
        //    camera.eulerAngles.z);

        float angle = camera.eulerAngles.y;

        float deltax = camera_distance * Mathf.Sin(angle * Mathf.PI / 180);
        float deltaz = camera_distance * Mathf.Cos(angle * Mathf.PI / 180);

        
        camera.position = new Vector3(player.position.x - deltax+0.5f,
            player.position.y + camera_height,
            player.position.z - deltaz);

        //Debug.Log("angle: " + angle + ",deltax:" + deltax + "deltaz: " + deltaz);
        //Debug.Log(player.position);
        //Debug.Log(camera.position);
	}
}
