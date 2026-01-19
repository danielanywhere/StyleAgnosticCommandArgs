# Style-Agnostic Command-Line Arguments

This tiny library allows you to support the user's own command line parameter preference by accepting either the **--** or **/** prefixes on each parameter.

A parameter name is interpreted if the parameter begins with the pattern *\[A-Za-z0-9-\_\]***:** Zero or more white-spaces are ignored after the colon character. A parameter name is not required, and its Name property will be an empty string if not supplied.

Immediately after parsing, the **CommandArgCollection** contains a list of **CommandArgItem** items, each having separate **Name** and **Value** properties.

---

## Example Application

The following example demonstrates this library in action.

```cs
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

```


## Updates

| Version | Description |
|---------|-------------|
| 26.2118.4210 | Initial publication to NuGet. |


## More Information

For more information, please see the GitHub project:
[danielanywhere/StyleAgnosticCommandArgs](https://github.com/danielanywhere/StyleAgnosticCommandArgs)

Full API documentation is available at this library's [GitHub User Page](https://danielanywhere.github.io/StyleAgnosticCommandArgs).

