using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.EventHandlers;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else if (value < Data)
        {
            if (Left is not null)
                return Left.Contains(value);
        }
        else if (value > Data)
        {
            if (Right is not null)
                return Right.Contains(value);
        }
        return false;
    }

    public int GetHeight()
    {
        int Max_Left, Max_Right;
        if (Left is not null)
            Max_Left = 1 + Left.GetHeight();
        else
            Max_Left = 1;
        if (Right is not null)
            Max_Right = 1 + Right.GetHeight();
        else
            Max_Right = 1;
        if (Max_Left > Max_Right)
        {
            return Max_Left;
        }
        else
        {
            return Max_Right;
        }
    }
}