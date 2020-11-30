﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject chesspiece;

    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private string currentPlayer = "white";

    private bool gameOver = false;

    void Start()
    {
        playerWhite = new GameObject[]
        {
            Create("white_knight", 0,0),
            Create("white_knight", 1,0),
            Create("white_knight", 2,0),
            Create("white_knight", 3,0),
            Create("white_knight", 4,0),
            Create("white_knight", 5,0),
            Create("white_knight", 6,0),
            Create("white_knight", 7,0),
            Create("white_knight", 0,1),
            Create("white_knight", 1,1),
            Create("white_knight", 2,1),
            Create("white_knight", 3,1),
            Create("white_knight", 4,1),
            Create("white_knight", 5,1),
            Create("white_knight", 6,1),
            Create("white_knight", 7,1),
        };

        playerBlack = new GameObject[]
        {
            Create("black_knight",0,6),
            Create("black_knight",1,6),
            Create("black_knight",2,6),
            Create("black_knight",3,6),
            Create("black_knight",4,6),
            Create("black_knight",5,6),
            Create("black_knight",6,6),
            Create("black_knight",7,6),
            Create("black_knight",0,7),
            Create("black_knight",1,7),
            Create("black_knight",2,7),
            Create("black_knight",3,7),
            Create("black_knight",4,7),
            Create("black_knight",5,7),
            Create("black_knight",6,7),
            Create("black_knight",7,7),
        };

        for(int i =0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
    }

    public GameObject Create(string name , int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }
    public bool PositionOnBoard(int x ,int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) 
            return false;
        return true;
    }

  
}
