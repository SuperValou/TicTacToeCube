using UnityEngine;
using System.Collections;

public class LineFollower : MonoBehaviour 
{
    public Transform Left
    {
        get;
        set;
    }
    public Transform Right
    {
        get;
        set;
    }
    public LineRenderer line
    {
        get;
        set;
    }

	void Update () 
    {
        this.line.SetPosition(0, Left.position);
        this.line.SetPosition(1, Right.position);
	}
}
