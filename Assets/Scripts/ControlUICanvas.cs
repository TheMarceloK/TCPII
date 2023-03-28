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
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        text.text = player.Bullets + "/6";

        if(player.Bullets == 0)
        {
            textWarning.SetActive(true);
        }
        else
        {
            textWarning.SetActive(false);
        }
    }
}
