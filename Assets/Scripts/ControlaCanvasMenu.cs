using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlaCanvasMenu : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) 
        {
            SceneManager.LoadScene("Matheus");
        }
    }
}
