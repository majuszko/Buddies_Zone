using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Pref;
    public GameObject Canv;
    public GameObject Cam;


    public void SpawnPlayer()
    {
        float randx = Random.Range(80f, 90f);
        float randz = Random.Range(-70f, -80f);
        PhotonNetwork.Instantiate(Pref.name,
            new Vector3(randx, 2.88f, randz),
            Quaternion.identity, 0);
        
        
        
        Canv.SetActive(false);
        
        
        
        //Cam.SetActive(false);
    }
}
