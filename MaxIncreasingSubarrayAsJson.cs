using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace PusulaTalentAcademy
{
    public class MaxIncreasingSubarrayAsJson
    {
        public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                return "[]";

            List<int> maxAltDizi = new List<int>();
            List<int> AltDizi = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == 0 || numbers[i] > numbers[i - 1])
                {
                    AltDizi.Add(numbers[i]); //eğer dizi ardışık gidiyorsa altdizi değişkenine geçerli sayıyı ekle
                }
                else
                {
                    if (Sum(AltDizi) > Sum(maxAltDizi))
                        maxAltDizi = new List<int>(AltDizi);
                    //eğer bir sayı dizisi içerisinde iki farklı alt dizi bulduysak bu iki diziyi kıyaslar ve
                    //toplama göre en büyük olan alt diziyi elde ederiz
                    

                    AltDizi = new List<int> { numbers[i] };
                }
            }

            if (Sum(AltDizi) > Sum(maxAltDizi))
                maxAltDizi = AltDizi;

            return JsonSerializer.Serialize(maxAltDizi);
        }

        private static int Sum(List<int> list)
        {
            int sum = 0;
            foreach (var num in list)
                sum += num;
            return sum;
        }
    }
}
