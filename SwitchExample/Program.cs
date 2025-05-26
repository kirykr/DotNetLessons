

var animals = new Animal?[]
{
  new Cat {
    Name = "Karen",
    Born = new(year: 2022, month: 8, day: 23),
    Legs = 4, IsDomestic = true
  },
  null,
  new Cat {
    Name = "Mufasa",
    Born = new(year: 1994, month: 6,
    day: 12)
  },
  new Spider { Name = "Sid Vicious", Born = DateTime.Today, IsVenomous = true},
  new Spider { Name = "Captain Furry", Born = DateTime.Today }
};

foreach (Animal? animal in animals)
{
  string message;
  // switch (animal)
  // {
  //   case Cat fourLeggedCat when fourLeggedCat.Legs == 4:
  //     message = $"The cat named {fourLeggedCat.Name} has four legs.";
  //     break;
  //   case Cat wildCat when wildCat.IsDomestic == false:
  //     message = $"The non-domestic cat is named {wildCat.Name}.";
  //     break;
  //   case Cat cat:
  //     message = $"The cat is named {cat.Name}.";
  //     break;
  //   default: // default is always evaluated last.
  //     message = $"Default: {animal.Name} is a {animal.GetType().Name}.";
  //     break;
  //   case Spider spider when spider.IsVenomous:
  //     message = $"The {spider.Name} spider is venomous. Run!";
  //     break;
  //   case null:
  //     message = "The animal is null.";
  //     break;
  // }

  // Using simplifying switch expression instead of switch statement.
  message = animal switch
  {
    Cat fourLeggedCat when fourLeggedCat.Legs == 4
      => $"The cat named {fourLeggedCat.Name} has four legs.",
    Cat wildCat when wildCat.IsDomestic == false
      => $"The non-domestic cat is named {wildCat.Name}.",
    Cat cat
      => $"The cat is named {cat.Name}.",
    Spider spider when spider.IsVenomous
      => $"The {spider.Name} spider is venomous. Run!",
    null
        => "The animal is null.",
    _
      => $"Default: {animal.Name} is a {animal.GetType().Name}."
  };
  WriteLine($"switch statement: {message}");
}

class Cat : Animal // This is a subtype of animal.
{
  public bool IsDomestic;
}
class Spider : Animal // This is another subtype of animal.
{
  public bool IsVenomous;
}
class Animal // This is the base type for all animals.
{
  public string? Name;
  public DateTime Born;
  public byte Legs;
}
