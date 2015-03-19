using UnityEngine;
using System.Collections;

public class FPSPlayer : MonoBehaviour
{

    // Use this for initialization
    private CharacterController m_ch;
    public Transform m_transform;
    private float m_moveSpeed = 6.0f;
    private float m_jumpSpeed = 8.0f;

    public int m_life = 5;
    private float m_gravity = 20.0f;

    private Transform m_camTransform;
    private Vector3 m_camRot;        //camera rotation

    private Vector3 movedirection=Vector3.zero;
    
    void Start()
    {
        m_transform = this.transform;
        m_ch = this.GetComponent<CharacterController>();

        m_camTransform = Camera.main.transform;

        m_camTransform.rotation = m_transform.rotation;

        // set camera eulerangles 
        m_camRot = m_camTransform.eulerAngles;

        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_life <= 0) return;

        // rotation camera
        float rv = Input.GetAxis("Mouse Y");
        float rh = Input.GetAxis("Mouse X");

        m_camRot.x -= rv;
        m_camRot.y += rh;

        m_camTransform.eulerAngles = m_camRot;

        // paler dynamically follow camera
        Vector3 camrot = m_camTransform.eulerAngles;
        camrot.x = 0; camrot.z = 0;     // only rotate on y axis
        m_transform.eulerAngles = camrot;

        if (m_ch.isGrounded)
        {
            movedirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movedirection = transform.TransformDirection(movedirection);
            movedirection*=m_moveSpeed;

            if (Input.GetButton("Jump"))
            {
                movedirection.y = m_jumpSpeed;
            }
        }
        movedirection.y -= m_gravity * Time.deltaTime;

        m_ch.Move(movedirection*Time.deltaTime);
    }
    
}
