using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControlReadScript : MonoBehaviour
{
    // Start is called before the first frame update
    public playerScript player1;
    public playerScript player2;
    public GameObject touchControls;

    public void ToggleTouchControls()
    {
        touchControls.SetActive(!touchControls.activeSelf);
    }



    bool mrp1;
    bool mlp1;
    bool mup1;

    bool mrp2;
    bool mlp2 ;
    bool mup2 ;

    private void Start()
    {
        mrp1 = false;
        mlp1 = false;
        mup1 = false;

        mrp2 = false;
        mlp2 = false;
        mup2 = false;
    }


    private void Update()
    {
        if (mrp1)
        {
            player1.MovePlayerRightStart();
        }

        if (mlp1)
        {
            player1.MovePlayerLeftStart();
        }

        if (mup1)
        {
            player1.JumpPlayer(1);
        }

        if (mrp2)
        {
            player2.MovePlayerRightStart();
        }

        if (mlp2)
        {
            player2.MovePlayerLeftStart();
        }

        if (mup2)
        {
            player2.JumpPlayer(1);
        }


    }


    public void StartMoveRightPlayer1()
    {
        mrp1 = true;
    }

    public void StopMoveRightPlayer1()
    {
        mrp1 = false;
        player1.StopPlayerHorizontal();
    }

    //

    public void StartMoveLeftPlayer1()
    {
        mlp1 = true;
    }

    public void StopMoveLeftPlayer1()
    {
        mlp1 = false;
        player1.StopPlayerHorizontal();
    }

    //

    public void StartMoveUpPlayer1()
    {
        mup1 = true;
    }

    public void StopMoveUpPlayer1()
    {
        mup1 = false;
    }

    //


    public void StartMoveRightPlayer2()
    {
        mrp2 = true;
        
    }

    public void StopMoveRightPlayer2()
    {
        player2.StopPlayerHorizontal();
        mrp2 = false;
    }

    //

    public void StartMoveLeftPlayer2()
    {
        mlp2 = true;
    }

    public void StopMoveLeftPlayer2()
    {
        mlp2 = false;
        player2.StopPlayerHorizontal();
    }

    //

    public void StartMoveUpPlayer2()
    {
        mup2 = true;
    }

    public void StopMoveUpPlayer2()
    {
        mup2 = false;
    }

    //







}
