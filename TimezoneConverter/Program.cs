class Program
{
    static void Main(string[] args)
    {
        string? input = string.Empty;
        string timezone = string.Empty;
        TimeZoneInfo timeZoneInfo;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("==========================================================");
        Console.WriteLine("Timezone converter application (UTC) to any timezone".ToUpper());
        Console.WriteLine("==========================================================");
        Console.ResetColor();
        do
        {
            try
            {
                Console.WriteLine("Please introduce a date with format YYYY-MM-DD HH:mm:ss or introduce <Enter> to exit");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                string date = input;
                string[] datetimeList = date.Split(" ");
                string[] listDate = datetimeList[0].Split("-");
                string[] listTime = datetimeList[1].Split(":");
                DateTime introducedDateTime = new(int.Parse(listDate[0]), int.Parse(listDate[1]), int.Parse(listDate[2]), int.Parse(listTime[0]), int.Parse(listTime[1]), int.Parse(listTime[2]));
                DateTimeOffset transformedDateTime = new(introducedDateTime, TimeZoneInfo.Utc.GetUtcOffset(introducedDateTime));
                Console.WriteLine("Please introduce the timezone Identifier that you want to use (if you press <Enter> without an identifier this will use Local timezone)");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    timeZoneInfo = TimeZoneInfo.Local;
                }
                else
                {
                    timezone = input!;
                    timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezone);
                }
                DateTimeOffset targetTime = TimeZoneInfo.ConvertTime(transformedDateTime, timeZoneInfo);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("==========================================================");
                Console.WriteLine("Introduced Date:");
                Console.WriteLine(transformedDateTime.ToString("yyyy-MM-dd HH:mm:ss zzz"));
                Console.WriteLine($"Timezone Identifier used: {timeZoneInfo.Id}");
                Console.WriteLine($"Timezone name: {timeZoneInfo.DisplayName}");
                Console.WriteLine($"Timezone Id: {timeZoneInfo.Id}");
                Console.WriteLine("==========================================================");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("==========================================================");
                Console.WriteLine("Timezone date:".ToUpper());
                Console.WriteLine(targetTime.ToString("yyyy-MM-dd HH:mm:ss zzz"));
                Console.WriteLine("==========================================================");
                Console.ResetColor();
            }
            catch (IndexOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("==========================================================");
                Console.WriteLine("Please introduce a valid datetime".ToUpper());
                Console.WriteLine("==========================================================");
                Console.ResetColor();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("==========================================================");
                Console.WriteLine("Please introduce a valid format datetime".ToUpper());
                Console.WriteLine("==========================================================");
                Console.ResetColor();
            }
            catch (TimeZoneNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("==========================================================");
                Console.WriteLine("Introduce a valid timezone Identifier".ToUpper());
                Console.WriteLine("==========================================================");
                Console.ResetColor();
            }

        } while (true);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("==========================================================");
        Console.WriteLine("Closing".ToUpper());
        Console.WriteLine("==========================================================");
        Console.ResetColor();
        return;
    }
}