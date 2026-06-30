using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LinkageLibrary
{
    public class clsValidInput
    {
        public bool IsValidInput(string type, string input)
        {
            string expression = "";
            switch (type)
            {
                case "UTF":
                    if (!input.Contains("<") && !input.Contains(">") && !input.Contains("'") && !input.Contains("&") && !input.Contains("\""))
                    {
                        return true;
                    }
                    else
                        return false;
                    break;
                //case "char":
                //    //expression = @"^[a-zA-Z]*$";
                //    //Match match = Regex.Match(input, expression, RegexOptions.IgnoreCase);
                //    //if (match.Success && input.Trim().Length <= length)
                //    //    return true;
                //    //else
                //    //    return false;
                //    //break;
                //    expression = @"^([1-9][0-9]*)|0$";
                //    Match match1 = Regex.Match(input, expression, RegexOptions.IgnoreCase);
                //    if (match1.Success)
                //    {
                //        return false;
                //    }
                //    else if (!input.Contains("<") && !input.Contains(">") && !input.Contains("#") && !input.Contains("&") && !input.Contains("$"))
                //    {
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //    break;


                //case "number":
                //    expression = @"^([1-9][0-9]*)|0$";
                //    Match match5 = Regex.Match(input, expression, RegexOptions.IgnoreCase);
                //    if (match5.Success)
                //        return true;
                //    else
                //        return false;
                //    break;
                //case "decimal":
                //    expression = @"^[1-9]\d*(\.\d+)?$";
                //    Match match2 = Regex.Match(input, expression, RegexOptions.IgnoreCase);
                //    if (match2.Success)
                //        return true;
                //    else
                //        return false;
                //    break;
                //case "alphanumeric":
                //    expression = @"^[a-zA-Z0-9]*$";
                //    Match match3 = Regex.Match(input, expression, RegexOptions.IgnoreCase);
                //    if (match3.Success)
                //        return true;
                //    else
                //        return false;
                //    break;
                //case "email":
                //    expression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                //    Match match4 = Regex.Match(input, expression, RegexOptions.IgnoreCase);
                //    if (match4.Success && !input.Contains("<") && !input.Contains(">") && !input.Contains("#") && !input.Contains("&") && !input.Contains("$"))
                //        return true;
                //    else
                //        return false;
                //    break;
                default:
                    return false;
            }
        }

    }
}
