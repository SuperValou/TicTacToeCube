using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
    public TicTacToe cube;
    private bool rotating = false;
    public float speedOfRotation = 1;

    public void RotateX()
    {
        if (this.rotating)
        {
            return;
        }
        this.rotating = true;
        StartCoroutine(this.rotate(Vector3.right));
    }
    public void RotateY()
    {
        if (this.rotating)
        {
            return;
        }
        this.rotating = true;
        StartCoroutine(this.rotate(Vector3.up));
    }
    public void RotateZ()
    {
        if (this.rotating)
        {
            return;
        }
        this.rotating = true;
        StartCoroutine(this.rotate(Vector3.forward));
    }

    private IEnumerator rotate(Vector3 axis)
    {
        float angle = 90F / this.speedOfRotation;
        while (angle-- > 0)
        {
            this.cube.transform.Rotate(axis, this.speedOfRotation, Space.World);
            yield return new WaitForEndOfFrame();
        }
        this.rotating = false;
    }

    public void Restart()
    {
        Application.LoadLevel(0);
    }
    
}
