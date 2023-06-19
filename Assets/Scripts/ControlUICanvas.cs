using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUICanvas : MonoBehaviour
{
    [SerializeField]
    private Text text;
    public GameObject textWarning;
    private Player player;
    [SerializeField]
    private Slider life;
    [SerializeField]
    private Slider ammo;
    [SerializeField]
    private GameObject UIPause, UIOptions, UIButtons, UIHud;    
    void Start()
    {
        player = FindObjectOfType<Player>();
        life.maxValue = 100;
        UIHud.SetActive(true);
    }

    void Update()
    {
        text.text = player.Bullets + "/" + player.defaultBullets;
        ammo.maxValue = player.defaultBullets;
        ammo.value = player.Bullets;

        if (player.Bullets == 0)
        {
            textWarning.SetActive(true);
        }
        else
        {
            textWarning.SetActive(false);
        }

        life.value = player.currentLife;

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            UIPause.SetActive(true);
            UIHud.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        UIPause.SetActive(false);
        UIHud.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Options()
    {
        UIOptions.SetActive(true);
        UIButtons.SetActive(false);
    }
    public void ReturnMenu()
    {
        UIOptions.SetActive(false);
        UIButtons.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
