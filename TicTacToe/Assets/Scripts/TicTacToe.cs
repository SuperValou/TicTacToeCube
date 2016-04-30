using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.Linq;

public enum Player
{
    Red,
    Blue,
    None
}

public class TicTacToe : MonoBehaviour 
{
    public Text currentPlayerText;
    public Button restartButton;

    public Grid[] grids;

    public LineFollower linePrefab;

    private Player currentPlayer = Player.Red;

    private bool gameEnded = false;

    public Text hint;

    void Start()
    {
        this.hint.gameObject.SetActive(true);
        this.restartButton.gameObject.SetActive(false);
        this.gameEnded = false;   
     
        // setup the cubes
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
            c.CubeClicked += new CubeClickedEventHandler(this.cubeWasClicked); // set up the click handler on each cube
        }

        // setup the gui
        this.currentPlayerText.text = this.currentPlayer.ToString() + ", it's your turn";
        switch (this.currentPlayer)
        {
            case Player.Red:
                this.currentPlayerText.color = Color.red;
                break;
            case Player.Blue:
                this.currentPlayerText.color = Color.blue;
                break;
            case Player.None:
                break;
            default:
                break;
        }

        // setup the interaction
        this.up = Vector3.Cross(Camera.main.transform.position - this.transform.position, Camera.main.transform.right);
        this.right = Vector3.Cross(this.up, Camera.main.transform.position - this.transform.position);
    }

    /// <summary>
    /// function that is called by the event of clicking a cube
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cubeWasClicked(Cube sender, EventArgs e)
    {
        if (this.gameEnded)
        {
            return;
        }

        // color the cube that was clicked
        sender.AssignPlayer(this.currentPlayer);

        // check if a player won
        List<Tuple> lines = new List<Tuple>();
        foreach (Grid g in this.grids)
        {
            var l = g.GetLines(this.currentPlayer);
            foreach (Tuple t in l)
            {
                lines.Add(t);
            }
        }
        if (lines.Count > 0)
        {
            foreach (Tuple t in lines)
            {
                LineFollower lf = (LineFollower) Instantiate(this.linePrefab, Vector3.zero, Quaternion.identity);
                lf.line = lf.GetComponent<LineRenderer>();
                lf.Left = t.Left;
                lf.Right = t.Right;
                    
                switch (this.currentPlayer)
                {
                    case Player.Red:
                        lf.line.SetColors(Color.red, Color.red);
                        break;
                    case Player.Blue:
                        lf.line.SetColors(Color.blue, Color.blue);
                        break;
                    case Player.None:
                        break;
                    default:
                        break;
                }
            }

            this.currentPlayerText.text = this.currentPlayer + " player wins !";
            this.gameEnded = true;
            this.restartButton.gameObject.SetActive(true);
            return;
        }
        

        this.nextTurn();
    }

    /// <summary>
    /// Change the current player to the next player
    /// </summary>
    private void nextTurn()
    {
        switch (this.currentPlayer)
        {
            case Player.Red:
                this.currentPlayer = Player.Blue;
                this.currentPlayerText.color = Color.blue;
                break;
            case Player.Blue:
                this.currentPlayer = Player.Red;
                this.currentPlayerText.color = Color.red;
                break;
            case Player.None:
                this.currentPlayerText.color = Color.white;
                break;
            default:
                break;
        }
        this.currentPlayerText.text = this.currentPlayer.ToString() + ", it's your turn";
    }

    /// <summary>
    /// Restart the game
    /// </summary>
    public void Restart()
    {
        Application.LoadLevel(0);
    }

    void Update()
    {
        if (!this.gameEnded && Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            this.transform.Rotate(this.up, x * 6, Space.World);
            this.transform.Rotate(this.right, y * 6, Space.World);
        }
        if (this.gameEnded)
        {
            this.transform.Rotate(this.up, 1, Space.World);

        }
        if (Input.GetMouseButtonDown(1))
        {
            this.hint.gameObject.SetActive(false);
        }
    }

    private Vector3 up;
    private Vector3 right;

}
