using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject btnOpt;
    [SerializeField] private GameObject btnBack;
    public void options()
    {
        canvas.SetActive(true);
        btnOpt.SetActive(false);
        btnBack.SetActive(true);
    }
    public void optionsLeave()
    {
        canvas.SetActive(false);
        btnOpt.SetActive(true);
        btnBack.SetActive(false);
    }
    
}
