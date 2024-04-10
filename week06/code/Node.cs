public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
    if (value < Data) {
        // Insert to the left
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else if (value > Data) {
        // Insert to the right
        if (Right is null)
            Right = new Node(value);
        else
            Right.Insert(value);
    }
    // do nothing if value is equal to Data, i.e., the value already exists in the tree
}

    public bool Contains(int value) {
        if (value < Data) {
            // Look to the left
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else if (value > Data) {
            // Look to the right
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
        else {
            // The current node's value is equal to the searched value
            return true;
        }
    }

    public int GetHeight() {
        int leftHeight = Left != null ? Left.GetHeight() : -1;
        int rightHeight = Right != null ? Right.GetHeight() : -1;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}