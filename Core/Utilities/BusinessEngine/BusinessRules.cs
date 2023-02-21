﻿using System;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
	public class BusinessRules
	{
		public static IResult Run(params IResult[] logics)
		{
			foreach (var logic in logics)
			{
				//Report Errored Logics to Business
				if (!logic.Success)
				{
					return logic;
				}
			}
			return null;
		}
	}
}
