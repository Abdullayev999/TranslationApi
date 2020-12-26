using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using ConsoleApp33;

namespace Translation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<string> list = new List<string>() {  "en", "tr", "az", "ru" };
            WebClient web = new WebClient();

            string url = "https://translation.googleapis.com/language/translate/v2?key=AIzaSyCqwaXLLd9JraElDHNGKFIN2zfbSAgAHms";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("!!Welcome to online translator!!");
            Menyu action;
            int translateWith, translateTo;


            do
            {
                Console.WriteLine("0 - Exit\n" +
                                  "1 - Translate\n");

                action = (Menyu)Enum.Parse(typeof(Menyu), Console.ReadLine());
                Console.Clear();
                if (action == Menyu.Exit)
                {
                    Console.WriteLine("You left the program\n");
                }
                else if (action == Menyu.Translate)
                {
                    Console.Write("What language do you want to translate FROM ? : \n\n");
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine($"{i} {list[i]}");
                    }

                    do
                    {
                        translateWith = Convert.ToInt32(Console.ReadLine());
                        if (translateWith >= 0 && translateWith < list.Count)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect choice\n");
                        }
                    } while (true);


                    Console.Write("What language do you want to translate INTO ? : \n\n");
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine($"{i} {list[i]}");
                    }

                    do
                    {
                        translateTo = Convert.ToInt32(Console.ReadLine());
                        if (translateTo >= 0 && translateTo < list.Count)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect choice\n");
                        }
                    } while (true);


                    do
                    {
                        try
                        {

                            TranslateRequest translate = new TranslateRequest() { source = list[translateWith], target = list[translateTo], format = "text" };
                            Console.WriteLine($"Your translate with {list[translateWith]} to {list[translateTo]}\n");
                            Console.Write("Enter your text : ");
                            translate.q = Console.ReadLine();

                            string answer = web.UploadString(url, JsonSerializer.Serialize(translate));

                            var response = JsonSerializer.Deserialize<TranslateResponse>(answer);

                            Console.Write("Your Translation : ");

                            Console.WriteLine(response.data.translations[0].translatedText);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine("\nPress ESC to back , or any buttoon for continue\n");
                        if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                    } while (true);
                }
                else
                {
                    Console.WriteLine("Incorrect choice\n");
                }
            } while (true);

        }
    }
}
