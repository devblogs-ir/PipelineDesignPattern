namespace Design.Cohesion;

public class Functional
{
    public int Sum(List<int> numbers)
    {
        return numbers.Sum();
    }

    public int Minimum(List<int> numbers)
    {
        return numbers.Min();
    }
    
}
