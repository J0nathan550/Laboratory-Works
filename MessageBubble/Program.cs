using Microsoft.Toolkit.Uwp.Notifications;

class Program
{
    static void Main(string[] args)
    {
        ToastContentBuilder builder = new ToastContentBuilder();
        builder.AddText("Вас вызывают ответить за лабораторку", AdaptiveTextStyle.Caption);
        builder.AddText("Принять?", AdaptiveTextStyle.Default);
        builder.Show();
    }
}