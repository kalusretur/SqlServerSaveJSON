using System.Collections.Generic;

namespace demoSqlSaveJson.Application.ViewModel
{
    public class DemoViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Detail> Detalle { get; set; }
    }

    public class Detail
    {
        public int Codigo { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public string Sede { get; set; }
        public int  state  { get; set; }
    }
}
