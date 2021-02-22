namespace Infrastructure
{
    public interface IEmployee : IEmployeeBase
    {
        decimal annualSalary
        {
            get;
        }
    }
}
