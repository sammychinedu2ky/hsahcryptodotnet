using System.Security.Cryptography;
using System.Text;
string output = "2a114d8da066acd377f9ccedcdec97fc50dd79636e9f7a5160da5704c9af1ce60387c9ec05692bd178f7bc5bf64d7ac5eead77b63a9a2c8b36f59dd4a7a02a114d8da066acd377f94c6a6aa98ddb714d49e61915120a1d5304de5c70f1dc7e932043c23741029b44dbeeb39951d2065a59f21d6fea9dc695410dae5a34079dc66663464c6a6aa98ddb71c2f150ec16cb37c1febbe07b30283b578b8eceb911684e461dc090136b535802cd3a3d7c40dbf91fc3f230cc330c60eaefc4e8dc9e7231c7c99d0f56fc2f1507709ce009a695a6dd3621ec0b5e28ac03071e2806316462624b3e03b165f3f1e048ecad888f9d78dfe676ae68667c7b6524fe8daf53fd144eeed4ae9296e8751e8b808f333f2f3204f2b7b7afc8007709ce009a695a6dd3621ec0b5e28ac03071e280631646e2af4eb15af30a2b5aa03a469c31b88abdc810f5fd964c9fc3affdd5238f9c432095e71f0dbc2d5b94613952437b1a5ad336f45efc54ce3ea75aa3dadedd6f69113e2af4eb15af30a2b5aa03a469c31b88a9855a7511365f11195e9837cce616672776f27b27495ce1e39fcf591f943754d3f25b670cd07f143d128880b58a45ee9aec338129da56f3e527ce53f7937c9db5516d8f7c64c6c53a9b2868a424f009855a7511365f11195e9837cce616672776f27b27495ce1e39fcf591f9433e782fcace4ecb7786774b426f2266f2625f3000182ae9e459bf5f7b3296262ea83fc23abab6df8862f585a4ba072e581f3797602550cd45700fb5129cbe3c03a1a1a41ef2c3e782fcace4ecb7786774b426f2266f262da8aad386690f2b9f5c60b6c3841d6853015312e63dcb6629ceb52eb6b70b8fb955b4d5d62f8b30895b47a39a696c7af48e56d4b993d449fc0f863c73efeb9004e76313fccb982b8e362aabf82cedda8aad386690f2b9f5c60b6c3841d6853015312e63dcb6addd78ad67da222c7ff62d838c4283f7b4420cf541aa42bdb9b792b0df1c9995ec1398380c60b24928db04168b41a3c63d120f257cecb82c982f3baddd78ad0ebfaa3d646962826635bc750a6715be15140c7855c77ac954fac502b05e923d969344cc87b0fe5861e66485dbead4035f43d7c08a0aae55573504356fe8e57dd3a5937d0f90ebfaa3d646962826635bcbbd8812c9a1f1853754b6c0ce4a012f9afb0aa99d0d5db7f6f7a88f95b2309a54c0fa1520eef94591e7ab5badf6cd941fa220248e375ee728c81c3310d6aedc43b2a54230f763f004cbbd8812c9a1f1853754b6c0ce4a0127912c437f43ce9a0e3ce87e5eea1978ee7ce86e7edfe307304f5d2a4a5581c0838d53394c5db85fd9abcb557ca8b6840b5dc594725ac85aedbf542650dc924f91eec0cc489087b13cc2cba98f33d44b7912c437f43ce9a0e3ce87e5eea1978ee7ce86e7edfe14305f7dc32d2da2c90f2898c74cd0bc98d289c5ed4c6de77a4dc3f0a55d63c910220e7460f9320744a461e9fc271fc6219262106d24f63cbdd67ae595920d801b4aaa8d36a94aaaa523d5934dfec0696e54b0545be3414305f7dc32d2da2c90f2898c74cd0bc98d289c5ed4c6de77a4dc3d1125205de49a032e7e852e50f84d035b3bea346dc19dddf0dba5b05ceffc56b997302e5370f78251a4cf1f168aa52494b5428d1945e127e8442d112";
List<string> first = Enumerable.Range(0, 127).Select(x => ((char)x).ToString()).ToList();
List<string> second = Enumerable.Range(0, 127).Select(x => ((char)x).ToString()).ToList();
second.Add("");
SortedDictionary<int, string> dict = new();
foreach (string i in first)
{
    foreach (string j in second)
    {
        string combined = i + j;
        byte[] data = Encoding.ASCII.GetBytes(combined);
        SHA512 shaM = SHA512.Create();
        byte[] hash = shaM.ComputeHash(data);
        var hashString = string.Join("", BitConverter.ToString(hash).Replace("-", "").ToLower().Reverse());
        var hashTakingOutMax = hashString[16..(hashString.Length - 16)];
        var localOutput = output;
        var indexStart = 0;
        while (localOutput.IndexOf(hashTakingOutMax, indexStart) is { } index)
        {
            if (index < 0) break;
            indexStart = index + hashTakingOutMax.Length;
            dict.Add(index, combined);
        }
    }
}
Console.WriteLine(string.Join("", dict.Select(x => x.Value)));


