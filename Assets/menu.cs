using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject playercanvas;
    public GameObject player;
    public GameObject boss;
    // Start is called before the first frame update
    private void Start()
    {
        player.SetActive(false);
        boss.SetActive(false);
        playercanvas.SetActive(false);
    }
    public void startgame()
    {
        playercanvas.SetActive(true);
        canvas.SetActive(false);
        player.SetActive(true);
        boss.SetActive(true);

    }


}
