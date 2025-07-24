using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var set1 = new HashSet<string>();
        var set2 = new List<string>();
        foreach (var word in words)
        {
            if (word[0] != word[1])
            {
                char a = word[0];
                char b = word[1];
                string search = new string(new char[] { b, a });
                if (set1.Contains(search))
                {
                    set2.Add(search + " & " + word);
                }
                else
                {
                    set1.Add(word);
                }
            }
        }

        return set2.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        var set1 = new HashSet<string>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            set1.Add(fields[3]);
        }
        foreach (var degree in set1)
        {
            degrees.Add(degree, 0);
        }
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            int count = degrees[fields[3].ToString()];
            degrees[fields[3].ToString()] = count + 1;

        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var word1_list = new List<char>();
        var word2_list = new List<char>();
        foreach (var letter in word1)
        {
            if(letter!=' ')
                word1_list.Add(letter);
        }
        foreach (var letter in word2)
        {
            if(letter!=' ')
                word2_list.Add(letter);
        }
        if (word1_list.Count() != word2_list.Count())
            return false;
        else
        {
            var d1 = new Dictionary<char, int>();
            var d2 = new Dictionary<char, int>();
            foreach (var letter in word1_list)
            {
                if (!d1.ContainsKey(letter))
                {
                    d1.Add(letter, 0);
                }
                int count = d1[letter];
                d1[letter] = count + 1;
            }
            foreach (var letter in word2_list)
            {
                if (!d2.ContainsKey(letter))
                {
                    d2.Add(letter, 0);
                }
                int count = d2[letter];
                d2[letter] = count + 1;
            }
            if (d1.Count != d2.Count)
                return false;
            else
            {
                foreach (var letter in word1_list)
                {
                    if (!d2.ContainsKey(letter))
                        return false;
                    else
                    {
                        if (d1[letter] != d2[letter])
                        return false;
                    }                   
                }
            }
            return true;
        }
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// 
    /// ps://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        var results = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            results.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
        }
        return results.ToArray();
    }
}