using System.Text.Json;
using System.Collections.Generic;

namespace PusulaTalentAcademy
{
    public class LongestVowelSubsequenceAsJson
    {
        public static string LongestVowelSubsequenceasJson(List<string> words)
        {
            if (words == null ||words.Count == 0)
                return "[]";

            var sesliHarfler = "aeiou";
            var sonuc = new List<object>();

            foreach (var word in words)
            {
                string enUzunDizi = "";
                string geciciDizi = "";

                foreach (var ch in word)
                {
                    if (sesliHarfler.Contains(char.ToLower(ch)))
                    {
                        geciciDizi += ch;
                        if (geciciDizi.Length > enUzunDizi.Length)
                            enUzunDizi = geciciDizi; 
                        
                    }
                    else
                    {
                        geciciDizi = "";
                    }
                    //gecici diziyi eger ilgili kosul saglanmazsa bosaltip en uzun sesli harf dizisini elde etmeye calisiriz
                }

                sonuc.Add(new
                {
                    kelime = word,
                    sesliHarfler = enUzunDizi,
                    uzunluk = enUzunDizi.Length
                });
            }

            return JsonSerializer.Serialize(sonuc);
        }
    }
}
