using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Github.Models
{
    public class gitd
    {
        public int ID { get; set; }
        public string AvatarURL { get; set; }
        public string Name { get; set; }
        public decimal Score { get; set; }
        public DateTime Updatedat { get; set; }
        

    }
    
    public class GitJSON
    {
        public List<gitd> gitdList { set; get; }
    }
}  
