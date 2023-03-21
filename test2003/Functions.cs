﻿using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2003
{
	public class Functions
	{
		public static void ProcessQueueMessage([QueueTrigger("queue0320")] string message, ILogger log)
		{
			log.LogInformation(message);
		}
	}
}
