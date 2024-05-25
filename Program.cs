﻿using System;
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

         Dictionary<string, string> valuesmyclient = JsonSerializer.Deserialize<Dictionary<string, string>>(element.Data.ToString());
         Console.WriteLine("User = " + valuesmyclient["User"] + "\n" + "key = " + valuesmyclient["key"]);
         foreach (KeyValuePair<string, string> keyvaluepair in valuesmyclient)
         {
            Console.WriteLine($"{keyvaluepair.Key} = {keyvaluepair.Value}");
         }

         // Десериализация словарей System.Text.Json по строке из файла
         string jsonString = File.ReadAllText("YoRHa2B.json");
         Dictionary<string, string> valuesclient2 = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
         foreach (KeyValuePair<string, string> keyvaluepair in valuesclient2)
         {
            Console.WriteLine($"{keyvaluepair.Key} = {keyvaluepair.Value}");
         }


         // Десериализация во вложенный словарь
         // Если нет возможности создавать класс для вложенного объекта, можно десериализовать его во вложенный словарь.
         string json2 = @"{""ABC"": {""Name"": ""Bob"", ""Age"": ""40""},""DEF"": {""Type"": ""Cat"",""Sound"": ""Meow""}}";
         Dictionary<string, Dictionary<string, string>> dictionary = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json2);
         foreach (var (key, nestedDictionary) in dictionary)
         {
            Console.WriteLine(key);
            foreach (var (property, val) in nestedDictionary)
            {
               Console.WriteLine($"\t{property} = {val}");
            }
         }

         // Десериализация во вложенный словарь System.Text.Json по строке из файла
         string jsonString2 = File.ReadAllText("NestedDictionary.json");

         Dictionary<string, Dictionary<string, string>> dictionary2 = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonString2);
        
         foreach (var (key, nestedDictionary2) in dictionary2)
         {
            Console.WriteLine(key);
            foreach (var (property, val) in nestedDictionary2)
            {
               Console.WriteLine($"\t{property} = {val}");
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