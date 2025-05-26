using System.Collections;

string[] names = { "Adam", "Barry", "Charlie" };
foreach (string name in names)
{
  WriteLine($"{name} has {name.Length} characters.");
}
WriteLine("============================");
// check if the names array implements IEnumerable

IEnumerator e = names.GetEnumerator();
while (e.MoveNext())
{
  string name = (string)e.Current; // Current is read-only!
  WriteLine($"{name} has {name.Length} characters.");
}
