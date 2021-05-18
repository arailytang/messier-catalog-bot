using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace HubbleMessier
{
    class Program
    {
        static TelegramBotClient Bot = new TelegramBotClient("[token]");
        static string imagesPath = @"C:\Users\Arailym\source\repos\HubbleMessier\HubbleMessier\images\";
        
        static List<string> nebulas = new List<string>
        {
            "m1.jpg", "m8.jpg", "m9.jpg", "m10.jpg", "m16.jpg", "m17.jpg", "m20.jpg", "m27.jpg", "m42.jpg", "m43.jpg", "m57.jpg", "m76.jpg", "m78.jpg"
        };

        static List<string> clusters = new List<string>
        {
            "m2.jpg", "m3.jpg", "m4.jpg", "m5.jpg", "m11.jpg", "m12.jpg", "m13.jpg", "m14.png", "m15.jpg", "m19.png", "m22.jpg", "m28.jpg", "m30.jpg", "m45.jpg", "m53.jpg", "m54.jpg", "m56.jpg", "m62.jpg", "m68.jpg", "m69.jpg", "m70.jpg", "m71.jpg", "m72.jpg", "m75.png", "m79.png", "m80.jpg", "m92.jpg", "m107.jpg"
        };

        static List<string> galaxies = new List<string>
        {
            "m31.jpg", "m32.jpg", "m33.jpg", "m49.png", "m51.jpg", "m58.png", "m59.jpg", "m60.jpg", "m61.jpg", "m63.jpg", "m64.jpg", "m65.jpg", "m66.jpg", "m74.jpg", "m77.jpg", "m81.jpg", "m82.jpg", "m83.jpg", "m84.jpg", "m85.jpg", "m86.png", "m87.jpg", "m88.jpg", "m89.png", "m90.jpg", "m91.jpg", "m94.jpg", "m95.jpg", "m96.jpg", "m98.png", "m99.jpg", "m100.png", "m101.jpg", "m102.jpg", "m104.jpg", "m105.jpg", "m106.jpg", "m108.png", "m110.png"
        };

        static void Main(string[] args)
        {
            Bot.StartReceiving();
            Bot.OnMessage += Bot_OnMessage;

            Console.ReadLine();
        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if(e.Message.Text.StartsWith("help"))
            {
                await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Hello, " + e.Message.Chat.Username);
                await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Send /image(type). Type can be either nebula, cluster or galaxy.");
            }

            if (e.Message.Text.StartsWith("/image("))
            {
                var query = e.Message.Text.Split('(')[1].Split(')')[0];

                if(query == "nebula1")
                {
                    using (var stream = System.IO.File.OpenRead(imagesPath + nebulas[0]))
                    {
                        InputOnlineFile inputOnlineFile = new InputOnlineFile(stream);
                        await Bot.SendPhotoAsync(e.Message.Chat.Id, inputOnlineFile, "<i>The Crab Nebula</i>", Telegram.Bot.Types.Enums.ParseMode.Html);
                    }
                }

                if (query == "cluster1")
                {
                    using (var stream = System.IO.File.OpenRead(imagesPath + clusters[0]))
                    {
                        InputOnlineFile inputOnlineFile = new InputOnlineFile(stream);
                        await Bot.SendPhotoAsync(e.Message.Chat.Id, inputOnlineFile, "<i>The globular cluster in the constellation Aquarius</i>", Telegram.Bot.Types.Enums.ParseMode.Html);
                    }
                }

                if (query == "galaxy1")
                {
                    using (var stream = System.IO.File.OpenRead(imagesPath + galaxies[0]))
                    {
                        InputOnlineFile inputOnlineFile = new InputOnlineFile(stream);
                        await Bot.SendPhotoAsync(e.Message.Chat.Id, inputOnlineFile, "<i>The Andromeda Galaxy is the nearest major galaxy to the Milky Way</i>", Telegram.Bot.Types.Enums.ParseMode.Html);
                    }
                }

                /*if (query == "nebulas")
                {
                    List<FileStream> streams = new List<FileStream>
                    {
                        System.IO.File.OpenRead(imagesPath + nebulas[0]),
                        System.IO.File.OpenRead(imagesPath + nebulas[1]),
                        System.IO.File.OpenRead(imagesPath + nebulas[2]),
                    };

                    List<InputMediaPhoto> media = new List<InputMediaPhoto>();

                    foreach(var stream in streams)
                    {
                        media.Add(new InputMediaPhoto(new InputMedia(stream, stream.Name)));
                    }    
                    await Bot.SendMediaGroupAsync(media, e.Message.Chat.Id);

                    foreach(var stream in streams)
                    {
                        stream.Close();
                    }
                }*/

                Random rand = new Random();

                if (query == "nebula")
                {
                    int nebulaR = rand.Next(nebulas.Count);
                    using (var stream = System.IO.File.OpenRead(imagesPath + nebulas[nebulaR]))
                    {
                        InputOnlineFile inputOnlineFile = new InputOnlineFile(stream);
                        await Bot.SendPhotoAsync(e.Message.Chat.Id, inputOnlineFile, "<i>Random nebula image</i>", Telegram.Bot.Types.Enums.ParseMode.Html);
                    }
                }

                if (query == "cluster")
                {
                    int clusterR = rand.Next(clusters.Count);
                    using (var stream = System.IO.File.OpenRead(imagesPath + clusters[clusterR]))
                    {
                        InputOnlineFile inputOnlineFile = new InputOnlineFile(stream);
                        await Bot.SendPhotoAsync(e.Message.Chat.Id, inputOnlineFile, "<i>Random cluster image</i>", Telegram.Bot.Types.Enums.ParseMode.Html);
                    }
                }

                if (query == "galaxy")
                {
                    int galaxyR = rand.Next(galaxies.Count);
                    using (var stream = System.IO.File.OpenRead(imagesPath + galaxies[galaxyR]))
                    {
                        InputOnlineFile inputOnlineFile = new InputOnlineFile(stream);
                        await Bot.SendPhotoAsync(e.Message.Chat.Id, inputOnlineFile, "<i>Random cluster image</i>", Telegram.Bot.Types.Enums.ParseMode.Html);
                    }
                }
            }
        }
    }
}
