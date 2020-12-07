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

    #region Get Set Board Cords
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
    #endregion

    #region 1. Set up board and figures
    //Attach controller
    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }
    //Give figures a sprite and attach to player
    public void Activate()
    {
        SetCords();

        switch (this.name)
        {
            case "black_knight": 
                this.GetComponent<SpriteRenderer>().sprite = black_bishop;
                player = "black";
                break;
            case "white_knight": 
                this.GetComponent<SpriteRenderer>().sprite = white_bishop;
                player = "white";
                break;
        }
    }
    //Placing figures on the board 
    public void SetCords()
    {
        float x = xBoard;
        float y = yBoard;
        //Board cofficient to proprerly display figures position
        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1);
    }
    #endregion

    #region 2. Display move paletes
    //Make a move 
    private void OnMouseUp()
    {   
        // Check if game is over and you use your figure
        if (!controller.GetComponent<Game>().IsGameOver() && controller.GetComponent<Game>().GetCurrentPlayer() == player)
        {
            DestroyMovePlates();
            LMovePlate();
        }
    }
    //Destroy palete
    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }
    //Find all knight posible moves
    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }
    //Instantiate a palete on given x and y, choose bethween green and red depends on others fugures
    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if (cp == null)
            {
                MovePlateSpawn(x, y);
            }
            else if (cp.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }
    //Instantiate a Green Plate on the board on given x and y cords
    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCords(matrixX, matrixY);
    }
    //Instantiate a Red Plate on the board on given x and y cords
    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCords(matrixX, matrixY);
    }
    #endregion
}
