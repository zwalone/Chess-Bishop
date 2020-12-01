using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    private GameObject controller;

    GameObject reference = null;

    int matrixX;
    int matrixY;

    public bool attack = false;

    private void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0, 1f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        var game = controller.GetComponent<Game>();
        var cm = reference.GetComponent<Chessman>();

        if (attack)
        {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            if (game.NumberOfFigure() == 0) 
                game.Winner(game.GetCurrentPlayer());

            Destroy(cp);
        }

        game.SetPositionEmpty(
            reference.GetComponent<Chessman>().GetXBoard(), 
            reference.GetComponent<Chessman>().GetYBoard()
        );

        cm.SetXBoard(matrixX);
        cm.SetYBoard(matrixY);
        cm.SetCords();

        game.SetPosition(reference);
        game.SetPosition(reference);
        game.NextTurn();
        cm.DestroyMovePlates();
    }

    public void SetCords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }

}
