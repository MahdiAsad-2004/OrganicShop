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


        public Toast(ToastType toastType, string text)
        {
            Type = toastType;
            Text = text;
            Title = GetTitle(toastType);
        }
        public Toast(ToastType toastType, string text, int timeMs)
        {
            Type = toastType;
            Text = text;
            TimeMs = timeMs;
            Title = GetTitle(toastType);
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
                    return "موفق";
                case ToastType.Error:
                    return "خطا !";
                case ToastType.Warning:
                    return "هشدار";
                case ToastType.Info:
                    return "اطلاعات";
                case ToastType.Question:
                    return "پرسش";
                default:
                    return "";
            }
        }
    }

}

