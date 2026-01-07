# Style-Agnostic Command-Line Arguments

This tiny library allows you to support the user's own command line parameter preference by accepting either the **--** or **/** prefixes on each parameter.

A parameter name is interpreted if the parameter begins with the pattern *[A-Za-z0-9-_]***:** Zero or more whitespaces are ignored after the colon character. A parameter name is not required, and its Name property will be an empty string if not supplied.

Immediately after parsing, the **CommandArgCollection** contains a list of **CommandArgItem** items, each having a separate **Name** and **Value** property.

```cs

 CommandArgCollection commandArgs = new CommandArgCollection(args);
 foreach(CommandArgItem argItem in commandArgs)
 {
  key = argItem.Name.ToLower();
  switch(key)
  {
   case "?":
    bShowHelp = true;
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
    break;
   case "wait":
    prg.mWaitAfterEnd = true;
    break;
  }
 }

```
