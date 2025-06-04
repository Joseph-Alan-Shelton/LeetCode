public class WildCardMatchingSolution
{
    public bool IsMatch(string s, string p)
    {
        // Handle null or empty strings
        if (string.IsNullOrEmpty(p))
        {
            return string.IsNullOrEmpty(s);
        }

        int stringIndex, patternIndex, asteriskIndex, matchIndex;
        asteriskIndex = -1;
        stringIndex = patternIndex = matchIndex = 0;

        while (stringIndex < s.Length)
        {
            if (patternIndex < p.Length && (p[patternIndex] == '?' || s[stringIndex] == p[patternIndex]))
            {
                stringIndex++;
                patternIndex++;
            }
            else if (patternIndex < p.Length && p[patternIndex] == '*')
            {
                asteriskIndex = patternIndex;
                matchIndex = stringIndex;
                patternIndex++;
            }
            else if (asteriskIndex != -1)
            {
                patternIndex = asteriskIndex + 1;
                matchIndex++;
                stringIndex = matchIndex;
            }
            else
            {
                return false;
            }
        }

        // Check for remaining characters in the pattern
        while (patternIndex < p.Length && p[patternIndex] == '*')
        {
            patternIndex++; // Skip over any trailing '*'
        }
        // If we have processed the entire pattern, we have a match
        return patternIndex == p.Length;

    }
    
}