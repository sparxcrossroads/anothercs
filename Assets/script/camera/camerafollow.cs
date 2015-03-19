using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {
    public float camera_height = 2.0f;
    public float camera_distance = 4.0f;

    private Transform player;
    private Transform camera;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        camera = Camera.main.transform;

	}
	
	// Update is called once per frame
	void Update () {

        //look at palyer
        //camera.LookAt(player);

        //forward
        camera.eulerAngles = new Vector3(camera.eulerAngles.x,
            player.eulerAngles.y,
            camera.eulerAngles.z);

        
        float angle = camera.eulerAngles.y;

        float deltax = camera_distance * Mathf.Sin(angle * Mathf.PI / 180);
        float deltaz = camera_distance * Mathf.Cos(angle * Mathf.PI / 180);

        camera.position = new Vector3(player.position.x - deltax,
            player.position.y + camera_height,
            player.position.z - deltaz);

        Debug.Log("angle: " + angle + ",deltax:" + deltax + "deltaz: " + deltaz);
       
	}
}
