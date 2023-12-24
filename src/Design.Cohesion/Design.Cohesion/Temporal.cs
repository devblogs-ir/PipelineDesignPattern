using System.Reflection.Emit;

namespace Design.Cohesion;

 public interface ILoan
{
    string label { get; set; }
    int quantity { get; set; }
    int installment { get; set; }
    
}



public class Temporal
{
    
    string name { get; set; }
    private DateTime createdAt { get; set; }
    ILoan loan { get; set; }
    bool isDebtor { get; set; }
    private List<int> transactions { get; set; }


    public Temporal(string name)
    {
        this.name = name;
        createdAt=DateTime.Now;
    }

    public void AddTransaction(int x) => transactions.Add(x);

    public void addLoan(ILoan loan)
    {
        if (transactions.Sum()>=10000000 && (createdAt - DateTime.Now).Days>700)
        {
            this.loan = loan;
        }
    }
    public void handleDebtor()
    {
        if (Convert.ToBoolean(loan.installment))
        {
            this.isDebtor = true;
        }
        else this.isDebtor = false;
    }
    
    
    //AddTransaction(300);
    //AddTransaction(200);
    //AddTransaction(500);
    //AddTransaction(100);
    //AddTransaction(400);
    //AddLoan
    //handleDebtor


}
