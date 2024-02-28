using System.Text.Json;

namespace OrganicShop.Mvc.Models.Toast
{
    public class Toast
    {
        public string Title { get; set; } = "";
        public string Text { get; set; } = "";
        public ToastType Type { get; set; } = ToastType.Success;
        public ToastPosition Position { get; set; } = ToastPosition.TopEnd;
        public int TimeMs { get; set; } = 3000;


        public Toast(ToastType messageType, string text)
        {
            Type = messageType;
            Text = text;
            Title = GetTitle(messageType);
        }
        public Toast(ToastType messageType, string text, int timeMs)
        {
            Type = messageType;
            Text = text;
            TimeMs = timeMs;
            Title = GetTitle(messageType);
        }



        public void SetMessageOnResponse(HttpResponse response)
        {
            var MessageJson = JsonSerializer.Serialize(this);
            response.Headers.Add("Message", MessageJson);
        }

        private string GetTitle(ToastType messageType)
        {
            switch (messageType)
            {
                case ToastType.Success:
                    return "Success";
                case ToastType.Error:
                    return "Error!";
                case ToastType.Info:
                    return "Info";
                case ToastType.Warning:
                    return "Warning";
                case ToastType.Question:
                    return "Question";
                default:
                    return "";
            }
        }
    }

}

