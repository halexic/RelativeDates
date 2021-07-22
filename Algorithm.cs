public static string GetRelativeDate(this DateTime date, int languageId)
{
	const int SECOND = 1;
	const int MINUTE = 60 * SECOND;
	const int HOUR = 60 * MINUTE;
	const int DAY = 24 * HOUR;
	const int MONTH = 30 * DAY;

	var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
	var delta = Math.Abs(ts.TotalSeconds);
	var seconds = Math.Abs(ts.Seconds);
	var minutes = Math.Abs(ts.Minutes);
	var hours = Math.Abs(ts.Hours);
	var days = Math.Abs(ts.Days);

	if (delta < 1 * MINUTE)
	{
		var oneSecondAgo = "one second ago";
		var secondsAgo = $"{seconds} seconds ago";
		switch (languageId)
		{
			case Languages.Slovenian:
				oneSecondAgo = "1 sekundo nazaj";
				if (minutes == 2)
				{
					secondsAgo = "2 sekundi nazaj";
				}
				else if (minutes == 3 || minutes == 4)
				{
					secondsAgo = $"{seconds} sekunde nazaj";
				}
				else
				{
					secondsAgo = $"{seconds} sekund nazaj";
				}
				break;
		}

		return seconds == 1 ? oneSecondAgo : secondsAgo;
	}

	if (delta < 2 * MINUTE)
	{
		var aMinuteAgo = "a minute ago";
		switch (languageId)
		{
			case Languages.Slovenian:
				aMinuteAgo = "1 minuto nazaj";
				break;
		}

		return aMinuteAgo;
	}

	if (delta < 45 * MINUTE)
	{
		var minutesAgo = $"{minutes} minutes ago";
		switch (languageId)
		{
			case Languages.Slovenian:
				if (minutes == 2)
				{
					minutesAgo = "2 minuti nazaj";
				}
				else if (minutes == 3 || minutes == 4)
				{
					minutesAgo = $"{minutes} minute nazaj";
				}
				else
				{
					minutesAgo = $"{minutes} minut nazaj";
				}
				break;
		}

		return minutesAgo;
	}

	if (delta < 90 * MINUTE)
	{
		var anHourAgo = "an hour ago";
		switch (languageId)
		{
			case Languages.Slovenian:
				anHourAgo = "1 uro nazaj";
				break;
		}

		return anHourAgo;
	}

	if (delta < 24 * HOUR)
	{
		var hoursAgo = $"{hours} hour ago";
		switch (languageId)
		{
			case Languages.Slovenian:
				if (minutes == 2)
				{
					hoursAgo = "2 uri nazaj";
				}
				else if (minutes == 3 || minutes == 4)
				{
					hoursAgo = $"{hours} ure nazaj";
				}
				else
				{
					hoursAgo = $"{hours} ur nazaj";
				}
				break;
		}

		return hoursAgo;
	}

	if (delta < 48 * HOUR)
	{
		var yesterday = "yesterday";
		switch (languageId)
		{
			case Languages.Slovenian:
				yesterday = "vceraj";
				break;
		}

		return yesterday;
	}

	if (delta < 30 * DAY)
	{
		var daysAgo = $"{days} days ago";
		switch (languageId)
		{
			case Languages.Slovenian:
				daysAgo = $"{days} dni nazaj";
				break;
		}

		return daysAgo;
	}

	if (delta < 12 * MONTH)
	{
		int months = Convert.ToInt32(Math.Floor((double)days / 30));
		var monthsAgo = months <= 1 ? "one month ago" : $"{months} months ago";
		switch (languageId)
		{
			case Languages.Slovenian:
				if (months == 1)
				{
					monthsAgo = "en mesec nazaj";
				}
				else if (1 < months && months < 5)
				{
					monthsAgo = $"{months} meseca nazaj";
				}
				else
				{
					monthsAgo = $"{months} mesecev nazaj";
				}
				break;
		}

		return monthsAgo;
	}
	else
	{
		int years = Convert.ToInt32(Math.Floor((double)days / 365));
		var yearsAgo = years <= 1 ? "one year ago" : $"{years} years ago";
		switch (languageId)
		{
			case Languages.Slovenian:
				if (years == 1)
				{
					yearsAgo = "eno leto nazaj";
				}
				else if (years == 2)
				{
					yearsAgo = "2 leti nazaj";
				}
				else if (2 < years && years < 5)
				{
					yearsAgo = $"{years} leta nazaj";
				}
				else
				{
					yearsAgo = $"{years} let nazaj";
				}
				break;
		}

		return yearsAgo;
	}
}
