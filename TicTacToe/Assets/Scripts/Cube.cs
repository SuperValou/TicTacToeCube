using UnityEngine;
using System.Collections;
using System;

public delegate void CubeClickedEventHandler(Cube sender, EventArgs e);

public class Cube : MonoBehaviour 
{
    public event CubeClickedEventHandler CubeClicked;

    public Player Player
    {
        get;
        set;
    }

    void Start()
    {
        this.Player = Player.None;
    }

    // function called when the cube is clicked
    protected virtual void OnClicked(EventArgs e)
    {
        if (this.CubeClicked != null) // if the click handler is not null
        {
            this.CubeClicked(this, e); // call the click handler
        }
    }

    // click on this cube
    void OnMouseDown()
    {
        if (this.Player == Player.None)
        {
            this.OnClicked(EventArgs.Empty);
        }        
    }

    internal void AssignPlayer(Player player)
    {
        this.Player = player;
        if (player == Player.Red)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (player == Player.Blue)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            return;
        }
    }
}
