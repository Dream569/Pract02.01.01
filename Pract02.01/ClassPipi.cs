namespace Pract02._01
{
    public class ClassPipi
    {
        private static readonly Dictionary<char, int> CharacterValues = new Dictionary<char, int>
    {
        { 'А', -16 }, { 'Б', -15 }, { 'В', -14 }, { 'Г', -13 }, { 'Д', -12 },
        { 'Е', -11 }, { 'Ё', -10 }, { 'Ж', -9 }, { 'З', -8 }, { 'И', -7 },
        { 'Й', -6 }, { 'К', -5 }, { 'Л', -4 }, { 'М', -3 }, { 'Н', -2 },
        { 'О', -1 }, { 'П', 0 }, { 'Р', 1 }, { 'С', 2 }, { 'Т', 3 },
        { 'У', 4 }, { 'Ф', 5 }, { 'Х', 6 }, { 'Ц', 7 }, { 'Ч', 8 },
        { 'Ш', 9 }, { 'Щ', 10 }, { 'Ь', 11 }, { 'Ю', 12 }, { 'Я', 13 }
    };

        public static List<int> GetNumericValues(string input)
        {
            List<int> numericValues = new List<int>();
            foreach (char c in input)
            {
                if (CharacterValues.TryGetValue(c, out int value))
                {
                    numericValues.Add(value);
                }
            }
            return numericValues;
        }
    }
}
