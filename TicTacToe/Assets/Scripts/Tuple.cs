using UnityEngine;

public class Tuple 
{
    public Vector3 Left { get; set; }
    public Vector3 Right { get; set; }

    public Tuple(Vector3 left, Vector3 right)
    {
        this.Left = left;
        this.Right = right;
    }

    public override int GetHashCode()
    {
        return (this.Left + this.Right).GetHashCode();
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
