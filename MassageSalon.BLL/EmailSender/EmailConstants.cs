using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.EmailSender
{
    public static class EmailConstants
    {
        public static string SenderName => "MassageSalon";
        public static string SenderEmail => "m4ssage.salon@yandex.by";
        public static string EmailPassword => "m4ssage";
        public static string SmtpHost => "smtp.yandex.com";
        public static int SmtpPort => 587;
    }
}
