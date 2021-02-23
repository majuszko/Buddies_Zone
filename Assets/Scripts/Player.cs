using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class Player : Photon.MonoBehaviour
{
    
    public GameObject playerCam;
    public PhotonView pV;
    public CharacterController control;
    public float speed = 6f;
    public float smooth = 0.1f;
    private float smoothVelocity;
    public Transform cam;
    private GameManager gm;
    [SerializeField] private CinemachineFreeLook playerCamera;
    private MenuController MC;
    [SerializeField] private TextMeshProUGUI UserName;
    

    private void Awake()
    {
        
        
    }

    void Start()
    {
        if (pV.isMine) {

            playerCam.SetActive(true);

            cam = GameObject.FindWithTag("MainCamera").gameObject.transform;
            
            
            
        }
        else
        {
            playerCam.SetActive(false);
            this.enabled=false;
        }
        
        AddUserName();
        
        
    }

    private void AddUserName()
    {
        UserName.text = photonView.owner.NickName;
    }
    
    void Update()
    {

        if (pV.isMine)
        {

            float hor = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");
            Vector3 movement = new Vector3(hor, 0f, ver).normalized;

            if (movement.magnitude >= 0.1f)
            {
                float angle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float turn = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref smoothVelocity, smooth);
                transform.rotation = Quaternion.Euler(0f, turn, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
                control.Move(moveDir.normalized * speed * Time.deltaTime);
            }
            
            playerCamera.Follow = gm.player.transform;
            playerCamera.LookAt = gm.player.transform;
            
            
        }
    }
    
}
