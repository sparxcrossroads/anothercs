using UnityEngine;
using System.Collections;

public class FPSPlayer : MonoBehaviour
{

    // Use this for initialization
    private CharacterController m_ch;
    public Transform m_transform;
    private Animator m_ani;

    private float m_moveSpeed = 2.5f;
    private float m_jumpSpeed = 8.0f;
    private float m_rotaspeed = 100.0f;
    public int m_life = 5;
    private float m_gravity = 20.0f;
    //0 walk 1 run
    private int fire_WalkorRun = 0;
    private float m_timer = 0;

    private Vector3 movedirection=Vector3.zero;
    void Start()
    {
        m_transform = this.transform;
        m_ch = this.GetComponent<CharacterController>();
        m_ani = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (m_life <= 0) return;
        m_transform.eulerAngles=new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        AnimatorStateInfo stateinfo = m_ani.GetCurrentAnimatorStateInfo(0);


        if (m_ch.isGrounded)
        {
            movedirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movedirection = transform.TransformDirection(movedirection);
            movedirection *= m_moveSpeed;

            if (Input.GetButton("Jump"))
            {
                movedirection.y = m_jumpSpeed;
            }

        }

        movedirection.y -= m_gravity * Time.deltaTime;

        m_ch.Move(movedirection * Time.deltaTime);

        transform.Rotate(0, 0, 0);

         // @animation
         // idle
        if (stateinfo.nameHash == Animator.StringToHash("Base Layer.idle") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("idle", false);

            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
                m_ani.SetBool("walk", true);

            if (Input.GetButton("Jump"))
                m_ani.SetBool("jump", true);

            if (Input.GetButton("Fire1"))
                m_ani.SetBool("idlefire", true);

            if (Input.GetKey(KeyCode.R))
            {
                print("reload");
                m_ani.SetBool("reload", true);
            }
        }

        // walk
        if (stateinfo.nameHash == Animator.StringToHash("Base Layer.walk") && !m_ani.IsInTransition(0))
        {
          
            m_ani.SetBool("walk", false);

            if (!Input.anyKey)
                m_ani.SetBool("idle", true);

            if (Input.GetButton("Jump"))
                m_ani.SetBool("jump", true);

            if (Input.GetButton("Fire1"))
                m_ani.SetBool("walkfire", true);

            if (Input.GetKey(KeyCode.R))
                m_ani.SetBool("reload", true);

        }

        // jump
        if (stateinfo.nameHash == Animator.StringToHash("Base Layer.jump") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("jump", false);

            if (m_ch.isGrounded)
                m_ani.SetBool("idle", true);

        }

        // idlefire
        if (stateinfo.nameHash == Animator.StringToHash("Base Layer.idlefire") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("idlefire", false);

            //print("idlefire");
            m_timer += Time.deltaTime;
            print(m_timer.ToString());

            if (m_timer > 0.8)
            {
                print("/rsssss");
                m_ani.SetBool("idle", true);
            }

            if (Input.GetKey(KeyCode.R))
            {
                print("reload");
                m_ani.SetBool("reload", true);
            }
        }

        // walkfire
        if (stateinfo.nameHash == Animator.StringToHash("Base Layer.walkfire") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("walkfire", false);

            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
                m_ani.SetBool("walk", true);

            if (Input.GetKey(KeyCode.R))
                m_ani.SetBool("reload", true);


        }

        //reload
         if (stateinfo.nameHash == Animator.StringToHash("Base Layer.reload") && !m_ani.IsInTransition(0))
         {
             m_ani.SetBool("reload", false);
             //finsh
             if (stateinfo.normalizedTime > 1.0f)
                 m_ani.SetBool("idle", true);

         }

         if (m_timer >0.8)
             m_timer = 0;
    }
    
}
