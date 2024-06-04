namespace VideoRental;

[Serializable]
public class RentalDaysException(int days) : Exception
{
    public int Days => days;
}