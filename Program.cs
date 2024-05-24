using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace DictionarySystemTextJson
{
   internal class Program
   {
      static void Main()
      {
         // Десериализация словарей System.Text.Json по строке
         string json = @"{""User"":""YoRHa2B"",""key"":""123""}";
         Dictionary<string, string> values = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
         Console.WriteLine(values.Count);
         Console.WriteLine(values["User"]);

         // Десериализация словарей System.Text.Json по классу
         MyClient element = new MyClient
         {
            Data = new StringBuilder(@"{""User"":""YoRHa2B"",""key"":""123""}")
         };

         Dictionary<string, string> valuesmyclient = JsonSerializer.Deserialize<Dictionary<string, string>>(element.Data.ToString());
         Console.WriteLine(valuesmyclient.Count);
         Console.WriteLine(valuesmyclient["User"]);
         Console.WriteLine(valuesmyclient["User"]);

         foreach (KeyValuePair<string, string> keyvaluepair in valuesmyclient)
         {
            Console.WriteLine($"{keyvaluepair.Key} = {keyvaluepair.Value}");
         }
         
         
         string json2 = @"{""ABC"": {""Name"": ""Bob"", ""Age"": ""40""},""DEF"": {""Type"": ""Cat"",""Sound"": ""Meow""}}";
         var dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json2);

         foreach (var (key, val) in dictionary)
         {
            Console.WriteLine($"{key}={val}");
         }

         // Десериализация словарей System.Text.Json по строке из файла
         string jsonString = File.ReadAllText("YoRHa2B.json");

         //Dictionary<string, string> valuesclient2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
         //foreach (KeyValuePair<string, string> keyvaluepair in valuesclient2)
         //{
         //   Console.WriteLine($"{keyvaluepair.Key} = {keyvaluepair.Value}");
         //}

         Console.ReadKey();
      }
   }

   class MyClient
   {
      public long Id;
      public StringBuilder Username;
      public TcpClient Client;
      public NetworkStream Stream;
      public byte[] Buffer;
      public StringBuilder Data;
      public EventWaitHandle Operate;
   };
}