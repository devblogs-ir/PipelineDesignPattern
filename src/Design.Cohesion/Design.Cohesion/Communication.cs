namespace Design.Cohesion;

public class Communication
{
    public int EnergyPercentage { get; set; }


    public void Sleep()=> EnergyPercentage += 4;
    

    public void Work() => EnergyPercentage -= 10;

}
