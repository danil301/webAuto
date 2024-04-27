






//using Newtonsoft.Json.Linq;
//using System.Text;



//string apiUrl = "https://api.api-ninjas.com/v1/imagetotext";
//string imagePath = "C:/Users/dvory/Desktop/tt.png";
//string apiKey = "WKaDt7a16+wo8BYJ19aNFg==n4GMNFvYPLSXN4kr";

//using (var httpClient = new HttpClient())
//{
//    using (var formData = new MultipartFormDataContent())
//    {
//        formData.Add(new StreamContent(File.OpenRead(imagePath)), "image", Path.GetFileName(imagePath));
//        formData.Add(new StringContent("rus"), "language");
//        httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

//        var response = await httpClient.PostAsync(apiUrl, formData);
//        var jsonResponse = await response.Content.ReadAsStringAsync();

//        // Парсинг JSON-ответа
//        var result = JArray.Parse(jsonResponse);

//        // Вывод текста из каждого элемента
//        foreach (var item in result)
//        {
//            Console.WriteLine(item["text"]);
//        }

//    }
//}