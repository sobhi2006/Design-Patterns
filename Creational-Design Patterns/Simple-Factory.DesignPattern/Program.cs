using System;

namespace Factory.DesignPattern;
public class Program
{
    public static void Main(string[] args)
    {
        SendType sendType = SendType.WhatsApp;
        ISender sender = SenderFactory.Send(sendType);
        sender.Send("Hello, this is a test message!");

    }
}