using System;
namespace HouseOfTrader.Models
{
    public class CFInsiderTrading
    {
        public string SYMBOL { get; set; }
        public string COMPANY { get; set; }
        public string REGULATION { get; set; }
        public string NAMEOFTHEACQUIRERDISPOSER { get; set; }
        public string CATEGORYOFPERSON { get; set; }
        public string TYPEOFSECURITYPRIOR { get; set; }
        public string NOOFSECURITYPRIOR { get; set; }
        public double SHAREHOLDINGPRIOR { get; set; }
        public string TYPEOFSECURITYACQUIREDDISPLOSED { get; set; }
        public double NOOFSECURITIESACQUIREDDISPLOSED { get; set; }
        public string VALUEOFSECURITYACQUIREDDISPLOSED { get; set; }
        public string ACQUISITIONDISPOSALTRANSACTIONTYPE { get; set; }
        public string TYPEOFSECURITYPOST { get; set; }
        public string NOOFSECURITYPOST { get; set; }
        public string POST { get; set; }
        public string DATEOFALLOTMENTACQUISITIONFROM { get; set; }
        public string DATEOFALLOTMENTACQUISITIONTO { get; set; }
        public string DATEOFINITMATIONTOCOMPANY { get; set; }
        public string MODEOFACQUISITION { get; set; }
        public string DERIVATIVETYPESECURITY { get; set; }
        public string DERIVATIVECONTRACTSPECIFICATION { get; set; }
        public double NOTIONALVALUEBUY { get; set; }
        public double NUMBEROFUNITSCONTRACTLOTSIZEBUY { get; set; }
        public double NOTIONALVALUESELL { get; set; }
        public double NUMBEROFUNITSCONTRACTLOTSIZESELL { get; set; }
        public string EXCHANGE { get; set; }
        public string REMARK { get; set; }
        //public DateTime BROADCASTEDATEANDTIME { get; set; }
        public string BROADCASTEDATEANDTIME { get; set; }
        public string XBRL { get; set; }
    }
}
