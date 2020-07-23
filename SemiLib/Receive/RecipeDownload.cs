using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Receive
{
    public class RecipeDownload : IReceive
    {
        public string EqpID { get => this.eqpID; set => this.eqpID = value; }

        public string RecipeID { get; set; }

        public string RecipeBody { get; set; }

        string eqpID;
    }
}
