using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BpstEducation.ViewModels
{


    public class AnswerViewModel
    {
        public List<KeyValueType> KeyValueTypes { get; set; }
        public List<ListType> ListTypes { get; set; }
        public List<TableType> TableTypes { get; set; }

    }


    // ----------------------------------------
    public class TableType
    {
        public int OrderSequence { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public List<string> ColumnHeaders { get; set; }
        public List<List<string>> ColumnRows { get; set; }
    }
    public class ListType
    {
        public int OrderSequence { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public List<string> Points { get; set; }
    }
    public class KeyValueType
    {
        public int OrderSequence { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string KeyHeading { get; set; }
        public string ValueHeading { get; set; }
        public List<KeyValuePair<string, string>> KeyValuePairList { get; set; }

    }
}
