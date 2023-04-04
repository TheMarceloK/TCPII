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
    void Start()
    {
        player = FindObjectOfType<Player>();
        life.maxValue = 100;
    }

    void Update()
    {
        text.text = player.Bullets + "/" + player.defaultBullets;

        if(player.Bullets == 0)
        {
            textWarning.SetActive(true);
        }
        else
        {
            textWarning.SetActive(false);
        }

        life.value = player.currentLife;
    }
}
