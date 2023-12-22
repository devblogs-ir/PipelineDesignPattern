namespace Design.Cohesion;

public class Sequential
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsTeenager { get; set; }


    public bool CheckTeenager(int age)=>(age >= 13 || age <= 17);

    public Sequential(string name, int age)
    {
        Name = name;
        Age = age;
        
        IsTeenager = CheckTeenager(age);    
    }
    
}
