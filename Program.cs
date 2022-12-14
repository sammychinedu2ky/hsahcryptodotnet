using System.Security.Cryptography;
using System.Text;
string output = File.ReadAllText("./input.txt");
var first = Enumerable.Range(0, 1_2_7).Select(x => ((char)x).ToString());
var second = Enumerable.Range(0, 1_2_7).Select(x => ((char)x).ToString());
second = second.Append("");
SortedDictionary<int, string> dict = new();
foreach (string i in first)
{
    foreach (string j in second)
    {
        string combined = i + j;
        byte[] data = Encoding.UTF8.GetBytes(combined);
        SHA512 shaM = SHA512.Create();
        byte[] hash = shaM.ComputeHash(data);
        // var hashString = string.Join("", BitConverter.ToString(hash).Replace("-", "").ToLower().Reverse());
        // var hashTakingOutMax = hashString[16..(hashString.Length - 16)];
        var hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();
        var hashTakingOutMax = string.Join("", hashString[16..(hashString.Length - 16)].Reverse());
        var indexStart = 0;
        while (output.IndexOf(hashTakingOutMax, indexStart) is { } index)
        {
            if (index < 0) break;
            indexStart = index + hashTakingOutMax.Length;
            dict.Add(index, combined);
        }
    }
}
// FLAG{Find-the-hash-in-trash!!}
Console.WriteLine(string.Join("", dict.Select(x => x.Value)));


