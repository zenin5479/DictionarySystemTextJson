using System;
using System.Collections.Generic;
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
         // Десериализация словарей System.Text.Json
         string json = @"{""User"":""YoRHa2B"",""key"":""123""}";
         Dictionary<string, string> values = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
         Console.WriteLine(values.Count);
         Console.WriteLine(values["User"]);

         MyClient element = new MyClient
         {
            Data = new StringBuilder(@"{""User"":""YoRHa2B"",""key"":""123""}")
         };

         Dictionary<string, string> values2 = JsonSerializer.Deserialize<Dictionary<string, string>>(element.Data.ToString());
         Console.WriteLine(values.Count);
         Console.WriteLine(values["User"]);
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