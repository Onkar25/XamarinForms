using System;
namespace HouseOfTrader.Models
{
    public class CFPledgeData
    {
        public string NAMEOFCOMPANY { get; set; }
        public double TOTALNOOFISSUEDSHARESABC { get; set; }
        public double TOTALPROMOTERHOLDINGNOOFSHARESA { get; set; }
        public string TOTALPROMOTERHOLDINGAABC { get; set; }
        public double TOTALPUBLICHOLDINGB { get; set; }
        public string PROMOTERSHARESENCUMBEREDASOFLASTQUARTERNOOFSHARESX { get; set; }
        public string PROMOTERSHARESENCUMBEREDASOFLASTQUARTEROFPROMOTERSHARESXA { get; set; }
        public string PROMOTERSHARESENCUMBEREDASOFLASTQUARTEROFTOTALSHARESXABC { get; set; }
        public string DISCLOSUREMADEBYPROMOTERS { get; set; }
        public string NOOFSHARESPLEDGEDINTHEDEPOSITORYSYSTEMNOOFSHARESPLEDGED { get; set; }
        public string NOOFSHARESPLEDGEDINTHEDEPOSITORYSYSTEMTOTALNOOFDEMATSHARES { get; set; }
        public string PLEDGEDEMAT { get; set; }
    }
}
