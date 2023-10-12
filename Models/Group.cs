using System.Text.RegularExpressions;

namespace PP_1lab_Anna.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public bool IsValidGroupName()
        {
            return Regex.Match(GroupName, @"/\D*-\d*-\d\d/g").Success;
        }
    }
}
