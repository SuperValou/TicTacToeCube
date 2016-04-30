using UnityEngine;

public class Tuple 
{
    public Transform Left { get; set; }
    public Transform Right { get; set; }

    public Tuple(Transform left, Transform right)
    {
        this.Left = left;
        this.Right = right;
    }

    public override int GetHashCode()
    {
        return (this.Left.position + this.Right.position).GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is Tuple)
        {
            return this.Left == ((Tuple)obj).Left && this.Right == ((Tuple)obj).Right;
        }
        return false;
    }
}
