public class WordList
{
    private static readonly string[] Words = { "apple", "banana", "cherry", "date", "elderberry" };

    public static string GetRandomWord()
    {
        Random random = new Random();
        int index = random.Next(Words.Length);
        return Words[index];
    }
}