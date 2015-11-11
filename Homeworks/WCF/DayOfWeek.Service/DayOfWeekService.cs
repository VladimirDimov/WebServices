namespace DayOfWeek.Service
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    public class DayOfWeekService : IDayOfWeekService
    {
        public string Today()
        {
           string[] DaysOfWeek = new string[7]
           {
               "Понделник", "Вторник", "Сряда", "Четвъртък", "Петък", "Събота", "Неделя"
           };

            var dayOfWeekNumber = (int)DateTime.Today.DayOfWeek;
            return DaysOfWeek[dayOfWeekNumber];
        }
    }
}
