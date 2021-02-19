using System;
using System.Collections.Generic;
using Telegram.Bot;
using MihaZupan;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using System.IO;


namespace bottesttelega
{
    public class Program
    {        
        static List <int> Idtp = null;
        static Dictionary<long, bool> _flags = null;
        static string Str;
        /* static readonly StreamReader sf = new StreamReader(@"C:\Users\evgeni\Desktop\ChatID.txt");
         static readonly string v = Convert.ToString(sf);   */

        private static ITelegramBotClient botClient;       
        static void Main(string[] args)
        {
         
        //StreamReader Idtpr = new StreamReader(@"files/ChatID.txt");
        //Idtp = int.Parse(Idtpr.ReadLine());

        string[] ids = System.IO.File.ReadAllLines(@"files/ChatID.txt");
            if (Idtp == null)
                Idtp = new List<int>();
            for (int i = 0; i < ids.Length; i++)           
            {
                Idtp.Add(int.Parse(ids[i]));
            }

            Lol p = new Lol();
            p.lalka();            
            var proxy = new HttpToSocks5Proxy("46.105.226.37", 9999);
            botClient = new TelegramBotClient("1626492139:AAEvm2-FftaUZ37d0E4RisQ3C3kMCCU69P8") { Timeout = TimeSpan.FromSeconds(20) };
            botClient.OnMessage += BotClient_OnMessage;
            
            var me = botClient.GetMeAsync().Result;
            Console.Title = me.Username;

            Console.WriteLine($"Bot id: {me.Id}. Bot Name: {me.FirstName}");
            botClient.StartReceiving();
            Console.Read();           
            botClient.StopReceiving();
           
        }       

        static async void BotClient_OnMessage(object sender, MessageEventArgs e)
        {


            StreamWriter mw = new StreamWriter(@"files/UserID.txt");
       
            var message = e.Message;
            string a = Convert.ToString(message.Chat.Id);
            int ab = int.Parse(a);
            var mes = e.Message;
            if (message == null || message.Type != MessageType.Text)
                return;           
            string name = $"Id:{message.Chat.Id} {message.From.FirstName} {message.From.LastName}";
            Console.WriteLine($"{name} отправил сообщение {message.Text}");
            mw.WriteLine($"ChatId: {message.Chat.Id} {message.From.FirstName} {message.From.LastName}");
            mw.Close();
            switch (message.Text)
            {
                case "/start":
                    string text =
@"Доброго времени cуток.
Список команд: 
**********************
/start - Приветствие 
**********************
/price - Ассортимент 
**********************
/buy - Оформить заказ
**********************
";
                    await botClient.SendTextMessageAsync(message.From.Id, text);
                    break;                
                case "/price":     
                    string[] lines = System.IO.File.ReadAllLines(@"files/Test.txt");
                   
                    {
                        int k = 0;                        
                        
                        foreach (string s in lines)
                        {
                           
                            if (s != null)
                            {
                                if (k == 100)
                                {
                                    await botClient.SendTextMessageAsync(message.From.Id, Str);
                                    k = 1;
                                    Str = s + "\n";
                                    System.Threading.Thread.Sleep(250);

                                }
                                else
                                {
                                    Str = Str + s + "\n";
                                    k = k + 1;
                                }
                            }
                         

                        }
                        if (Str != "")
                        {
                            await botClient.SendTextMessageAsync(message.From.Id, Str);
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(message.From.Id, @"/buy - оформить заказ.");
                        }
                       
                    }
                    break;

                case "/buy":
                    {
                        string hilol =
    @"Оформление заказа.
**********************************
Укажите контактный номер телефона.
**********************************
Введите название нужных вам позиций 
и нужное вам количество.
**********************************
Например:
**********************************
Дарксайд Шот- Азовский вайб 30 гр. - 10 шт.
Zomo- Коко Айленд 50гр. - 20 шт.
и т.д.
**********************************
Допускается сокращённыя запись.
Так же вы можете написать(Дарксайд Шот 30гр. ассортимент по 5шт.)
**********************************
********** ВНИМАНИЕ! **********
Важно написать весь заказ в одном сообщении.
**********************************
";
                        await botClient.SendTextMessageAsync(message.From.Id, hilol);
                        for (int i = 0; i < Idtp.Count; i++)
                        {
                            await botClient.SendTextMessageAsync(chatId: Idtp[i], $"Пользователь @{message.From.Username} {message.From.FirstName} {message.From.LastName} оформляет заказ");
                        }
                        if (_flags == null)
                            _flags = new Dictionary<long, bool>();
                        _flags.Add(message.Chat.Id, true);
                        
                    }
                        break;
                default:
                    {
                        if (_flags == null)
                            _flags = new Dictionary<long, bool>();
                        if (_flags.ContainsKey(message.Chat.Id))
                        {
                            if (_flags[message.Chat.Id]) {
                                for (int i = 0; i < Idtp.Count; i++)
                                {
                                    await botClient.SendTextMessageAsync(chatId: Idtp[i], $"Заказ от пользователя @{ message.From.Username} { message.From.FirstName } {message.From.LastName}" + "\n" + mes.Text);
                                }
                                await botClient.SendTextMessageAsync(message.From.Id, "Ваш заказ принят.");
                                System.Threading.Thread.Sleep(250);
                                _flags.Remove(message.Chat.Id);
                            }
                        }
                    }
                    break;
            }
            
        }
    }
}
