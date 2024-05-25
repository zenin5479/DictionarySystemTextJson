using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
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
         Console.WriteLine("User = " + values["User"] + "\n" + "key = " + values["key"]);
         foreach (KeyValuePair<string, string> keyvaluepair in values)
         {
            Console.WriteLine($"{keyvaluepair.Key} = {keyvaluepair.Value}");
         }

         // Десериализация словарей System.Text.Json по классу
         MyClient element = new MyClient
         {
            Data = new StringBuilder(@"{""User"":""YoRHa2B"",""key"":""123""}")
         };

         Dictionary<string, string> valueselement = JsonSerializer.Deserialize<Dictionary<string, string>>(element.Data.ToString());
         Console.WriteLine("User = " + valueselement["User"] + "\n" + "key = " + valueselement["key"]);
         foreach (KeyValuePair<string, string> keyvaluepair in valueselement)
         {
            Console.WriteLine($"{keyvaluepair.Key} = {keyvaluepair.Value}");
         }

         // Десериализация словарей System.Text.Json по строке из файла
         string jsonfile = File.ReadAllText("YoRHa2B.json");
         Dictionary<string, string> valuesjsonfile = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonfile);
         foreach (KeyValuePair<string, string> keyvaluepair in valuesjsonfile)
         {
            Console.WriteLine($"{keyvaluepair.Key} = {keyvaluepair.Value}");
         }

         // Десериализация во вложенный словарь
         // Если нет возможности создавать класс для вложенного объекта, можно десериализовать его во вложенный словарь.
         const string jsonnesteddictionary = @"{""ABC"": {""Name"": ""Bob"", ""Age"": ""40""},""DEF"": {""Type"": ""Cat"",""Sound"": ""Meow""}}";
         Dictionary<string, Dictionary<string, string>> dictionarynesteddictionary = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonnesteddictionary);
         foreach (var (key, nesteddictionary) in dictionarynesteddictionary)
         {
            Console.WriteLine(key);
            foreach (var (property, val) in nesteddictionary)
            {
               Console.WriteLine($"\t{property} = {val}");
            }
         }

         // Десериализация во вложенный словарь System.Text.Json по строке из файла
         string jsonnesteddictionaryfile = File.ReadAllText("NestedDictionary.json");
         Dictionary<string, Dictionary<string, string>> dictionarynesteddictionaryfile = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonnesteddictionaryfile);
         foreach (KeyValuePair<string, Dictionary<string, string>> keyvaluepair in dictionarynesteddictionaryfile)
         {
            Console.WriteLine(keyvaluepair.Key);
            foreach (KeyValuePair<string, string> pairkeyvalue in keyvaluepair.Value)
            {
               Console.WriteLine($"\t{pairkeyvalue.Key} = {pairkeyvalue.Value}");
            }
         }

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