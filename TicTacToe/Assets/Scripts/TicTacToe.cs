using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public enum Player
{
    Red,
    Blue,
    None
}

public class TicTacToe : MonoBehaviour 
{
    public Text winnerText;
    public Button[] buttons;
    public Button restartButton;

    public Grid[] grids;

    public LineRenderer lineRendererPrefab;

    private Player currentPlayer = Player.Red;

    private bool gameEnded = false;

    void Start()
    {
        this.restartButton.gameObject.SetActive(false);
        this.winnerText.gameObject.SetActive(false);
        this.gameEnded = false;
        HashSet<Cube> cubes = new HashSet<Cube>();
        foreach (Grid g in this.grids)
        {
            foreach (Cube c in g.grid)
            {
                cubes.Add(c);
            }
        }
        foreach (Cube c in cubes)
        {
            c.CubeClicked += new CubeClickedEventHandler(this.CubeWasClicked); // set up the click handler on each cube
        }
    }

    // function that is called by the event of clicking a cube
    private void CubeWasClicked(Cube sender, EventArgs e)
    {
        if (this.gameEnded)
        {
            return;
        }

        sender.AssignPlayer(this.currentPlayer);

        foreach (Grid g in this.grids)
        {
            List<Tuple> lines = g.GetLines(this.currentPlayer);
            if (lines.Count > 0)
            {
                foreach (Tuple t in lines)
                {
                    LineRenderer lr = (LineRenderer) Instantiate(this.lineRendererPrefab, Vector3.zero, Quaternion.identity);
                    lr.SetPosition(0, t.Left);
                    lr.SetPosition(1, t.Right);
                }
                this.winnerText.gameObject.SetActive(true);
                this.winnerText.text = this.currentPlayer + " player wins !";
                foreach (Button b in this.buttons)
                {
                    b.gameObject.SetActive(false);
                }
                this.gameEnded = true;
                this.restartButton.gameObject.SetActive(true);
                return;
            }
        }

        this.nextTurn();
    }


    private void nextTurn()
    {
        switch (this.currentPlayer)
        {
            case Player.Red:
                this.currentPlayer = Player.Blue;
                break;
            case Player.Blue:
                this.currentPlayer = Player.Red;
                break;
            case Player.None:
                break;
            default:
                break;
        }
    }
}
