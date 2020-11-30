using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    private GameObject controller;
    [SerializeField]
    private GameObject movePlate;

    private int xBoard = -1;
    private int yBoard = -1;

    private string player;

    public Sprite black_bishop;
    public Sprite white_bishop;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    public void Activate()
    {
        SetCords();

        switch (this.name)
        {
            case "black_knight": this.GetComponent<SpriteRenderer>().sprite = black_bishop;
                break;
            case "white_knight": this.GetComponent<SpriteRenderer>().sprite = white_bishop;
                break;
        }
    }

    public void SetCords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1);
    }

    public int GetXBoard()
    {
        return xBoard;
    }
    public int GetYBoard()
    {
        return yBoard;
    }
    public void SetXBoard(int x)
    {
        xBoard = x;
    }
    public void SetYBoard(int y)
    {
        yBoard = y;
    }
}
