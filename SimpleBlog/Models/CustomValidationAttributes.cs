using System.ComponentModel.DataAnnotations;
public class NotPastDateAttribute : ValidationAttribute
{
  public override bool IsValid(object value)
  {
    DateTime date;
    if (DateTime.TryParse(value?.ToString(), out date))
    {
      return date >= DateTime.Now;
    }
    return false;
  }
}
