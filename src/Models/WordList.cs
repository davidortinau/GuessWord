public class PuzzleList
{
    private static readonly string[] Puzzles = { "apple", "banana", "cherry", "date", "elderberry", "frozen yogurt", "green tea", "hot chocolate", "ice cream", "lemonade" };

    public static string GetRandomPuzzle()
    {
        Random random = new Random();
        int index = random.Next(Puzzles.Length);
        return Puzzles[index];
    }
}