 CommandArgCollection commandArgs = new CommandArgCollection(args);
 foreach(CommandArgItem argItem in commandArgs)
 {
  key = argItem.Name.ToLower();
  switch(key)
  {
   case "":
    // When no name was specified, check for the value.
    key = argItem.Value.ToLower();
    switch(key)
    {
     case "?":
      bShowHelp = true;
      break;
     case "wait":
      prg.mWaitAfterEnd = true;
      break;
    }
    break;
   case "action":
    if(Enum.TryParse<PActionTypeEnum>(argItem.Value,
     true, out action))
    {
     if(action != PActionTypeEnum.None)
     {
      prg.ActionItem.Action = action;
      bActivity = true;
     }
     else
     {
      message.Append("Error: No action specified...");
      bShowHelp = true;
      break;
     }
    }
    else
    {
      message.Append("Error: Unknown action specified...");
    }
    break;
  }
 }
