/*
 * Copyright (c). 2026 Daniel Patterson, MCSD (danielanywhere).
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 * 
 */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using static StyleAgnosticCommandArgs.CommandArgUtil;

namespace StyleAgnosticCommandArgs
{
	//*-------------------------------------------------------------------------*
	//*	CommandArgCollection																										*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Collection of CommandArgItem Items.
	/// </summary>
	public class CommandArgCollection : List<CommandArgItem>
	{
		//*************************************************************************
		//*	Private																																*
		//*************************************************************************
		//*-----------------------------------------------------------------------*
		//* InitializeCollection																									*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Initialize the provided collection with the contents of the supplied
		/// command-line arguments.
		/// </summary>
		/// <param name="collection">
		/// Reference to the target collection.
		/// </param>
		/// <param name="args">
		/// Reference to the source arguments.
		/// </param>
		private static void InitializeCollection(CommandArgCollection collection,
			string[] args)
		{
			CommandArgItem item = null;
			Match match = null;
			if(collection != null && args?.Length > 0)
			{
				foreach(string argItem in args)
				{
					match = Regex.Match(argItem, ResourceMain.rxParamNameValue);
					if(match.Success)
					{
						item = new CommandArgItem()
						{
							Name = GetValue(match, "name"),
							Value = GetValue(match, "value")
						};
						collection.Add(item);
					}
				}
			}
		}
		//*-----------------------------------------------------------------------*

		//*************************************************************************
		//*	Protected																															*
		//*************************************************************************
		//*************************************************************************
		//*	Public																																*
		//*************************************************************************
		//*-----------------------------------------------------------------------*
		//*	_Constructor																													*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Create a new instance of the CommandArgCollection item.
		/// </summary>
		public CommandArgCollection()
		{
		}
		//*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
		/// <summary>
		/// Create a new instance of the CommandArgCollection item.
		/// </summary>
		/// <param name="args">
		/// Reference to an array of command-line arguments to read.
		/// </param>
		public CommandArgCollection(string[] args)
		{
			InitializeCollection(this, args);
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Parse																																	*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Parse the caller's command-line arguments and return the collection of
		/// names and values.
		/// </summary>
		/// <param name="args">
		/// Reference to an array of command-line arguments to read.
		/// </param>
		public static CommandArgCollection Parse(string[] args)
		{
			CommandArgCollection result = new CommandArgCollection();

			if(args?.Length > 0)
			{
				InitializeCollection(result, args);
			}
			return result;
		}
		//*-----------------------------------------------------------------------*


	}
	//*-------------------------------------------------------------------------*

	//*-------------------------------------------------------------------------*
	//*	CommandArgItem																													*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Information about a single style-agnostic command-line argument.
	/// </summary>
	public class CommandArgItem
	{
		//*************************************************************************
		//*	Private																																*
		//*************************************************************************
		//*************************************************************************
		//*	Protected																															*
		//*************************************************************************
		//*************************************************************************
		//*	Public																																*
		//*************************************************************************
		//*-----------------------------------------------------------------------*
		//*	Name																																	*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Private member for <see cref="Name">Name</see>.
		/// </summary>
		private string mName = "";
		/// <summary>
		/// Get/Set the name of the argument.
		/// </summary>
		public string Name
		{
			get { return mName; }
			set { mName = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	ToString																															*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Return the string representation of this item.
		/// </summary>
		public override string ToString()
		{
			string result = "";

			if(mName?.Length > 0)
			{
				result = $"{mName}: {mValue}";
			}
			else if(mValue?.Length > 0)
			{
				result = mValue;
			}
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Value																																	*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Private member for <see cref="Value">Value</see>.
		/// </summary>
		private string mValue = "";
		/// <summary>
		/// Get/Set the value of the argument.
		/// </summary>
		public string Value
		{
			get { return mValue; }
			set { mValue = value; }
		}
		//*-----------------------------------------------------------------------*


	}
	//*-------------------------------------------------------------------------*


}
