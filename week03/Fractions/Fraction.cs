class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor with no parameters - initializes to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor with one parameter for the top - initializes denominator to 1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor with two parameters for top and bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter for top
    public int GetTop()
    {
        return _top;
    }

    // Setter for top
    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter for bottom
    public int GetBottom()
    {
        return _bottom;
    }

    // Setter for bottom
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Returns the fraction in the form 3/4
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns a double that is the result of dividing top by bottom
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
